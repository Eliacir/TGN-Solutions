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


Public Class RespuestaAutorizacionGerenciamiento

    Private _IdAutorizacion As Int64
    Public Property IdAutorizacion() As Int64
        Get
            Return _IdAutorizacion
        End Get
        Set(ByVal value As Int64)
            _IdAutorizacion = value
        End Set
    End Property

    Private _IdFormaPago As Int16
    Public Property IdFormaPago() As Int16
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Int16)
            _IdFormaPago = value
        End Set
    End Property

    Private _ValorAutorizado As Decimal
    Public Property ValorAutorizado() As Decimal
        Get
            Return _ValorAutorizado
        End Get
        Set(ByVal value As Decimal)
            _ValorAutorizado = value
        End Set
    End Property

    Private _SaldoDisponible As Decimal
    Public Property SaldoDisponible() As Decimal
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Decimal)
            _SaldoDisponible = value
        End Set
    End Property

    Private _MensajeError As String = String.Empty
    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property


    Private _EsAutorizado As Boolean
    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    Private _ConsumoMes As Double
    Public Property ConsumoMes() As Double
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Double)
            _ConsumoMes = value
        End Set
    End Property
    Private _FechaContrato As Date
    Public Property FechaContrato() As Date
        Get
            Return _FechaContrato
        End Get
        Set(ByVal value As Date)
            _FechaContrato = value
        End Set
    End Property

    Private _LecturaOdometro As String
    Public Property LecturaOdometro() As String
        Get
            Return _LecturaOdometro
        End Get
        Set(ByVal value As String)
            _LecturaOdometro = value
        End Set
    End Property

    Private _NumeroContratoPrepago As String
    Public Property NumeroContratoPrepago() As String
        Get
            Return _NumeroContratoPrepago
        End Get
        Set(ByVal value As String)
            _NumeroContratoPrepago = value
        End Set
    End Property

    Private _NumeroTarjetaPrepago As String
    Public Property NumeroTarjetaPrepago() As String
        Get
            Return _NumeroTarjetaPrepago
        End Get
        Set(ByVal value As String)
            _NumeroTarjetaPrepago = value
        End Set
    End Property

    Private _EsPrepago As Boolean

    Public Property EsPrepago() As Boolean
        Get
            Return _EsPrepago
        End Get
        Set(ByVal value As Boolean)
            _EsPrepago = value
        End Set
    End Property

End Class

Public Class AutorizacionCodigoClienteCredito
    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _Cara As String
    Public Property Cara() As String
        Get
            Return _Cara
        End Get
        Set(ByVal value As String)
            _Cara = value
        End Set
    End Property
End Class

Public Class CupoPrepago
    Private _Pagos As New Dictionary(Of Short, Double)
    Private _NroTarjeta As String
    Private _Valor As Double

    Private _FormaPago As Short = 12


    Private _Kilometraje As String
    Public Property kilometraje() As String
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As String)
            _Kilometraje = value
        End Set
    End Property

    Public Property FormaPago() As Short
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As Short)
            _FormaPago = value
        End Set
    End Property

    Public Property Valor() As Double
        Get
            Return _Valor
        End Get
        Set(ByVal value As Double)
            _Valor = value
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

    Public Property Pagos() As Dictionary(Of Short, Double)
        Get
            Return _Pagos
        End Get
        Set(ByVal value As Dictionary(Of Short, Double))
            _Pagos = value
        End Set
    End Property

    Public Sub AgregarMedioPago(ByVal idFormaPago As Short, ByVal Valor As Double)
        If Pagos.ContainsKey(idFormaPago) Then
            Pagos(idFormaPago) = Pagos(idFormaPago) + Valor
        Else
            Pagos.Add(idFormaPago, Valor)
        End If
    End Sub

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
    Private _SaldoDisponible As Decimal
    Private _Autorizacion As String
    Private _FormaPago As Int16
    Private _IdProducto As Int32
    Private _Placa As String
    Private _ConsumoMes As Double
    Private _RUTConductor As String
    Private _TarjetaPrepago As String
    Private _EsPrepago As Boolean



    Private _FechaContrato As Date
    Public Property FechaContrato() As Date
        Get
            Return _FechaContrato
        End Get
        Set(ByVal value As Date)
            _FechaContrato = value
        End Set
    End Property

    Private _LecturaOdometro As String
    Public Property LecturaOdometro() As String
        Get
            Return _LecturaOdometro
        End Get
        Set(ByVal value As String)
            _LecturaOdometro = value
        End Set
    End Property

    Private _NumeroContratoPrepago As String
    Public Property NumeroContratoPrepago() As String
        Get
            Return _NumeroContratoPrepago
        End Get
        Set(ByVal value As String)
            _NumeroContratoPrepago = value
        End Set
    End Property

    Private _NumeroTarjetaPrepago As String
    Public Property NumeroTarjetaPrepago() As String
        Get
            Return _NumeroTarjetaPrepago
        End Get
        Set(ByVal value As String)
            _NumeroTarjetaPrepago = value
        End Set
    End Property

    Public Property EsPrepago() As Boolean
        Get
            Return _EsPrepago
        End Get
        Set(ByVal value As Boolean)
            _EsPrepago = value
        End Set
    End Property


    Public Property TarjetaPrepago() As String
        Get
            Return _TarjetaPrepago
        End Get
        Set(ByVal value As String)
            _TarjetaPrepago = value
        End Set
    End Property


    Public Property RUTconductor() As String
        Get
            Return _RUTConductor
        End Get
        Set(ByVal value As String)
            _RUTConductor = value
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


    Public Property IdProducto() As Int32
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Int32)
            _IdProducto = value
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

    Public Property ConsumoMes() As Double
        Get
            Return _ConsumoMes
        End Get
        Set(ByVal value As Double)
            _ConsumoMes = value
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

Public Class CreditoFullstation
    Private _TipoIdentificacion As TipoIdentificadorVehiculo = TipoIdentificadorVehiculo.CHIP
    Private _EsEfectivo As Boolean
    Private _Documento As String = ""
    Private _DocumentoAux As String = ""
    Private _ValorPredeterminado As String
    Private _FormaPago As Int16
    Private _Kilometraje As String
    Private _Tarjeta As TarjetaFidelizacion = Nothing
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
    Private _TipoVehiculo As Int32
    Private _TipoManejo As TipoManejo
    Private _ImprimirDescuento As Boolean
    Private _NoContrato As String = ""
    Private _CodCentroCosto As String = ""
    Private _NombreCentroCosto As String = ""
    Private _Autorizacion As String
    Private _Iva As Decimal




    Private _RUTconductor As String
    Public Property RUTconductor() As String
        Get
            Return _RUTconductor
        End Get
        Set(ByVal value As String)
            _RUTconductor = value
        End Set
    End Property

    Private _FechaContrato As Date
    Public Property FechaContrato() As Date
        Get
            Return _FechaContrato
        End Get
        Set(ByVal value As Date)
            _FechaContrato = value
        End Set
    End Property

    Private _LecturaOdometro As String
    Public Property LecturaOdometro() As String
        Get
            Return _LecturaOdometro
        End Get
        Set(ByVal value As String)
            _LecturaOdometro = value
        End Set
    End Property

    Private _NumeroContratoPrepago As String
    Public Property NumeroContratoPrepago() As String
        Get
            Return _NumeroContratoPrepago
        End Get
        Set(ByVal value As String)
            _NumeroContratoPrepago = value
        End Set
    End Property

    Private _NumeroTarjetaPrepago As String
    Public Property NumeroTarjetaPrepago() As String
        Get
            Return _NumeroTarjetaPrepago
        End Get
        Set(ByVal value As String)
            _NumeroTarjetaPrepago = value
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


    Public Property Rom() As String
        Get
            Return _Rom
        End Get
        Set(ByVal value As String)
            _Rom = value
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

    Public Property Tarjeta() As TarjetaFidelizacion
        Get
            Return _Tarjeta
        End Get
        Set(ByVal value As TarjetaFidelizacion)
            _Tarjeta = value
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
    Public Property Contrato() As String
        Get
            Return _NoContrato
        End Get
        Set(ByVal value As String)
            _NoContrato = value
        End Set
    End Property

    ''' <summary>
    ''' Codigo del Centro de Costo Asociado al Vehículo del Cliente en caso de ser Crédito
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodigoCentroCosto() As String
        Get
            Return _CodCentroCosto
        End Get
        Set(ByVal value As String)
            _CodCentroCosto = value
        End Set
    End Property

    ''' <summary>
    ''' Descripción ó nombre del centro de costo en caso de ser un cliente crédito
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CentroCosto() As String
        Get
            Return _NombreCentroCosto
        End Get
        Set(ByVal value As String)
            _NombreCentroCosto = value
        End Set
    End Property


    Public Property ImprimirDescuento() As Boolean
        Get
            Return _ImprimirDescuento
        End Get
        Set(ByVal value As Boolean)
            _ImprimirDescuento = value
        End Set
    End Property

    Public Property TipoManejo() As TipoManejo
        Get
            Return _TipoManejo
        End Get
        Set(ByVal value As TipoManejo)
            _TipoManejo = value
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

    Public Property ValorPredeterminado() As String
        Get
            Return _ValorPredeterminado
        End Get
        Set(ByVal value As String)
            _ValorPredeterminado = value
        End Set
    End Property

    Public Property TipoIdentificacion() As TipoIdentificadorVehiculo
        Get
            Return _TipoIdentificacion
        End Get
        Set(ByVal value As TipoIdentificadorVehiculo)
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

    Public Property Iva() As Decimal
        Get
            Return _Iva
        End Get
        Set(ByVal value As Decimal)
            _Iva = value
        End Set
    End Property
End Class


Public Class Vale

    Private _Placa As String
    Private _NroVale As String
    Private _TipoVale As POSstation.Fabrica.TipoEnvaseBolivia
    Private _FormaPago As Int16
    Private _NumeroFactura As String

    Public Property FormaPago() As Int16
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As Int16)
            _FormaPago = value
        End Set
    End Property

    Public Property TipoVale() As POSstation.Fabrica.TipoEnvaseBolivia
        Get
            Return _TipoVale
        End Get
        Set(ByVal value As POSstation.Fabrica.TipoEnvaseBolivia)
            _TipoVale = value
        End Set
    End Property


    Public Property NroVale() As String
        Get
            Return _NroVale
        End Get
        Set(ByVal value As String)
            _NroVale = value
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


    Public Property NumeroFactura As String
        Get
            Return _NumeroFactura
        End Get
        Set(ByVal value As String)
            _NumeroFactura = value
        End Set
    End Property

End Class