
Public Class VentasFueraDeSistema

    Private lstMangueras As New List(Of Short)
    Private _UltimaManguera As Short
    Private _CantidadGalones As Decimal
    Private _ValorFaltante As Decimal
    Private _IndexMangueras As Integer
    Private _Precio As Decimal

    Public Property UltimaManguera() As Short
        Get
            Return _UltimaManguera
        End Get
        Set(ByVal value As Short)
            _UltimaManguera = value
        End Set
    End Property

    Public Property CantidadGalones() As Decimal
        Get
            Return _CantidadGalones
        End Get
        Set(ByVal value As Decimal)
            _CantidadGalones = value
        End Set
    End Property

    Public Property ValorFaltante() As Decimal
        Get
            Return _ValorFaltante
        End Get
        Set(ByVal value As Decimal)
            _ValorFaltante = value
        End Set
    End Property

    Public Property IndexMangueras() As Integer
        Get
            Return _IndexMangueras
        End Get
        Set(ByVal value As Integer)
            _IndexMangueras = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property

    Public Sub AgregarMangueras(ByVal manguera As Short)
        Try
            'Adicionamos la manguera a la lista
            lstMangueras.Add(manguera)
        Catch
            Throw
        End Try
    End Sub

    Public Function ExisteManguera(ByVal manguera As Short) As Boolean
        Try
            'Verificamos si la manguera existe o no
            If lstMangueras.Contains(manguera) Then
                Return True
            Else
                Return False
            End If
        Catch
            Throw
        End Try
    End Function

    Public Function RecuperarManguera(ByVal index As Integer) As Short
        Try
            'Retornamos la manguera que se encuentre en el indice señalado
            Return lstMangueras(index)
        Catch
            Throw
        End Try
    End Function

End Class

Public Class MedioPago
    Inherits Disposable

    Private _IdMedioPago As Int16
    Private _Documento As String
    Private _NroConfirmacion As String
    Private _Valor As Decimal
    Private _TipoLectura As Int32

    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property
    Public Property IdMedioPago() As Int16
        Get
            Return _IdMedioPago
        End Get
        Set(ByVal value As Int16)
            _IdMedioPago = value
        End Set
    End Property
    Public Property NroConfirmacion() As String
        Get
            Return _NroConfirmacion
        End Get
        Set(ByVal value As String)
            _NroConfirmacion = value
        End Set
    End Property
    Public Property TipoLectura() As Int32
        Get
            Return _TipoLectura
        End Get
        Set(ByVal value As Int32)
            _TipoLectura = value
        End Set
    End Property
    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(ByVal value As Decimal)
            _Valor = value
        End Set
    End Property

End Class

Public Class IdentificadorVenta

    Private _Identificador As String
    Public Property Identificador() As String
        Get
            Return _Identificador
        End Get
        Set(ByVal value As String)
            _Identificador = value
        End Set
    End Property

    Private _NumeroSeguridad As String
    Public Property NumeroSeguridad() As String
        Get
            Return _NumeroSeguridad
        End Get
        Set(ByVal value As String)
            _NumeroSeguridad = value
        End Set
    End Property

    Private _TipoIdentificador As TipoIdentificacionCredito
    Public Property TipoIdentificador() As TipoIdentificacionCredito
        Get
            Return _TipoIdentificador
        End Get
        Set(ByVal value As TipoIdentificacionCredito)
            _TipoIdentificador = value
        End Set
    End Property

End Class


Public Class CreditoVenta
    Private _EsEfectivo As Boolean
    Private _Autorizacion As String
    Private _FormaPago As Int16
    Private _Kilometraje As String
    Private _Identificador As IdentificadorVenta = Nothing
    Private _EsAutorizacionLocal As Boolean
    Private _NroAutorizacionManual As String = Nothing
    Private _Precio As Decimal
    Private _FormaPagoContado As FormaPagoVenta = Nothing
    Private _IdClienteCDC As Int32
    Private _DescuentoValor As Decimal
    Private _DescuentoPorcentaje As Decimal
    Private _PrecioCliente As Decimal
    Private _EsVentaDirectaEnMR As Boolean
    Private _Placa As String
    Private _Rom As String
    Private _IdProducto As Integer
    Private _Estado As EstadoAutorizacion
    Private _HoraInicio As DateTime = Now
    Private _SaldoDisponible As Decimal
    Private _ValorPredeterminado As Decimal = 0
    Private _TipoVehiculo As Int32
    Private _TarjetaFidelizacion As TarjetaFidelizacion = Nothing

    Public Property TarjetaFidelizacion() As TarjetaFidelizacion
        Get
            Return _TarjetaFidelizacion
        End Get
        Set(ByVal value As TarjetaFidelizacion)
            _TarjetaFidelizacion = value
        End Set
    End Property

    Public Property TipoVehiculo() As Int32
        Get
            Return _TipoVehiculo
        End Get
        Set(ByVal value As Int32)
            _TipoVehiculo = value
        End Set
    End Property

    Public Property ValorPredeterminado() As Decimal
        Get
            Return _ValorPredeterminado
        End Get
        Set(ByVal value As Decimal)
            _ValorPredeterminado = value
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

    Public Property HoraInicio() As DateTime
        Get
            Return _HoraInicio
        End Get
        Set(ByVal value As DateTime)
            _HoraInicio = value
        End Set
    End Property


    Public Property Estado() As EstadoAutorizacion
        Get
            Return _Estado
        End Get
        Set(ByVal value As EstadoAutorizacion)
            _Estado = value
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

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property


    Public Property EsVentaDirectaEnMR() As Boolean
        Get
            Return _EsVentaDirectaEnMR
        End Get
        Set(ByVal value As Boolean)
            _EsVentaDirectaEnMR = value
        End Set
    End Property


    Public Property PrecioCliente() As Decimal
        Get
            Return _PrecioCliente
        End Get
        Set(ByVal value As Decimal)
            _PrecioCliente = value
        End Set
    End Property


    Public Property DescuentoValor() As Decimal
        Get
            Return _DescuentoValor
        End Get
        Set(ByVal value As Decimal)
            _DescuentoValor = value
        End Set
    End Property

    Public Property DescuentoPorcentaje() As Decimal
        Get
            Return _DescuentoPorcentaje
        End Get
        Set(ByVal value As Decimal)
            _DescuentoPorcentaje = value
        End Set
    End Property


    Public Property FormaPagoContado() As FormaPagoVenta
        Get
            Return _FormaPagoContado
        End Get
        Set(ByVal value As FormaPagoVenta)
            _FormaPagoContado = value
        End Set
    End Property

    Public Property EsAutorizacionLocal() As Boolean
        Get
            Return _EsAutorizacionLocal
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizacionLocal = value
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

    Public Property IdClienteCDC() As Int32
        Get
            Return _IdClienteCDC
        End Get
        Set(ByVal value As Int32)
            _IdClienteCDC = value
        End Set
    End Property

    Public Property Kilometraje() As String
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As String)
            _Kilometraje = value
        End Set
    End Property

    Public Property Identificador() As IdentificadorVenta
        Get
            Return _Identificador
        End Get
        Set(ByVal value As IdentificadorVenta)
            _Identificador = value
        End Set
    End Property

    Public Property NroAutorizacionManual() As String
        Get
            Return _NroAutorizacionManual
        End Get
        Set(ByVal value As String)
            _NroAutorizacionManual = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property
End Class

Public Class ModificacionVentaChile
    Private _cara As Byte
    Private _Recibo As String
    Private _EsVentaRegistrada As Boolean

    Public Property Cara() As Byte
        Get
            Return _cara
        End Get
        Set(ByVal value As Byte)
            _cara = value
        End Set
    End Property

    Public Property Recibo() As String
        Get
            Return _Recibo
        End Get
        Set(ByVal value As String)
            _Recibo = value
        End Set
    End Property


    Public Property EsVentaRegistrada() As Boolean
        Get
            Return _EsVentaRegistrada
        End Get
        Set(ByVal value As Boolean)
            _EsVentaRegistrada = value
        End Set
    End Property


End Class


Public Class FacturaConsolidadaFullStation
    Private _Cedula As String
    Private _CodigoEstacion As String
    Private _Descuento As Decimal
    Private _FechaFacturada As DateTime
    Private _Prefijo As String
    Private _Consecutivo As String
    Private _TipoMOvimiento As String
    Private _CodigoContable As String
    Private _Bodega As String
    Private _TipoInventario As String
    Private _TotalFactura As Decimal
    Private _SobreTasa As Decimal
    Private _Subtotal As Decimal
    Private _ValorTotalSobreTasa As Decimal
    Private _DescuentoGrabado As Decimal
    Private _ValorCosto As Decimal
    Private _TipoCuenta As String
    Private _Plazo As Integer
    Private _CodigoVendedor As String
    Private _Usuario As String
    Private _FechaHoraGeneracion As DateTime
    Private _Cantidad As Double
    Private _Producto As String
    Private _Iva As Double


    Public Property Iva() As Double
        Get
            Return _Iva
        End Get
        Set(ByVal value As Double)
            _Iva = value
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

    Public Property Producto() As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
        End Set
    End Property


    Public Property FechaHoraGeneracion() As DateTime
        Get
            Return _FechaHoraGeneracion
        End Get
        Set(ByVal value As DateTime)
            _FechaHoraGeneracion = value
        End Set
    End Property




    Public Property Plazo() As Integer
        Get
            Return _Plazo
        End Get
        Set(ByVal value As Integer)
            _Plazo = value
        End Set
    End Property

    Public Property DescuentoGrabado() As Decimal
        Get
            Return _DescuentoGrabado
        End Get
        Set(ByVal value As Decimal)
            _DescuentoGrabado = value
        End Set
    End Property


    Public Property ValorCosto() As Decimal
        Get
            Return _ValorCosto
        End Get
        Set(ByVal value As Decimal)
            _ValorCosto = value
        End Set
    End Property

    Public Property ValorTotalSobreTasa() As Decimal
        Get
            Return _ValorTotalSobreTasa
        End Get
        Set(ByVal value As Decimal)
            _ValorTotalSobreTasa = value
        End Set
    End Property


    Public Property Subtotal() As Decimal
        Get
            Return _Subtotal
        End Get
        Set(ByVal value As Decimal)
            _Subtotal = value
        End Set
    End Property

    Public Property SobreTasa() As Decimal
        Get
            Return _SobreTasa
        End Get
        Set(ByVal value As Decimal)
            _SobreTasa = value
        End Set
    End Property
    Public Property TipoCuenta() As String
        Get
            Return _TipoCuenta
        End Get
        Set(ByVal value As String)
            _TipoCuenta = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property CodigoVendedor() As String
        Get
            Return _CodigoVendedor
        End Get
        Set(ByVal value As String)
            _CodigoVendedor = value
        End Set
    End Property


    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal value As String)
            _Cedula = value
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


    Public Property Descuento() As Decimal
        Get
            Return _Descuento
        End Get
        Set(ByVal value As Decimal)
            _Descuento = value
        End Set
    End Property



    Public Property FechaFacturada() As DateTime
        Get
            Return _FechaFacturada
        End Get
        Set(ByVal value As DateTime)
            _FechaFacturada = value
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


    Public Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
        Set(ByVal value As String)
            _Consecutivo = value
        End Set
    End Property


    Public Property TipoMovimiento() As String
        Get
            Return _TipoMOvimiento
        End Get
        Set(ByVal value As String)
            _TipoMOvimiento = value
        End Set
    End Property


    Public Property Bodega() As String
        Get
            Return _Bodega
        End Get
        Set(ByVal value As String)
            _Bodega = value
        End Set
    End Property


    Public Property TipoInventario() As String
        Get
            Return _TipoInventario
        End Get
        Set(ByVal value As String)
            _TipoInventario = value
        End Set
    End Property

    Public Property TotalFactura() As Decimal
        Get
            Return _TotalFactura
        End Get
        Set(ByVal value As Decimal)
            _TotalFactura = value
        End Set
    End Property


End Class

Public Class FacturaConfiguracion

    Private _Espacio As String
    Private _tamaño As String

    Public Property tamaño() As String
        Get
            Return _tamaño
        End Get
        Set(ByVal value As String)
            _tamaño = value
        End Set
    End Property


    Public Property Espacio() As String
        Get
            Return _Espacio
        End Get
        Set(ByVal value As String)
            _Espacio = value
        End Set
    End Property

End Class