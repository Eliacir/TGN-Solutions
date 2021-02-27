Public Interface ServicioRecaudoEmpresa
    Function RecaudarAEmpresa(ByVal Placa As String, ByVal Movil As Int32, ByVal IdRecaudo As Int32, ByVal IdConcepto As Int32, ByVal CantidadPeriodos As Int32, ByVal Valor As Decimal, ByVal CodEstacion As String) As RespuestaServicioRecaudoEmpresa
    Function ConsultarConceptos(ByVal Placa As String, ByVal Movil As Int32) As RespuestaConsultaConceptoEmpresa
    Sub InformarPagoNoRealizado(ByVal Placa As String, ByVal Movil As Int32, ByVal IdRecaudo As Int32, ByVal Valor As Decimal, ByVal CodEstacion As String, ByVal Fecha As DateTime)
End Interface