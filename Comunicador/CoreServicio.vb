Imports gasolutions.DataAccess
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System
Imports POSstation.Fabrica
Imports gasolutions.Factory
Imports Newtonsoft.Json
Imports gasolutions

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
            TimerEnvio = New Timers.Timer
            AddHandler TimerEnvio.Elapsed, AddressOf TimerEnvio_Elapsed
            TimerEnvio.Interval = My.Settings.Timer
            TimerEnvio.Enabled = True
            IniciarConfiguracion()
        Catch ex As System.Exception
            AlmacenarEnArchivo(ex.Message & "OnStar InicioSauce")
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
                Dim servicessatrack As New ServiceSatrack.getEvents

                Dim UsuarioSatrac As String
                Dim ClaveSatrack As String
                Dim placaVehiculoEnRuta As String
                Dim longitud As String
                Dim latitud As String

                'Recuperamos usuario y clave de la BD
                UsuarioSatrac = oHelper.RecuperarParametro("UsuarioSatrck")
                ClaveSatrack = oHelper.RecuperarParametro("PasswordSatrck")

                'Recuperamos los vehiculos en ruta de jeronimo
                dsVehiculos = oHelper.RecuperarVehiculosEnRuta
                For Each oDatos As DataRow In dsVehiculos.Tables(0).Rows

                    placaVehiculoEnRuta = oDatos("Placa").ToString()

                    'Consultamos el vehiculo en satrack
                    Dim DataSet = servicessatrack.getLastEvent(UsuarioSatrac, ClaveSatrack, placaVehiculoEnRuta)
                    Dim cont = 0

                    For i = 0 To DataSet.Tables.Count() - 1
                        For Each Datos As DataRow In DataSet.Tables(i).Rows
                            latitud = oDatos("Latitud").ToString()
                            longitud = oDatos("Longitud").ToString()
                        Next
                    Next

                Next


            Catch ex As Exception
                AlmacenarEnArchivo("Error en RecuperarVehiculosEnRuta, evento ConsultarVehiculosEnRuta: " & ex.Message)
            End Try


        Catch ex As Exception
            AlmacenarEnArchivo("Error en EnviarDatosCDC: " & ex.Message)
        End Try
    End Sub

#End Region


#Region "Funciones auxiliares"

    Private Sub RegistrarVentasTexaco(ByVal IdRegistroVenta As Int64)

        Try

            'Dim ObjDatosEntrada As New ProcesosFleetStar.VentaCombustible
            'Dim Procesos As New ProcesosFleetStar.ProcesosController

            'Dim CodigoEDS As String = Nothing
            'Dim Usuario As String = Nothing
            'Dim Clave As String = Nothing
            'Dim UrlServicio As String = Nothing

            'Dim RespuestaCT = oHelper.RecuperarCredencialesCreditoTercero(oHelper.RecuperarIdEstacionPorIdRegistroVenta(IdRegistroVenta), 1)

            'For Each oDst As DataRow In RespuestaCT.Tables(0).Rows
            '    CodigoEDS = oDst("CodigoEDS").ToString()
            '    Usuario = oDst("Usuario").ToString()
            '    Clave = oDst("Clave").ToString()
            '    UrlServicio = oDst("UrlServicio").ToString()
            'Next

            'Dim oVenta = oHelper.RecuperarVentaCreditoTexaco(IdRegistroVenta)
            'For Each DatosVenta As DataRow In oVenta.Tables(0).Rows

            '    Dim Detalle As New ProcesosFleetStar.DetalleVentaMaterial
            '    Dim ListaDetalle As New List(Of ProcesosFleetStar.DetalleVentaMaterial)
            '    Detalle.Cantidad = CDbl(DatosVenta("Cantidad"))
            '    Detalle.CodigoMaterial = DatosVenta("CodigoMaterial")
            '    Detalle.Precio = CDbl(DatosVenta("Precio"))
            '    Detalle.Total = CDbl(DatosVenta("Total"))
            '    ListaDetalle.Add(Detalle)

            '    Dim oFormaPago As New ProcesosFleetStar.FormaPago
            '    Dim ListaFormaPago As New List(Of ProcesosFleetStar.FormaPago)
            '    oFormaPago.Nombre = DatosVenta("FormaPago").ToString()
            '    oFormaPago.CodigoSAP = DatosVenta("CodFormaPago")
            '    oFormaPago.Valor = CDbl(DatosVenta("Total"))
            '    ListaFormaPago.Add(oFormaPago)

            '    With ObjDatosEntrada
            '        .CodigoEDS = CodigoEDS
            '        .CodigoPosicion = DatosVenta("CodCara")
            '        .FechaHoraFin = DatosVenta("HoraFin")
            '        .FechaHoraInicio = DatosVenta("HoraInicio")
            '        .IdAutorizacion = CInt(DatosVenta("Autorizacion"))
            '        .IdCorteTV = 1
            '        .IdTurno = CInt(DatosVenta("IdTurno"))
            '        .IdTurnoHorario = CInt(DatosVenta("NumeroTurno"))
            '        .Kilometraje = 0
            '        .LecturaFinal = CDbl(DatosVenta("LecturaFinal"))
            '        .LecturaInicial = CDbl(DatosVenta("LecturaInicial"))
            '        .Placa = DatosVenta("Placa")
            '        .NumeroDocumento = DatosVenta("Recibo")
            '        .NumeroIdentificador = DatosVenta("ROM")
            '        .PrecioVentaCliente = CDbl(DatosVenta("Precio"))
            '        .PrecioVentaEDS = CDbl(DatosVenta("PrecioEDS"))
            '        .TotalVenta = CDbl(DatosVenta("Total"))
            '        .VentaManual = False
            '        .DetalleVentaMaterial = ListaDetalle.ToArray()
            '        .FormasPago = ListaFormaPago.ToArray()
            '        .NumeroManifiesto = ""
            '        .IdentificacionVendedor = DatosVenta("Cedula")
            '    End With
            'Next

            'Dim credencials As New ProcesosFleetStar.Credencial
            'credencials.Usuario = Usuario
            'credencials.Clave = Clave
            'credencials.CodigoEDS = CodigoEDS

            'Procesos.CredencialValue = credencials
            'Procesos.Url = UrlServicio

            'AlmacenarEnArchivo("Enviando venta Texaco, recibo: " & ObjDatosEntrada.NumeroDocumento & " - Autorizacion: " & ObjDatosEntrada.IdAutorizacion.ToString)

            'Dim Respuesta = Procesos.RegistrarVentaCombustible(ObjDatosEntrada)
            'AlmacenarEnArchivo("Respuesta estado:" & Respuesta.Estado.ToString)
            'If Respuesta.Estado = ServicesFleetStar.EstadoSolicitud.Procesado Then
            '    oHelper.ActualizarEstadoVentaCreditoTercero(IdRegistroVenta, True)
            'Else
            '    AlmacenarEnArchivo("Respuesta Mensaje:" & Respuesta.Mensaje.ToString)
            'End If

        Catch Ex As Exception
            ErrorVentasTexaco = Ex.Message
            AlmacenarEnArchivo(Ex.Message)
        Finally
            ErrorVentasTexaco = False
        End Try
    End Sub

    Private Sub RegistrarVentasPetromil(ByVal IdRegistroVenta As Int64)

        Try

            'Dim ObjDatosEntrada As New ServicesFleetStar.VentaCombustible
            'Dim Procesos As New ServicesFleetStar.ProcesosFleetStar

            'Dim CodigoEDS As String = Nothing
            'Dim Usuario As String = Nothing
            'Dim Clave As String = Nothing
            'Dim UrlServicio As String = Nothing

            'Dim RespuestaCT = oHelper.RecuperarCredencialesCreditoTercero(oHelper.RecuperarIdEstacionPorIdRegistroVenta(IdRegistroVenta), 2)

            'For Each oDst As DataRow In RespuestaCT.Tables(0).Rows
            '    CodigoEDS = oDst("CodigoEDS").ToString()
            '    Usuario = oDst("Usuario").ToString()
            '    Clave = oDst("Clave").ToString()
            '    UrlServicio = oDst("UrlServicio").ToString()
            'Next

            'Dim oVenta = oHelper.RecuperarVentaCreditoPetromil(IdRegistroVenta)
            'For Each DatosVenta As DataRow In oVenta.Tables(0).Rows

            '    Dim Detalle As New ServicesFleetStar.DetalleVentaMaterial
            '    Dim ListaDetalle As New List(Of ServicesFleetStar.DetalleVentaMaterial)
            '    Detalle.Cantidad = CDbl(DatosVenta("Cantidad"))
            '    Detalle.CodigoMaterial = DatosVenta("CodigoMaterial")
            '    Detalle.Precio = CDbl(DatosVenta("Precio"))
            '    Detalle.Total = CDbl(DatosVenta("Total"))
            '    ListaDetalle.Add(Detalle)

            '    Dim oFormaPago As New ServicesFleetStar.FormaPago
            '    Dim ListaFormaPago As New List(Of ServicesFleetStar.FormaPago)
            '    oFormaPago.Nombre = "Credito Petromil"
            '    oFormaPago.CodigoSAP = DatosVenta("CodFormaPago")
            '    oFormaPago.Valor = CDbl(DatosVenta("Total"))
            '    ListaFormaPago.Add(oFormaPago)

            '    With ObjDatosEntrada
            '        .CodigoEDS = CodigoEDS
            '        '.CodigoPosicion = "01"
            '        .CodigoPosicion = DatosVenta("CodCara")
            '        .FechaHoraFin = DatosVenta("HoraFin")
            '        .FechaHoraInicio = DatosVenta("HoraInicio")
            '        .IdAutorizacion = CInt(DatosVenta("Autorizacion"))
            '        .IdCorteTV = 1
            '        .IdTurno = CInt(DatosVenta("IdTurno"))
            '        .IdTurnoHorario = CInt(DatosVenta("NumeroTurno"))
            '        .Kilometraje = 0
            '        .LecturaFinal = CDbl(DatosVenta("LecturaFinal"))
            '        .LecturaInicial = CDbl(DatosVenta("LecturaInicial"))
            '        .Placa = DatosVenta("Placa")
            '        .NumeroDocumento = DatosVenta("Recibo")
            '        .NumeroIdentificador = DatosVenta("ROM")
            '        .PrecioVentaCliente = CDbl(DatosVenta("Precio"))
            '        .PrecioVentaEDS = CDbl(DatosVenta("PrecioEDS"))
            '        .TotalVenta = CDbl(DatosVenta("Total"))
            '        .VentaManual = False
            '        .DetalleVentaMaterial = ListaDetalle.ToArray()
            '        .FormasPago = ListaFormaPago.ToArray()
            '        .NumeroManifiesto = ""
            '        .IdentificacionVendedor = DatosVenta("Cedula")
            '    End With

            '    AlmacenarEnArchivo("Enviando venta Petromil, recibo: " & ObjDatosEntrada.NumeroDocumento & " - Autorizacion: " & ObjDatosEntrada.IdAutorizacion.ToString)
            'Next

            'Dim Json = JsonConvert.SerializeObject(ObjDatosEntrada)
            'AlmacenarEnArchivo(Json)
            'Dim credencials As New ServicesFleetStar.Credencial
            'credencials.Usuario = Usuario
            'credencials.Clave = Clave
            'credencials.CodigoEDS = CodigoEDS

            'Procesos.CredencialValue = credencials
            'Procesos.Url = UrlServicio



            'Dim Respuesta = Procesos.RegistrarVentaCombustible(ObjDatosEntrada)
            'AlmacenarEnArchivo("Respuesta estado:" & Respuesta.Estado.ToString)
            'If Respuesta.Estado = ServicesFleetStar.EstadoSolicitud.Procesado Then
            '    oHelper.ActualizarEstadoVentaCreditoTercero(IdRegistroVenta, True)
            'Else
            '    AlmacenarEnArchivo("Respuesta estado:" & Respuesta.Mensaje.ToString)
            'End If

        Catch Ex As Exception
            ErrorVentasTexaco = Ex.Message
            AlmacenarEnArchivo(Ex.Message)
        Finally
            ErrorVentasTexaco = False
        End Try
    End Sub

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
    ''' <summary>
    ''' Recibe 1 para el temporizador de consulta y 0 para el temporizador de envio
    ''' </summary>
    ''' <param name="TipoTimer"></param>
    ''' <remarks></remarks>

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
        Catch ex As Exception
            AlmacenarEnArchivo("Error en TimerEnvio_Elapsed: " & ex.Message)
        Finally
            IniciarTimer()
        End Try
    End Sub

    Private Sub EscribirMensaje(ByVal Texto As String)
        Try
            If My.Settings.RastrearTareas Then
                Mensaje = Texto
                'txtMensajes.BeginInvoke(New MethodInvoker(AddressOf Rastrear))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
