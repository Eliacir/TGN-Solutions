
Public Class EcoPesos
    Inherits Disposable

    Dim _NroTarjeta As String
    Dim _Acumular As Boolean
    Dim _Total As Decimal
    Dim _Saldo As Decimal
    Dim _Contrato As String
    Dim _PuntosEcopesos As Integer
    Dim _Validada As Boolean = False

    Public Property NroTarjeta() As String
        Get
            Return _NroTarjeta
        End Get
        Set(ByVal value As String)
            _NroTarjeta = value
        End Set
    End Property

    Public Property Validada() As Boolean
        Get
            Return _Validada
        End Get
        Set(ByVal value As Boolean)
            _Validada = value
        End Set
    End Property

    Public Property Acumular() As Boolean
        Get
            Return _Acumular
        End Get
        Set(ByVal value As Boolean)
            _Acumular = value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
        End Set
    End Property

    Public Property Contrato() As String
        Get
            Return _Contrato
        End Get
        Set(ByVal value As String)
            _Contrato = value
        End Set
    End Property

    Public Property PuntosEcopesos() As Integer
        Get
            Return _PuntosEcopesos
        End Get
        Set(ByVal value As Integer)
            _PuntosEcopesos = value
        End Set
    End Property

End Class

Public Class VentasSICC
    Inherits Disposable

    Private _Codigo As String
    Private _Contrato As String
    Private _Fecha As DateTime
    Private _IdRecibo As Int64
    Private _Hora As DateTime
    Private _IdManguera As Integer
    Private _IdProducto As Integer
    Private _Cantidad As Decimal
    Private _PrecioSICC As Decimal
    Private _PrecioGNC As Decimal
    Private _AjustePrecio As Decimal
    Private _AjusteMant As Decimal
    Private _AjusteAdm As Decimal
    Private _Recaudo As Decimal
    Private _DescuentoContrato As Decimal
    Private _Descuento As Decimal
    Private _Efectivo As Decimal
    Private _Credito As Decimal
    Private _Placa As String
    Private _IdVehiculo As Int32
    Private _Rom As String
    Private _Total As Decimal
    Private _TipoContrato As String
    Private _IdSurtidor As Integer
    Private _Tarjeta As String
    Private _Ecopesos As Decimal
    Private _VentaGNC As Decimal



    Public Property AjusteAdm() As Decimal
        Get
            Return _AjusteAdm
        End Get
        Set(ByVal value As Decimal)
            _AjusteAdm = value
        End Set
    End Property

    Public Property Credito() As Decimal
        Get
            Return _Credito
        End Get
        Set(ByVal value As Decimal)
            _Credito = value
        End Set
    End Property
    Public Property Efectivo() As Decimal
        Get
            Return _Efectivo
        End Get
        Set(ByVal value As Decimal)
            _Efectivo = value
        End Set
    End Property
    Public Property IdVehiculo() As Int32
        Get
            Return _IdVehiculo
        End Get
        Set(ByVal value As Int32)
            _IdVehiculo = value
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
    Public Property PrecioSICC() As Decimal
        Get
            Return _PrecioSICC
        End Get
        Set(ByVal value As Decimal)
            _PrecioSICC = value
        End Set
    End Property

    Public Property PrecioGNC() As Decimal
        Get
            Return _PrecioGNC
        End Get
        Set(ByVal value As Decimal)
            _PrecioGNC = value
        End Set
    End Property

    Public Property AjustePrecio() As Decimal
        Get
            Return _AjustePrecio
        End Get
        Set(ByVal value As Decimal)
            _AjustePrecio = value
        End Set
    End Property


    Public Property AjusteMant() As Decimal
        Get
            Return _AjusteMant
        End Get
        Set(ByVal value As Decimal)
            _AjusteMant = value
        End Set
    End Property

    Public Property Recaudo() As Decimal
        Get
            Return _Recaudo
        End Get
        Set(ByVal value As Decimal)
            _Recaudo = value
        End Set
    End Property

    Public Property DescuentoContrato() As Decimal
        Get
            Return _DescuentoContrato
        End Get
        Set(ByVal value As Decimal)
            _DescuentoContrato = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Contrato() As String
        Get
            Return _Contrato
        End Get
        Set(ByVal value As String)
            _Contrato = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Public Property Recibo() As Int64
        Get
            Return _IdRecibo
        End Get
        Set(ByVal value As Int64)
            _IdRecibo = value
        End Set
    End Property

    Public Property Hora() As DateTime
        Get
            Return _Hora
        End Get
        Set(ByVal value As DateTime)
            _Hora = value
        End Set
    End Property

    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
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

    Public Property Rom() As String
        Get
            Return _Rom
        End Get
        Set(ByVal value As String)
            _Rom = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property

    Public Property TipoContrato() As String
        Get
            Return _TipoContrato
        End Get
        Set(ByVal value As String)
            _TipoContrato = value
        End Set
    End Property

    Public Property IdSurtidor() As Integer
        Get
            Return _IdSurtidor
        End Get
        Set(ByVal value As Integer)
            _IdSurtidor = value
        End Set
    End Property

    Public Property IdManguera() As Integer
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Integer)
            _IdManguera = value
        End Set
    End Property

    Public Property Tarjeta() As String
        Get
            Return _Tarjeta
        End Get
        Set(ByVal value As String)
            _Tarjeta = value
        End Set
    End Property

    Public Property Ecopesos() As Decimal
        Get
            Return _Ecopesos
        End Get
        Set(ByVal value As Decimal)
            _Ecopesos = value
        End Set
    End Property

    Public Property VentaGNC() As Decimal
        Get
            Return _VentaGNC
        End Get
        Set(ByVal value As Decimal)
            _VentaGNC = value
        End Set
    End Property
    Public Property Descuento() As Decimal
        Get
            Return _Descuento
        End Get
        Set(ByVal value As Decimal)
            _Descuento = value
        End Set
    End Property



End Class

