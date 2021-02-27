Public Enum TipoManejo
    Descuento = 0
    Manejo = 1
End Enum

Public Enum TipoDeVerificacionEnBaseDatos
    RecaudosTercero = 1
    Venta = 2
    PagosExtraordinarios = 3
    Reversion = 4
    NotasCredito = 5
    Movimientoscanastilla = 6
    Ventascanastilla = 7
    Restricciones = 8
    Gerenciamiento = 9
    Turno = 10
    PagosSRE = 11
    GerenciamientoAnulado = 12
    VentasCreditoCanastilla = 13
    VentasCanastillaNoFacturable = 14
    FacturaCombustible = 15
    FacturaElectronica = 16
End Enum

Public Enum TipoDocumentoPeru
    Boleta = 1
    Factura = 2
    Vale = 3
    Calibracion = 4
End Enum

Public Enum EstadoTransmisionCodigoPGn
    Pendiente = 1
    Procesado = 2
    FallaComunicacion = 3
    NoAutorizadoCDC = 4
End Enum

Public Enum TipoDocumentoChile
    Ninguno = 0
    Boleta = 1
    Factura = 2
    GuiaDespacho = 3
End Enum

Public Enum CDCS
    CDCIG = 1
    CDCCOFIDE = 2
    CDCGST = 3
    CDCPGN = 4
    CDCFOMPLUS = 5
    CDCCHILE = 6
End Enum

Public Enum TipoLecturaTarjeta
    BandaMagnetica = 1
    CodigoBarra = 2
    Cedula = 5
End Enum

Public Enum IdentificacionCredito
    CHIP = 1
    TARJETA = 2
    NUMEROVALE = 3
    PLACA = 4
    PLACAVALE = 5
End Enum

Public Enum FormatoEncriptacion
    ServiPunto = 1
    TwoFish = 2
End Enum

Public Enum RespuestaInfoCampaña
    TarjetaNoExiste = 0
    TarjetaSinCliente = -1
End Enum

Public Enum ServiciosSRE
    Tarifa = 1
    PagosEnLinea = 2
End Enum


Public Enum TiposMovimientosDetalle
    Factura = 1
    Devolucion = 2
    Pedido = 3
    TrasladoEntrada = 4
    TrasladoSalida = 5
    AjustePorSobrantes = 6
    AjustePorFaltantes = 7
End Enum

Public Enum Empresas
    InfoTaxi = 1
End Enum

Public Enum EstadosVenta
    NoModificada = 0
    Modificada = 1
    Reversada = 2
End Enum

Public Enum TipoIdentificacionCredito
    CHIP = 1
    PLACA = 2
    TARJETA = 3
    NUMEROAUTORIZACION = 4
    CODIGODEBARRA = 5
End Enum

Public Enum TipoIdentificador
    CHIP = 1
    PLACA = 2
    TARJETA = 3
    CODIGODEBARRA = 4
End Enum

Public Enum TipoIdentificadorFidelizacion
    TARJETA = 1
    NroConductor = 2
End Enum

Public Enum TipoConsumo
    Calibracion = 1
    ConsumoInterno = 2
End Enum

Public Enum EstadosPagoExtraordinario
    Anulado = 1
    Pendiente = 2
    Procesado = 3
End Enum

Public Enum ConsignacionSobres
    Pico = 0
    Total = 1
End Enum

Public Enum FormaPagoTerpel
    CONSUMO = 1
    CHEQUE = 2
End Enum

Public Enum TipoInsercionReciboCombuetible
    INICIAL = 1
    REPETICION = 2
End Enum

Public Enum TipoFidelizacion
    Tarjeta = 1
    Cedula = 2
End Enum

Public Enum EstadoAutorizacion
    Inicial = 1
    LecturaCHIP = 2
    Autorizando = 3
    Autorizado = 4
End Enum

Public Enum TipoTurnoTrabajo
    TDC = 1
    Servicios = 2
    Combustible = 3
End Enum

Public Enum MangueraVentaFueraDeSistema
    Nueva = 1
    Utilizada = 2
End Enum

Public Enum CantidadReciboCombustible
    Menor = 1
    Mayor = 2
    Igual = 3
End Enum

Public Enum RecuperacionReciboCombustible
    Terminado = 0
    AjusteOperacion = 1
    Finalizar = 2
    AjusteRecibo = 3
End Enum

Public Enum EstadoEmpleados
    Inactivo = 0
    Activo = 1
End Enum

Public Enum TipoEmpleado
    Despachador = 1
    Administrador = 2
    Tecnico = 3
End Enum

Public Enum TipoCombustibleChile
    Propio = 1
    Flota = 2
    Storage = 3
End Enum

Public Enum RedFidelizacion
    Gasolutions = 1
    Bono = 2
    Mixta = 4
    PGN = 5
End Enum

Public Enum EstadoTransmision
    Pendiente = 1
    Procesado = 2
    Retransmision = 3
End Enum
Public Enum TipoEstacion
    TerpelPropia = 1
    TerpelAfiliada = 2
    GazelPropia = 3
    GazelFranquiciada = 4
End Enum

Public Enum tipoComunicacionProtocolo
    RS232 = 1
    TCPIP = 2
End Enum

Public Enum TipoValidacionChip
    PLACA = 1
    VIN = 2
End Enum