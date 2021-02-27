

Public Class InformacionVentaFidelizada
    Inherits Disposable

    Private IdProductoAux As Short
    Public Property IdProducto() As Short
        Get
            Return IdProductoAux
        End Get
        Set(ByVal value As Short)
            IdProductoAux = value
        End Set
    End Property

    Private PlacaAux As String
    Public Property Placa() As String
        Get
            Return PlacaAux
        End Get
        Set(ByVal value As String)
            PlacaAux = value
        End Set
    End Property

    Private CodEstacionAux As String
    Public Property CodEstacion() As String
        Get
            Return CodEstacionAux
        End Get
        Set(ByVal value As String)
            CodEstacionAux = value
        End Set
    End Property

    Private FechaAux As String
    Public Property Fecha() As String
        Get
            Return FechaAux
        End Get
        Set(ByVal value As String)
            FechaAux = value
        End Set
    End Property

    Private TotalAux As String
    Public Property Total() As String
        Get
            Return TotalAux
        End Get
        Set(ByVal value As String)
            TotalAux = value
        End Set
    End Property

    Private CantidadAux As String
    Public Property Cantidad() As String
        Get
            Return CantidadAux
        End Get
        Set(ByVal value As String)
            CantidadAux = value
        End Set
    End Property

    Private TarjetaAux As String
    Public Property Tarjeta() As String
        Get
            Return TarjetaAux
        End Get
        Set(ByVal value As String)
            TarjetaAux = value
        End Set
    End Property


    Private _Rut As String
    Public Property Rut() As String
        Get
            Return _Rut
        End Get
        Set(ByVal value As String)
            _Rut = value
        End Set
    End Property



End Class
Public Class InformacionUltimaVentaFidelizada
    Inherits Disposable

    Private IdProductoAux As Short
    Public Property IdProducto() As Short
        Get
            Return IdProductoAux
        End Get
        Set(ByVal value As Short)
            IdProductoAux = value
        End Set
    End Property

    Private PlacaAux As String
    Public Property Placa() As String
        Get
            Return PlacaAux
        End Get
        Set(ByVal value As String)
            PlacaAux = value
        End Set
    End Property

    Private CodEstacionAux As String
    Public Property CodEstacion() As String
        Get
            Return CodEstacionAux
        End Get
        Set(ByVal value As String)
            CodEstacionAux = value
        End Set
    End Property

    Private FechaAux As String
    Public Property Fecha() As String
        Get
            Return FechaAux
        End Get
        Set(ByVal value As String)
            FechaAux = value
        End Set
    End Property

    Private TotalAux As String
    Public Property Total() As String
        Get
            Return TotalAux
        End Get
        Set(ByVal value As String)
            TotalAux = value
        End Set
    End Property

    Private CantidadAux As String
    Public Property Cantidad() As String
        Get
            Return CantidadAux
        End Get
        Set(ByVal value As String)
            CantidadAux = value
        End Set
    End Property

    Private TarjetaAux As String
    Public Property Tarjeta() As String
        Get
            Return TarjetaAux
        End Get
        Set(ByVal value As String)
            TarjetaAux = value
        End Set
    End Property


End Class
Public Class AutorizacionVentaBono
    Inherits Disposable

    Private _Mensaje As String
    Private _ValorBono As Decimal
    Private _EsAutorizado As Boolean
    Private _NroAutorizacion As String
    Private _Cantidad As Decimal

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

#End Region

    Sub New(ByVal Tarjeta As String, ByVal Puerto As String)
        _nroTarjeta = Tarjeta
        _puerto = Puerto
    End Sub
End Class

