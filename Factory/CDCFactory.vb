
Public Class MediosPagoTemporales
    Public EsAutorizado As Boolean
    Public Saldo As Decimal
    Public Valor As Double
End Class

Public Class InformacionMediosPagoAbono
    Inherits Disposable

    Private FechaTurnoAux As String
    Private FechaAux As String
    Private IdTurnoAux As Int32
    Private CodigoAux As String
    Private PlacaAux As String
    Private ValorAux As String
    Private CodEstacionAux As String
    Private _IdEmpleado As Int32
    Private _GUIDPago As String
    Private _CedulaEmpleado As String
    Private _EsAnulado As Boolean
    Private _IdCredito As String
    Private _EstadoPagoExtraordiario As Int32
    Private _Movil As Nullable(Of Int32)
    Private _IdConcepto As Nullable(Of Int32)
    Private _Concepto As String
    Private _IdEmpresa As Int32
    Private _NitEmpresa As String
    Private _Empresa As String
    Private _IdPagoEmpresa As Int32
    Private _IdRecaudoCDC As Nullable(Of Int32)
    Private _Recibo As Int64

    Public Property Recibo() As Int64
        Get
            Return _Recibo
        End Get
        Set(ByVal value As Int64)
            _Recibo = value
        End Set
    End Property

    Public Property IdRecaudoCDC() As Nullable(Of Int32)
        Get
            Return _IdRecaudoCDC
        End Get
        Set(ByVal value As Nullable(Of Int32))
            _IdRecaudoCDC = value
        End Set
    End Property
    Private _NroTarjeta As String
    Public Property NroTarjeta() As String
        Get
            Return _NroTarjeta
        End Get
        Set(ByVal value As String)
            _NroTarjeta = value
        End Set
    End Property

    Private _TipoLectura As Integer
    Public Property TipoLectura() As Integer
        Get
            Return _TipoLectura
        End Get
        Set(ByVal value As Integer)
            _TipoLectura = value
        End Set
    End Property

    Private _NroSeguridad As String
    Public Property NroSeguridad() As String
        Get
            Return _NroSeguridad
        End Get
        Set(ByVal value As String)
            _NroSeguridad = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property
    Public Property IdPagoEmpresa() As Int32
        Get
            Return _IdPagoEmpresa
        End Get
        Set(ByVal value As Int32)
            _IdPagoEmpresa = value
        End Set
    End Property
    Public Property NitEmpresa() As String
        Get
            Return _NitEmpresa
        End Get
        Set(ByVal value As String)
            _NitEmpresa = value
        End Set
    End Property
    Public Property IdEmpresa() As Int32
        Get
            Return _IdEmpresa
        End Get
        Set(ByVal value As Int32)
            _IdEmpresa = value
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
    Public Property IdConcepto() As Nullable(Of Int32)
        Get
            Return _IdConcepto
        End Get
        Set(ByVal value As Nullable(Of Int32))
            _IdConcepto = value
        End Set
    End Property
    Public Property Movil() As Nullable(Of Int32)
        Get
            Return _Movil
        End Get
        Set(ByVal value As Nullable(Of Int32))
            _Movil = value
        End Set
    End Property
    Public Property EstadoPagoExtraordinario() As Int32
        Get
            Return _EstadoPagoExtraordiario
        End Get
        Set(ByVal value As Int32)
            _EstadoPagoExtraordiario = value
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

    Public Property CedulaEmpleado() As String
        Get
            Return _CedulaEmpleado
        End Get
        Set(ByVal value As String)
            _CedulaEmpleado = value
        End Set
    End Property

    Public Property GUIDPago() As String
        Get
            Return _GUIDPago
        End Get
        Set(ByVal value As String)
            _GUIDPago = value
        End Set
    End Property

    Public Property FechaTurno() As String
        Get
            Return FechaTurnoAux
        End Get
        Set(ByVal value As String)
            FechaTurnoAux = value
        End Set
    End Property
    Public Property Fecha() As String
        Get
            Return FechaAux
        End Get
        Set(ByVal value As String)
            FechaAux = value
        End Set
    End Property
    Public Property IdTurno() As Int32
        Get
            Return IdTurnoAux
        End Get
        Set(ByVal value As Int32)
            IdTurnoAux = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return CodigoAux
        End Get
        Set(ByVal value As String)
            CodigoAux = value
        End Set
    End Property
    Public Property Placa() As String
        Get
            Return PlacaAux
        End Get
        Set(ByVal value As String)
            PlacaAux = value
        End Set
    End Property
    Public Property Valor() As String
        Get
            Return (ValorAux)
        End Get
        Set(ByVal value As String)
            ValorAux = value
        End Set
    End Property
    Public Property CodEstacion() As String
        Get
            Return CodEstacionAux
        End Get
        Set(ByVal value As String)
            CodEstacionAux = value
        End Set
    End Property

    Public Property IdEmpleado() As Int32
        Get
            Return _IdEmpleado
        End Get
        Set(ByVal value As Int32)
            _IdEmpleado = value
        End Set
    End Property

    Public Property IdCredito() As String
        Get
            Return _IdCredito
        End Get
        Set(ByVal value As String)
            _IdCredito = value
        End Set
    End Property

End Class

Public Class RespuestaConsultaDescuentosCanastilla

    Private _ClasificacionCliente As String
    Private _Descuentos As New List(Of DescuentosCanastilla)
    Private _IdentificacionCliente As String
    Private _MensajeError As String
    Private _NombreCliente As String
    Private _Procesado As Boolean

    Public Property ClasificacionCliente() As String
        Get
            Return _ClasificacionCliente
        End Get
        Set(ByVal value As String)
            _ClasificacionCliente = value
        End Set
    End Property

    Public Property Descuentos() As List(Of DescuentosCanastilla)
        Get
            Return _Descuentos
        End Get
        Set(ByVal value As List(Of DescuentosCanastilla))
            _Descuentos = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
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

    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property


End Class

Public Class DescuentosCanastilla

    Private _CantidadAutorizada As Integer

    Private _CodProducto As Integer

    Private _Mensaje As String

    Private _PorcDescuento As Decimal


    Private _NombreProducto As String

    Public Property CantidadAutorizada() As Integer
        Get
            Return _CantidadAutorizada
        End Get
        Set(ByVal value As Integer)
            _CantidadAutorizada = value
        End Set
    End Property

    Public Property CodProducto() As Integer
        Get
            Return _CodProducto
        End Get
        Set(ByVal value As Integer)
            _CodProducto = value
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

    Public Property PorcDescuento() As Decimal
        Get
            Return _PorcDescuento
        End Get
        Set(ByVal value As Decimal)
            _PorcDescuento = value
        End Set
    End Property

    Public Property NombreProducto() As String
        Get
            Return _NombreProducto
        End Get
        Set(ByVal value As String)
            _NombreProducto = value
        End Set
    End Property





End Class

Public Class UltimosMovimientosPrepago
    Private _TarjetaActiva As Boolean
    Private _SaldoActual As Decimal
    Private _MensajeError As String
    Private _ListaMovimientos As New List(Of Movimientos)


    Public Property TarjetaActiva() As Boolean
        Get
            Return _TarjetaActiva
        End Get
        Set(ByVal value As Boolean)
            _TarjetaActiva = value
        End Set
    End Property

    Public Property SaldoActual() As Decimal
        Get
            Return _SaldoActual
        End Get
        Set(ByVal value As Decimal)
            _SaldoActual = value
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

    Public Property ListaMovimientos() As List(Of Movimientos)
        Get
            Return _ListaMovimientos
        End Get
        Set(ByVal value As List(Of Movimientos))
            _ListaMovimientos = value
        End Set
    End Property

End Class

Public Class RespuestaRestricciones
    Private _CantidadDia As Decimal
    Private _CantidadMes As Decimal
    Private _CantidadQuincena As Decimal
    Private _CantidadSemanal As Decimal
    Private _EsPorDinero As Boolean
    Private _MostrarRestriccionesEnTiquete As Boolean
    Private _NoVisitasDia As Integer
    Private _NoVisitasMes As Integer
    Private _NoVisitasQuincena As Integer
    Private _NoVisitasSemana As Integer
    Private _FechaHora As String
    Private _Placa As String
    Private _Cliente As String
    Private _Empleado As String



    Public Property CantidadDia() As Decimal
        Get
            Return _CantidadDia
        End Get
        Set(ByVal value As Decimal)
            _CantidadDia = value
        End Set
    End Property

    Public Property CantidadMes() As Decimal
        Get
            Return _CantidadMes
        End Get
        Set(ByVal value As Decimal)
            _CantidadMes = value
        End Set
    End Property

    Public Property CantidadQuincena() As Decimal
        Get
            Return _CantidadQuincena
        End Get
        Set(ByVal value As Decimal)
            _CantidadQuincena = value
        End Set
    End Property

    Public Property CantidadSemanal() As Decimal
        Get
            Return _CantidadSemanal
        End Get
        Set(ByVal value As Decimal)
            _CantidadSemanal = value
        End Set
    End Property

    Public Property EsPorDinero() As Boolean
        Get
            Return _EsPorDinero
        End Get
        Set(ByVal value As Boolean)
            _EsPorDinero = value
        End Set
    End Property

    Public Property MostrarRestriccionesEnTiquete() As Boolean
        Get
            Return _MostrarRestriccionesEnTiquete
        End Get
        Set(ByVal value As Boolean)
            _MostrarRestriccionesEnTiquete = value
        End Set
    End Property

    Public Property NoVisitasDia() As Integer
        Get
            Return _NoVisitasDia
        End Get
        Set(ByVal value As Integer)
            _NoVisitasDia = value
        End Set
    End Property

    Public Property NoVisitasMes() As Integer
        Get
            Return _NoVisitasMes
        End Get
        Set(ByVal value As Integer)
            _NoVisitasMes = value
        End Set
    End Property

    Public Property NoVisitasQuincena() As Integer
        Get
            Return _NoVisitasQuincena
        End Get
        Set(ByVal value As Integer)
            _NoVisitasQuincena = value
        End Set
    End Property

    Public Property NoVisitasSemana() As Integer
        Get
            Return _NoVisitasSemana
        End Get
        Set(ByVal value As Integer)
            _NoVisitasSemana = value
        End Set
    End Property

    Public Property FechaHora() As String
        Get
            Return _FechaHora
        End Get
        Set(ByVal value As String)
            _FechaHora = value
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

    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Public Property Empleado() As String
        Get
            Return _Empleado
        End Get
        Set(ByVal value As String)
            _Empleado = value
        End Set
    End Property

End Class

Public Class Movimientos
    Private _Estacion As String
    Private _Fecha As String
    Private _Recibo As String
    Private _Valor As Decimal
    Private _IdUnidadMoneda As Integer

    Public Property Estacion() As String
        Get
            Return _Estacion
        End Get
        Set(ByVal value As String)
            _Estacion = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
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

    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(ByVal value As Decimal)
            _Valor = value
        End Set
    End Property

    Public Property IdUnidadMoneda() As Integer
        Get
            Return _IdUnidadMoneda
        End Get
        Set(ByVal value As Integer)
            _IdUnidadMoneda = value
        End Set
    End Property
End Class

Public Class Conductor
    Private _IdentificacionCliente As String
    Private _mensaje As String
    Private _NombreCliente As String
    Private _TipoDocumento As String

    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As String)
            _TipoDocumento = value
        End Set
    End Property


    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property


    Public Property Mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property
End Class

Public Class RespuestaMediosPagos
    Inherits Disposable

    Private _Procesado As Boolean
    Private _MensajeError As String
    Private _Saldo As Decimal
    Private _ValorFaltante As Decimal
    Private _ValorBono As Int32

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
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

    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
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

    Public Property ValorBono() As Int32
        Get
            Return _ValorBono
        End Get
        Set(ByVal value As Int32)
            _ValorBono = value
        End Set
    End Property
End Class

Public Class Prepagos
    Inherits Disposable

    Private _nroCodigoBarraPrepago As String

    Public Property NroCodigoBarraPrepago() As String
        Get
            Return _nroCodigoBarraPrepago
        End Get
        Set(ByVal value As String)
            _nroCodigoBarraPrepago = value
        End Set
    End Property

    Private _NroTarjetaPrepago As String

    Public Property NroTarjetaPrepago() As String
        Get
            Return _NroTarjetaPrepago
        End Get
        Set(ByVal value As String)
            _NroTarjetaPrepago = value
        End Set
    End Property

    Private _Saldo As Decimal
    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
        End Set
    End Property

    Private _NroConfirmacion As String
    Public Property NroConfirmacion() As String
        Get
            Return _NroConfirmacion
        End Get
        Set(ByVal value As String)
            _NroConfirmacion = value
        End Set
    End Property

    Private _TipoLectura As Integer

    Public Property TipoLectura() As Integer
        Get
            Return _TipoLectura
        End Get
        Set(ByVal value As Integer)
            _TipoLectura = value
        End Set
    End Property

End Class

Public Class RespuestaAutorizacionCheque
    Private _Procesado As Boolean
    Private _MensajeError As String

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
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

Public Class RespuestaVentaPrepago
    Inherits Disposable

    Private _Procesado As Boolean
    Private _MensajeError As String
    Private _TarjetaPrepago As Prepagos

    Public Property TarjetaPrepago() As Prepagos
        Get
            Return _TarjetaPrepago
        End Get
        Set(ByVal value As Prepagos)
            _TarjetaPrepago = value
        End Set
    End Property

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
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

Public Class MediosPagos
    Inherits Disposable

    Private _IdFormaPago As Short
    Private _NroConfirmacion As String
    Private _NroTarjeta As String
    Private _TipoLectura As Integer
    Private _Valor As Double
    Private _Saldo As Double
    Private _MensajeCDC As String = String.Empty
    Private _EsAutorizado As Boolean
    Private _IdMediosPago As Int64
    Private _Consecutivo As Long
    Private _Monto As Double = 0
    Private _idTipoFormaPago As Byte
    Private _numAutorizacionCheque As Long
    Private _PlacaCheque As String
    Private _Recaudo As Decimal

    Public Property Recaudo() As Decimal
        Get
            Return _Recaudo
        End Get
        Set(ByVal value As Decimal)
            _Recaudo = value
        End Set
    End Property

    Public Property NumAutorizacionCheque() As Long
        Get
            Return _numAutorizacionCheque
        End Get
        Set(ByVal value As Long)
            _numAutorizacionCheque = value
        End Set
    End Property

    Public Property PlacaCheque() As String
        Get
            Return _PlacaCheque
        End Get
        Set(ByVal value As String)
            _PlacaCheque = value
        End Set
    End Property

    Public Property idTipoFormaPago() As Byte
        Get
            Return _idTipoFormaPago
        End Get
        Set(ByVal value As Byte)
            _idTipoFormaPago = value
        End Set
    End Property

    Public Property IdMediosPago() As Int64
        Get
            Return _IdMediosPago
        End Get
        Set(ByVal value As Int64)
            _IdMediosPago = value
        End Set
    End Property

    Public Property Consecutivo() As Long
        Get
            Return _Consecutivo
        End Get
        Set(ByVal value As Long)
            _Consecutivo = value
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

    Public Property IdFormaPago() As Short
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Short)
            _IdFormaPago = value
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

    Public Property NroTarjeta() As String
        Get
            Return _NroTarjeta
        End Get
        Set(ByVal value As String)
            _NroTarjeta = value
        End Set
    End Property

    Public Property TipoLectura() As Integer
        Get
            Return _TipoLectura
        End Get
        Set(ByVal value As Integer)
            _TipoLectura = value
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

    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal value As Double)
            _Monto = value
        End Set
    End Property

    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Double)
            _Saldo = value
        End Set
    End Property

    Public Property MensajeCDC() As String
        Get
            Return _MensajeCDC
        End Get
        Set(ByVal value As String)
            _MensajeCDC = value
        End Set
    End Property

End Class

Public Class RespuestaRecaudoSRE
    Private _mensaje As String
    Private _IdEmpresa As Integer
    Private _nrAutorizacion As Long

    Public Property mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property
    Public Property IdEmpresa() As Integer
        Get
            Return _IdEmpresa
        End Get
        Set(ByVal value As Integer)
            _IdEmpresa = value
        End Set
    End Property
    Public Property nrAutorizacion() As Long
        Get
            Return _nrAutorizacion
        End Get
        Set(ByVal value As Long)
            _nrAutorizacion = value
        End Set
    End Property
End Class

Public Class RespuestaRecaudoEmpresaTercero
    Private _procesado As Boolean
    Private _mensaje As String
    Private _fecha As Date
    Private _IdAprobacion As String

    Public Property procesado() As Boolean
        Get
            Return _procesado
        End Get
        Set(ByVal value As Boolean)
            _procesado = value
        End Set
    End Property

    Public Property mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property

    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Public Property IdAprobacion() As String
        Get
            Return _IdAprobacion
        End Get
        Set(ByVal value As String)
            _IdAprobacion = value
        End Set
    End Property


End Class

Public Class RespuestaConsultaRecaudoEmpresaTercero

    Private _IdEmpresa As Integer
    Private _procesado As Boolean
    Private _mensaje As String
    Private _descripcion As String
    Private _valor As Decimal
    Private _valor1 As Decimal
    Private _valor2 As Decimal

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property

    Public Property Procesado() As Boolean
        Get
            Return _procesado
        End Get
        Set(ByVal value As Boolean)
            _procesado = value
        End Set
    End Property

    Public Property IdEmpresa() As Integer
        Get
            Return _IdEmpresa
        End Get
        Set(ByVal value As Integer)
            _IdEmpresa = value
        End Set
    End Property
    Public Property valor() As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
        End Set
    End Property

    Public Property valor1() As Decimal
        Get
            Return _valor1
        End Get
        Set(ByVal value As Decimal)
            _valor1 = value
        End Set
    End Property

    Public Property valor2() As Decimal
        Get
            Return _valor2
        End Get
        Set(ByVal value As Decimal)
            _valor2 = value
        End Set
    End Property


End Class

#Region "Clases para Interface SW Recaudo Empresa"
Public Class RespuestaServicioRecaudoEmpresa
    Private _mensaje As String
    Private _IdPago As Integer
    Private _EsProcesado As Boolean
    Private _Periodos As Int32
    Private _Valor As Decimal
    Private _Fecha As String
    Private _Descripcion As String

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property



    Public Property Mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property
    Public Property IdRecaudoEmpresa() As Integer
        Get
            Return _IdPago
        End Get
        Set(ByVal value As Integer)
            _IdPago = value
        End Set
    End Property
    Public Property Periodos() As Int32
        Get
            Return _Periodos
        End Get
        Set(ByVal value As Int32)
            _Periodos = value
        End Set
    End Property
    Public Property EsProcesado() As Boolean
        Get
            Return _EsProcesado
        End Get
        Set(ByVal value As Boolean)
            _EsProcesado = value
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
    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property
End Class

Public Class RespuestaConsultaConceptoEmpresa
    Private _IdConcepto As Int32
    Private _Descripcion As String
    Private _Periodos As Int32
    Private _DescPeriodos As String
    Private _Saldo As Decimal
    Private _FechaInicial As DateTime
    Private _FechaFinal As DateTime
    Private _Periodo As Int32
    Private _IdMovil As Int32
    Public Property DescPeriodos() As String
        Get
            Return _DescPeriodos
        End Get
        Set(ByVal value As String)
            _DescPeriodos = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property FechaFinal() As DateTime
        Get
            Return _FechaFinal
        End Get
        Set(ByVal value As DateTime)
            _FechaFinal = value
        End Set
    End Property
    Public Property FechaInicial() As DateTime
        Get
            Return _FechaInicial
        End Get
        Set(ByVal value As DateTime)
            _FechaInicial = value
        End Set
    End Property
    Public Property IdMovil() As Int32
        Get
            Return _IdMovil
        End Get
        Set(ByVal value As Int32)
            _IdMovil = value
        End Set
    End Property
    Public Property Periodo() As Int32
        Get
            Return _Periodo
        End Get
        Set(ByVal value As Int32)
            _Periodo = value
        End Set
    End Property
    Public Property Periodos() As Int32
        Get
            Return _Periodos
        End Get
        Set(ByVal value As Int32)
            _Periodos = value
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
    Public Property IdConcepto() As Int32
        Get
            Return _IdConcepto
        End Get
        Set(ByVal value As Int32)
            _IdConcepto = value
        End Set
    End Property
End Class
#End Region

Public Class RespuestaPagoInfoTaxi
    Private _mensaje As String
    Private _IdPago As Integer
    Private _EsProcesado As Boolean
    Private _Periodos As Int32
    Private _Valor As Decimal
    Private _Fecha As String

    Public Property Mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property
    Public Property IdPago() As Integer
        Get
            Return _IdPago
        End Get
        Set(ByVal value As Integer)
            _IdPago = value
        End Set
    End Property
    Public Property Periodos() As Int32
        Get
            Return _Periodos
        End Get
        Set(ByVal value As Int32)
            _Periodos = value
        End Set
    End Property
    Public Property EsProcesado() As Boolean
        Get
            Return _EsProcesado
        End Get
        Set(ByVal value As Boolean)
            _EsProcesado = value
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
    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property
End Class

Public Class RespuestaConsultaPrepago
    Inherits Disposable

    Private _MensajeError As String
    Private _SaldoActual As Decimal
    Private _TarjetaActiva As Boolean
    Private _ValorMinimo As Decimal
    Private _ValorMaximo As Decimal
    Private _NroTarjeta As String

    Public Property NroTarjeta() As String
        Get
            Return _NroTarjeta
        End Get
        Set(ByVal value As String)
            _NroTarjeta = value
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
    Public Property SaldoActual() As Decimal
        Get
            Return _SaldoActual
        End Get
        Set(ByVal value As Decimal)
            _SaldoActual = value
        End Set
    End Property
    Public Property TarjetaActiva() As Boolean
        Get
            Return _TarjetaActiva
        End Get
        Set(ByVal value As Boolean)
            _TarjetaActiva = value
        End Set
    End Property
    Public Property ValorMaximo() As Decimal
        Get
            Return _ValorMaximo
        End Get
        Set(ByVal value As Decimal)
            _ValorMaximo = value
        End Set
    End Property
    Public Property ValorMinimo() As Decimal
        Get
            Return _ValorMinimo
        End Get
        Set(ByVal value As Decimal)
            _ValorMinimo = value
        End Set
    End Property


End Class

Public Class VentaModificada
    Inherits Disposable

    Private _Recibo As Long
    Private _Prepagos As New List(Of MediosPagos)
    Private _Bonos As New List(Of MediosPagos)
    Private _Pagos As New List(Of MediosPagos)
    Private _numAutorizacionCheque As Long
    Private _placaCheque As String
    Private _Procesando As Boolean


    Public Property Procesando() As Boolean
        Get
            Return _Procesando
        End Get
        Set(ByVal value As Boolean)
            _Procesando = value
        End Set
    End Property

    Public Property numAutorizacionCheque() As Long
        Get
            Return _numAutorizacionCheque
        End Get
        Set(ByVal value As Long)
            _numAutorizacionCheque = value
        End Set
    End Property

    Public Property placaCheque() As String
        Get
            Return _placaCheque
        End Get
        Set(ByVal value As String)
            _placaCheque = value
        End Set
    End Property

    Public Property Recibo() As Long
        Get
            Return _Recibo
        End Get
        Set(ByVal value As Long)
            _Recibo = value
        End Set
    End Property

    Public Property Prepagos() As List(Of MediosPagos)
        Get
            Return _Prepagos
        End Get
        Set(ByVal value As List(Of MediosPagos))
            _Prepagos = value
        End Set
    End Property

    Public Property Pagos() As List(Of MediosPagos)
        Get
            Return _Pagos
        End Get
        Set(ByVal value As List(Of MediosPagos))
            _Pagos = value
        End Set
    End Property

    Public Property Bonos() As List(Of MediosPagos)
        Get
            Return _Bonos
        End Get
        Set(ByVal value As List(Of MediosPagos))
            _Bonos = value
        End Set
    End Property

    Public Sub GuardarPagoPrepago(ByVal idFormaPago As Short, ByVal nroConfirmacion As String, ByVal nroTarjeta As String, ByVal tipoLectura As Integer, ByVal valor As Double, ByVal saldo As Double)
        'If Prepagos.Contains(nroTarjeta) Then
        '    Dim Pay As MediosPagos = CType(Prepagos.Item(nroTarjeta), MediosPagos)
        '    Pay.Saldo = saldo
        '    Pay.Valor = Pay.Valor + valor
        'Else
        Dim Pay As New MediosPagos
        Pay.IdFormaPago = idFormaPago
        Pay.NroConfirmacion = nroConfirmacion
        Pay.NroTarjeta = nroTarjeta
        Pay.TipoLectura = tipoLectura
        Pay.Valor = valor
        Pay.Saldo = saldo
        Prepagos.Add(Pay)
        'End If
    End Sub

    Public Sub GuardarPrepago(ByVal pago As MediosPagos)
        'If Prepagos.Contains(pago.NroTarjeta) Then
        '    Dim Pay As MediosPagos = CType(Prepagos.Item(pago.NroTarjeta), MediosPagos)
        '    Pay.Saldo = pago.Saldo
        '    Pay.Valor = Pay.Valor + pago.Valor
        'Else
        Prepagos.Add(pago)
        'End If
    End Sub

    Public Sub GuardarBono(ByVal pago As MediosPagos)
        Bonos.Add(pago)
    End Sub


    Public Function ExisteBono(ByVal numeroBono As String) As Boolean

        For Each OBono As MediosPagos In Bonos
            If OBono.NroTarjeta = numeroBono Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub GuardarPagosGenerales(ByVal idFormaPago As Short, ByVal nroConfirmacion As String, ByVal nroTarjeta As String, ByVal tipoLectura As Integer, ByVal valor As Double)
        Dim Pay As New MediosPagos
        Pay.IdFormaPago = idFormaPago
        Pay.NroConfirmacion = nroConfirmacion
        Pay.NroTarjeta = nroTarjeta
        Pay.TipoLectura = tipoLectura
        Pay.Valor = valor
        Pagos.Add(Pay)
    End Sub

    Public Sub GuardarPagosGenerales(ByVal pay As MediosPagos)
        Pagos.Add(pay)
    End Sub

    Public Sub GuardarPagosBonos(ByVal idFormaPago As Short, ByVal nroConfirmacion As String, ByVal nroTarjeta As String, ByVal tipoLectura As Integer, ByVal valor As Double)
        Dim Pay As New MediosPagos
        Pay.IdFormaPago = idFormaPago
        Pay.NroConfirmacion = nroConfirmacion
        Pay.NroTarjeta = nroTarjeta
        Pay.TipoLectura = tipoLectura
        Pay.Valor = valor
        Bonos.Add(Pay)
    End Sub


    Public Function GetArrayPagosReversion() As Array
        Dim ArrayPagos As System.Array = Nothing

        ArrayPagos = System.Array.CreateInstance(GetType(String), 1)

        Return ArrayPagos
    End Function

    Public Function GetArrayPagos() As Array
        Dim ListaPagos As New System.Collections.ArrayList
        Dim ArrayPagos As System.Array = Nothing


        For Each prepago As MediosPagos In Prepagos
            Dim Datos As String
            Datos = prepago.IdFormaPago & "|" & prepago.NroTarjeta & "|" & prepago.Valor & "|" & prepago.Saldo & "|" & prepago.MensajeCDC
            ListaPagos.Add(Datos)
        Next

        For Each Bono As MediosPagos In Bonos
            Dim Datos As String
            Datos = Bono.IdFormaPago & "|" & Bono.NroTarjeta & "|" & Bono.Valor & "|" & "0"
            ListaPagos.Add(Datos)
        Next

        For Each PagoGeneral As MediosPagos In Me.Pagos
            Dim Datos As String
            'If PagoGeneral.IdFormaPago <> 4 Then
            Datos = PagoGeneral.IdFormaPago & "|" & PagoGeneral.NroTarjeta & "|" & PagoGeneral.Valor & "|" & "0"
            ListaPagos.Add(Datos)
            'End If
        Next

        If ListaPagos.Count > 0 Then
            ArrayPagos = System.Array.CreateInstance(GetType(String), ListaPagos.Count)
            ListaPagos.CopyTo(ArrayPagos)
        End If

        Return ArrayPagos
    End Function

    Public Function GetListMediosPago(ByVal idFormaPago As Short, ByVal nroConfirmacion As String, ByVal nroTarjeta As String, ByVal tipoLectura As Integer, ByVal valor As Double) As List(Of MediosPagos)
        Dim Pay As New MediosPagos
        Dim MediosDePagos As New List(Of MediosPagos)
        Pay.IdFormaPago = idFormaPago
        Pay.NroConfirmacion = nroConfirmacion
        Pay.NroTarjeta = nroTarjeta
        Pay.TipoLectura = tipoLectura
        Pay.Valor = valor
        MediosDePagos.Add(Pay)
        Return MediosDePagos
    End Function


End Class

Public Class RespuestaAbonoCDC

    Private _Procesado As Boolean
    Private _Resultado As String = ""

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property Resultado() As String
        Get
            Return _Resultado
        End Get
        Set(ByVal value As String)
            _Resultado = value
        End Set
    End Property

End Class

Public Class RespuestaSaldoCredito
    Inherits Disposable

    Private _MensajeError As String
    Private _NroCredito As String
    Private _Producto As String
    Private _ValorCuota As Decimal
    Private _PagoCuota As Decimal
    Private _MetaConsumo As Decimal
    Private _ConsumoActual As Decimal
    Private _IdCredito As Long
    Private _IdTipoCredito As Int32
    Private _SaldoVencido As Decimal
    Private _TotalPagar As Decimal
    Private _TotalGeneral As Decimal
    Private _ConsumoMesAnterior As Decimal

    Public Property IdTipoCredito() As Int32
        Get
            Return _IdTipoCredito
        End Get
        Set(ByVal value As Int32)
            _IdTipoCredito = value
        End Set
    End Property

    Public Property IdCredito() As Long
        Get
            Return _IdCredito
        End Get
        Set(ByVal value As Long)
            _IdCredito = value
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

    Public Property NroCredito() As String
        Get
            Return _NroCredito
        End Get
        Set(ByVal value As String)
            _NroCredito = value
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

    Public Property ValorCuota() As Decimal
        Get
            Return _ValorCuota
        End Get
        Set(ByVal value As Decimal)
            _ValorCuota = value
        End Set
    End Property

    Public Property PagoCuota() As Decimal
        Get
            Return _PagoCuota
        End Get
        Set(ByVal value As Decimal)
            _PagoCuota = value
        End Set
    End Property

    Public Property MetaConsumo() As Decimal
        Get
            Return _MetaConsumo
        End Get
        Set(ByVal value As Decimal)
            _MetaConsumo = value
        End Set
    End Property
    Public Property ConsumoActual() As Decimal
        Get
            Return _ConsumoActual
        End Get
        Set(ByVal value As Decimal)
            _ConsumoActual = value
        End Set
    End Property
    Public Property SaldoVencido() As Decimal
        Get
            Return _SaldoVencido
        End Get
        Set(ByVal value As Decimal)
            _SaldoVencido = value
        End Set
    End Property
    Public Property TotalPagar() As Decimal
        Get
            Return _TotalPagar
        End Get
        Set(ByVal value As Decimal)
            _TotalPagar = value
        End Set
    End Property
    Public Property TotalGeneral() As Decimal
        Get
            Return _TotalGeneral
        End Get
        Set(ByVal value As Decimal)
            _TotalGeneral = value
        End Set
    End Property
    Public Property ConsumoMesAnterior() As Decimal
        Get
            Return _ConsumoMesAnterior
        End Get
        Set(ByVal value As Decimal)
            _ConsumoMesAnterior = value
        End Set
    End Property
End Class

Public Class RespuestaUltimoPago
    Inherits Disposable

    Private _MensajeError As String
    Private _FechaPago As DateTime
    Private _ValorCancelado As Decimal

    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property

    Public Property FechaPago() As DateTime
        Get
            Return _FechaPago
        End Get
        Set(ByVal value As DateTime)
            _FechaPago = value
        End Set
    End Property

    Public Property ValorCancelado() As Decimal
        Get
            Return _ValorCancelado
        End Get
        Set(ByVal value As Decimal)
            _ValorCancelado = value
        End Set
    End Property
End Class

Public Class Credito
    Private _EsEfectivo As Boolean
    Private _Autorizacion As String
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
    Private _ValorPredeterminado As Decimal = 0
    Private _TipoIdentificacion As Factory.TipoIdentificacionCredito = TipoIdentificacionCredito.CHIP
    Private _TipoVehiculo As Int32
    Private _TipoManejo As TipoManejo
    Private _ImprimirDescuento As Boolean
    Private _NoContrato As String = ""
    Private _CodCentroCosto As String = ""
    Private _NombreCentroCosto As String = ""

    ''' <summary>
    ''' Número del contrato asociado al cliente en caso de ser crédito
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    Public Property TipoIdentificacion() As Factory.TipoIdentificacionCredito
        Get
            Return _TipoIdentificacion
        End Get
        Set(ByVal value As Factory.TipoIdentificacionCredito)
            _TipoIdentificacion = value
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
End Class

Public Class DatosVehiculoVenta
    Private _Placa As String
    Private _IdTipoVehiculo As Int32
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property
    Public Property IdTipoVehiculo() As Int32
        Get
            Return _IdTipoVehiculo
        End Get
        Set(ByVal value As Int32)
            _IdTipoVehiculo = value
        End Set
    End Property

End Class

Public Class FormaPagoVenta

    Private _IdFormaPago As Int32
    Private _Valor As Decimal
    Private _NumeroAutorizacion As String
    Private _Placa As String = Nothing
    Private _HoraInicio As Date = Now

    Public Property HoraInicio() As Date
        Get
            Return _HoraInicio
        End Get
        Set(ByVal value As Date)
            _HoraInicio = value
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

    Public Property NumeroAutorizacion() As String
        Get
            Return _NumeroAutorizacion
        End Get
        Set(ByVal value As String)
            _NumeroAutorizacion = value
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

    Public Property IdFormaPago() As Int32
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Int32)
            _IdFormaPago = value
        End Set
    End Property

End Class

Public Class ConsultaConcepto

    Private _placa As String
    Private _movil As Int32
    Private _url As String

    Public Property Placa() As String
        Get
            Return _placa
        End Get
        Set(ByVal value As String)
            _placa = value
        End Set
    End Property

    Public Property Movil() As Int32
        Get
            Return _movil
        End Get
        Set(ByVal value As Int32)
            _movil = value
        End Set
    End Property

    Public Property Url() As String
        Get
            Return _url

        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property


End Class

Public Class TarjetaFidelizacion
    Private _NumeroSeguridad As String
    Private _CodigoTarjeta As String
    Private _TipoLecturaTarjeta As Int32
    Private _EsGerenciamiento As Boolean
    Private _InformacionCampanas As RespuestaInfoCampañaCliente = Nothing
    Private _IdentificacionCliente As String
    Private _ClasificacionCliente As String
    Private _TipoFidelizacion As Int32
    Private _Cedula As String
    Private _MensajeDescuentoPromocional As String

    Public Property MensajeDescuentoPromocional() As String
        Get
            Return _MensajeDescuentoPromocional
        End Get
        Set(ByVal value As String)
            _MensajeDescuentoPromocional = value
        End Set
    End Property

    Public Property TipoFidelizacion() As Int32
        Get
            Return _TipoFidelizacion
        End Get
        Set(ByVal value As Int32)
            _TipoFidelizacion = value
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

    Public Property ClasificacionCliente() As String
        Get
            Return _ClasificacionCliente
        End Get
        Set(ByVal value As String)
            _ClasificacionCliente = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property

    Public Property InformacionCampanas() As RespuestaInfoCampañaCliente
        Get
            Return _InformacionCampanas
        End Get
        Set(ByVal value As RespuestaInfoCampañaCliente)
            _InformacionCampanas = value
        End Set
    End Property

    Public Property NumeroSeguridad() As String
        Get
            Return _NumeroSeguridad
        End Get
        Set(ByVal value As String)
            _NumeroSeguridad = value
        End Set
    End Property

    Public Property CodigoTarjeta() As String
        Get
            Return _CodigoTarjeta
        End Get
        Set(ByVal value As String)
            _CodigoTarjeta = value
        End Set
    End Property

    Public Property TipoLecturaTarjeta() As Int32
        Get
            Return _TipoLecturaTarjeta
        End Get
        Set(ByVal value As Int32)
            _TipoLecturaTarjeta = value
        End Set
    End Property
    Public Property EsGerenciamiento() As Boolean
        Get
            Return _EsGerenciamiento
        End Get
        Set(ByVal value As Boolean)
            _EsGerenciamiento = value
        End Set
    End Property

End Class

Public Class RespuestaCreditoConsumo
    Inherits Disposable

    Private _Respuesta As Boolean
    Private _Autorizacion As String
    Private _CupoMaximo As Decimal
    Private _FormaPago As Int16
    Private _Mensaje As String
    Private _CupoMaximoEnDinero As Decimal
    Private _CupoMaximoEnVolumen As Decimal
    Private _PrecioClienteGerenciado As Decimal
    Private _DescuentoValor As Decimal
    Private _DescuentoPorcentaje As Decimal
    Private _SaldoDisponible As Decimal
    Private _TipoManejo As TipoManejo
    Private _ImprimirDescuento As Boolean
    Private _NoContrato As String = ""
    Private _CodCentroCosto As String = ""
    Private _NombreCentroCosto As String = ""
    Private _Restricciones As RespuestaRestricciones

    ''' <summary>
    ''' Número del contrato asociado al cliente en caso de ser crédito
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    Public Property SaldoDisponible() As Decimal
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Decimal)
            _SaldoDisponible = value
        End Set
    End Property

    Public Property CupoMaximoEnDinero() As Decimal
        Get
            Return _CupoMaximoEnDinero
        End Get
        Set(ByVal value As Decimal)
            _CupoMaximoEnDinero = value
        End Set
    End Property
    Public Property CupoMaximoEnVolumen() As Decimal
        Get
            Return _CupoMaximoEnVolumen
        End Get
        Set(ByVal value As Decimal)
            _CupoMaximoEnVolumen = value
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
    Public Property DescuentoValor() As Decimal
        Get
            Return _DescuentoValor
        End Get
        Set(ByVal value As Decimal)
            _DescuentoValor = value
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

    Public Property PrecioClienteGerenciado() As Decimal
        Get
            Return _PrecioClienteGerenciado
        End Get
        Set(ByVal value As Decimal)
            _PrecioClienteGerenciado = value
        End Set
    End Property
    Public Property Respuesta() As Boolean
        Get
            Return _Respuesta
        End Get
        Set(ByVal value As Boolean)
            _Respuesta = value
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

    Public Property CupoMaximo() As Decimal
        Get
            Return _CupoMaximo
        End Get
        Set(ByVal value As Decimal)
            _CupoMaximo = value
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

    Public Property Restricciones() As RespuestaRestricciones
        Get
            Return _Restricciones
        End Get
        Set(ByVal value As RespuestaRestricciones)
            _Restricciones = value
        End Set
    End Property
End Class

Public Class RespuestaNroAutorizacion
    Inherits Disposable

    Private _Autorizado As Boolean
    Private _Mensaje As String
    Private _Placa As String

    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property Autorizado() As Boolean
        Get
            Return _Autorizado
        End Get
        Set(ByVal value As Boolean)
            _Autorizado = value
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
End Class

Public Class DuplicadoRedencion
    Inherits Disposable

    Private _IdRedencion As Int32
    Private _FechaRedencion As Date
    Private _FechaIni As Date
    Private _FechaFin As Date
    Private _Lugar As String
    Private _CodIsla As Int32
    Private _IdTurno As Int32
    Private _NumeroCelular As String



    Public Property IdRedencion() As Int32
        Get
            Return _IdRedencion
        End Get
        Set(ByVal value As Int32)
            _IdRedencion = value
        End Set
    End Property


    Public Property CodIsla() As Int32
        Get
            Return _CodIsla
        End Get
        Set(ByVal value As Int32)
            _CodIsla = value
        End Set
    End Property

    Public Property IdTurno() As Int32
        Get
            Return _IdTurno
        End Get
        Set(ByVal value As Int32)
            _IdTurno = value
        End Set
    End Property

    Public Property FechaRedencion() As Date
        Get
            Return _FechaRedencion
        End Get
        Set(ByVal value As Date)
            _FechaRedencion = value
        End Set
    End Property

    Public Property FechaIni() As Date
        Get
            Return _FechaIni
        End Get
        Set(ByVal value As Date)
            _FechaIni = value
        End Set
    End Property

    Public Property FechaFin() As Date
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As Date)
            _FechaFin = value
        End Set
    End Property

    Public Property Lugar() As String
        Get
            Return _Lugar
        End Get
        Set(ByVal value As String)
            _Lugar = value
        End Set
    End Property

    Public Property NumeroCelular() As String
        Get
            Return _NumeroCelular
        End Get
        Set(ByVal value As String)
            _NumeroCelular = value
        End Set
    End Property

End Class

Public Class RespuestaDuplicadoRedencion
    Inherits Disposable

    Private _Procesado As Boolean
    Private _IdentificacionCliente As String
    Private _NombreCliente As String
    Private _Mensaje As String
    Private _IdCampana As Int32
    Private _NombreCampana As String
    Private _IdPremio As Int32
    Private _NombrePremio As String
    Private _M3Redimidos As Decimal
    Private _Valor As Decimal
    Private _Tipo As String
    Private _NumeroCelular As String
    Private _Duplicados As New List(Of DuplicadoRedencion)



    Public Property Duplicados() As List(Of DuplicadoRedencion)
        Get
            Return _Duplicados
        End Get
        Set(ByVal value As List(Of DuplicadoRedencion))
            _Duplicados = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
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

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property IdCampana() As Int32
        Get
            Return _IdCampana
        End Get
        Set(ByVal value As Int32)
            _IdCampana = value
        End Set
    End Property

    Public Property NombreCampana() As String
        Get
            Return _NombreCampana
        End Get
        Set(ByVal value As String)
            _NombreCampana = value
        End Set
    End Property

    Public Property IdPremio() As Int32
        Get
            Return _IdPremio
        End Get
        Set(ByVal value As Int32)
            _IdPremio = value
        End Set
    End Property

    Public Property NombrePremio() As String
        Get
            Return _NombrePremio
        End Get
        Set(ByVal value As String)
            _NombrePremio = value
        End Set
    End Property

    Public Property M3Redimidos() As Decimal
        Get
            Return _M3Redimidos
        End Get
        Set(ByVal value As Decimal)
            _M3Redimidos = value
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

    Public Property NumeroCelular() As String
        Get
            Return _NumeroCelular
        End Get
        Set(ByVal value As String)
            _NumeroCelular = value
        End Set
    End Property

End Class

Public Class RespuestaCambiarNroCelular
    Inherits Disposable

    Private _Procesado As Boolean
    Private _Informacion As New List(Of String)
    Private _NumeroCelular As String

    'Alberto: Cambios hechos para el Cambio de Número de Celular GAZEL
    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property Informacion() As List(Of String)
        Get
            Return _Informacion
        End Get
        Set(ByVal value As List(Of String))
            _Informacion = value
        End Set
    End Property

    Public Property NumeroCelular() As String
        Get
            Return _NumeroCelular
        End Get
        Set(ByVal value As String)
            _NumeroCelular = value
        End Set
    End Property

End Class

Public Class RespuestaRedimirPremio
    Inherits Disposable

    Private _Procesado As Boolean
    Private _IdRedencion As Int32
    Private _IdentificacionCliente As String
    Private _NombreCliente As String
    Private _Mensaje As String
    Private _IdCampana As Int32
    Private _NombreCampana As String
    Private _IdPremio As Int32
    Private _NombrePremio As String
    Private _M3Redimidos As Decimal
    Private _Valor As Decimal
    Private _FechaRedencion As Date
    Private _FechaIni As Date
    Private _FechaFin As Date
    Private _Lugar As String
    Private _CodIsla As Int32
    Private _IdTurno As Int32
    Private _Tipo As String
    Private _NumeroCelular As String

    Public Property NumeroCelular() As String
        Get
            Return _NumeroCelular
        End Get
        Set(ByVal value As String)
            _NumeroCelular = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property CodIsla() As Int32
        Get
            Return _CodIsla
        End Get
        Set(ByVal value As Int32)
            _CodIsla = value
        End Set
    End Property

    Public Property IdTurno() As Int32
        Get
            Return _IdTurno
        End Get
        Set(ByVal value As Int32)
            _IdTurno = value
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

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property IdRedencion() As Int32
        Get
            Return _IdRedencion
        End Get
        Set(ByVal value As Int32)
            _IdRedencion = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property IdCampana() As Int32
        Get
            Return _IdCampana
        End Get
        Set(ByVal value As Int32)
            _IdCampana = value
        End Set
    End Property

    Public Property NombreCampana() As String
        Get
            Return _NombreCampana
        End Get
        Set(ByVal value As String)
            _NombreCampana = value
        End Set
    End Property

    Public Property IdPremio() As Int32
        Get
            Return _IdPremio
        End Get
        Set(ByVal value As Int32)
            _IdPremio = value
        End Set
    End Property

    Public Property NombrePremio() As String
        Get
            Return _NombrePremio
        End Get
        Set(ByVal value As String)
            _NombrePremio = value
        End Set
    End Property

    Public Property M3Redimidos() As Decimal
        Get
            Return _M3Redimidos
        End Get
        Set(ByVal value As Decimal)
            _M3Redimidos = value
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

    Public Property FechaRedencion() As Date
        Get
            Return _FechaRedencion
        End Get
        Set(ByVal value As Date)
            _FechaRedencion = value
        End Set
    End Property

    Public Property FechaIni() As Date
        Get
            Return _FechaIni
        End Get
        Set(ByVal value As Date)
            _FechaIni = value
        End Set
    End Property

    Public Property FechaFin() As Date
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As Date)
            _FechaFin = value
        End Set
    End Property

    Public Property Lugar() As String
        Get
            Return _Lugar
        End Get
        Set(ByVal value As String)
            _Lugar = value
        End Set
    End Property
End Class

Public Class RespuestaReclamarPremio
    Inherits Disposable

    Private _Procesado As Boolean
    Private _Mensaje As String
    Private _IdPremio As Int32
    Private _NombrePremio As String
    Private _NombreCliente As String
    Private _IdentificacionCliente As String
    Private _NombreEDS As String
    Private _Fecha As Date
    Private _CodIsla As Int32
    Private _IdTurnoEDS As Int32

    Public Property CodIsla() As Int32
        Get
            Return _CodIsla
        End Get
        Set(ByVal value As Int32)
            _CodIsla = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property

    Public Property IdTurnoEDS() As Int32
        Get
            Return _IdTurnoEDS
        End Get
        Set(ByVal value As Int32)
            _IdTurnoEDS = value
        End Set
    End Property

    Public Property NombreEDS() As String
        Get
            Return _NombreEDS
        End Get
        Set(ByVal value As String)
            _NombreEDS = value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
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

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property IdPremio() As Int32
        Get
            Return _IdPremio
        End Get
        Set(ByVal value As Int32)
            _IdPremio = value
        End Set
    End Property

    Public Property NombrePremio() As String
        Get
            Return _NombrePremio
        End Get
        Set(ByVal value As String)
            _NombrePremio = value
        End Set
    End Property
End Class

Public Class Campaña
    Inherits Disposable

    Private _IdCampaña As Int32
    Private _NombreCampaña As String
    Private _M3Acumulados As Decimal
    Private _Tipo As String

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property


    Public Property NombreCampaña() As String
        Get
            Return _NombreCampaña
        End Get
        Set(ByVal value As String)
            _NombreCampaña = value
        End Set
    End Property

    Public Property IdCampaña() As Int32
        Get
            Return _IdCampaña
        End Get
        Set(ByVal value As Int32)
            _IdCampaña = value
        End Set
    End Property

    Public Property M3Acumulados() As Decimal
        Get
            Return _M3Acumulados
        End Get
        Set(ByVal value As Decimal)
            _M3Acumulados = value
        End Set
    End Property

End Class

Public Class RespuestaConsultaConcepto

    Private _dtConConcepto As DataTable

    Public Property dtconconcepto() As DataTable
        Get
            Return _dtConConcepto
        End Get
        Set(ByVal value As DataTable)
            _dtConConcepto = value
        End Set
    End Property
End Class

Public Class RespuestaInfoCampañaCliente
    Inherits Disposable

    Private _Procesado As Boolean
    Private _Informacion As New List(Of String)
    Private _ImprimeNuevoTiquete As Boolean
    Private _NuevoTiquete As New List(Of String)

    'Alberto: Cambios hechos para la Información Solicitud de Campañas GAZEL
    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property Informacion() As List(Of String)
        Get
            Return _Informacion
        End Get
        Set(ByVal value As List(Of String))
            _Informacion = value
        End Set
    End Property

    Public Property ImprimeNuevoTiquete() As Boolean
        Get
            Return _ImprimeNuevoTiquete
        End Get
        Set(ByVal value As Boolean)
            _ImprimeNuevoTiquete = value
        End Set
    End Property

    Public Property NuevoTiquete() As List(Of String)
        Get
            Return _NuevoTiquete
        End Get
        Set(ByVal value As List(Of String))
            _NuevoTiquete = value
        End Set
    End Property

End Class

Public Class RespuestaConsutarBono
    Private _IdBono As Integer
    Private _NroBono As Decimal
    Private _ValorBono As Decimal
    Private _FechaVencimiento As String
    Private _Activo As Boolean
    Private _TipoBono As String
    Private _BonoYaUtiliado As Boolean
    Private _Reservado As Boolean

    Public Property IdBono() As Integer
        Get
            Return _IdBono
        End Get
        Set(ByVal value As Integer)
            _IdBono = value
        End Set
    End Property
    Public Property NroBono() As Decimal
        Get
            Return _NroBono
        End Get
        Set(ByVal value As Decimal)
            _NroBono = value
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

    Public Property FechaVencimiento() As String
        Get
            Return _FechaVencimiento
        End Get
        Set(ByVal value As String)
            _FechaVencimiento = value
        End Set
    End Property
    Public Property Activo() As Boolean
        Get
            Return _Activo
        End Get
        Set(ByVal value As Boolean)
            _Activo = value
        End Set
    End Property
    Public Property TipoBono() As String
        Get
            Return _TipoBono
        End Get
        Set(ByVal value As String)
            _TipoBono = value
        End Set
    End Property
    Public Property BonoYaUtiliado() As Boolean
        Get
            Return _BonoYaUtiliado
        End Get
        Set(ByVal value As Boolean)
            _BonoYaUtiliado = value
        End Set
    End Property
    Public Property Reservado() As Boolean
        Get
            Return _Reservado
        End Get
        Set(ByVal value As Boolean)
            _Reservado = value
        End Set
    End Property
End Class

Public Class RespuestaValidarCredenciales
    Private _Mensaje As String
    Private _Autorizado As Boolean
    Private _MotivosCalibracion As List(Of MotivoCalibracion)
    Private _EsEmpleadoAdministrador As Boolean

    Public Sub New()
    End Sub

    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property Autorizado() As Boolean
        Get
            Return _Autorizado
        End Get
        Set(ByVal value As Boolean)
            _Autorizado = value
        End Set
    End Property
    Public Property MotivosCalibracion() As List(Of MotivoCalibracion)
        Get
            Return _MotivosCalibracion
        End Get
        Set(ByVal value As List(Of MotivoCalibracion))
            _MotivosCalibracion = value
        End Set
    End Property
    Public Property EsEmpleadoAdministrador() As Boolean
        Get
            Return _EsEmpleadoAdministrador
        End Get
        Set(ByVal value As Boolean)
            _EsEmpleadoAdministrador = value
        End Set
    End Property
End Class

Public Class MotivoCalibracion
    Private _IdMotivo As Int32
    Private _DescripcionCorta As String
    Public Property DescripcionCorta() As String
        Get
            Return _DescripcionCorta
        End Get
        Set(ByVal value As String)
            _DescripcionCorta = value
        End Set
    End Property
    Public Property IdMotivo() As Int32
        Get
            Return _IdMotivo
        End Get
        Set(ByVal value As Int32)
            _IdMotivo = value
        End Set
    End Property
End Class

Public Class Consumo
    Private _IdManguera As Int16
    Private _IdMotivoCalibracion As Int32
    Private _TipoConsumo As Factory.TipoConsumo
    Public Property IdManguera() As Int16
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Int16)
            _IdManguera = value
        End Set
    End Property
    Public Property IdMotivoCalibracion() As Int32
        Get
            Return _IdMotivoCalibracion
        End Get
        Set(ByVal value As Int32)
            _IdMotivoCalibracion = value
        End Set
    End Property
    Public Property TipoConsumo() As Factory.TipoConsumo
        Get
            Return _TipoConsumo
        End Get
        Set(ByVal value As Factory.TipoConsumo)
            _TipoConsumo = value
        End Set
    End Property

End Class

Public Class MediosLectura
    Private _Cara As Byte
    Private _NumeroTarjeta As String
    Private _TipoLectura As Byte
    Private _NroSeguridad As String
    Private _NroAutorizacionManual As String
    Private _TipoIdentificacion As Short

    Public Property Cara() As Byte
        Get
            Return _Cara
        End Get
        Set(ByVal value As Byte)
            _Cara = value
        End Set
    End Property

    Public Property NumeroTarjeta() As String
        Get
            Return _NumeroTarjeta
        End Get
        Set(ByVal value As String)
            _NumeroTarjeta = value
        End Set
    End Property

    Public Property TipoLectura() As Byte
        Get
            Return _TipoLectura
        End Get
        Set(ByVal value As Byte)
            _TipoLectura = value
        End Set
    End Property

    Public Property NroSeguridad() As String
        Get
            Return _NroSeguridad
        End Get
        Set(ByVal value As String)
            _NroSeguridad = value
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

    Public Property TipoIdentificacion() As Short
        Get
            Return _TipoIdentificacion
        End Get
        Set(ByVal value As Short)
            _TipoIdentificacion = value
        End Set
    End Property
End Class

Public Class AutorizacionCheque
    Private _NoAutorizacion As Integer
    Private _NoCheque As Integer
    Private _Valor As Decimal
    Private _CodBanco As Integer
    Private _IdFinanciera As Integer
    Private _ValorSuministro As Decimal
    Private _ValorCambio As Decimal
    Private _IdCliente As Integer
    Private _NoAutorizacionAval As Integer
    Private _CodEstacion As String
    Private _IdIslero As String
    Private _IdEstacion As Integer

    Public Property NoAutorizacion() As Integer
        Get
            Return _NoAutorizacion
        End Get
        Set(ByVal value As Integer)
            _NoAutorizacion = value
        End Set
    End Property

    Public Property NoCheque() As Integer
        Get
            Return _NoCheque
        End Get
        Set(ByVal value As Integer)
            _NoCheque = value
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

    Public Property CodBanco() As Integer
        Get
            Return _CodBanco
        End Get
        Set(ByVal value As Integer)
            _CodBanco = value
        End Set
    End Property

    Public Property IdFinanciera() As Integer
        Get
            Return _IdFinanciera
        End Get
        Set(ByVal value As Integer)
            _IdFinanciera = value
        End Set
    End Property

    Public Property ValorSuministro() As Decimal
        Get
            Return _ValorSuministro
        End Get
        Set(ByVal value As Decimal)
            _ValorSuministro = value
        End Set
    End Property

    Public Property ValorCambio() As Decimal
        Get
            Return _ValorCambio
        End Get
        Set(ByVal value As Decimal)
            _ValorCambio = value
        End Set
    End Property

    Public Property IdCliente() As Integer
        Get
            Return _IdCliente
        End Get
        Set(ByVal value As Integer)
            _IdCliente = value
        End Set
    End Property

    Public Property NoAutorizacionAval() As Integer
        Get
            Return _NoAutorizacionAval
        End Get
        Set(ByVal value As Integer)
            _NoAutorizacionAval = value
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

    Public Property IdIslero() As String
        Get
            Return _IdIslero
        End Get
        Set(ByVal value As String)
            _IdIslero = value
        End Set
    End Property

    Public Property IdEstacion() As Integer
        Get
            Return _IdEstacion
        End Get
        Set(ByVal value As Integer)
            _IdEstacion = value
        End Set
    End Property
End Class

Public Class RespuestaValidacionDescuentoPromocional

#Region "   Declaracion de Variables    "

    Private _Procesado As Boolean = False
    Private _Mensaje As String = ""
    Private _Esporcentual As Boolean = False
    Private _ValorDescuento As Decimal = 0

#End Region

#Region "   Constructores   "

    Public Sub New()
        _Procesado = False
        _Mensaje = ""
        _Esporcentual = False
        _ValorDescuento = 0
    End Sub

#End Region

#Region "   Declaracion de Propiedades  "

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
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

    Public Property Esporcentual() As Boolean
        Get
            Return _Esporcentual
        End Get
        Set(ByVal value As Boolean)
            _Esporcentual = value
        End Set
    End Property

    Public Property ValorDescuento() As Decimal
        Get
            Return _ValorDescuento
        End Get
        Set(ByVal value As Decimal)
            _ValorDescuento = value
        End Set
    End Property

#End Region

End Class