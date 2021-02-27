Public Class VentaChipGasolina
    Inherits Disposable

    Private _Kilometraje As String
    Private _EsVentaCredito As Boolean

    Public Property Kilometraje() As String
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As String)
            _Kilometraje = value
        End Set
    End Property

    Public Property EsVentaCredito() As Boolean
        Get
            Return _EsVentaCredito
        End Get
        Set(ByVal value As Boolean)
            _EsVentaCredito = value
        End Set
    End Property

End Class

Public Structure VentaCredito
    Private _EsEfectivo As Boolean
    Private _Ruc As String
    Private _SaldoDisponible As Decimal
    Private _Autorizacion As String
    Private _FormaPago As Int16

    Public Property EsEfectivo() As Boolean
        Get
            Return _EsEfectivo
        End Get
        Set(ByVal value As Boolean)
            _EsEfectivo = value
        End Set
    End Property

    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property
    Public Property SaldoDisponible() As Decimal
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Decimal)
            _SaldoDisponible = value
        End Set
    End Property
    Public Property Autorizacion() As String
        Get
            Return _Autorizacion
        End Get
        Set(ByVal value As String)
            _Autorizacion = value
        End Set
    End Property
    Public Property FormaPago() As Int16
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As Int16)
            _FormaPago = value
        End Set
    End Property
End Structure

Public Class CreditoEstacion
    Private _TipoIdentificacion As IdentificacionCredito
    Private _EsEfectivo As Boolean
    Private _Documento As String = ""
    Private _DocumentoAux As String = ""

    Public Property TipoIdentificacion() As IdentificacionCredito
        Get
            Return _TipoIdentificacion
        End Get
        Set(ByVal value As IdentificacionCredito)
            _TipoIdentificacion = value
        End Set
    End Property

    Public Property EsEfectivo() As Boolean
        Get
            Return _EsEfectivo
        End Get
        Set(ByVal value As Boolean)
            _EsEfectivo = value
        End Set
    End Property

    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property

    Public Property DocumentoAux() As String
        Get
            Return _DocumentoAux
        End Get
        Set(ByVal value As String)
            _DocumentoAux = value
        End Set
    End Property

End Class

Public Class MediosPagoAbonoExtraordinario
    Private _MedioPago As String
    Private _Valor As Integer
    Private _NumAprobacion As String


    Public Property MedioPago() As String
        Get
            Return _MedioPago
        End Get
        Set(ByVal value As String)
            _MedioPago = value
        End Set
    End Property


    Public Property NumeroAprobacion() As String
        Get
            Return _NumAprobacion
        End Get
        Set(ByVal value As String)
            _NumAprobacion = value
        End Set
    End Property



    Public Property Valor() As Integer
        Get
            Return _Valor
        End Get
        Set(ByVal value As Integer)
            _Valor = value
        End Set
    End Property
End Class