Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class Venta
    Public Property IdFormaPago As Integer
    Public Property IdProducto As Integer
    Public Property Placa As String
    Public Property CodEstacion As String
    Public Property Consecutivo As Long
    Public Property FechaHora As String
    Public Property IdTurno As Integer
    Public Property HoraInicial As String
    Public Property horaFinal As String
    Public Property LecturaInicial As String
    Public Property LecturaFinal As String
    Public Property Total As String
    Public Property Cantidad As String
    Public Property Precio As String
    Public Property IdManguera As String
    Public Property ROM As String
    Public Property ApiKey As String
    Public Property ListaRecaudo() As DetalleCredito()
End Class

Public Class DetalleCredito
    Public Property IdCredito As String
    Public Property ValorRecaudado As Decimal
End Class

Public Class Autorizacion
    Public Property CodEstacion As String
    Public Property ApyKey As String
    Public Property Rom As String
    Public Property FechaHora As String
End Class

Public Class RespuestaRecaudo    
    Public Property Valor As Decimal
    Public Property IdTipoPagoCredito As Integer    
End Class
Public Class CreditoVehiculo
    Public Property Recaudos As List(Of RespuestaRecaudo)
    Public Property MensajeError As String
    Public Property EsProcesado As Boolean
End Class

Public Class Turno
    Public Property IdTurno As String
    Public Property IdManguera() As String
    Public FechaApertura As String
    Public Cierre As String
    Public CodEstacion As String
    Public ApiKey As String
End Class

Public Class RespuestaTurno
    Public MensajeError As String
    Public Procesado As Boolean
End Class
