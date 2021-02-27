
Public Class PagoRecaudos
#Region "   Declaracion de Variables    "
    Private _Codigo As String = ""
    Private _Concepto As String = ""
    Private _Ruc As String = ""
    Private _RazonSocial As String = ""
    Private _Nombre As String = ""
    Private _Placa As String = ""
    Private _IdTurno As Integer = 0
    Private _CodigoEstacion As String = ""
    Private _Monto As Double = 0
    Private _SerialImpresora As String = ""
    Private _EsAnulado As Boolean
#End Region
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal value As String)
            _Concepto = value
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
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
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
    Public Property IdTurno() As Integer
        Get
            Return _IdTurno
        End Get
        Set(ByVal value As Integer)
            _IdTurno = value
        End Set
    End Property
    Public Property CodigoEstacion() As String
        Get
            Return _CodigoEstacion
        End Get
        Set(ByVal value As String)
            _CodigoEstacion = value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal value As Double)
            _Monto = value
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
    Public Property EsAnulado() As Boolean
        Get
            Return _EsAnulado
        End Get
        Set(ByVal value As Boolean)
            _EsAnulado = value
        End Set
    End Property
End Class

Public Class Empresa
    Private _CodigoEmpresa As Int32
    Private _Descripcion As String

    Public Property CodigoEmpresa As Int32
        Get
            Return _CodigoEmpresa
        End Get
        Set(value As Int32)
            _CodigoEmpresa = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
End Class
