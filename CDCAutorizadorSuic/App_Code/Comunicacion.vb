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
        Dim service As New Gasolutions.DataAccess.ServiceApis
        'Dim Comunicacion As New Satrack.getEvents
        Dim Kilometros As Long
        Try
            If FechaFinal < FechaInicial Then
                Throw New System.Exception("La fecha Final debe ser mayor a la Fecha Inicial.")
            End If
            Dim TotalHour = (FechaFinal - FechaInicial).TotalHours()
            If TotalHour > 48 Then
                Throw New System.Exception("El rango entre las fechas no debe ser mayor a 48 horas.")
            End If

            Dim res = service.GetKilometraje(Placa, FechaInicial, FechaFinal)
            respuesta = res.Result

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
        Dim service As New Gasolutions.DataAccess.ServiceApis
        'Dim Comunicacion As New Satrack.getEvents
        Try

            Dim res = service.GetLastEventLocationAllVehicle()
            For Each oDatos In res.Result
                If oHelper.TMS_ExisteVehiculoARA(oDatos.Placa) Then
                    Dim oVehiculo As New Vehiculo
                    oVehiculo.Placa = oDatos.Placa
                    oVehiculo.Latitud = oDatos.Latitud
                    oVehiculo.Longitud = oDatos.Longitud
                    oVehiculo.Velocidad = oDatos.Velodcidad
                    oVehiculo.Ubicacion = oDatos.EstadoUbicacion
                    oVehiculo.FechaHora_GPS = oDatos.GenerationDateGMT
                    oVehiculo.Estado_Ignicion = True
                    If oDatos.Estado = "0" Then
                        oVehiculo.Estado_Ignicion = False
                    End If
                    respuesta.Add(oVehiculo)
                End If
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
