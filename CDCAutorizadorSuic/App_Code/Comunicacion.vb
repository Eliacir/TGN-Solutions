Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.Data
Imports System.Net
Imports Gasolutions.DataAccess
Imports SICOM
Imports POSstation.ServerServices.ServicesSuic
Imports POSstation.Fabrica

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Comunicacion
    Inherits System.Web.Services.WebService


    <WebMethod()>
    Public Function GetDistanceBetweenDates(ByVal Placa As String, ByVal FechaInicial As DateTime, ByVal FechaFinal As DateTime) As String
        Dim respuesta As String = ""
        Dim oHelper As New Gasolutions.DataAccess.DA
        Dim Comunicacion As New Satrack.getEvents
        Dim Kilometros As Long
        Try
            If FechaFinal < FechaInicial Then
                Throw New System.Exception("La fecha Final debe ser mayor a la Fecha Inicial.")
            End If
            Dim TotalHour = (FechaFinal - FechaInicial).TotalHours()
            If TotalHour > 48 Then
                Throw New System.Exception("El rango entre las fechas no debe ser mayor a 48 horas.")
            End If

            Dim usuario = oHelper.RecuperarParametro("UsuarioSatrack")
            Dim clave = oHelper.RecuperarParametro("PasswordSatrack")
            Dim credenciales As ICredentials = New NetworkCredential(usuario, clave)
            Dim DataSet = Comunicacion.GetKilometer(usuario, clave, Placa, DatePart("yyyy", FechaInicial), DatePart("m", FechaInicial), DatePart("d", FechaInicial), DatePart("h", FechaInicial), DatePart("n", FechaInicial), DatePart("s", FechaInicial), DatePart("yyyy", FechaFinal), DatePart("m", FechaFinal), DatePart("d", FechaFinal), DatePart("h", FechaFinal), DatePart("n", FechaFinal), DatePart("s", FechaFinal))
            Dim cont = 0
            For i = 0 To DataSet.Tables.Count() - 1
                For Each oDatos As DataRow In DataSet.Tables(i).Rows
                    Kilometros = CLng(oDatos("Kilometros").ToString())
                Next
            Next
            Kilometros = Kilometros * 1000
            respuesta = Kilometros.ToString()


        Catch ex As SoapException
            respuesta = ex.Message
        Catch ex As System.Exception
            respuesta = ex.Message
        End Try
        Return respuesta
    End Function

    <WebMethod()>
    Public Function GetAllVehicles() As List(Of Vehiculo)
        Dim respuesta As New List(Of Vehiculo)
        Dim oHelper As New Gasolutions.DataAccess.DA
        Dim Comunicacion As New Satrack.getEvents
        Try


            Dim usuario = oHelper.RecuperarParametro("UsuarioSatrack")
            Dim claveopcional = oHelper.RecuperarParametro("ClaveOpcionalSatrack")
            Dim clave = oHelper.RecuperarParametro("PasswordSatrack")
            Dim NroRegistros = CInt(oHelper.RecuperarParametro("NroRegistros"))

            'Dim usuario = "operacionesbaq"
            'Dim clave = "Barranquilla2020+"

            Dim credenciales As ICredentials = New NetworkCredential(usuario, clave)
            Dim DataSet = Comunicacion.retrieveEventsByIDV3(usuario, clave, "*", "21", CLng(claveopcional), NroRegistros)
            Dim cont = 0
            If DataSet Is Nothing Then
                Throw New System.Exception("No se encontraron datos.")
            End If
            For i = 0 To DataSet.Tables.Count() - 1
                For Each oDatos As DataRow In DataSet.Tables(i).Rows
                    If oHelper.TMS_ExisteVehiculoARA(oDatos("Placa").ToString()) Then
                        Dim oVehiculo As New Vehiculo
                        oVehiculo.Placa = oDatos("Placa")
                        oVehiculo.Latitud = oDatos("Latitud")
                        oVehiculo.Longitud = oDatos("Longitud")
                        oVehiculo.Velocidad = oDatos("Velocidad")
                        oVehiculo.Ubicacion = oDatos("Ubicacion")
                        oVehiculo.FechaHora_GPS = oDatos("FechaHora_GPS")
                        oVehiculo.Estado_Ignicion = True
                        If oDatos("Estado_Ignicion").ToString() = "Apagado" Then
                            oVehiculo.Estado_Ignicion = False
                        End If
                        respuesta.Add(oVehiculo)
                    End If
                Next
            Next
            Return respuesta
        Catch ex As SoapException
            Throw ex
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function


End Class

Public Class Vehiculo
    Public Property Placa As String
    Public Property LocationDate As String
    Public Property Latitud As String
    Public Property Longitud As String
    Public Property Velocidad As String
    Public Property Ubicacion As String
    Public Property FechaHora_GPS As String
    Public Property Estado_Ignicion As Boolean

End Class

Public Class RespuestaRecaudoCAS
    Public Property Financiera As String
    Public Property MensajeError As String
    Public Property Procesado As Boolean
    Public Property IdCliente As Int32
    Public Property IdCredito As Int32
    Public Property IdFinanciera As Int32
    Public Property IdTipoPagoCredito As Int32
    Public Property IdVehiculo As Int32
    Public Property Pagare As String
    Public Property PlacaVehiculo As String
    Public Property Porcentaje As Decimal
    Public Property ProximaRevision As String
End Class
