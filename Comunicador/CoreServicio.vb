Imports gasolutions.DataAccess
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System
Imports POSstation.Fabrica
Imports Facturacion
Imports Newtonsoft.Json
Imports gasolutions
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports GraphQL.Client.Http
Imports GraphQL
Imports GraphQL.Client.Serializer.Newtonsoft

Public Class CoreServicio

#Region "Definicion de Variables y Objetos"
    Dim ThreadEnvioCDC As Thread
    Dim ThreadConsultaCDC As Thread
    Dim LogFallas As New EstacionException
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Private Recibo_ As Double
    Private Mensaje As String
    Private ValorVentasTexaco As String
    Private ErrorVentasTexaco As String
    Private EnviarVentasTexaco As Boolean

    Public Shared LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
    Dim oHelper As New DataAccess.DA
    Dim StopEnvioCDC As Boolean
    Dim StopConsultasCDC As Boolean
    WithEvents TimerEnvio As System.Timers.Timer
#End Region

    Public Sub New()
        Incializar()
    End Sub

    Protected Overrides Sub Finalize()
        Terminar()
        MyBase.Finalize()
    End Sub

    Public Sub Incializar()
        Try

            'prueba token
            Dim token As String = GetToken()

            Dim lista As New List(Of String)
            lista.Add("ehm000")
            ' prueba GetlastEventLocation
            Dim respuesta = GetLastEventLocation(lista, token)

            'Prueba  comunicador
            'EnviarDatosTMS()

            TimerEnvio = New Timers.Timer
            AddHandler TimerEnvio.Elapsed, AddressOf TimerEnvio_Elapsed
            TimerEnvio.Interval = My.Settings.Timer
            TimerEnvio.Enabled = True
            IniciarConfiguracion()
        Catch ex As System.Exception
            AlmacenarEnArchivo(ex.Message & "OnStar InicioSauce")
        End Try
    End Sub

    Private Sub IniciarTimer()
        Try

            If Not TimerEnvio Is Nothing Then
                TimerEnvio.Dispose()
                TimerEnvio = Nothing
            End If


            TimerEnvio = New Timers.Timer
            AddHandler TimerEnvio.Elapsed, AddressOf TimerEnvio_Elapsed
            TimerEnvio.Interval = My.Settings.Timer
            TimerEnvio.Enabled = True
        Catch ex As Exception
            Try
                AlmacenarEnArchivo("Error en IniciarTimer: " & ex.Message)
            Catch

            End Try
        End Try
    End Sub

    Private Sub TimerEnvio_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TimerEnvio.Elapsed
        Try
            TimerEnvio.Enabled = False

            ConsultarVehiculosEnRuta()

            EnviarDatosTMS()

        Catch ex As Exception
            AlmacenarEnArchivo("Error en TimerEnvio_Elapsed: " & ex.Message)
        Finally
            IniciarTimer()
        End Try
    End Sub

    Public Sub Terminar()
        Try
            ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
            StopEnvioCDC = False

            AlmacenarEnArchivo("Finaliza el comunicador.")

            If Not TimerEnvio Is Nothing Then
                TimerEnvio.Enabled = False
                TimerEnvio.Dispose()
                TimerEnvio = Nothing
            End If
        Catch ex As Exception
            AlmacenarEnArchivo("Error en Terminar: " & ex.Message)
        End Try
    End Sub

    Private Sub IniciarConfiguracion()

        AlmacenarEnArchivo("Inicio la ejecución del Comunicador terceros")
        Try
            AlmacenarEnArchivo("INICIA SERVICIO")
        Catch ex As Exception
            EventLog1.WriteEntry("Falla al Almacenar en Archivo: " & ex.Message)
            Throw ex
        End Try
        StopEnvioCDC = True
        StopConsultasCDC = True
        AlmacenarEnArchivo("Inicio la ejecucion del  Envio")

    End Sub

#Region "Envio Informacion"

    Private Sub ConsultarVehiculosEnRuta()
        Try

            Try

                Dim dsVehiculos As New DataSet

                Dim placaVehiculoEnRuta As String

                'Recuperamos los vehiculos en ruta de jeronimo
                dsVehiculos = oHelper.RecuperarVehiculosEnRuta
                For Each oDatos As DataRow In dsVehiculos.Tables(0).Rows

                    placaVehiculoEnRuta = oDatos("Placa").ToString()

                    'Insertar RegistroEventoVehiculo
                    oHelper.InsertarRegistroEventosVehiculo(placaVehiculoEnRuta, 1)
                Next

            Catch ex As Exception
                AlmacenarEnArchivo("Error en RecuperarVehiculosEnRuta, evento ConsultarVehiculosEnRuta: " & ex.Message)
            End Try

        Catch ex As Exception
            AlmacenarEnArchivo("Error en ConsultarVehiculosEnRuta: " & ex.Message)
        End Try
    End Sub

    Private Sub EnviarDatosTMS()
        Try
            Dim servicessatrack As New ServiceSatrack.getEvents

            Dim UsuarioSatrac As String
            Dim ClaveSatrack As String
            Dim ClaveOpcionalSatrack As Long
            Dim NroRegistros As Integer

            Dim placa As String
            Dim latitud As String = String.Empty
            Dim longitud As String = String.Empty
            Dim Temperatura1 As String = String.Empty
            Dim Temperatura2 As String = String.Empty

            'Recuperamos usuario y clave de la BD
            UsuarioSatrac = oHelper.RecuperarParametro("UsuarioSatrack")
            ClaveSatrack = oHelper.RecuperarParametro("PasswordSatrack")
            ClaveOpcionalSatrack = CLng(oHelper.RecuperarParametro("ClaveOpcionalSatrack"))
            NroRegistros = CInt(oHelper.RecuperarParametro("NroRegistros"))

            servicessatrack.Url = oHelper.RecuperarParametro("UrlSatrack")

            Dim DataSetSatrack As DataSet = servicessatrack.retrieveEventsByIDV3(UsuarioSatrac, ClaveSatrack, "*", 21, ClaveOpcionalSatrack, 1)


            If Not DataSetSatrack Is Nothing Then
                For i = 0 To DataSetSatrack.Tables.Count() - 1
                    For Each Datos As DataRow In DataSetSatrack.Tables(i).Rows

                        Dim PLacaStrack = Datos("Placa").ToString()
                        Dim DatosEvento = oHelper.RecuperarDatosEnvioEvento(PLacaStrack)

                        If Not DatosEvento Is Nothing Then
                            For Each oDatos As DataRow In DatosEvento.Tables(0).Rows

                                If CInt(oDatos("IdEventoAra")) = 1 Then 'LLEGADA A STORE

                                    latitud = Datos("Latitud").ToString()
                                    longitud = Datos("Longitud").ToString()
                                    Temperatura1 = Datos("Temperatura1").ToString()
                                    Temperatura2 = Datos("Temperatura2").ToString()

                                    Dim respuesta As String = oHelper.EsLlegadaAPuntoDeInteres(latitud, longitud)

                                    If Not String.IsNullOrEmpty(respuesta) Then
                                        'Consumir servicio de envio a jeronimo

                                        '

                                        'Actualizamos la tabla TMSRegistroEventosVehiculo
                                        oHelper.TMS_ActualizarRegistroEvento(PLacaStrack, 1)
                                    End If

                                ElseIf (CInt(oDatos("IdEventoAra")) = 9) Or (CInt(oDatos("IdEventoAra")) = 10) Then 'APERTURA DE PUERTA
                                    Dim AperturaPuerta As DataSet = servicessatrack.retrieveEventsByIDV3(UsuarioSatrac, ClaveSatrack, "*", 3, ClaveOpcionalSatrack, 1)

                                    'Consumir servicio de envio a jeronimo

                                    '

                                    'Actualizamos la tabla TMSRegistroEventosVehiculo
                                    oHelper.TMS_ActualizarRegistroEvento(PLacaStrack, CInt(oDatos("IdEventoAra")))

                                ElseIf (CInt(oDatos("IdEventoAra")) = 2) Then 'SALIDA STORE
                                    Dim AperturaPuerta As DataSet = servicessatrack.retrieveEventsByIDV3(UsuarioSatrac, ClaveSatrack, "*", 21, ClaveOpcionalSatrack, 1)

                                    'Consumir servicio de envio a jeronimo

                                    '    


                                    latitud = Datos("Latitud").ToString()
                                    longitud = Datos("Longitud").ToString()
                                    Temperatura1 = Datos("Temperatura1").ToString()
                                    Temperatura2 = Datos("Temperatura2").ToString()

                                    Dim respuesta As String = oHelper.EsLlegadaAPuntoDeInteres(latitud, longitud)

                                    If String.IsNullOrEmpty(respuesta) Then
                                        'Consumir servicio de envio a jeronimo

                                        'Actualizamos la tabla TMSRegistroEventosVehiculo
                                        oHelper.TMS_ActualizarRegistroEvento(PLacaStrack, 2)
                                    End If

                                End If

                            Next
                        End If
                    Next
                Next
            Else
                AlmacenarEnArchivo("Error en EnviarDatosTMS: Servicio satrack devuelve dataset vacio en evento retrieveEventsByIDV3 para la placa" & placa)
            End If

        Catch ex As Exception
            AlmacenarEnArchivo("Error en EnviarDatosTMS: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Metodos Api"
    Public Shared Function GetToken() As String
        Try

            Using client = New HttpClient()

                client.BaseAddress = New Uri("http://securityprovider.satrack.com:8080/auth/realms/satrack-base/protocol/openid-connect/token")

                Dim nvc = New List(Of KeyValuePair(Of String, String))()

                nvc.Add(New KeyValuePair(Of String, String)("client_id", "external-client-transportesgandur01"))
                nvc.Add(New KeyValuePair(Of String, String)("client_secret", "e1b5c49a-845c-4b8b-b6e3-99763be6a648"))
                nvc.Add(New KeyValuePair(Of String, String)("grant_type", "client_credentials"))

                Dim request As HttpRequestMessage = New HttpRequestMessage(HttpMethod.Post, "")
                request.Content = New FormUrlEncodedContent(nvc)
                Dim response = client.SendAsync(request)

                If response.Result.IsSuccessStatusCode Then
                    Dim respuesta = response.Result.Content.ReadAsStringAsync()
                    Dim token = JsonConvert.DeserializeObject(Of TokenResult)(respuesta.Result)
                    Return token.access_token
                End If
            End Using

            Return Nothing

        Catch ex As Exception
            Return Nothing
            Throw
        End Try
    End Function

    Public Shared Async Function GetLastEventLocation(ByVal physicalIds As List(Of String), token As String) As Task(Of List(Of ApiData))
        Try

            'If Not physicalIds Is Nothing And physicalIds.Any Then

            Dim serviceCode As String = JsonConvert.SerializeObject(physicalIds)

            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri("http://location.integration.satrack.com/api/location")}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                .Query = "{ last (serviceCodes: " & serviceCode & ")" &
                                "{ address, batteryLevel, customerPoint, customerPointDistance, customerPointName, description,  " &
                                " deviceType, generationDateGMT, direction, id, ignition, latitude, locationStatus, longitude, " &
                                " samePlaceMinutes, serviceCode, speed, temperature, town, recordDateunifiedEventCode }" &
                          "}"
            }

            Dim queryc = request.Query


            Dim response = Await client.SendQueryAsync(Of ApiData)(request)
            'Dim response = Await client.SendQueryAsync(Of Object)(request)
            If Not response.Data Is Nothing Then

                Dim lista As New List(Of ApiData)

                lista.Add(response.Data)

                Return lista

            End If

            'End If

        Catch ex As Exception
            Return Nothing
            Throw
        End Try
    End Function


    Public Class TokenResult
        Public Property access_token As String
    End Class

    Public Class ApiData

        <JsonProperty(PropertyName:="address")>
        Public Property address As String

        <JsonProperty(PropertyName:="batteryLevel")>
        Public Property bateryLevel As String

        <JsonProperty(PropertyName:="customerPoint")>
        Public Property customerPoint As String

        <JsonProperty(PropertyName:="customerPointDistance")>
        Public Property customerPointDistance As String

        <JsonProperty(PropertyName:="customerPointName")>
        Public Property customerPointName As String

        <JsonProperty(PropertyName:="description")>
        Public Property description As String

        <JsonProperty(PropertyName:="deviceType")>
        Public Property deviceType As String

        <JsonProperty(PropertyName:="generationDateGMT")>
        Public Property generationDateGMT As String

        <JsonProperty(PropertyName:="direction")>
        Public Property direction As String

        <JsonProperty(PropertyName:="id")>
        Public Property id As String

        <JsonProperty(PropertyName:="ignItion")>
        Public Property ignItion As String

        <JsonProperty(PropertyName:="latitude")>
        Public Property latitude As String

        <JsonProperty(PropertyName:="locationStatus")>
        Public Property locationStatus As String

        <JsonProperty(PropertyName:="longitude")>
        Public Property longitude As String

        <JsonProperty(PropertyName:="samePlaceMinutes")>
        Public Property samePlaceMinutes As String

        <JsonProperty(PropertyName:="serviceCode")>
        Public Property serviceCode As String

        <JsonProperty(PropertyName:="speed")>
        Public Property speed As String

        <JsonProperty(PropertyName:="temperature")>
        Public Property temperature As String

        <JsonProperty(PropertyName:="town")>
        Public Property town As String

        <JsonProperty(PropertyName:="recordDateunifiedEventCode")>
        Public Property recordDateunifiedEventCode As String

    End Class

#End Region

#Region "Funciones auxiliares"


    Function ValidarTamanoArchivo(ByVal rutaFichero As String) As Long
        Try
            Dim fichero As New FileInfo(rutaFichero)
            Return fichero.Length
        Catch ex As Exception
            Return 50
        End Try
    End Function

    Private Sub AlmacenarEnArchivo(ByVal Mensaje As String)
        Dim tamanoFicheros As Long
        Try
            If My.Settings.Archivo Then
                tamanoFicheros = ValidarTamanoArchivo(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt")
                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Depuracion") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Depuracion")
                End If
                Using sw As StreamWriter = File.AppendText(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt")
                    sw.WriteLine(DateTime.Now & "|" & Mensaje)
                    sw.Close()
                End Using
                tamanoFicheros = tamanoFicheros / 1024 / 1024

                If tamanoFicheros > 20 Then
                    Dim fichero As New FileInfo(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt")
                    Rename(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt", My.Application.Info.DirectoryPath & "\Depuracion\Rastro" & Now.ToString("yyyyMMddhhmmss") & ".txt")
                End If
            End If
        Catch ex As System.Exception

        End Try
    End Sub


#End Region


End Class
