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
Imports RestSharp
Imports gasolutions.Factory

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
            ' Dim res = ServiceApis.GetKilometraje()

            'Dim llerres = res.Result

            'Prueba  comunicador
            EnviarDatosTMS()

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

    Private Async Sub EnviarDatosTMS()
        Try

            Dim latitud As String = String.Empty
            Dim longitud As String = String.Empty
            Dim Temperatura As String = String.Empty

            Dim ListaVehiculos = GetLastEventLocationAllVehicle()

            If (ListaVehiculos.Result.Count > 0) Then

                For Each oResSatrack As LocationEvent In ListaVehiculos.Result

                    Dim PLacaStrack = oResSatrack.Placa.ToString()
                    Dim DatosEvento = oHelper.RecuperarDatosEnvioEvento(PLacaStrack)

                    For Each oEventoBD As DataRow In DatosEvento.Tables(0).Rows

                        If CInt(oEventoBD("IdEventoAra")) = 1 Then 'LLEGADA A STORE

                            latitud = oResSatrack.Latitud.ToString()
                            longitud = oResSatrack.Longitud.ToString()
                            Temperatura = oResSatrack.Temperatura

                            Dim respuesta As String = oHelper.EsLlegadaAPuntoDeInteres(latitud, longitud)

                            If Not String.IsNullOrEmpty(respuesta) Then
                                'Consumir servicio de envio a jeronimo
                                '
                                'Actualizamos la tabla TMSRegistroEventosVehiculo
                                oHelper.TMS_ActualizarRegistroEvento(PLacaStrack, 1)
                            End If

                        ElseIf (CInt(oEventoBD("IdEventoAra")) = 9) Or (CInt(oEventoBD("IdEventoAra")) = 10) Then 'APERTURA DE PUERTA/ CIERRE
                            Dim AperturaPuerta = Await GetLastEventLocationPorPlaca(PLacaStrack)

                            'Consumir servicio de envio a jeronimo
                            '

                            'Actualizamos la tabla TMSRegistroEventosVehiculo
                            oHelper.TMS_ActualizarRegistroEvento(PLacaStrack, CInt(oEventoBD("IdEventoAra")))
                        ElseIf (CInt(oEventoBD("IdEventoAra")) = 2) Then 'SALIDA STORE
                            Dim SalidaStore = Await GetLastEventLocationPorPlaca(PLacaStrack)

                            'Consumir servicio de envio a jeronimo
                            ' 
                            '    
                            latitud = oResSatrack.Latitud.ToString()
                            longitud = oResSatrack.Longitud.ToString()
                            Temperatura = oResSatrack.Temperatura.ToString()

                            Dim respuesta As String = oHelper.EsLlegadaAPuntoDeInteres(latitud, longitud)

                            If String.IsNullOrEmpty(respuesta) Then
                                'Consumir servicio de envio a jeronimo

                                'Actualizamos la tabla TMSRegistroEventosVehiculo
                                oHelper.TMS_ActualizarRegistroEvento(PLacaStrack, 2)
                            End If

                        End If
                    Next
                Next
            Else
                AlmacenarEnArchivo("Error en EnviarDatosTMS: Servicio satrack metodo GetLastEventLocation no devolvio datos")
            End If

        Catch ex As Exception
            AlmacenarEnArchivo("Error en EnviarDatosTMS: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Metodos Api"
    Public Shared Function GetToken() As String
        Try
            Dim oHelper As New DataAccess.DA

            Dim UrlTokenSatrack As String = oHelper.RecuperarParametro("UrlTokenSatrack")
            Dim client_id As String = oHelper.RecuperarParametro("client_id")
            Dim client_secret As String = oHelper.RecuperarParametro("client_secret")
            Dim grant_type As String = oHelper.RecuperarParametro("grant_type")


            Using client = New HttpClient()

                client.BaseAddress = New Uri(UrlTokenSatrack)

                Dim nvc = New List(Of KeyValuePair(Of String, String))()

                nvc.Add(New KeyValuePair(Of String, String)("client_id", client_id))
                nvc.Add(New KeyValuePair(Of String, String)("client_secret", client_secret))
                nvc.Add(New KeyValuePair(Of String, String)("grant_type", grant_type))

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

    Public Shared Async Function GetLastEventLocationPorPlaca(ByVal placa As String) As Task(Of List(Of LocationEvent))
        Try

            Dim oHelper As New DataAccess.DA

            'Obtener token
            Dim token As String = GetToken()

            Dim UrlApiSatrack As String = oHelper.RecuperarParametro("UrlApiSatrack")

            Dim serviceCode As String = JsonConvert.SerializeObject(placa)

            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri(UrlApiSatrack)}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                    .Query = "{ last(serviceCodes: " + serviceCode + ")" + "{ address,batteryLevel,customerPoint,customerPointDistance,description," + " 
                                                                          deviceType, generationDateGMT, direction, id, ignition, latitude, locationStatus, longitude," + "
                                                                          samePlaceMinutes, serviceCode, speed, temperature, town, vehicleStatus, unifiedEventCode,recordDate
                          } }"
                   }

            Dim response = Await client.SendQueryAsync(Of LocationResponse)(request)
            If Not response.Data Is Nothing Then

                Return response.Data.LocationEvents

            End If

            Return Nothing

        Catch ex As Exception
            Return Nothing
            Throw
        End Try
    End Function

    Public Shared Async Function GetLastEventLocationAllVehicle() As Task(Of List(Of LocationEvent))
        Try

            Dim oHelper As New DataAccess.DA

            'Obtener token
            Dim token As String = GetToken()

            Dim UrlApiSatrack As String = oHelper.RecuperarParametro("UrlApiSatrack")

            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri(UrlApiSatrack)}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                    .Query = "{ last(serviceCodes: [] ){ address,batteryLevel,customerPoint,customerPointDistance,description," + " 
                                                                          deviceType, generationDateGMT, direction, id, ignition, latitude, locationStatus, longitude," + "
                                                                          samePlaceMinutes, serviceCode, speed, temperature, town, vehicleStatus, unifiedEventCode,recordDate
                          } }"
                   }

            Dim response = Await client.SendQueryAsync(Of LocationResponse)(request)
            If Not response.Data Is Nothing Then

                Return response.Data.LocationEvents

            End If

            Return Nothing

        Catch ex As Exception
            Return Nothing
            Throw
        End Try
    End Function



    Public Shared Async Function GetKilometraje() As Task(Of String)
        Try


            Dim oHelper As New DataAccess.DA

            'Obtener token
            Dim token As String = GetToken()

            Dim UrlApiSatrack As String = oHelper.RecuperarParametro("UrlApiSatrack")

            Dim placa As String = JsonConvert.SerializeObject("JKU006")
            Dim fechainicial As String = JsonConvert.SerializeObject("2021/03/15 10:00:00")
            Dim fechafinal As String = JsonConvert.SerializeObject("2021/03/19 18:00:00")


            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri(UrlApiSatrack)}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                    .Query = "{ byDate " +
                              "(serviceCode: " + placa + ", currentPage: 1 , itemsPerPage: 1," +
                              "initialDate: " + fechainicial + ", endDate: " + fechafinal + ")" +
                              "{ pagination{ currentPage }events{ odometer }}" +
                              "}"
                    }


            Try

                ' Dim response = Await client.SendQueryAsync(Of LocationResponseDate)(request)
                Dim response = Await client.SendQueryAsync(Of LocationResponseDate)(request)

                Dim op2 = response.Data
                Dim op3 = response.Errors
                Dim op4 = response.Extensions

                If response.AsGraphQLHttpResponse.StatusCode = 200 Then
                    If Not response.Data Is Nothing Then
                        Return response.Data.LocationEventsDate.events.FirstOrDefault.odometer.ToString()
                    End If
                End If

            Catch ex As Exception
                Dim m = ex.Message
            End Try


            Return Nothing

        Catch ex As Exception

            Return Nothing
            Throw
        End Try
    End Function


    Public Class TokenResult
        Public Property access_token As String
    End Class

    Public Class LocationResponseDate

        <JsonProperty("byDate")>
        Public Property LocationEventsDate As ByDate

    End Class

    Public Class ByDate
        Public Property pagination As Pagination
        Public Property events As IList(Of Events)
    End Class

    Public Class Pagination
        Public Property currentPage As Integer
    End Class

    Public Class Events
        Public Property odometer As Double
    End Class

    Public Class LocationResponse
        <JsonProperty("last")>
        Public Property LocationEvents As List(Of LocationEvent)
    End Class

    Public Class LocationEvent

        <JsonProperty("serviceCode")>
        Public Property Placa As String

        <JsonProperty("latitude")>
        Public Property Latitud As String

        <JsonProperty("longitude")>
        Public Property Longitud As String

        <JsonProperty("address")>
        Public Property DireccionAddres As String

        <JsonProperty("town")>
        Public Property Ciudad As String

        <JsonProperty("generationDateGMT")>
        Public Property GenerationDateGMT As DateTime

        <JsonProperty("speed")>
        Public Property Velodcidad As String

        <JsonProperty("ignition")>
        Public Property Estado As String

        <JsonProperty("direction")>
        Public Property Direccion As String

        <JsonProperty("description")>
        Public Property Descripcion As String

        <JsonProperty("vehicleStatus")>
        Public Property EstadoVehiculo As String

        <JsonProperty("unifiedEventCode")>
        Public Property CodigoEvento As String

        <JsonProperty("deviceType")>
        Public Property TipoDispositivo As String

        <JsonProperty("locationStatus")>
        Public Property EstadoUbicacion As String

        <JsonProperty("batteryLevel")>
        Public Property NivelBateria As String

        <JsonProperty("customerPoint")>
        Public Property PuntoCliente As String

        <JsonProperty("customerPointDistance")>
        Public Property DistanciaPuntoCliente As String

        <JsonProperty("customerPointName")>
        Public Property NombrePuntoCliente As String

        <JsonProperty("id")>
        Public Property id As String

        <JsonProperty("samePlaceMinutes")>
        Public Property TiempoEnElMismoSitiominuto As String

        <JsonProperty("temperature")>
        Public Property Temperatura As String

        <JsonProperty("recordDate")>
        Public Property FechaEvento As String

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
