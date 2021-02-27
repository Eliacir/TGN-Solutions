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

Public Class CanjePGN
    Inherits Disposable

    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String
    Private CodeCanje_ As String
    Private CodeTarjeta_ As String
    Private mensaje_ As String
    Private premio_ As String
    Private esPrevioVale_ As String
    Private CodeEstacion_ As String
    Private cantidad_ As String
    Private precioReferencial_ As String
    Private puntos_ As String
    Private puntosTotales_ As String
    Private precioTotal_ As String
    Private precioTotalPagar_ As String
    Private efectivo_ As String
    Private procesoOK_ As Boolean
    Private autorizacion_ As String
    Private serialImpresora_ As String
    Private fecha_ As String
    Private consecutivo_ As String
    Private cliente_ As String
    Private hora_ As String

    


    Public Property hora() As String
        Get
            Return hora_
        End Get
        Set(ByVal value As String)
            hora_ = value
        End Set
    End Property


    Public Property cliente() As String
        Get
            Return cliente_
        End Get
        Set(ByVal value As String)
            cliente_ = value
        End Set
    End Property


    Public Property consecutivo() As String
        Get
            Return consecutivo_
        End Get
        Set(ByVal value As String)
            consecutivo_ = value
        End Set
    End Property


    Public Property fecha() As String
        Get
            Return fecha_
        End Get
        Set(ByVal value As String)
            fecha_ = value
        End Set
    End Property



    Public Property serialImpresora() As String
        Get
            Return serialImpresora_
        End Get
        Set(ByVal value As String)
            serialImpresora_ = value
        End Set
    End Property


    Public Property autorizacion() As String
        Get
            Return autorizacion_
        End Get
        Set(ByVal value As String)
            autorizacion_ = value
        End Set
    End Property


    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property procesoOk() As Boolean
        Get
            Return procesoOK_
        End Get
        Set(ByVal value As Boolean)
            procesoOK_ = value
        End Set
    End Property


    Public Property efectivo() As String
        Get
            Return efectivo_
        End Get
        Set(ByVal value As String)
            efectivo_ = value
        End Set
    End Property



    Public Property precioTotalPagar() As String
        Get
            Return precioTotalPagar_
        End Get
        Set(ByVal value As String)
            precioTotalPagar_ = value
        End Set
    End Property


    Public Property precioTotal() As String
        Get
            Return precioTotal_
        End Get
        Set(ByVal value As String)
            precioTotal_ = value
        End Set
    End Property


    Public Property puntosTotales() As String
        Get
            Return puntosTotales_
        End Get
        Set(ByVal value As String)
            puntosTotales_ = value
        End Set
    End Property


    Public Property puntos() As String
        Get
            Return puntos_
        End Get
        Set(ByVal value As String)
            puntos_ = value
        End Set
    End Property


    Public Property precioReferencial() As String
        Get
            Return precioReferencial_
        End Get
        Set(ByVal value As String)
            precioReferencial_ = value
        End Set
    End Property

    Public Property cantidad() As String
        Get
            Return cantidad_
        End Get
        Set(ByVal value As String)
            cantidad_ = value
        End Set
    End Property


    Public Property CodeEstacion() As String
        Get
            Return CodeEstacion_
        End Get
        Set(ByVal value As String)
            CodeEstacion_ = value
        End Set
    End Property


    Public Property esPrevioVale() As String
        Get
            Return esPrevioVale_
        End Get
        Set(ByVal value As String)
            esPrevioVale_ = value
        End Set
    End Property


    Public Property premio() As String
        Get
            Return premio_
        End Get
        Set(ByVal value As String)
            premio_ = value
        End Set
    End Property


    Public Property mensaje() As String
        Get
            Return mensaje_
        End Get
        Set(ByVal value As String)
            mensaje_ = value
        End Set
    End Property


    Public Property Codetarjeta() As String
        Get
            Return CodeTarjeta_
        End Get
        Set(ByVal value As String)
            CodeTarjeta_ = value
        End Set
    End Property

    Public Property CodeCanje() As String
        Get
            Return CodeCanje_
        End Get
        Set(ByVal value As String)
            CodeCanje_ = value
        End Set
    End Property

End Class

Public Class ConfirmacionCanjePGN

    Private CodeCanje_ As String
    Private procesoOK_ As String
    Private mensaje_ As String
    Private CodeEstacion_ As String

    Public Property CodeEstacion() As String
        Get
            Return CodeEstacion_
        End Get
        Set(ByVal value As String)
            CodeEstacion_ = value
        End Set
    End Property


    Public Property mensaje() As String
        Get
            Return mensaje_
        End Get
        Set(ByVal value As String)
            mensaje_ = value
        End Set
    End Property


    Public Property procesoOK() As String
        Get
            Return procesoOK_
        End Get
        Set(ByVal value As String)
            procesoOK_ = value
        End Set
    End Property


    Public Property CodeCanje() As String
        Get
            Return CodeCanje_
        End Get
        Set(ByVal value As String)
            CodeCanje_ = value
        End Set
    End Property

End Class



Public Class DespachoValePGN

    Private CodeDespacho_ As String
    Private procesoOK_ As String
    Private mensaje_ As String
    Private CodeEstacion_ As String
    Private CodeTarjeta_ As String


    Public Property CodeTarjeta() As String
        Get
            Return CodeTarjeta_
        End Get
        Set(ByVal value As String)
            CodeTarjeta_ = value
        End Set
    End Property


    Public Property CodeEstacion() As String
        Get
            Return CodeEstacion_
        End Get
        Set(ByVal value As String)
            CodeEstacion_ = value
        End Set
    End Property


    Public Property mensaje() As String
        Get
            Return mensaje_
        End Get
        Set(ByVal value As String)
            mensaje_ = value
        End Set
    End Property


    Public Property procesoOK() As String
        Get
            Return procesoOK_
        End Get
        Set(ByVal value As String)
            procesoOK_ = value
        End Set
    End Property


    Public Property CodeDespacho() As String
        Get
            Return CodeDespacho_
        End Get
        Set(ByVal value As String)
            CodeDespacho_ = value
        End Set
    End Property

End Class


Public Class SolicitudSincronizacionPGN
    Inherits Disposable

    Private _EsAutorizado As Boolean = False
    Private _AutosAlta As String = ""
    Private _AutosBaja As String = ""
    Private _MensajeError As String = ""
    Private _FechaSincronizacion As DateTime
    Private _FechaMaximaSincronizacion As DateTime
    Private _ChecksumAlta As String = ""
    Private _ChecksumBaja As String = ""

    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    Public Property AutosAlta() As String
        Get
            Return _AutosAlta
        End Get
        Set(ByVal value As String)
            _AutosAlta = value
        End Set
    End Property

    Public Property AutosBaja() As String
        Get
            Return _AutosBaja
        End Get
        Set(ByVal value As String)
            _AutosBaja = value
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

    Public Property ChecksumAlta() As String
        Get
            Return _ChecksumAlta
        End Get
        Set(ByVal value As String)
            _ChecksumAlta = value
        End Set
    End Property

    Public Property ChecksumBaja() As String
        Get
            Return _ChecksumBaja
        End Get
        Set(ByVal value As String)
            _ChecksumBaja = value
        End Set
    End Property

    Public Property FechaSincronizacion() As DateTime
        Get
            Return _FechaSincronizacion
        End Get
        Set(ByVal value As DateTime)
            _FechaSincronizacion = value
        End Set
    End Property

    Public Property FechaMaximaSincronizacion() As DateTime
        Get
            Return _FechaMaximaSincronizacion
        End Get
        Set(ByVal value As DateTime)
            _FechaMaximaSincronizacion = value
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


Public Class SolicitudValidacionPgn

    Private _CodigoSolicitud As String
    Public Property CodigoSolicitud() As String
        Get
            Return _CodigoSolicitud
        End Get
        Set(ByVal value As String)
            _CodigoSolicitud = value
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




    Private _ProcesoOk As String
    Public Property ProcesoOk() As String
        Get
            Return _ProcesoOk
        End Get
        Set(ByVal value As String)
            _ProcesoOk = value
        End Set
    End Property


    Private _Mensaje As String
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property


    Private _Serie As String
    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal value As String)
            _Serie = value
        End Set
    End Property


    Private _Numero As String
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property



    Private _Recibo As String
    Public Property Recibo() As String
        Get
            Return _Recibo
        End Get
        Set(ByVal value As String)
            _Recibo = value
        End Set
    End Property


    Private _TipoDocumento As String
    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As String)
            _TipoDocumento = value
        End Set
    End Property


    Private _TarjetaCliente As String
    Public Property TarjetaCliente() As String
        Get
            Return _TarjetaCliente
        End Get
        Set(ByVal value As String)
            _TarjetaCliente = value
        End Set
    End Property



    Private _TarjetaEmpresa As String
    Public Property TarjetaEmpresa() As String
        Get
            Return _TarjetaEmpresa
        End Get
        Set(ByVal value As String)
            _TarjetaEmpresa = value
        End Set
    End Property



    Private _Ruc As String
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property


    Private _ValePromocionConsumo As String
    Public Property ValePromocionConsumo() As String
        Get
            Return _ValePromocionConsumo
        End Get
        Set(ByVal value As String)
            _ValePromocionConsumo = value
        End Set
    End Property


    Private _ValeCredito As String
    Public Property ValeCredito() As String
        Get
            Return _ValeCredito
        End Get
        Set(ByVal value As String)
            _ValeCredito = value
        End Set
    End Property


    Private _TipoError As Boolean
    Public Property FallaEnComunicacion() As Boolean
        Get
            Return _TipoError
        End Get
        Set(ByVal value As Boolean)
            _TipoError = value
        End Set
    End Property

End Class



Public Class RespuestaConsultaPagosPGN


    Private _MensajeError As String
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


    Private _CodigoMaqRegistradora As String
    Public Property CodigoMaqRegistradora() As String
        Get
            Return _CodigoMaqRegistradora
        End Get
        Set(ByVal value As String)
            _CodigoMaqRegistradora = value
        End Set
    End Property


    Private _FechaFin As String
    Public Property FechaFin() As String
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As String)
            _FechaFin = value
        End Set
    End Property


    Private _FechaInicio As String
    Public Property FechaInicio() As String
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As String)
            _FechaInicio = value
        End Set
    End Property



    Private _FechaTransaccion As String
    Public Property FechaTransaccion() As String
        Get
            Return _FechaTransaccion
        End Get
        Set(ByVal value As String)
            _FechaTransaccion = value
        End Set
    End Property

    Private _HoraTransaccion As String
    Public Property HoraTransaccion() As String
        Get
            Return _HoraTransaccion
        End Get
        Set(ByVal value As String)
            _HoraTransaccion = value
        End Set
    End Property


    Private _Placa As String
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property


    Private _RazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property

    Private _Total As Nullable(Of Decimal)
    Public Property Total() As Nullable(Of Decimal)
        Get
            Return _Total
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _Total = value
        End Set
    End Property


    Private _TotalEspecifico As Boolean
    Public Property TotalEspecifico() As Boolean
        Get
            Return _TotalEspecifico
        End Get
        Set(ByVal value As Boolean)
            _TotalEspecifico = value
        End Set
    End Property


    Private _ListaDetalle As New List(Of DetalleConsultaPagoPgn)
    Public Property ListaDetalle() As List(Of DetalleConsultaPagoPgn)
        Get
            Return _ListaDetalle
        End Get
        Set(ByVal value As List(Of DetalleConsultaPagoPgn))
            _ListaDetalle = value
        End Set
    End Property


    Public Sub AgregarItemPago(ByVal Valor As DetalleConsultaPagoPgn)
        Try

            If _ListaDetalle Is Nothing Then
                _ListaDetalle = New List(Of DetalleConsultaPagoPgn)
            End If
            ListaDetalle.Add(Valor)
        Catch ex As System.Exception
            Throw
        End Try
    End Sub



End Class

Public Class DetalleConsultaPagoPgn

    Private _Concepto As String
    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal value As String)
            _Concepto = value
        End Set
    End Property


    Private _FechaPago As String
    Public Property FechaPago() As String
        Get
            Return _FechaPago
        End Get
        Set(ByVal value As String)
            _FechaPago = value
        End Set
    End Property


    Private _Monto As Nullable(Of Decimal)
    Public Property Monto() As Nullable(Of Decimal)
        Get
            Return _Monto
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _Monto = value
        End Set
    End Property


    Private _MontoEspeficoDetalle As Boolean
    Public Property MontoEspecificoDetalle() As Boolean
        Get
            Return _MontoEspeficoDetalle
        End Get
        Set(ByVal value As Boolean)
            _MontoEspeficoDetalle = value
        End Set
    End Property




End Class