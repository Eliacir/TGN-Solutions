Public Class VentaCanastilla

#Region "   Declaracion de Variables    "
    Private _Codigo As Int32
    Private _Cantidad As Double
#End Region

    Public Property Codigo() As Int32
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Int32)
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
