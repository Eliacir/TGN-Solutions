
Public Class AutorizacionVentaBono
    Inherits Disposable

    Private _Mensaje As String
    Private _ValorBono As Decimal
    Private _EsAutorizado As Boolean
    Private _NroAutorizacion As String
    Private _Cantidad As Decimal
    Private _NroTarjeta As String
    Private _ValorUnitarioPremio As Decimal
    Private _PuntosCanjeados As Decimal
    Private _CantidadBonosRedimidos As Int64

    Public Property NroTarjeta As String
        Get
            Return _NroTarjeta
        End Get
        Set(value As String)
            _NroTarjeta = value
        End Set
    End Property

    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property
    Public Property ValorBono() As Decimal
        Get
            Return _ValorBono
        End Get
        Set(ByVal value As Decimal)
            _ValorBono = value
        End Set
    End Property
    Public Property NroAutorizacion() As String
        Get
            Return _NroAutorizacion
        End Get
        Set(ByVal value As String)
            _NroAutorizacion = value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property ValorUnitarioPremio() As Decimal
        Get
            Return _ValorUnitarioPremio
        End Get
        Set(ByVal value As Decimal)
            _ValorUnitarioPremio = value
        End Set
    End Property

    Public Property PuntosCanjeados() As Decimal
        Get
            Return _PuntosCanjeados
        End Get
        Set(ByVal value As Decimal)
            _PuntosCanjeados = value
        End Set
    End Property

    Public Property CantidadBonosRedimidos() As Int64
        Get
            Return _CantidadBonosRedimidos
        End Get
        Set(ByVal value As Int64)
            _CantidadBonosRedimidos = value
        End Set
    End Property

End Class

Public Class PredeterminacionPagoVentaBono
    Inherits Disposable

#Region " Declaracion de Variables "
    Private _nroTarjeta As String
    Private _puerto As String
#End Region

#Region " Declaracion de Propiedades    "
    ''' <summary>
    ''' Numero de la tarjeta de fidelizacion con la cual se redimiran los bonos
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property nroTarjeta() As String
        Get
            Return _nroTarjeta
        End Get
        Set(ByVal value As String)
            _nroTarjeta = value
        End Set
    End Property

    ''' <summary>
    ''' Puerto en el cual se genera la solicitud para el proceso
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property puerto() As String
        Get
            Return _puerto
        End Get
        Set(ByVal value As String)
            _puerto = value
        End Set
    End Property


    Private _TipoIdentificacion As String
    Public Property TipoIdentificacion() As String
        Get
            Return _TipoIdentificacion
        End Get
        Set(ByVal value As String)
            _TipoIdentificacion = value
        End Set
    End Property


    Private _NumBonos As String
    Public Property NumBonos() As String
        Get
            Return _NumBonos
        End Get
        Set(ByVal value As String)
            _NumBonos = value
        End Set
    End Property



    Private _IdPremio As String
    Public Property IdPremio() As String
        Get
            Return _IdPremio
        End Get
        Set(ByVal value As String)
            _IdPremio = value
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


    Private _Cantidad As Decimal
    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property
#End Region

    Sub New(ByVal Tarjeta As String, ByVal Puerto As String)
        _nroTarjeta = Tarjeta
        _puerto = Puerto
    End Sub
End Class

