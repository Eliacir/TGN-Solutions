
Imports Newtonsoft.Json
Imports gasolutions
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports GraphQL.Client.Http
Imports GraphQL
Imports GraphQL.Client.Serializer.Newtonsoft
Imports System.Threading.Tasks

Public Class ServiceApis

    Public Shared Function GetToken() As String
        Try
            Dim oHelper As New DataAccess.DA


            Dim UrlTokenSatrack As String = oHelper.RecuperarParametro("UrlTokenSatrack")
            Dim client_id As String = oHelper.RecuperarParametro("client_id")
            Dim client_secret As String = oHelper.RecuperarParametro("client_secret")
            Dim grant_type As String = oHelper.RecuperarParametro("grant_type")


            Using client = New HttpClient()

                client.BaseAddress = New Uri(UrlTokenSatrack)

                Dim nvc = New List(Of KeyValuePair(Of String, String))()

                nvc.Add(New KeyValuePair(Of String, String)("client_id", client_id))
                nvc.Add(New KeyValuePair(Of String, String)("client_secret", client_secret))
                nvc.Add(New KeyValuePair(Of String, String)("grant_type", grant_type))

                Dim request As HttpRequestMessage = New HttpRequestMessage(HttpMethod.Post, "")
                request.Content = New FormUrlEncodedContent(nvc)
                Dim response = client.SendAsync(request)

                If response.Result.IsSuccessStatusCode Then
                    Dim respuesta = response.Result.Content.ReadAsStringAsync()
                    Dim token = JsonConvert.DeserializeObject(Of TokenResult)(respuesta.Result)
                    Return token.access_token
                End If
            End Using

            Return Nothing

        Catch ex As Exception
            Return Nothing
            Throw
        End Try
    End Function

    Public Async Function GetLastEventLocationPorPlaca(ByVal placa As String) As Task(Of List(Of LocationEvent))
        Try

            Dim oHelper As New DataAccess.DA

            'Obtener token
            Dim token As String = GetToken()

            Dim UrlApiSatrack As String = oHelper.RecuperarParametro("UrlApiSatrack")

            Dim serviceCode As String = JsonConvert.SerializeObject(placa)

            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri(UrlApiSatrack)}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                    .Query = "{ last(serviceCodes: " + serviceCode + ")" + "{ address,batteryLevel,customerPoint,customerPointDistance,description," + " 
                                                                          deviceType, generationDateGMT, direction, id, ignition, latitude, locationStatus, longitude," + "
                                                                          samePlaceMinutes, serviceCode, speed, temperature, town, vehicleStatus, unifiedEventCode,recordDate
                          } }"
                   }
            Try
                Dim response = Await client.SendQueryAsync(Of LocationResponse)(request)
                If Not response.Data Is Nothing Then

                    Return response.Data.LocationEvents

                End If

                Return Nothing
            Catch ex As Exception
                Dim respuesta = DirectCast(ex, GraphQL.Client.Http.GraphQLHttpRequestException).Content
                Dim Clas As Example = JsonConvert.DeserializeObject(Of Example)(respuesta)
                Throw New Exception(Clas.result.errors.FirstOrDefault.message)
            End Try


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Async Function GetLastEventLocationAllVehicle() As Task(Of List(Of LocationEvent))
        Try

            Dim oHelper As New DataAccess.DA

            'Obtener token
            Dim token As String = GetToken()

            Dim UrlApiSatrack As String = oHelper.RecuperarParametro("UrlApiSatrack")

            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri(UrlApiSatrack)}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                    .Query = "{ last(serviceCodes: [] ){ address,batteryLevel,customerPoint,customerPointDistance,description," + " 
                                                                          deviceType, generationDateGMT, direction, id, ignition, latitude, locationStatus, longitude," + "
                                                                          samePlaceMinutes, serviceCode, speed, temperature, town, vehicleStatus, unifiedEventCode,recordDate
                          } }"
                   }
            Try
                Dim response = Await client.SendQueryAsync(Of LocationResponse)(request)
                If Not response.Data Is Nothing Then

                    Return response.Data.LocationEvents

                End If
            Catch ex As Exception
                Dim respuesta = DirectCast(ex, GraphQL.Client.Http.GraphQLHttpRequestException).Content
                Dim Clas As Example = JsonConvert.DeserializeObject(Of Example)(respuesta)
                Throw New Exception(Clas.result.errors.FirstOrDefault.message)
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Async Function GetKilometraje(ByVal Placa As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As Task(Of String)
        Dim respuesta As String = ""
        Try

            Dim Reenviar = False
            Dim oHelper As New DataAccess.DA


            'Obtener token
            Dim token As String = GetToken()

            Dim UrlApiSatrack As String = oHelper.RecuperarParametro("UrlApiSatrack")

            Dim PlacaC = JsonConvert.SerializeObject(Placa)
            Dim fechainicialC = JsonConvert.SerializeObject(fechainicial.ToString("yyyy/MM/dd hh:mm:ss"))
            Dim fechafinalC = JsonConvert.SerializeObject(fechafinal.ToString("yyyy/MM/dd hh:mm:ss"))


            Dim client = New GraphQLHttpClient(New GraphQLHttpClientOptions With {.EndPoint = New Uri(UrlApiSatrack)}, New NewtonsoftJsonSerializer())

            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

            Dim request = New GraphQLHttpRequest With {
                    .Query = "{ byDate " +
                              "(serviceCode: " + PlacaC + ", currentPage: 1 , itemsPerPage: 1," +
                              "initialDate: " + fechainicialC + ", endDate: " + fechafinalC + ")" +
                              "{ pagination{ currentPage }events{ odometer }}" +
                              "}"
                    }

            Dim response As New GraphQLResponse(Of LocationResponseDate)
            Try

                ' Dim response = Await client.SendQueryAsync(Of LocationResponseDate)(request)
                response = Await client.SendQueryAsync(Of LocationResponseDate)(request)



                Dim op2 = response.Data
                Dim op3 = response.Errors
                Dim op4 = response.Extensions

                If response.AsGraphQLHttpResponse.StatusCode = 200 Then
                    If response.Data.LocationEventsDate.events.Count <= 0 Then
                        Throw New Exception("ETGN001: No se encontraron registros")
                    End If
                    If Not response.Data Is Nothing Then
                        respuesta = response.Data.LocationEventsDate.events.FirstOrDefault.odometer.ToString()
                    End If
                End If

            Catch ex As Exception
                If ex.Message.Contains("ETGN001") Then
                    respuesta = ex.Message
                Else
                    respuesta = DirectCast(ex, GraphQL.Client.Http.GraphQLHttpRequestException).Content
                    Dim Clas As Example = JsonConvert.DeserializeObject(Of Example)(respuesta)
                    respuesta = Clas.result.errors.FirstOrDefault.message
                End If
            End Try
            Return respuesta

        Catch ex As Exception
            respuesta = ex.Message
        End Try
        Return respuesta
    End Function


    Public Class Data
        Public Property byDate As Object
    End Class



    Public Class Extensions
        Public Property code As String
    End Class



    Public Class [Error]
        Public Property message As String
        Public Property extensions As Extensions
    End Class



    Public Class Result
        Public Property data As Data
        Public Property errors As IList(Of [Error])
    End Class



    Public Class Example
        Public Property result As Result
        Public Property graphQLErrors As IList(Of String)
    End Class

    Public Class TokenResult
        Public Property access_token As String
    End Class

    Public Class LocationResponseDate

        <JsonProperty("byDate")>
        Public Property LocationEventsDate As ByDate

    End Class

    Public Class ByDate
        Public Property pagination As Pagination
        Public Property events As IList(Of Events)
    End Class

    Public Class Pagination
        Public Property currentPage As Integer
    End Class

    Public Class Events
        Public Property odometer As Double
    End Class


    Public Class LocationResponse
        <JsonProperty("last")>
        Public Property LocationEvents As List(Of LocationEvent)
    End Class

    Public Class LocationEvent

        <JsonProperty("serviceCode")>
        Public Property Placa As String

        <JsonProperty("latitude")>
        Public Property Latitud As String

        <JsonProperty("longitude")>
        Public Property Longitud As String

        <JsonProperty("address")>
        Public Property DireccionAddres As String

        <JsonProperty("town")>
        Public Property Ciudad As String

        <JsonProperty("generationDateGMT")>
        Public Property GenerationDateGMT As DateTime

        <JsonProperty("speed")>
        Public Property Velodcidad As String

        <JsonProperty("ignition")>
        Public Property Estado As String

        <JsonProperty("direction")>
        Public Property Direccion As String

        <JsonProperty("description")>
        Public Property Descripcion As String

        <JsonProperty("vehicleStatus")>
        Public Property EstadoVehiculo As String

        <JsonProperty("unifiedEventCode")>
        Public Property CodigoEvento As String

        <JsonProperty("deviceType")>
        Public Property TipoDispositivo As String

        <JsonProperty("locationStatus")>
        Public Property EstadoUbicacion As String

        <JsonProperty("batteryLevel")>
        Public Property NivelBateria As String

        <JsonProperty("customerPoint")>
        Public Property PuntoCliente As String

        <JsonProperty("customerPointDistance")>
        Public Property DistanciaPuntoCliente As String

        <JsonProperty("customerPointName")>
        Public Property NombrePuntoCliente As String

        <JsonProperty("id")>
        Public Property id As String

        <JsonProperty("samePlaceMinutes")>
        Public Property TiempoEnElMismoSitiominuto As String

        <JsonProperty("temperature")>
        Public Property Temperatura As String

        <JsonProperty("recordDate")>
        Public Property FechaEvento As String

    End Class

End Class
