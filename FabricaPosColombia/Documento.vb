Public Class Documento
    Private _TipoDocumento As TipoDocumentoPeru = TipoDocumentoPeru.Boleta
    Private _Valor As Decimal
    Private _Numero As String = ""
    Private _FormaPago As Short = 4
    Private _NroVale As String
    Private _MontoValePromocional As Decimal
    Private _NombrePromocion As String
    Private _Identificacion As String = ""
    Private _IdentificacionAux As String = ""
    Private _TipoIdentificacion As IdentificacionCredito
    Private _Franquicia As String
    Private _esFacturaGrande As Boolean
    Private _EsPrepago As Boolean

    Private _Saldo As Decimal
    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
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

    Private _NroConfirmacion As String
    Public Property NroConfirmacion() As String
        Get
            Return _NroConfirmacion
        End Get
        Set(ByVal value As String)
            _NroConfirmacion = value
        End Set
    End Property


    Public Property esFacturaGrande() As Boolean
        Get
            Return _esFacturaGrande
        End Get
        Set(ByVal value As Boolean)
            _esFacturaGrande = value
        End Set
    End Property


    Public Property Franquicia() As String
        Get
            Return _Franquicia
        End Get
        Set(ByVal value As String)
            _Franquicia = value
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

    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal value As String)
            _Identificacion = value
        End Set
    End Property


    Public Property IdentificacionAux() As String
        Get
            Return _IdentificacionAux
        End Get
        Set(ByVal value As String)
            _IdentificacionAux = value
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


    Public Property NombrePromocion() As String
        Get
            Return _NombrePromocion
        End Get
        Set(ByVal value As String)
            _NombrePromocion = value
        End Set
    End Property

    Public Property MontoValePromocional() As Decimal
        Get
            Return _MontoValePromocional
        End Get
        Set(ByVal value As Decimal)
            _MontoValePromocional = value
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

    Public Property TipoDocumento() As TipoDocumentoPeru
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As TipoDocumentoPeru)
            _TipoDocumento = value
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

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
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





End Class


Public Class DocumentoCanastillaPeru

    Private _Franquicia As String
    Public Property Franquicia() As String
        Get
            Return _Franquicia
        End Get
        Set(ByVal value As String)
            _Franquicia = value
        End Set
    End Property


    Private _Voucher As String
    Public Property Voucher() As String
        Get
            Return _Voucher
        End Get
        Set(ByVal value As String)
            _Voucher = value
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


    Private _FormaPago As Int32
    Public Property FormaPago() As Int32
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As Int32)
            _FormaPago = value
        End Set
    End Property


    Private _TipoDocumento As Int32
    Public Property TipoDocumento() As Int32
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As Int32)
            _TipoDocumento = value
        End Set
    End Property



End Class

Public Class DocumentoBolivia
    Private _TipoDocumento As TipoDocumentoPeru = TipoDocumentoPeru.Factura
    Private _Valor As Decimal
    Private _Numero As String = ""
    Private _FormaPago As Short = 4
    Private _NroVale As String
    Private _MontoValePromocional As Decimal
    Private _NombrePromocion As String
    Private _Identificacion As String = ""
    Private _IdentificacionAux As String = ""
    Private _TipoIdentificacion As IdentificacionCredito
    Private _Franquicia As String

    Private _TipoEnvase As String = "-1"
    Public Property TipoEnvase() As String
        Get
            Return _TipoEnvase
        End Get
        Set(ByVal value As String)
            _TipoEnvase = value
        End Set
    End Property


    Private _Autorizacion As String = "-1"
    Public Property Autorizacion() As String
        Get
            Return _Autorizacion
        End Get
        Set(ByVal value As String)
            _Autorizacion = value
        End Set
    End Property




    Private _NumeroPlaca As String
    Public Property NumeroPlaca() As String
        Get
            Return _NumeroPlaca
        End Get
        Set(ByVal value As String)
            _NumeroPlaca = value
        End Set
    End Property


    Private _Pais As String
    Public Property Pais() As String
        Get
            Return _Pais
        End Get
        Set(ByVal value As String)
            _Pais = value
        End Set
    End Property


    Private _NombreCliente As String
    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property


    Public Property Franquicia() As String
        Get
            Return _Franquicia
        End Get
        Set(ByVal value As String)
            _Franquicia = value
        End Set
    End Property


    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal value As String)
            _Identificacion = value
        End Set
    End Property


    Public Property IdentificacionAux() As String
        Get
            Return _IdentificacionAux
        End Get
        Set(ByVal value As String)
            _IdentificacionAux = value
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


    Public Property NombrePromocion() As String
        Get
            Return _NombrePromocion
        End Get
        Set(ByVal value As String)
            _NombrePromocion = value
        End Set
    End Property

    Public Property MontoValePromocional() As Decimal
        Get
            Return _MontoValePromocional
        End Get
        Set(ByVal value As Decimal)
            _MontoValePromocional = value
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

    Public Property TipoDocumento() As TipoDocumentoPeru
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As TipoDocumentoPeru)
            _TipoDocumento = value
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

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
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
End Class

Public Class RespuestaBonoFidelizacion
 
    Private _BonoFidelizacion As List(Of BonosFidelizacion)
    Private _MensajeError As String = String.Empty


    Public Property BonoFidelizacion() As List(Of BonosFidelizacion)
        Get
            Return _BonoFidelizacion
        End Get
        Set(ByVal value As List(Of BonosFidelizacion))
            _BonoFidelizacion = value
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

Public Class BonosFidelizacion
    Private _IdPremio As Long
    Private _Nombre As String
    Private _Tipo As String
    Private _Puntos As Decimal
    Private _Valor As Decimal
    Private _MensajeError As String = String.Empty

    Public Property IdPremio() As Long
        Get
            Return _IdPremio
        End Get
        Set(ByVal value As Long)
            _IdPremio = value
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

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Puntos() As Decimal
        Get
            Return _Puntos
        End Get
        Set(ByVal value As Decimal)
            _Puntos = value
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


    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property

End Class


Public Class Fidelizacion
    Private _Tarjeta As String
    Private _RedFidelizacion As Short
    Private _Saldos As DataSet = Nothing
    Private _MensajeError As String = String.Empty
    Private _MensajesCliente As DataSet = Nothing
    Private _MensajeFidelizacionPGN As String = String.Empty
    Private _FidelizarVenta As Boolean = True
    Private _NroConductor As String

    Public Property MensajeFidelizacionPGN() As String
        Get
            Return _MensajeFidelizacionPGN
        End Get
        Set(ByVal value As String)
            _MensajeFidelizacionPGN = value
        End Set
    End Property
    Public Property MensajesCliente() As DataSet
        Get
            Return _MensajesCliente
        End Get
        Set(ByVal value As DataSet)
            _MensajesCliente = value
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

    Public Property Tarjeta() As String
        Get
            Return _Tarjeta
        End Get
        Set(ByVal value As String)
            _Tarjeta = value
        End Set
    End Property

    Public Property RedFidelizacion() As Short
        Get
            Return _RedFidelizacion
        End Get
        Set(ByVal value As Short)
            _RedFidelizacion = value
        End Set
    End Property
    Public Property Saldos() As DataSet
        Get
            Return _Saldos
        End Get
        Set(ByVal value As DataSet)
            _Saldos = value
        End Set
    End Property

    Public Property FidelizarVenta() As Boolean
        Get
            Return _FidelizarVenta
        End Get
        Set(ByVal value As Boolean)
            _FidelizarVenta = value
        End Set
    End Property

    Public Property NroConductor() As String
        Get
            Return _NroConductor
        End Get
        Set(ByVal value As String)
            _NroConductor = value
        End Set
    End Property

End Class

Public Class RespuestaPagarVentaConBono
    Private _Autorizado As Boolean
    Public Property Autorizado() As Boolean
        Get
            Return _Autorizado
        End Get
        Set(ByVal value As Boolean)
            _Autorizado = value
        End Set
    End Property

    Private _MensajeError As String
    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property
End Class

Public Class DTOVenta

    Private _Recibo As String
    Public Property Recibo() As String
        Get
            Return _Recibo
        End Get
        Set(ByVal value As String)
            _Recibo = value
        End Set
    End Property

    Private _Fecha As String
    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Private _Precio As String
    Public Property Precio() As String
        Get
            Return _Precio
        End Get
        Set(ByVal value As String)
            _Precio = value
        End Set
    End Property

    Private _Cantidad As String
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property

    Private _Valor As String
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
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

    Private _Manguera As String
    Public Property Manguera() As String
        Get
            Return _Manguera
        End Get
        Set(ByVal value As String)
            _Manguera = value
        End Set
    End Property

    Private _Producto As String
    Public Property Producto() As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
        End Set
    End Property

    Private _Descuento As String
    Public Property Descuento() As String
        Get
            Return _Descuento
        End Get
        Set(ByVal value As String)
            _Descuento = value
        End Set
    End Property

    Private _EsFidelizada As Boolean
    Public Property EsFidelizada() As Boolean
        Get
            Return _EsFidelizada
        End Get
        Set(ByVal value As Boolean)
            _EsFidelizada = value
        End Set
    End Property

    Private _EsFidelizadaLocal As Boolean
    Public Property EsFidelizadaLocal() As Boolean
        Get
            Return _EsFidelizadaLocal
        End Get
        Set(ByVal value As Boolean)
            _EsFidelizadaLocal = value
        End Set
    End Property

    Private _FechaProximoMantenimiento As String
    Public Property FechaProximoMantenimiento() As String
        Get
            Return _FechaProximoMantenimiento
        End Get
        Set(ByVal value As String)
            _FechaProximoMantenimiento = value
        End Set
    End Property

End Class

Public Class DocumentoChile
    Private _TipoDocumento As TipoDocumentoChile = TipoDocumentoChile.Boleta

    Public Property TipoDocumento() As TipoDocumentoChile
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As TipoDocumentoChile)
            _TipoDocumento = value
        End Set
    End Property

    Private _TipoCombustible As TipoCombustibleChile = TipoCombustibleChile.Propio
    Public Property TipoCombustible() As TipoCombustibleChile
        Get
            Return _TipoCombustible
        End Get
        Set(ByVal value As TipoCombustibleChile)
            _TipoCombustible = value
        End Set
    End Property


    Private _NumeroDocumento As String = ""
    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(ByVal value As String)
            _NumeroDocumento = value
        End Set
    End Property

    Private _Cantidad As Decimal = 0
    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Private _Ruc As String = ""
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Private _RazonSocial As String = ""
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property

    Private _Direccion As String = ""
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Private _Profesion As String = ""
    Public Property Giro() As String
        Get
            Return _Profesion
        End Get
        Set(ByVal value As String)
            _Profesion = value
        End Set
    End Property

    Private _Placa As String = ""
    Public Property Patente() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Private _Kilometraje As Int32 = 0
    Public Property Kilometraje() As Int32
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As Int32)
            _Kilometraje = value
        End Set
    End Property
End Class

Public Class VentaStorage

    Private _NumeroDocumento As String = String.Empty
    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(ByVal value As String)
            _NumeroDocumento = value
        End Set
    End Property

    Private _Ruc As String = ""
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property


    Private _Placa As String = String.Empty
    Public Property Patente() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

End Class


Public Class DocumentoConductor
    Private _Placa As String
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property


    Private _Identificacion As String
    Public Property Identificacion() As String
        Get
            Return _Identificacion
        End Get
        Set(ByVal value As String)
            _Identificacion = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Pais As String
    Public Property Pais() As String
        Get
            Return _Pais
        End Get
        Set(ByVal value As String)
            _Pais = value
        End Set
    End Property


End Class


Public Class DatosTemporalesSauce
    Inherits Disposable
    Private _Cara As Byte

    Private _Placa As String
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property


    Private _EsVentaGerenciada As String
    Public Property Gerenciada() As String
        Get
            Return _EsVentaGerenciada
        End Get
        Set(ByVal value As String)
            _EsVentaGerenciada = value
        End Set
    End Property


    Private _ListaPrecios As System.Array
    Public Property ListaPrecio() As System.Array
        Get
            Return _ListaPrecios
        End Get
        Set(ByVal value As System.Array)
            _ListaPrecios = value
        End Set
    End Property



    Private _Puerto As String
    Public Property Puerto() As String
        Get
            Return _Puerto
        End Get
        Set(ByVal value As String)
            _Puerto = value
        End Set
    End Property


    Private _Surtidores As String
    Public Property Surtidores() As String
        Get
            Return _Surtidores
        End Get
        Set(ByVal value As String)
            _Surtidores = value
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


    Private _Cantidad As String
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property


    Private _Precio As String
    Public Property Precio() As String
        Get
            Return _Precio
        End Get
        Set(ByVal value As String)
            _Precio = value
        End Set
    End Property




    Private _Valor As String
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property


    Private _lecturaInicial As String
    Public Property LecturaInicial() As String
        Get
            Return _lecturaInicial
        End Get
        Set(ByVal value As String)
            _lecturaInicial = value
        End Set
    End Property


    Private _presionLLenado As String
    Public Property PresionLLenado() As String
        Get
            Return _presionLLenado
        End Get
        Set(ByVal value As String)
            _presionLLenado = value
        End Set
    End Property



    Private _LecturaFinal As String
    Public Property LecturaFinal() As String
        Get
            Return _LecturaFinal
        End Get
        Set(ByVal value As String)
            _LecturaFinal = value
        End Set
    End Property


    Public Property Cara() As Byte
        Get
            Return _Cara
        End Get
        Set(ByVal value As Byte)
            _Cara = value
        End Set
    End Property

    Private _Producto As Integer
    Public Property Producto() As Integer
        Get
            Return _Producto
        End Get
        Set(ByVal value As Integer)
            _Producto = value
        End Set
    End Property
    Private _Manguera As Integer
    Public Property Manguera() As Integer
        Get
            Return _Manguera
        End Get
        Set(ByVal value As Integer)
            _Manguera = value
        End Set
    End Property
    Private _Lectura As String
    Public Property Lectura() As String
        Get
            Return _Lectura
        End Get
        Set(ByVal value As String)
            _Lectura = value
        End Set
    End Property
End Class