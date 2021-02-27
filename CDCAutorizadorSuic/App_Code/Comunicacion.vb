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


    <WebMethod()> _
    Public Function AutorizarVentaGNV(ByVal ROM As String, ByVal Placa As String, ByVal EsCombustible As Boolean) As Respuesta
        Dim respuesta As New Respuesta
        Dim oHelper As New DataAccess
        Try
            'oHelper.RecuperarEstadoVehiculo(ROM, Placa, EsCombustible)
            respuesta.Procesado = True
            respuesta.ErrorMessage = Nothing
        Catch ex As SoapException
            respuesta.ErrorMessage = ex.Message
            respuesta.NroConfirmacion = ""
        Catch ex As System.Exception
            respuesta.ErrorMessage = ex.Message
            respuesta.NroConfirmacion = ""
        End Try
        Return respuesta
    End Function

    <WebMethod()> _
    Public Function RecuperarFechaProximoMantenimientoPorROM(ByVal ROM As String) As Respuesta
        Dim respuesta As New Respuesta
        Dim oHelper As New DataAccess
        Try
            ' respuesta.NroConfirmacion = oHelper.RecuperarFechaProximoMantenimientoPorROM(ROM)
            respuesta.Procesado = True
            respuesta.ErrorMessage = Nothing
        Catch ex As SoapException
            respuesta.ErrorMessage = ex.Message
            respuesta.NroConfirmacion = ""
        Catch ex As System.Exception
            respuesta.ErrorMessage = ex.Message
            respuesta.NroConfirmacion = ""
        End Try
        Return respuesta
    End Function


End Class

Public Class Respuesta
    Public Property ErrorMessage As String
    Public Property NroConfirmacion As String
    Public Property Procesado As Boolean
    Public Property Recaudos As New List(Of RespuestaRecaudoCAS)
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
