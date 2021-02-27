Public Class VentaGasCaribe
    Inherits Disposable

    Private _Usuario As String
    Private _Password As String
    Private _Fechaventa As String
    Private _IdEstacion As String
    Private _Placa As String
    Private _CantidadM3 As Double
    Private _CapacidadCilindro As Double
    Private _NumeroCilindro As Integer
    Private _FechaUltimoMantenimiento As String
    Private _IdChip As String
    Private _CedulaVendedor As String
    Private _SerialMaquina As String
    Private _IdEmpresa As String

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Public Property FechaVenta() As String
        Get
            Return _Fechaventa
        End Get
        Set(ByVal value As String)
            _Fechaventa = value
        End Set
    End Property
    Public Property IdEstacion() As String
        Get
            Return _IdEstacion
        End Get
        Set(ByVal value As String)
            _IdEstacion = value
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
    Public Property CantidadM3() As Double
        Get
            Return _CantidadM3
        End Get
        Set(ByVal value As Double)
            _CantidadM3 = value
        End Set
    End Property
    Public Property CapacidadCilindro() As Double
        Get
            Return _CapacidadCilindro
        End Get
        Set(ByVal value As Double)
            _CapacidadCilindro = value
        End Set
    End Property
    Public Property NumeroCilindro() As Integer
        Get
            Return _NumeroCilindro
        End Get
        Set(ByVal value As Integer)
            _NumeroCilindro = value
        End Set
    End Property
    Public Property FechaUltimoMantenimiento() As String
        Get
            Return _FechaUltimoMantenimiento
        End Get
        Set(ByVal value As String)
            _FechaUltimoMantenimiento = value
        End Set
    End Property
    Public Property IdChip() As String
        Get
            Return _IdChip
        End Get
        Set(ByVal value As String)
            _IdChip = value
        End Set
    End Property
    Public Property CedulaVendedor() As String
        Get
            Return _CedulaVendedor
        End Get
        Set(ByVal value As String)
            _CedulaVendedor = value
        End Set
    End Property
    Public Property SerialMaquina() As String
        Get
            Return _SerialMaquina
        End Get
        Set(ByVal value As String)
            _SerialMaquina = value
        End Set
    End Property
    Public Property IdEmpresa() As String
        Get
            Return _IdEmpresa
        End Get
        Set(ByVal value As String)
            _IdEmpresa = value
        End Set
    End Property
End Class
