
Public Class RespuestaAutorizacionVentaTerpel

    Private _Procesado As Boolean

    Private _IdAprobacion As Integer

    Private _MensajeError As String

    Private _IdFormaPago As Integer

    Private _CupoMaximoVolumen As Decimal

    Private _CupoMaximoDinero As Decimal

    Private _SaldoCliente As Decimal

    Private _NombreCliente As String

    Private _NitCliente As String

    Private _PlacaVehiculo As String

    Private _ValorIvaImplicito As Decimal

    Public Property Procesado() As Boolean
        Get
            Return Me._Procesado
        End Get
        Set(value As Boolean)
            Me._Procesado = value
        End Set
    End Property

    Public Property IdAprobacion() As Integer
        Get
            Return Me._IdAprobacion
        End Get
        Set(value As Integer)
            Me._IdAprobacion = value
        End Set
    End Property


    Public Property MensajeError() As String
        Get
            Return Me._MensajeError
        End Get
        Set(value As String)
            Me._MensajeError = value
        End Set
    End Property

    Public Property IdFormaPago() As Integer
        Get
            Return Me._IdFormaPago
        End Get
        Set(value As Integer)
            Me._IdFormaPago = value
        End Set
    End Property

    Public Property CupoMaximoVolumen() As Decimal
        Get
            Return Me._CupoMaximoVolumen
        End Get
        Set(value As Decimal)
            Me._CupoMaximoVolumen = value
        End Set
    End Property


    Public Property CupoMaximoDinero() As Decimal
        Get
            Return Me._CupoMaximoDinero
        End Get
        Set(value As Decimal)
            Me._CupoMaximoDinero = value
        End Set
    End Property


    Public Property SaldoCliente() As Decimal
        Get
            Return Me._SaldoCliente
        End Get
        Set(value As Decimal)
            Me._SaldoCliente = value
        End Set
    End Property


    Public Property NombreCliente() As String
        Get
            Return Me._NombreCliente
        End Get
        Set(value As String)
            Me._NombreCliente = value
        End Set
    End Property


    Public Property NitCliente() As String
        Get
            Return Me._NitCliente
        End Get
        Set(value As String)
            Me._NitCliente = value
        End Set
    End Property


    Public Property PlacaVehiculo() As String
        Get
            Return Me._PlacaVehiculo
        End Get
        Set(value As String)
            Me._PlacaVehiculo = value
        End Set
    End Property


    Public Property ValorIvaImplicito() As Decimal
        Get
            Return Me._ValorIvaImplicito
        End Get
        Set(value As Decimal)
            Me._ValorIvaImplicito = value
        End Set
    End Property
End Class


Public Class RespuestaFaltantesTerpel

    Private _AprobacionesFaltantes As List(Of Integer)

    Private _TurnosFaltantes As List(Of Integer)

    Public Sub New()
        AprobacionesFaltantes = New List(Of Integer)()
        TurnosFaltantes = New List(Of Integer)()
    End Sub

    Public Property AprobacionesFaltantes() As List(Of Integer)
        Get
            Return Me._AprobacionesFaltantes
        End Get
        Set(value As List(Of Integer))
            Me._AprobacionesFaltantes = value
        End Set
    End Property


    Public Property TurnosFaltantes() As List(Of Integer)
        Get
            Return Me._TurnosFaltantes
        End Get
        Set(value As List(Of Integer))
            Me._TurnosFaltantes = value
        End Set
    End Property


End Class