Public Class ValePromocional
    Inherits Disposable

    Private _EsAutorizado As Boolean = False
    Private _Monto As Decimal
    Private _Mensaje As String = ""
    Private _NombrePromocion As String

    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    Public Property Monto() As Decimal
        Get
            Return _Monto
        End Get
        Set(ByVal value As Decimal)
            _Monto = value
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

    Public Property NombrePromocion() As String
        Get
            Return _NombrePromocion
        End Get
        Set(ByVal value As String)
            _NombrePromocion = value
        End Set
    End Property
End Class
Public Class ValidacionVentaPGN
    Inherits Disposable

    Private _EsAutorizado As Boolean = False
    Private _Mensaje As String = ""
    Private _MensajeError As String = ""

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

    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property
End Class

Public Class VentaPGN
    Inherits Disposable

    Private _IdManguera As Int16
    Private _IdCara As Int16
    Private _IdSurtidor As Int32
    Private _IdIsla As Int32
    Private _CodEstacion As String
    Private _Prefijo As String
    Private _Numero As String
    Private _SerialImpresora As String
    Private _NumeroTurno As Int32
    Private _FechaHoraVenta As DateTime
    Private _FechaHoraProceso As DateTime
    Private _FechaHoraApertura As DateTime
    Private _FechaHoraInicio As DateTime
    Private _FechaHoraFin As DateTime
    Private _LecturaInicialVenta As DateTime
    Private _LecturaFinalVenta As DateTime
    Private _RucCliente As String
    Private _IdProducto As Int32
    Private _CantidadVenta As Decimal
    Private _PrecioVenta As Decimal
    Private _ValorVentaSinImpuesto As Decimal
    Private _ValorImpuesto As Decimal
    Private _ValorVentaConImpuesto As Decimal
    Private _ValorRecaudo As Decimal
    Private _Placa As String
    Private _Recibo As Int64
    Private _TipoTransaccion As String
    Private _NroTarjeta As String
    Private _ValeCredito As String
    Public Property CantidadVenta() As Decimal
        Get
            Return _CantidadVenta
        End Get
        Set(ByVal value As Decimal)
            _CantidadVenta = value
        End Set
    End Property
    Public Property FechaHoraApertura() As DateTime
        Get
            Return _FechaHoraApertura
        End Get
        Set(ByVal value As DateTime)
            _FechaHoraApertura = value
        End Set
    End Property
    Public Property FechaHoraFin() As DateTime
        Get
            Return _FechaHoraFin
        End Get
        Set(ByVal value As DateTime)
            _FechaHoraFin = value
        End Set
    End Property
    Public Property FechaHoraInicio() As DateTime
        Get
            Return _FechaHoraInicio
        End Get
        Set(ByVal value As DateTime)
            _FechaHoraInicio = value
        End Set
    End Property
    Public Property FechaHoraProceso() As DateTime
        Get
            Return _FechaHoraProceso
        End Get
        Set(ByVal value As DateTime)
            _FechaHoraProceso = value
        End Set
    End Property
    Public Property FechaHoraVenta() As DateTime
        Get
            Return _FechaHoraVenta
        End Get
        Set(ByVal value As DateTime)
            _FechaHoraVenta = value
        End Set
    End Property
    Public Property IdProducto() As Int32
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Int32)
            _IdProducto = value
        End Set
    End Property
    Public Property LecturaFinalVenta() As DateTime
        Get
            Return _LecturaFinalVenta
        End Get
        Set(ByVal value As DateTime)
            _LecturaFinalVenta = value
        End Set
    End Property
    Public Property LecturaInicialVenta() As DateTime
        Get
            Return _LecturaInicialVenta
        End Get
        Set(ByVal value As DateTime)
            _LecturaInicialVenta = value
        End Set
    End Property
    Public Property NroTarjeta() As String
        Get
            Return _NroTarjeta
        End Get
        Set(ByVal value As String)
            _NroTarjeta = value
        End Set
    End Property
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property
    Public Property CodEstacion() As String
        Get
            Return _CodEstacion
        End Get
        Set(ByVal value As String)
            _CodEstacion = value
        End Set
    End Property
    Public Property IdCara() As Int16
        Get
            Return _IdCara
        End Get
        Set(ByVal value As Int16)
            _IdCara = value
        End Set
    End Property
    Public Property IdIsla() As Int32
        Get
            Return _IdIsla
        End Get
        Set(ByVal value As Int32)
            _IdIsla = value
        End Set
    End Property
    Public Property IdManguera() As Int16
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Int16)
            _IdManguera = value
        End Set
    End Property
    Public Property IdSurtidor() As Int32
        Get
            Return _IdSurtidor
        End Get
        Set(ByVal value As Int32)
            _IdSurtidor = value
        End Set
    End Property
    Public Property NumeroTurno() As Int32
        Get
            Return _NumeroTurno
        End Get
        Set(ByVal value As Int32)
            _NumeroTurno = value
        End Set
    End Property
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property
    Public Property PrecioVenta() As Decimal
        Get
            Return _PrecioVenta
        End Get
        Set(ByVal value As Decimal)
            _PrecioVenta = value
        End Set
    End Property
    Public Property Prefijo() As String
        Get
            Return _Prefijo
        End Get
        Set(ByVal value As String)
            _Prefijo = value
        End Set
    End Property
    Public Property Recibo() As Int64
        Get
            Return _Recibo
        End Get
        Set(ByVal value As Int64)
            _Recibo = value
        End Set
    End Property
    Public Property RucCliente() As String
        Get
            Return _RucCliente
        End Get
        Set(ByVal value As String)
            _RucCliente = value
        End Set
    End Property
    Public Property SerialImpresora() As String
        Get
            Return _SerialImpresora
        End Get
        Set(ByVal value As String)
            _SerialImpresora = value
        End Set
    End Property
    Public Property TipoTransaccion() As String
        Get
            Return _TipoTransaccion
        End Get
        Set(ByVal value As String)
            _TipoTransaccion = value
        End Set
    End Property
    Public Property ValeCredito() As String
        Get
            Return _ValeCredito
        End Get
        Set(ByVal value As String)
            _ValeCredito = value
        End Set
    End Property
    Public Property ValorImpuesto() As Decimal
        Get
            Return _ValorImpuesto
        End Get
        Set(ByVal value As Decimal)
            _ValorImpuesto = value
        End Set
    End Property
    Public Property ValorRecaudo() As Decimal
        Get
            Return _ValorRecaudo
        End Get
        Set(ByVal value As Decimal)
            _ValorRecaudo = value
        End Set
    End Property
    Public Property ValorVentaConImpuesto() As Decimal
        Get
            Return _ValorVentaConImpuesto
        End Get
        Set(ByVal value As Decimal)
            _ValorVentaConImpuesto = value
        End Set
    End Property
    Public Property ValorVentaSinImpuesto() As Decimal
        Get
            Return _ValorVentaSinImpuesto
        End Get
        Set(ByVal value As Decimal)
            _ValorVentaSinImpuesto = value
        End Set
    End Property
End Class