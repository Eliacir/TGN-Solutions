Public Enum TipoManejo
    Descuento = 0
    Manejo = 1
End Enum

Public Enum TipoDocumentoPeru
    Boleta = 1
    Factura = 2
    Vale = 3
    Calibracion = 4
    FacturaGrande = 5
End Enum

Public Enum tipoComunicacionProtocolo
    RS232 = 1
    TCPIP = 2
End Enum
Public Enum TipoDocumentoChile
    Ninguno = 0
    Boleta = 1
    Factura = 2
    GuiaDespacho = 3
End Enum


Public Enum TipoEnvaseBolivia
    Bolsa = 1
    Botella = 2
    Bidon = 3
    SinPlaca = 4
    ConPlaca = 5
End Enum


Public Enum CDCS
    CDCIG = 1
    CDCCOFIDE = 2
    CDCGST = 3
    'CDCPGN = 4
    DATATRACK = 4
    CDCFOMPLUS = 5
    CRM = 6
End Enum

Public Enum TipoLecturaTarjeta
    BandaMagnetica = 1
    CodigoBarra = 2
End Enum

Public Enum IdentificacionCredito
    CHIP = 1
    TARJETA = 2
    NUMEROVALE = 3
    PLACA = 4
    PLACAVALE = 5
    RUCCHIP = 6
    RUCTARJETA = 7
    RUCPLACA = 8
    TALONARIO = 9
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
    NIT = 6
End Enum

Public Enum TipoIdentificacionCreditoCanastilla
    CHIP = 1
    TARJETA = 2
End Enum
Public Enum TipoIdentificador
    CHIP = 1
    PLACA = 2
    TARJETA = 3
    CODIGODEBARRA = 4
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
    CALIBRACION = 7
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

Public Enum TipoIdentificadorVehiculo
    CHIP = 1
    TARJETA = 2
    PLACA = 3
End Enum

Public Enum TipoIdentificadorVehiculoPeru
    TARJETA = 1
    CHIP = 2
    PLACA = 3
End Enum

Public Enum AccionesConfiguradorPeru
    ConfiguracionImpresoras = 1
    ConfiguracionImpuestos = 2
    ConfiguracionCapturadores = 3
    ConfiguracionRed1wire = 4
    ConfiguracionPuertos = 5
    ConfiguracionHorariosdeturno = 6
    ConfiguracionHistoricodeprecios = 7
    ConfiguracionProductos = 8
    ConfiguracionReddesurtidores = 9
    ConfiguracionAutorizacionylecturadeidentificador = 10
    ConfiguracionServiciosweb = 11
    ConfiguracionParametrosgenerales = 12
    ConfiguracionLectores = 13
    ConfiguracionEstacion = 14
    ConfiguracionFormasdepago = 15
    ConfiguracionDispositivosdemedicion = 16
    ConfiguracionTanques = 17
    ConfiguracionAforo = 18
    ConfiguracionProductosatanques = 19
    ConfiguracionTarjetasPrepago = 20
    ConfiguracionDatosEstacion = 21
    ConfiguracionTanquesConectados = 22
    ConfiguracionValorTRM = 43
End Enum

Public Enum AccionesDataAdminPeru
    ABMEmpleados = 23
    ABMClientes = 24
    ABMVehiculos = 25
    ABMCreditos = 26
    FacturarVentasCredito = 27
    InactivacionChips = 28
    IncrementosFormaPago = 29
    ABMTransportadoras = 30
    ConsignacionesTransportadora = 31
    AutorizacionCheques = 32
    ABMBancos = 33
    DevolucionCheques = 34
    AutorizacionVentasFlota = 35
    RestriccionesVehiculos = 44
End Enum

Public Enum AccionesDBTuning
    ProgramacionHorario = 36
    EjecucionManualMantenimiento = 37
End Enum

Public Enum AccionesFileGenerator
    ImporteArchivosCargaMasiva = 38
    ReportesVarios = 39
    ExporteImporteArchivosRazonSocial = 40
End Enum

Public Enum AccionesToolStation
    RevisionLogs = 41
    RealizarBackupsBD = 42
End Enum

Public Enum AccionesConfiguradorColombia
    ConfiguracionImpresoras = 1
    ConfiguracionSincronizacion = 2
    ConfiguracionCapturadores = 3
    ConfiguracionRed1wire = 4
    ConfiguracionPuertos = 5
    ConfiguracionHorariosdeturno = 6
    ConfiguracionHistoricodeprecios = 7
    ConfiguracionProductos = 8
    ConfiguracionReddesurtidores = 9
    ConfiguracionAutorizacionylecturadeidentificador = 10
    ConfiguracionServiciosweb = 11
    ConfiguracionParametrosgenerales = 12
    ConfiguracionLectores = 13
    ConfiguracionEstacion = 14
    ConfiguracionUnidadesMedida = 15
    ConfiguracionDispositivosdemedicion = 16
    ConfiguracionTanques = 17
    ConfiguracionAforo = 18
    ConfiguracionProductosatanques = 19
    ConfiguracionTarjetasPrepago = 20
    ConfiguracionDatosEstacion = 21
    ConfiguracionTanquesConectados = 22
    ConfiguracionSobreTasa = 43
End Enum

Public Enum AccionesDataAdminColombia
    ABMEmpleados = 23
    ABMClientes = 24
    ABMVehiculos = 25
    ABMCreditos = 26
    InactivacionChips = 27
    RestriccionVehiculos = 28
    ResolucionesFacturacion = 29
    ABMTransportadoras = 30
    ConsignacionesTransportadora = 31
    AutorizacionCheques = 32
    KilometrajeVentas = 33
    DevolucionCheques = 34
    SolicitudOrdenPedidoCombustible = 35
    VentasFueraSistema = 44
    ABMFinancieras = 45
    TiposVehiculo = 53
    PrecioCliente = 54
End Enum


Public Enum TipoValeBolivia
    Prepago = 1
    PostPago = 2

End Enum