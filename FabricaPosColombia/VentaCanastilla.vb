Public Class VentaCanastilla

#Region "   Declaracion de Variables    "
    Private _Codigo As String
    Private _Cantidad As Double
#End Region

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property

End Class
