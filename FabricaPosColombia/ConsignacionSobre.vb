Public Class ConsignacionSobre


    Private _TipoMoneda As Integer
    Public Property TipoMoneda() As Integer
        Get
            Return _TipoMoneda
        End Get
        Set(ByVal value As Integer)
            _TipoMoneda = value
        End Set
    End Property


    Private _Valor As Decimal
    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(ByVal value As Decimal)
            _Valor = value
        End Set
    End Property


    Private _TipoConsignacion As Integer
    Public Property TipoConsignacion() As Integer
        Get
            Return _TipoConsignacion
        End Get
        Set(ByVal value As Integer)
            _TipoConsignacion = value
        End Set
    End Property

    Property Cantidad As Decimal

End Class
