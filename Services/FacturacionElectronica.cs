using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using gasolutions.DataAccess;
using gasolutions.Factory;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using DotNetOpenAuth.OAuth2;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using gasolutions;

namespace Facturacion
{


    public class FacturacionElectronica
    {

        private static Dictionary<string, string> ColCliente = new Dictionary<string, string>();
        public static HttpClient _client;
        public static string _serviceNamespace;
        public static string _serviceUrl;

        public static RespuestaClienteFE ConsultarCliente(string TipoIdentificacion, string identificacion, string Cara)
        {

            CategoriasLog LogCategorias = new CategoriasLog();
            PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
            RespuestaClienteFE Respuesta = new RespuestaClienteFE();
            gasolutions.DataAccess.DA oDatos = new gasolutions.DataAccess.DA();

            try
            {
                string Token = TokenCliente();

                TokenResult Tokenres = new TokenResult();
                Tokenres = JsonConvert.DeserializeObject<TokenResult>(Token);

                string ServicioURL = oDatos.RecuperarParametro("UrlServicioValidacionClienteFE");

                string localIP = "";
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }

                var client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenres.access_token);

                UriBuilder builder = new UriBuilder(ServicioURL);

                var query = HttpUtility.ParseQueryString(builder.Query);

                query["fecha"] = DateTime.Now.ToString();
                query["aplicacion"] = "FullStationTerpel";
                //query["cliente.identificadorDispositivo"] = localIP;
                query["Dispositivo"] = localIP;
                query["codigoTipoIdentificacion"] = TipoIdentificacion;
                query["numeroIdentificacion"] = identificacion;

                builder.Query = query.ToString();

                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Antes de enviar la consulta");
                LogPropiedades.Agregar("QUERY ENVIADO CLIENTE", query.ToString());
                LogPropiedades.Agregar("IDENTIFICACION", identificacion);
                LogPropiedades.Agregar("Fecha", DateTime.Now.ToString());
                gasolutions.Factory.LogIt.Loguear("Antes de consultar cliente.", LogPropiedades, LogCategorias);

                Task<HttpResponseMessage> responseResult = client.GetAsync(builder.Uri.ToString());
                responseResult.Wait();
                var status = responseResult.Result.StatusCode;
                string body = responseResult.Result.Content.ReadAsStringAsync().Result;
                //string body = "{\"codigoRespuesta\":\"20000\",\"tipoRespuesta\":\"Funcional\",\"mensajeRespuesta\":\"El cliente fue identificado correctamente.\",\"fechaProceso\":\"2020-07-16 10:17:45\",\"datosIdentificacionCliente\":{\"codigoTipoIdentificacion\":13,\"numeroIdentificacion\":1026283362,\"digitoVerificacion\":null,\"identificadorTipoPersona\":2,\"nombreComercial\":\"JORGE MARTIN\",\"nombreRegistro\":\"JORGE MARTIN\",\"correoElectronico\":\"jorge.martin@terpel.com\",\"telefonoContacto\":3203791929,\"codigoSAP\":454545,\"regimenFiscal\":49,\"direccionCliente\":{\"codigoCiudad\":\"11001\",\"nombreCiudad\":\"BOGOTÁ D.C\",\"codigoPostal\":\"110911\",\"nombreDepartamento\":\"BOGOTÁ\",\"codigoDepartamento\":\"11\",\"direccionLibre\":\"AV EL DORADO # 99-13\",\"codigoPais\":\"CO\",\"nombrePais\":\"Colombia\"},\"direccionFiscalCliente\":{\"codigoCiudad\":\"11001\",\"nombreCiudad\":\"BOGOTÁ D.C\",\"codigoPostal\":\"110911\",\"nombreDepartamento\":\"BOGOTÁ\",\"codigoDepartamento\":\"11\",\"direccionLibre\":\"AV EL DORADO # 99-13\",\"codigoPais\":\"CO\",\"nombrePais\":\"Colombia\"},\"tipoResponsabilidad\":[{\"codigoResponsabilidad\":\"R-99-PN\"}],\"datosTributariosAdquirente\":[{\"codigoTributo\":\"ZY\",\"descripcionTributo\":\"NO CAUSA\"}]}}";

                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Despues de enviar datos");
                LogPropiedades.Agregar("JSON RECIBIDO CLIENTE", body);
                LogPropiedades.Agregar("Fecha", DateTime.Now.ToString());
                gasolutions.Factory.LogIt.Loguear("Recibir datos del cliente", LogPropiedades, LogCategorias);

                if (ColCliente.ContainsKey(Cara))
                {
                    ColCliente.Remove(Cara);
                }

                Respuesta = JsonConvert.DeserializeObject<RespuestaClienteFE>(body);

                if (status == HttpStatusCode.OK)
                {
                    Respuesta.codigoRespuesta = "20000";

                    RespuestaClienteFE ClienteFe = Respuesta;

                    if (string.IsNullOrEmpty(ClienteFe.datosIdentificacionCliente.numeroIdentificacion) ||
                        string.IsNullOrEmpty(ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion) ||
                        string.IsNullOrEmpty(ClienteFe.datosIdentificacionCliente.nombreRegistro))
                    {
                        throw new Exception("Datos del cliente inconsistentes");
                    }
                    else
                    {
                        if (ClienteFe.datosIdentificacionCliente.identificadorTipoPersona == 1)
                        {
                            if (string.IsNullOrEmpty(ClienteFe.datosIdentificacionCliente.nombreComercial) ||
                               string.IsNullOrEmpty(ClienteFe.datosIdentificacionCliente.regimenFiscal) ||
                                ClienteFe.datosIdentificacionCliente.tipoResponsabilidad.Count == 0)
                            {
                                throw new Exception("Datos del cliente inconsistentes");
                            }
                        }

                        if (ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion == "31")
                        {
                            if (string.IsNullOrEmpty(ClienteFe.datosIdentificacionCliente.digitoVerificacion.ToString()))
                            {
                                throw new Exception("Digito de verificacion es obligatorio para el tipo de documento seleccionado");
                            }
                        }

                    }

                    ColCliente.Add(Cara, body);
                }
                else if (status == HttpStatusCode.NotFound) { Respuesta.codigoRespuesta = "404"; Respuesta.MensajeRespuesta = "Cliente no existe"; }
                else if (status == HttpStatusCode.BadRequest) { Respuesta.codigoRespuesta = "400"; Respuesta.MensajeRespuesta = "No se puede identificar"; }
                else if (status == HttpStatusCode.BadGateway) { Respuesta.codigoRespuesta = "502"; Respuesta.MensajeRespuesta = "Error en el motor de base de datos"; }
                else if (status == HttpStatusCode.GatewayTimeout) { Respuesta.codigoRespuesta = "504"; Respuesta.MensajeRespuesta = "Tiempo de espera agotado"; }
                else { Respuesta.codigoRespuesta = "Comunicacion"; Respuesta.MensajeRespuesta = "En este momento no podemos validar el cliente"; }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Respuesta.codigoRespuesta = "Comunicacion";
                Respuesta.MensajeRespuesta = "En este momento no podemos validar el cliente. ";

                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta de cliente", LogPropiedades, LogCategorias);
            }
            catch (System.Net.WebException ex)
            {
                Respuesta.codigoRespuesta = "Comunicacion";
                Respuesta.MensajeRespuesta = "En este momento no podemos validar el cliente. ";

                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta de cliente", LogPropiedades, LogCategorias);
            }
            catch (System.Exception ex)
            {
                Respuesta.codigoRespuesta = "Comunicacion";
                Respuesta.MensajeRespuesta = "En este momento no podemos validar el cliente. ";

                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta de cliente", LogPropiedades, LogCategorias);
            }

            return Respuesta;
        }

        public static string TokenCliente()
        {
            CategoriasLog LogCategorias = new CategoriasLog();
            PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
            string token = "";

            try
            {

                string grant_type = "";
                string client_id = "";
                string client_secret = "";
                string Scope = "";
                string username = "";
                string password = "";
                string baseAddress = "";
                var client = new HttpClient();

                gasolutions.DataAccess.DA oDatos = new gasolutions.DataAccess.DA();
                var datostoken = oDatos.RecuperarDatosToken(1);

                if (datostoken.Tables.Count != 0)
                {
                    foreach (DataRow Res in datostoken.Tables[0].Rows)
                    {
                        grant_type = Res["grant_type"].ToString();
                        client_id = Res["client_id"].ToString();
                        client_secret = Res["client_secret"].ToString();
                        Scope = Res["Scope"].ToString();
                        username = Res["username"].ToString();
                        password = Res["password"].ToString();
                        baseAddress = Res["uri"].ToString();
                    }
                }

                var form = new Dictionary<string, string>
                    {
                        {"grant_type", grant_type},
                        {"client_id", client_id},
                        {"client_secret", client_secret},
                        {"scope", Scope},
                        {"username", username},
                        {"password", password}

                    };

                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                HttpContent content = new FormUrlEncodedContent(form);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.Timeout = TimeSpan.FromMinutes(2);
                var responseResult = client.PostAsync(baseAddress, content).Result;
                responseResult.Content.ReadAsStringAsync().Wait();
                token = responseResult.Content.ReadAsStringAsync().Result;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta  TokenCliente", LogPropiedades, LogCategorias);
            }
            catch (System.Net.WebException ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta TokenCliente", LogPropiedades, LogCategorias);
            }
            catch (System.Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta TokenCliente", LogPropiedades, LogCategorias);
                throw ex;
            }
            return token;

        }

        public static string Token()
        {
            CategoriasLog LogCategorias = new CategoriasLog();
            PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
            string token = "";

            try
            {
                string grant_type = "";
                string client_id = "";
                string client_secret = "";
                string Scope = "";
                string username = "";
                string password = "";
                string baseAddress = "";
                var client = new HttpClient();

                gasolutions.DataAccess.DA oDatos = new gasolutions.DataAccess.DA();
                var datostoken = oDatos.RecuperarDatosToken(2);

                if (datostoken.Tables.Count != 0)
                {
                    foreach (DataRow Res in datostoken.Tables[0].Rows)
                    {
                        grant_type = Res["grant_type"].ToString();
                        client_id = Res["client_id"].ToString();
                        client_secret = Res["client_secret"].ToString();
                        Scope = Res["Scope"].ToString();
                        username = Res["username"].ToString();
                        password = Res["password"].ToString();
                        baseAddress = Res["uri"].ToString();
                    }
                }

                var form = new Dictionary<string, string>
                    {
                        {"grant_type", grant_type},
                        {"client_id", client_id},
                        {"client_secret", client_secret},
                        {"scope", Scope},
                        {"username", username},
                        {"password", password}

                    };

                HttpContent content = new FormUrlEncodedContent(form);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                var responseResult = client.PostAsync(baseAddress, content).Result;
                token = responseResult.Content.ReadAsStringAsync().Result;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta  Token", LogPropiedades, LogCategorias);
            }
            catch (System.Net.WebException ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta Token", LogPropiedades, LogCategorias);
            }
            catch (System.Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("FacturacionElectronica");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                gasolutions.Factory.LogIt.Loguear("Excepcion Consulta Token", LogPropiedades, LogCategorias);
                throw ex;
            }


            return token;
        }

        //public static string FacturarElectronicaVenta(string recibo, ref string NombreCliente)
        //{
        //    string Respuesta = "";
        //    string TipoResponsabilidad = "";
        //    CategoriasLog LogCategorias = new CategoriasLog();
        //    PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        //    ok salida = new ok();
        //    try
        //    {
        //        var token = Token();

        //        RespuestaClienteFE ResCliente = new RespuestaClienteFE();
        //        gasolutions.DataAccess.DA oDatos = new gasolutions.DataAccess.DA();

        //        if (ColCliente.ContainsKey(recibo))
        //        {
        //            ResCliente = JsonConvert.DeserializeObject<RespuestaClienteFE>(ColCliente[recibo]);
        //            ColCliente.Remove(recibo);
        //        }

        //        RespuestaClienteFE ClienteFe = ResCliente;

        //        foreach (tipoResponsabilidad iten in ClienteFe.datosIdentificacionCliente.tipoResponsabilidad)
        //        {
        //            TipoResponsabilidad = TipoResponsabilidad + iten.codigoResponsabilidad + "|";
        //        }

        //        var DatosFactura = oDatos.RecuperarVentaConFacturaElectronica(Int64.Parse(recibo));

        //        //var DatosEstacion = oDatos.RecuperarDatosEstacionFE();

        //        string Prefijo = "", ConsecutivoFactura = "", PhycodigoCiudad = "", PhynombreCiudad = "", PhynombreDepartamento = "", PhycodigoDepartamento = "", PhydireccionLibre = "", PhycodigoPais = "", PhynombrePais = "",
        //            RAcodigoCiudad = "", RAnombreCiudad = "", RAnombreDepartamento = "", RAcodigoDepartamento = "", RAdireccionLibre = "", RAcodigoPais = "", RAnombrePais = "";

        //        DatosVenta Venta = new DatosVenta();
        //        List<DatosVenta> ListVenta = new List<DatosVenta>();

        //        if (DatosFactura.Tables.Count != 0)
        //        {
        //            foreach (DataRow Res in DatosFactura.Tables[0].Rows)
        //            {
        //                Prefijo = Res["Prefijo"].ToString();
        //                ConsecutivoFactura = Res["ConsecutivoFactura"].ToString();
        //            }
        //        }


        //        string Url = oDatos.RecuperarParametro("URLServicioFacturacionElectronica");

        //        TokenResult Tokenres = new TokenResult();
        //        Tokenres = JsonConvert.DeserializeObject<TokenResult>(token);

        //        XmlDocument xmlDoc = new XmlDocument();

        //        String SchemeType = "";
        //        foreach (datosTributariosAdquirente iten in ClienteFe.datosIdentificacionCliente.datosTributariosAdquirente)
        //        {
        //            SchemeType = SchemeType + "<v11:SchemeType>";
        //            SchemeType = SchemeType + "<v11:ID>" + iten.codigoTributo + "</v11:ID><v11:Name>" + iten.descripcionTributo + "</v11:Name>";
        //            SchemeType = SchemeType + "</v11:SchemeType>";
        //        }


        //        if (ClienteFe.datosIdentificacionCliente.direccionCliente != null)
        //        {
        //            PhycodigoCiudad = ClienteFe.datosIdentificacionCliente.direccionCliente.codigoCiudad;
        //            PhynombreCiudad = ClienteFe.datosIdentificacionCliente.direccionCliente.nombreCiudad;
        //            PhynombreDepartamento = ClienteFe.datosIdentificacionCliente.direccionCliente.nombreDepartamento;
        //            PhycodigoDepartamento = ClienteFe.datosIdentificacionCliente.direccionCliente.codigoDepartamento;
        //            PhydireccionLibre = ClienteFe.datosIdentificacionCliente.direccionCliente.direccionLibre;
        //            PhycodigoPais = ClienteFe.datosIdentificacionCliente.direccionCliente.codigoPais;
        //            PhynombrePais = ClienteFe.datosIdentificacionCliente.direccionCliente.nombrePais;
        //        }

        //        if (ClienteFe.datosIdentificacionCliente.direccionFiscalCliente != null)
        //        {

        //            RAcodigoCiudad = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.codigoCiudad;
        //            RAnombreCiudad = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.nombreCiudad;
        //            RAnombreDepartamento = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.nombreDepartamento;
        //            RAcodigoDepartamento = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.codigoDepartamento;
        //            RAdireccionLibre = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.direccionLibre;
        //            RAcodigoPais = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.codigoPais;
        //            RAnombrePais = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.nombrePais;
        //        }

        //        if (ClienteFe.datosIdentificacionCliente.identificadorTipoPersona == 1)
        //        {
        //            NombreCliente = ClienteFe.datosIdentificacionCliente.nombreComercial;
        //        }
        //        else
        //        {
        //            NombreCliente = ClienteFe.datosIdentificacionCliente.nombreRegistro;
        //        }

        //        if (string.IsNullOrEmpty(ResCliente.datosIdentificacionCliente.codigoSAP))
        //        {
        //            ResCliente.datosIdentificacionCliente.codigoSAP = "0";
        //        }

        //        oDatos.ActualizarCodigoSAPPorRecibo(Int64.Parse(recibo), ResCliente.datosIdentificacionCliente.codigoSAP, false, NombreCliente, Int16.Parse(ResCliente.datosIdentificacionCliente.codigoTipoIdentificacion), ResCliente.datosIdentificacionCliente.numeroIdentificacion);


        //        string XmlFactura = oDatos.RecuperarXmlFacturaEnvio(Convert.ToInt64(recibo), ClienteFe.datosIdentificacionCliente.numeroIdentificacion, ClienteFe.datosIdentificacionCliente.digitoVerificacion.ToString(),
        //            ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion, ClienteFe.datosIdentificacionCliente.identificadorTipoPersona.ToString(),
        //            NombreCliente, ClienteFe.datosIdentificacionCliente.nombreRegistro,
        //            PhycodigoCiudad, PhynombreCiudad, PhynombreDepartamento, PhycodigoDepartamento, PhydireccionLibre, PhycodigoPais,
        //            PhynombrePais, ClienteFe.datosIdentificacionCliente.regimenFiscal, TipoResponsabilidad,
        //            ClienteFe.datosIdentificacionCliente.telefonoContacto, ClienteFe.datosIdentificacionCliente.correoElectronico, SchemeType,
        //            RAcodigoCiudad, RAnombreCiudad, RAnombreDepartamento, RAcodigoDepartamento, RAdireccionLibre, RAcodigoPais,
        //            RAnombrePais);

        //        xmlDoc.LoadXml(XmlFactura);


        //        if (!Directory.Exists(Application.StartupPath + "/XmlFacturacion"))
        //        {
        //            Directory.CreateDirectory(Application.StartupPath + "/XmlFacturacion/");
        //        }

        //        string RutaSave = Application.StartupPath + "\\XmlFacturacion\\" + "Factura" + Prefijo + ConsecutivoFactura + "_" + DateTime.Now.ToString("d").Replace("/", "") + DateTime.Now.ToString("hh") + DateTime.Now.Date.ToString("mm") + DateTime.Now.ToString("ss") + ".XML";
        //        xmlDoc.Save(RutaSave);
        //        xmlDoc.Load(RutaSave);


        //        _client = new HttpClient();
        //        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        //        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenres.access_token);
        //        _serviceUrl = Url;
        //        _serviceNamespace = "https://www.terpel.com/integraciones/schemas/enviarFacturaDian/v1.0";

        //        string method = "EnviarFacturaDian";

        //        const string header = "SOAPAction";
        //        if (_client.DefaultRequestHeaders.Contains(header))
        //        {
        //            _client.DefaultRequestHeaders.Remove(header);
        //        }
        //        _client.DefaultRequestHeaders.Add(header,
        //            $"{_serviceNamespace}{(_serviceNamespace.EndsWith("/") ? "" : "/")}{method}");

        //        XNamespace xmlns = _serviceNamespace;
        //        XNamespace soap = "http://www.w3.org/2003/05/soap-envelope";
        //        XElement xmlOut = XElement.Parse(xmlDoc.OuterXml);

        //        var data = xmlOut?.Elements();
        //        var xDocument = XDocument.Parse(xmlDoc.OuterXml);


        //        if (bool.Parse(oDatos.RecuperarParametro("AplicaFacturacionElectronica")))
        //        {
        //            var response = _client.PostAsync(_serviceUrl, new StringContent(xDocument.ToString(), Encoding.UTF8, "text/xml"));
        //            response.Wait();
        //            var xmlResult = response.Result.Content.ReadAsStringAsync();

        //            XmlDocument xmlDocx = new XmlDocument();
        //            xmlDocx.LoadXml(xmlResult.Result.Replace("soapenv:", "").Replace("v1:", "").Replace("v11:", ""));
        //            string json = JsonConvert.SerializeXmlNode(xmlDocx);
        //            salida = JsonConvert.DeserializeObject<ok>(json);

        //            LogCategorias.Clear();
        //            LogCategorias.Agregar("FacturacionElectronica");
        //            LogPropiedades.Clear();
        //            LogPropiedades.Agregar("JSON RESPUESTA", json);
        //            gasolutions.Factory.LogIt.Loguear("Respuesta servicio", LogPropiedades, LogCategorias);

        //            if (!(salida.Envelope.Body.EnviarFacturaDianResponse.EnviarFacturaDianResult is null))
        //            {
        //                if (!string.IsNullOrEmpty(salida.Envelope.Body.EnviarFacturaDianResponse.EnviarFacturaDianResult.UUID))
        //                {
        //                    oDatos.ActualizarUUIDPorRecibo(Int64.Parse(recibo), salida.Envelope.Body.EnviarFacturaDianResponse.EnviarFacturaDianResult.UUID, false);
        //                }
        //            }

        //            if (bool.Parse(oDatos.RecuperarParametro("AplicaBorradoXMLFacturacionElectronica")))
        //                File.Delete(RutaSave);
        //        }
        //    }

        //    catch (System.Net.Sockets.SocketException ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion Facturar Venta", LogPropiedades, LogCategorias);
        //    }
        //    catch (System.Net.WebException ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion Codigo");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion Facturar Venta", LogPropiedades, LogCategorias);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion Facturar Venta", LogPropiedades, LogCategorias);
        //        throw ex;
        //    }

        //    return Respuesta;
        //}

        //public static string FacturarElectronicaVentaCanastilla(string IdVentaCanastilla, ref string NombreCliente, string Puerto, bool EsFactura = false)
        //{
        //    string Respuesta = "";
        //    string TipoResponsabilidad = "";
        //    CategoriasLog LogCategorias = new CategoriasLog();
        //    PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        //    ok salida = new ok();
        //    try
        //    {
        //        var token = Token();

        //        RespuestaClienteFE ResCliente = new RespuestaClienteFE();
        //        gasolutions.DataAccess.DA oDatos = new gasolutions.DataAccess.DA();

        //        if (ColCliente.ContainsKey(Puerto))
        //        {
        //            ResCliente = JsonConvert.DeserializeObject<RespuestaClienteFE>(ColCliente[Puerto]);
        //            ColCliente.Remove(Puerto);
        //        }

        //        RespuestaClienteFE ClienteFe = ResCliente;

        //        foreach (tipoResponsabilidad iten in ClienteFe.datosIdentificacionCliente.tipoResponsabilidad)
        //        {
        //            TipoResponsabilidad = TipoResponsabilidad + iten.codigoResponsabilidad + "|";
        //        }

        //        var DatosFactura = oDatos.RecuperarVentaConFacturaElectronicaCanastilla(Int64.Parse(IdVentaCanastilla), EsFactura);


        //        string Prefijo = "", ConsecutivoFactura = "", PhycodigoCiudad = "", PhynombreCiudad = "", PhynombreDepartamento = "", PhycodigoDepartamento = "", PhydireccionLibre = "", PhycodigoPais = "", PhynombrePais = "",
        //            RAcodigoCiudad = "", RAnombreCiudad = "", RAnombreDepartamento = "", RAcodigoDepartamento = "", RAdireccionLibre = "", RAcodigoPais = "", RAnombrePais = "";
        //        if (DatosFactura.Tables.Count != 0)
        //        {
        //            foreach (DataRow Res in DatosFactura.Tables[0].Rows)
        //            {
        //                Prefijo = Res["Prefijo"].ToString();
        //                ConsecutivoFactura = Res["ConsecutivoFactura"].ToString();
        //            }
        //        }


        //        string Url = oDatos.RecuperarParametro("URLServicioFacturacionElectronica");

        //        TokenResult Tokenres = new TokenResult();
        //        Tokenres = JsonConvert.DeserializeObject<TokenResult>(token);

        //        XmlDocument xmlDoc = new XmlDocument();

        //        String SchemeType = "";
        //        foreach (datosTributariosAdquirente iten in ClienteFe.datosIdentificacionCliente.datosTributariosAdquirente)
        //        {
        //            SchemeType = SchemeType + "<v11:SchemeType>";
        //            SchemeType = SchemeType + "<v11:ID>" + iten.codigoTributo + "</v11:ID><v11:Name>" + iten.descripcionTributo + "</v11:Name>";
        //            SchemeType = SchemeType + "</v11:SchemeType>";
        //        }

        //        if (ClienteFe.datosIdentificacionCliente.direccionCliente != null)
        //        {
        //            PhycodigoCiudad = ClienteFe.datosIdentificacionCliente.direccionCliente.codigoCiudad;
        //            PhynombreCiudad = ClienteFe.datosIdentificacionCliente.direccionCliente.nombreCiudad;
        //            PhynombreDepartamento = ClienteFe.datosIdentificacionCliente.direccionCliente.nombreDepartamento;
        //            PhycodigoDepartamento = ClienteFe.datosIdentificacionCliente.direccionCliente.codigoDepartamento;
        //            PhydireccionLibre = ClienteFe.datosIdentificacionCliente.direccionCliente.direccionLibre;
        //            PhycodigoPais = ClienteFe.datosIdentificacionCliente.direccionCliente.codigoPais;
        //            PhynombrePais = ClienteFe.datosIdentificacionCliente.direccionCliente.nombrePais;
        //        }

        //        if (ClienteFe.datosIdentificacionCliente.direccionFiscalCliente != null)
        //        {

        //            RAcodigoCiudad = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.codigoCiudad;
        //            RAnombreCiudad = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.nombreCiudad;
        //            RAnombreDepartamento = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.nombreDepartamento;
        //            RAcodigoDepartamento = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.codigoDepartamento;
        //            RAdireccionLibre = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.direccionLibre;
        //            RAcodigoPais = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.codigoPais;
        //            RAnombrePais = ClienteFe.datosIdentificacionCliente.direccionFiscalCliente.nombrePais;
        //        }

        //        if (ClienteFe.datosIdentificacionCliente.identificadorTipoPersona == 1)
        //        {
        //            NombreCliente = ClienteFe.datosIdentificacionCliente.nombreComercial;
        //        }
        //        else
        //        {
        //            NombreCliente = ClienteFe.datosIdentificacionCliente.nombreRegistro;
        //        }

        //        if (string.IsNullOrEmpty(ResCliente.datosIdentificacionCliente.codigoSAP))
        //        {
        //            ResCliente.datosIdentificacionCliente.codigoSAP = "0";
        //        }

        //        oDatos.ActualizarCodigoSAPPorRecibo(Int64.Parse(IdVentaCanastilla), ResCliente.datosIdentificacionCliente.codigoSAP, true, NombreCliente, Int16.Parse(ResCliente.datosIdentificacionCliente.codigoTipoIdentificacion), ResCliente.datosIdentificacionCliente.numeroIdentificacion, EsFactura);

        //        string XmlFacturaCanastilla = "";

        //        if (EsFactura)
        //            XmlFacturaCanastilla = oDatos.RecuperarXmlFacturaCanastillaEnvioFactura(Convert.ToInt64(IdVentaCanastilla), ClienteFe.datosIdentificacionCliente.numeroIdentificacion, ClienteFe.datosIdentificacionCliente.digitoVerificacion.ToString(),
        //            ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion, ClienteFe.datosIdentificacionCliente.identificadorTipoPersona.ToString(),
        //            NombreCliente, ClienteFe.datosIdentificacionCliente.nombreRegistro,
        //            PhycodigoCiudad, PhynombreCiudad, PhynombreDepartamento, PhycodigoDepartamento, PhydireccionLibre, PhycodigoPais,
        //            PhynombrePais, ClienteFe.datosIdentificacionCliente.regimenFiscal, TipoResponsabilidad,
        //            ClienteFe.datosIdentificacionCliente.telefonoContacto, ClienteFe.datosIdentificacionCliente.correoElectronico, SchemeType,
        //            RAcodigoCiudad, RAnombreCiudad, RAnombreDepartamento, RAcodigoDepartamento, RAdireccionLibre, RAcodigoPais,
        //            RAnombrePais);
        //        else
        //            XmlFacturaCanastilla = oDatos.RecuperarXmlFacturaCanastillaEnvio(Convert.ToInt64(IdVentaCanastilla), ClienteFe.datosIdentificacionCliente.numeroIdentificacion, ClienteFe.datosIdentificacionCliente.digitoVerificacion.ToString(),
        //            ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion, ClienteFe.datosIdentificacionCliente.identificadorTipoPersona.ToString(),
        //            NombreCliente, ClienteFe.datosIdentificacionCliente.nombreRegistro,
        //            PhycodigoCiudad, PhynombreCiudad, PhynombreDepartamento, PhycodigoDepartamento, PhydireccionLibre, PhycodigoPais,
        //            PhynombrePais, ClienteFe.datosIdentificacionCliente.regimenFiscal, TipoResponsabilidad,
        //            ClienteFe.datosIdentificacionCliente.telefonoContacto, ClienteFe.datosIdentificacionCliente.correoElectronico, SchemeType,
        //            RAcodigoCiudad, RAnombreCiudad, RAnombreDepartamento, RAcodigoDepartamento, RAdireccionLibre, RAcodigoPais,
        //            RAnombrePais);


        //        xmlDoc.LoadXml(XmlFacturaCanastilla);
        //        string RutaSave = Application.StartupPath + "\\XmlFacturacion\\" + "Factura" + Prefijo + ConsecutivoFactura + "_" + DateTime.Now.ToString("d").Replace("/", "") + DateTime.Now.ToString("hh") + DateTime.Now.Date.ToString("mm") + DateTime.Now.ToString("ss") + ".XML";
        //        xmlDoc.Save(RutaSave);
        //        xmlDoc.Load(RutaSave);

        //        //xmlDoc.Save(RutaSave);

        //        _client = new HttpClient();
        //        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        //        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenres.access_token);
        //        _serviceUrl = Url;
        //        _serviceNamespace = "https://www.terpel.com/integraciones/schemas/enviarFacturaDian/v1.0";

        //        string method = "EnviarFacturaDian";

        //        const string header = "SOAPAction";
        //        if (_client.DefaultRequestHeaders.Contains(header))
        //        {
        //            _client.DefaultRequestHeaders.Remove(header);
        //        }
        //        _client.DefaultRequestHeaders.Add(header,
        //            $"{_serviceNamespace}{(_serviceNamespace.EndsWith("/") ? "" : "/")}{method}");

        //        XNamespace xmlns = _serviceNamespace;
        //        XNamespace soap = "http://www.w3.org/2003/05/soap-envelope";
        //        XElement xmlOut = XElement.Parse(xmlDoc.OuterXml);

        //        var data = xmlOut?.Elements();
        //        var xDocument = XDocument.Parse(xmlDoc.OuterXml);

        //        if (bool.Parse(oDatos.RecuperarParametro("AplicaFacturacionElectronica")))
        //        {

        //            var response = _client.PostAsync(_serviceUrl, new StringContent(xDocument.ToString(), Encoding.UTF8, "text/xml"));
        //            response.Wait();
        //            var xmlResult = response.Result.Content.ReadAsStringAsync();

        //            XmlDocument xmlDocx = new XmlDocument();
        //            xmlDocx.LoadXml(xmlResult.Result.Replace("soapenv:", "").Replace("v1:", "").Replace("v11:", ""));
        //            string json = JsonConvert.SerializeXmlNode(xmlDocx);
        //            salida = JsonConvert.DeserializeObject<ok>(json);

        //            LogCategorias.Clear();
        //            LogCategorias.Agregar("FacturacionElectronica");
        //            LogPropiedades.Clear();
        //            LogPropiedades.Agregar("JSON RESPUESTA", json);
        //            gasolutions.Factory.LogIt.Loguear("Respuesta servicio", LogPropiedades, LogCategorias);

        //            if (!(salida.Envelope.Body.EnviarFacturaDianResponse.EnviarFacturaDianResult is null))
        //            {
        //                if (!string.IsNullOrEmpty(salida.Envelope.Body.EnviarFacturaDianResponse.EnviarFacturaDianResult.UUID))
        //                {
        //                    oDatos.ActualizarUUIDPorRecibo(Int64.Parse(IdVentaCanastilla), salida.Envelope.Body.EnviarFacturaDianResponse.EnviarFacturaDianResult.UUID, true, EsFactura);
        //                }
        //            }



        //            if (bool.Parse(oDatos.RecuperarParametro("AplicaBorradoXMLFacturacionElectronica")))
        //                File.Delete(RutaSave);
        //        }

        //    }

        //    catch (System.Net.Sockets.SocketException ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion Facturar Venta Canastilla", LogPropiedades, LogCategorias);
        //    }
        //    catch (System.Net.WebException ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion Facturar Venta Canastilla", LogPropiedades, LogCategorias);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion Facturar Venta Canastilla", LogPropiedades, LogCategorias);
        //        throw ex;
        //    }

        //    return Respuesta;
        //}

        //public static string FacturarElectronicaNotaCredito(string Puerto, string prefijoAnulacion, Int64 consecutivoAnulacion, string Empleado, string ClaveEmpleado)
        //{
        //    bool EsFactura = false;
        //    string Respuesta = "";
        //    CategoriasLog LogCategorias = new CategoriasLog();
        //    PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        //    ok salida = new ok();
        //    string NombreCliente = "";
        //    try
        //    {
        //        var token = Token();
        //        gasolutions.DataAccess.DA oDatos = new gasolutions.DataAccess.DA();

        //        var DatosRechazo = oDatos.RecuperarDatosRechazoNotaCredito(prefijoAnulacion, consecutivoAnulacion);

        //        string TipoID = "", NumeroID = "",
        //            IdVentaCanastilla = "", PhycodigoCiudad = "", PhynombreCiudad = "", PhynombreDepartamento = "", PhycodigoDepartamento = "", PhydireccionLibre = "", PhycodigoPais = "", PhynombrePais = "",
        //            RAcodigoCiudad = "", RAnombreCiudad = "", RAnombreDepartamento = "", RAcodigoDepartamento = "", RAdireccionLibre = "", RAcodigoPais = "", RAnombrePais = "";

        //        if (DatosRechazo.Tables.Count != 0)
        //        {
        //            foreach (DataRow Res in DatosRechazo.Tables[0].Rows)
        //            {
        //                TipoID = Res["TipoID"].ToString();
        //                NumeroID = Res["NumeroID"].ToString();
        //                IdVentaCanastilla = Res["IdVentaCanastilla"].ToString();
        //                EsFactura = Convert.ToBoolean(Res["EsFacturada"]);
        //            }
        //        }

        //        var RespuestaCliente = ConsultarCliente(TipoID, NumeroID, Puerto);

        //        RespuestaClienteFE ResCliente = new RespuestaClienteFE();

        //        if (ColCliente.ContainsKey(Puerto))
        //        {
        //            ResCliente = JsonConvert.DeserializeObject<RespuestaClienteFE>(ColCliente[Puerto]);
        //            ColCliente.Remove(Puerto);
        //        }

        //        string TipoResponsabilidad = "";
        //        foreach (tipoResponsabilidad iten in ResCliente.datosIdentificacionCliente.tipoResponsabilidad)
        //        {
        //            TipoResponsabilidad = TipoResponsabilidad + iten.codigoResponsabilidad + "|";
        //        }

        //        String SchemeType = "";
        //        string name = "https://www.terpel.com/integraciones/schemas/enviarNotaCreditoDian/v1.0";
        //        foreach (datosTributariosAdquirente iten in ResCliente.datosIdentificacionCliente.datosTributariosAdquirente)
        //        {
        //            SchemeType = SchemeType + "<v11:SchemeType>";
        //            SchemeType = SchemeType + "<v11:ID>" + iten.codigoTributo + "</v11:ID><v11:Name>" + iten.descripcionTributo + "</v11:Name>";
        //            SchemeType = SchemeType + "</v11:SchemeType>";
        //        }

        //        if (ResCliente.datosIdentificacionCliente.direccionCliente != null)
        //        {
        //            PhycodigoCiudad = ResCliente.datosIdentificacionCliente.direccionCliente.codigoCiudad;
        //            PhynombreCiudad = ResCliente.datosIdentificacionCliente.direccionCliente.nombreCiudad;
        //            PhynombreDepartamento = ResCliente.datosIdentificacionCliente.direccionCliente.nombreDepartamento;
        //            PhycodigoDepartamento = ResCliente.datosIdentificacionCliente.direccionCliente.codigoDepartamento;
        //            PhydireccionLibre = ResCliente.datosIdentificacionCliente.direccionCliente.direccionLibre;
        //            PhycodigoPais = ResCliente.datosIdentificacionCliente.direccionCliente.codigoPais;
        //            PhynombrePais = ResCliente.datosIdentificacionCliente.direccionCliente.nombrePais;
        //        }

        //        if (ResCliente.datosIdentificacionCliente.direccionFiscalCliente != null)
        //        {

        //            RAcodigoCiudad = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.codigoCiudad;
        //            RAnombreCiudad = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.nombreCiudad;
        //            RAnombreDepartamento = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.nombreDepartamento;
        //            RAcodigoDepartamento = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.codigoDepartamento;
        //            RAdireccionLibre = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.direccionLibre;
        //            RAcodigoPais = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.codigoPais;
        //            RAnombrePais = ResCliente.datosIdentificacionCliente.direccionFiscalCliente.nombrePais;
        //        }

        //        if (ResCliente.datosIdentificacionCliente.identificadorTipoPersona == 1)
        //        {
        //            NombreCliente = ResCliente.datosIdentificacionCliente.nombreComercial;
        //        }
        //        else
        //        {
        //            NombreCliente = ResCliente.datosIdentificacionCliente.nombreRegistro;
        //        }
        //        DataSet DatosAnulacion;
        //        if (EsFactura)
        //            DatosAnulacion = oDatos.AnularFacturaElectronicaCanastillaFactura(prefijoAnulacion, consecutivoAnulacion, Empleado, ClaveEmpleado);
        //        else
        //            DatosAnulacion = oDatos.AnularFacturaElectronicaCanastilla(prefijoAnulacion, consecutivoAnulacion, Empleado, ClaveEmpleado);

        //        string ConsecutivoActualAnulacion = "", PrefijoAnulacion = "", InicialAnulacion = "", FinalAnulacion = "", FechaAnulacion = "";
        //        if (DatosAnulacion.Tables.Count != 0)
        //        {
        //            foreach (DataRow Res in DatosAnulacion.Tables[0].Rows)
        //            {
        //                ConsecutivoActualAnulacion = Res["ConsecutivoActual"].ToString();
        //                PrefijoAnulacion = Res["Prefijo"].ToString();
        //                InicialAnulacion = Res["Inicial"].ToString();
        //                FinalAnulacion = Res["Final"].ToString();
        //                FechaAnulacion = Res["FechaAnulacion"].ToString();
        //            }
        //        }

        //        RespuestaClienteFE ClienteFe = ResCliente;

        //        var DatosFactura = oDatos.RecuperarVentaConFacturaElectronicaCanastilla(Int64.Parse(IdVentaCanastilla), EsFactura);

        //        string Prefijo = "", ConsecutivoFactura = "";

        //        List<DatosVenta> ListVenta = new List<DatosVenta>();

        //        if (DatosFactura.Tables.Count != 0)
        //        {
        //            foreach (DataRow Res in DatosFactura.Tables[0].Rows)
        //            {
        //                Prefijo = Res["Prefijo"].ToString();
        //                ConsecutivoFactura = Res["ConsecutivoFactura"].ToString();
        //            }
        //        }

        //        string Url = oDatos.RecuperarParametro("URLServicioNotaCreditoElectronica");

        //        TokenResult Tokenres = new TokenResult();
        //        Tokenres = JsonConvert.DeserializeObject<TokenResult>(token);

        //        XmlDocument xmlDoc = new XmlDocument();
        //        string XmlFacturaCanastilla = "";
        //        if (EsFactura)
        //            XmlFacturaCanastilla = oDatos.RecuperarXmlNotaCreditoFacturaEnvio(Convert.ToInt64(IdVentaCanastilla), ClienteFe.datosIdentificacionCliente.numeroIdentificacion, ClienteFe.datosIdentificacionCliente.digitoVerificacion.ToString(),
        //            ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion, ClienteFe.datosIdentificacionCliente.identificadorTipoPersona.ToString(),
        //            NombreCliente, ClienteFe.datosIdentificacionCliente.nombreRegistro,
        //            PhycodigoCiudad, PhynombreCiudad, PhynombreDepartamento, PhycodigoDepartamento, PhydireccionLibre, PhycodigoPais,
        //            PhynombrePais, ClienteFe.datosIdentificacionCliente.regimenFiscal, TipoResponsabilidad,
        //            ClienteFe.datosIdentificacionCliente.telefonoContacto, ClienteFe.datosIdentificacionCliente.correoElectronico, SchemeType,
        //            RAcodigoCiudad, RAnombreCiudad, RAnombreDepartamento, RAcodigoDepartamento, RAdireccionLibre, RAcodigoPais,
        //            RAnombrePais, Prefijo, Convert.ToInt64(ConsecutivoFactura));
        //        else
        //            XmlFacturaCanastilla = oDatos.RecuperarXmlNotaCreditoEnvio(Convert.ToInt64(IdVentaCanastilla), ClienteFe.datosIdentificacionCliente.numeroIdentificacion, ClienteFe.datosIdentificacionCliente.digitoVerificacion.ToString(),
        //            ClienteFe.datosIdentificacionCliente.codigoTipoIdentificacion, ClienteFe.datosIdentificacionCliente.identificadorTipoPersona.ToString(),
        //            NombreCliente, ClienteFe.datosIdentificacionCliente.nombreRegistro,
        //            PhycodigoCiudad, PhynombreCiudad, PhynombreDepartamento, PhycodigoDepartamento, PhydireccionLibre, PhycodigoPais,
        //            PhynombrePais, ClienteFe.datosIdentificacionCliente.regimenFiscal, TipoResponsabilidad,
        //            ClienteFe.datosIdentificacionCliente.telefonoContacto, ClienteFe.datosIdentificacionCliente.correoElectronico, SchemeType,
        //            RAcodigoCiudad, RAnombreCiudad, RAnombreDepartamento, RAcodigoDepartamento, RAdireccionLibre, RAcodigoPais,
        //            RAnombrePais, Prefijo, Convert.ToInt64(ConsecutivoFactura));

        //        xmlDoc.LoadXml(XmlFacturaCanastilla);

        //        string RutaSave = Application.StartupPath + "\\XmlFacturacion\\" + "Notacredito" + Prefijo + ConsecutivoFactura + "_" + DateTime.Now.ToString("d").Replace("/", "") + DateTime.Now.ToString("hh") + DateTime.Now.Date.ToString("mm") + DateTime.Now.ToString("ss") + ".XML";
        //        xmlDoc.Save(RutaSave);
        //        xmlDoc.Load(RutaSave);



        //        xmlDoc.Save(RutaSave);

        //        _client = new HttpClient();
        //        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        //        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenres.access_token);
        //        _serviceUrl = Url;
        //        _serviceNamespace = name;

        //        string method = "EnviarNotaCreditoDian";

        //        const string header = "SOAPAction";
        //        if (_client.DefaultRequestHeaders.Contains(header))
        //        {
        //            _client.DefaultRequestHeaders.Remove(header);
        //        }
        //        _client.DefaultRequestHeaders.Add(header,
        //            $"{_serviceNamespace}{(_serviceNamespace.EndsWith("/") ? "" : "/")}{method}");

        //        XNamespace xmlns = _serviceNamespace;
        //        XNamespace soap = "http://www.w3.org/2003/05/soap-envelope";
        //        XElement xmlOut = XElement.Parse(xmlDoc.OuterXml);

        //        var data = xmlOut?.Elements();
        //        var xDocument = XDocument.Parse(xmlDoc.OuterXml);

        //        if (bool.Parse(oDatos.RecuperarParametro("AplicaFacturacionElectronica")))
        //        {
        //            var response = _client.PostAsync(_serviceUrl, new StringContent(xDocument.ToString(), Encoding.UTF8, "text/xml"));
        //            response.Wait();
        //            var xmlResult = response.Result.Content.ReadAsStringAsync();

        //            XmlDocument xmlDocx = new XmlDocument();
        //            xmlDocx.LoadXml(xmlResult.Result.Replace("soapenv:", "").Replace("v1:", "").Replace("v11:", ""));
        //            string json = JsonConvert.SerializeXmlNode(xmlDocx);
        //            salida = JsonConvert.DeserializeObject<ok>(json);

        //            LogCategorias.Clear();
        //            LogCategorias.Agregar("FacturacionElectronica");
        //            LogPropiedades.Clear();
        //            LogPropiedades.Agregar("JSON RESPUESTA", json);
        //            gasolutions.Factory.LogIt.Loguear("Respuesta servicio Nota", LogPropiedades, LogCategorias);

        //            if (bool.Parse(oDatos.RecuperarParametro("AplicaBorradoXMLFacturacionElectronica")))
        //                File.Delete(RutaSave);
        //        }

        //    }

        //    catch (System.Net.Sockets.SocketException ex)
        //    {
        //        if (ColCliente.ContainsKey(Puerto))
        //        {
        //            ColCliente.Remove(Puerto);
        //        }

        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion en NotaCredito", LogPropiedades, LogCategorias);
        //    }
        //    catch (System.Net.WebException ex)
        //    {
        //        if (ColCliente.ContainsKey(Puerto))
        //        {
        //            ColCliente.Remove(Puerto);
        //        }

        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion en NotaCredito", LogPropiedades, LogCategorias);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        if (ColCliente.ContainsKey(Puerto))
        //        {
        //            ColCliente.Remove(Puerto);
        //        }
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("FacturacionElectronica");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", "No hubo comunicacion");
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        gasolutions.Factory.LogIt.Loguear("Excepcion en NotaCredito", LogPropiedades, LogCategorias);
        //        throw ex;
        //    }

        //    return Respuesta;
        //}

    }

    public class TokenResult
    {
        public string access_token { get; set; }

    }

    public class DatosParaAutorizar
    {
        public string grant_type { get; set; }
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string Scope { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string baseAddress { get; set; }
    }


    public class RespuestaClienteFE
    {
        public string codigoRespuesta { get; set; }
        public string TipoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string FechaRespuesta { get; set; }
        public datosIdentificacionCliente datosIdentificacionCliente { get; set; }

    }

    public class InFormacionCliente
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
    }

    public class datosIdentificacionCliente
    {
        public string codigoTipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public Nullable<int> digitoVerificacion { get; set; }
        public int identificadorTipoPersona { get; set; }
        public string nombreComercial { get; set; }
        public string nombreRegistro { get; set; }
        public string correoElectronico { get; set; }
        public string telefonoContacto { get; set; }
        public string codigoSAP { get; set; }
        public string regimenFiscal { get; set; }
        public direccion direccionCliente { get; set; }
        public direccion direccionFiscalCliente { get; set; }
        public List<tipoResponsabilidad> tipoResponsabilidad { get; set; }
        public List<datosTributariosAdquirente> datosTributariosAdquirente { get; set; }
    }

    public class direccion
    {
        public string codigoCiudad { get; set; }
        public string nombreCiudad { get; set; }
        public string codigoPostal { get; set; }
        public string nombreDepartamento { get; set; }
        public string codigoDepartamento { get; set; }
        public string direccionLibre { get; set; }
        public string codigoPais { get; set; }
        public string nombrePais { get; set; }

    }

    public class tipoResponsabilidad
    {
        public string codigoResponsabilidad { get; set; }
    }

    public class datosTributariosAdquirente
    {
        public string codigoTributo { get; set; }
        public string descripcionTributo { get; set; }
    }

    public class ok
    {
        public Envelope Envelope { get; set; }
    }
    public class Envelope
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
    }

    public class Header
    {
        public headerResponse headerResponse { get; set; }
    }

    public class Body
    {
        public EnviarFacturaDianResponse EnviarFacturaDianResponse { get; set; }
    }

    public class EnviarFacturaDianResponse
    {
        public EnviarFacturaDianResult EnviarFacturaDianResult { get; set; }
        public string mensaje { get; set; }

    }

    public class EnviarFacturaDianResult
    {
        public string Estado { get; set; }
        public string NumDocumento { get; set; }
        public string UUID { get; set; }
        public string FechaAutorizacion { get; set; }
        public string CodigoError { get; set; }
        public string MensajeRespuesta { get; set; }
        List<iMensajeRespuesta> lMensajeRespuesta { get; set; }
    }

    public class iMensajeRespuesta
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
    }

    public class headerResponse
    {
        public string codigo { get; set; }
        public string mensaje { get; set; }
        public string descripcion { get; set; }
        public string fechaEjecucion { get; set; }
    }

    public class DatosVenta
    {
        public string FechaEncabezado { get; set; }
        public string Aplicacion { get; set; }
        public string Dispositivo { get; set; }
        public string Clave { get; set; }
        public string Entorno { get; set; }
        public string UsuarioTransaccionERP { get; set; }
        public string Recibo { get; set; }
        public string CodEstacion { get; set; }
        public string NombreIntegracion { get; set; }
        public string Prefijo { get; set; }
        public string ConsecutivoFactura { get; set; }
        public string ConsecutivoInicial { get; set; }
        public string ConsecutivoFinal { get; set; }
        public string CustomizationID { get; set; }
        public string FechaDocumento { get; set; }
        public string Moneda { get; set; }
        public string Descuento { get; set; }
        public string Incremento { get; set; }
        public string TotalVenta { get; set; }
        public string PayableRoundingAmount { get; set; }
        public string TotalPagar { get; set; }
        public string PrepaidAmount { get; set; }
        public string BaseImponible { get; set; }
        public string TaxInclusiveAmount { get; set; }
        public string MetodoPago { get; set; }
        public string CodigoMedioPago { get; set; }
        public string TipoFactura { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string CantidadReal { get; set; }
        public string UnidadMedida { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Code { get; set; }
        public string TaxExclusiveAmount { get; set; }
        public string IdentificationDV { get; set; }
        public string IdentificationType1 { get; set; }
        public string TaxLevelCodeObligations { get; set; }
        public string Name { get; set; }
        public string NIT { get; set; }
    }

}

