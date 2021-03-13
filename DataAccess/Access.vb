Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports CDIChileFactory
Imports System.IO
Imports System.Net.Mail
Imports System.Net.Configuration
Imports System.Configuration
Imports System.Web
Imports System


Public Class DA

#Region "METODOS TGN"

    Public Function EsLlegadaAPuntoDeInteres(ByVal Latitud As Decimal, ByVal Longitud As Decimal) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                Dim Resultado As String
                'Crea un sqlComand a partir del nombre del procedimiento almacenado
                Dim SqlCommand As String = "TMS_EsLlegadaAPuntoDeInteres"
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

                DB.AddInParameter(DatabaseCommand, "Latitud", DbType.Decimal, Latitud)
                DB.AddInParameter(DatabaseCommand, "Longitud", DbType.Decimal, Longitud)

                'Ejecuta el Procedimiento Almacenado
                Resultado = DB.ExecuteScalar(DatabaseCommand).ToString()
                connection.Close()
                Return Resultado
            Catch
                Throw
            Finally
                If Not connection Is Nothing Then
                    connection.Close()
                End If
            End Try
        End Using
    End Function

    Public Function RecuperarDatosEnvioEvento(ByVal Placa As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "TMS_RecuperarDatosEnvioEvento"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(DataBaseCommand, "Placa", DbType.String, Placa)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Sub InsertarRegistroEventosVehiculo(ByVal Placa As String, ByVal IdEvento As Integer)
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "TMS_InsertarRegistroEventosVehiculo"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Placa", DbType.String, Placa)
        DB.AddInParameter(DatabaseCommand, "IdEventoAra", DbType.Decimal, IdEvento)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Function TMS_ExisteVehiculoARA(ByVal Placa As String) As Boolean
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "TMS_ExisteVehiculoARA"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "Placa", DbType.String, Placa)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Return CBool(DB.ExecuteScalar(DatabaseCommand))
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarVehiculosEnRuta() As DataSet
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "TMS_RecuperarVehiculosEnRuta"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function RecuperarParametro(ByVal nombre As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                Dim Resultado As String
                'Crea un sqlComand a partir del nombre del procedimiento almacenado
                Dim SqlCommand As String = "TMS_RecuperarParametro"
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

                DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, nombre)

                'Ejecuta el Procedimiento Almacenado
                Resultado = DB.ExecuteScalar(DatabaseCommand).ToString()
                connection.Close()
                Return Resultado
            Catch
                Throw
            Finally
                If Not connection Is Nothing Then
                    connection.Close()
                End If
            End Try
        End Using
    End Function
#End Region

    Public Enum VehiculoTanques
        Insertar
        Actualizar
        Eliminar
    End Enum

    Public Structure CapacidadVehiculos
        Dim IdVehiculo As Integer
        Dim Capacidad As Double
    End Structure

    Public Function RecuperarDatosToken(ByVal Tipo As Int16) As DataSet
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDatosToken"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "Tipo", DbType.Int16, Tipo)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function CrearActualizarCredibancoTefCloud(ByVal idEstacion As Integer, ByVal Codigo As String, ByVal Usuario As String, ByVal Clave As String) As Boolean

        Dim SeInserto As Boolean = False
        Dim Transaction As DbTransaction = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand("CrearActualizarCredibancoTefCloud")

        db.AddInParameter(DataBaseCommand, "idEstacion", DbType.Int32, idEstacion)
        db.AddInParameter(DataBaseCommand, "Codigo", DbType.String, Codigo)
        db.AddInParameter(DataBaseCommand, "Usuario", DbType.String, Usuario)
        db.AddInParameter(DataBaseCommand, "Clave", DbType.String, Clave)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Transaction = Connection.BeginTransaction()
                db.ExecuteNonQuery(DataBaseCommand)
                Transaction.Commit()
                SeInserto = True
            Catch ex As Exception
                If Not Transaction Is Nothing Then Transaction.Rollback()
                SeInserto = False
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
        Return SeInserto
    End Function

    Public Function RecuperarConfiguracionCredibancoTEFCloud(ByVal idEstacion As Integer) As IDataReader

        Dim Transaction As DbTransaction = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim DatabaseCommand As DbCommand = db.GetStoredProcCommand("RecuperarConfiguracionCredibancoTEFCloud")

        db.AddInParameter(DatabaseCommand, "idEstacion", DbType.Int32, idEstacion)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Transaction = Connection.BeginTransaction()
                Return db.ExecuteReader(DatabaseCommand)
                Transaction.Commit()
            Catch ex As Exception
                If Not Transaction Is Nothing Then Transaction.Rollback()
                'Return Nothing
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarCorreoXUserId(ByVal Id As String) As String
        Dim oDB As Database = DatabaseFactory.CreateDatabase()
        Dim oConn As DbConnection = oDB.CreateConnection
        Dim Correo As String
        Try
            Dim SQLString As String = "RecuperarCorreoXUserId"
            Dim oCmmd As DbCommand = oDB.GetStoredProcCommand(SQLString)

            oDB.AddInParameter(oCmmd, "id", DbType.String, Id)

            oConn.Open()

            Correo = oDB.ExecuteScalar(oCmmd)

            Return Correo

        Catch ex As Exception
            Throw ex
        Finally
            oConn.Close()
        End Try
    End Function

    Public Function RecuperarTodasLasEstaciones() As DataSet
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarTodasLasEstaciones"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarReciboPorReciboLocal(ByVal IdEstacion As String, ByVal ReciboLocal As String) As String
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarReciboPorReciboLocal"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEstacion", DbType.String, IdEstacion)
        DB.AddInParameter(DatabaseCommand, "ReciboLocal", DbType.String, ReciboLocal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Return DB.ExecuteScalar(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ValidarTurnoPorReciboEstacion(ByVal IdEstacion As Integer, ByVal Recibo As Int64) As Boolean
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "ValidarTurnoPorReciboEstacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEstacion", DbType.String, IdEstacion)
        DB.AddInParameter(DatabaseCommand, "Recibo", DbType.String, Recibo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Return CBool(DB.ExecuteScalar(DatabaseCommand))
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarEstacionesPorCompañia(ByVal IdCompañia As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "[RecuperarEstacionesPorCompañia]"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        db.AddInParameter(DataBaseCommand, "IdCompañia", DbType.Int32, IdCompañia)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDatosClientes(ByVal IdCompañia As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "[RecuperarClientes]"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        db.AddInParameter(DataBaseCommand, "IdGrupoUsuario", DbType.Int32, IdCompañia)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Sub AplicarDescuentoVentaPorRecibo(ByVal IdEstacion As String, ByVal Recibo As String)
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim SqlCommand As String = "AplicarDescuentoVentaPorRecibo"
        Dim DatabaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        db.AddInParameter(DatabaseCommand, "IdEstacion", DbType.String, IdEstacion)
        db.AddInParameter(DatabaseCommand, "Recibo", DbType.String, Recibo)

        Using Connection As DbConnection = db.CreateConnection
            Try
                Connection.Open()
                db.ExecuteNonQuery(DatabaseCommand)
                DatabaseCommand.Parameters.Clear()
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarEstructuraArchivoCargaMasiva() As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "[RecuperarEstructuraArchivoCargaMasiva]"

        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTipoDocumentoDescripcion(ByVal DescripcionTipoDocumento As String, ByVal Identificacion As String, ByVal TipoPais As String, ByVal IdGrupo As Int16, ByVal RetornaIdCliente As Boolean) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarTipoDocumentoDescripcion")

        oDb.AddInParameter(oCmmd, "DescripcionTipoDocumento", DbType.String, DescripcionTipoDocumento)
        oDb.AddInParameter(oCmmd, "Identificacion", DbType.String, Identificacion)
        oDb.AddInParameter(oCmmd, "TipoPais", DbType.String, TipoPais)
        oDb.AddInParameter(oCmmd, "IdGrupo", DbType.Int16, IdGrupo)
        oDb.AddInParameter(oCmmd, "RetornaIdCliente", DbType.Boolean, RetornaIdCliente)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarEstadoCivilDescripcion(ByVal Descripcion As String) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarEstadoCivilDescripcion ")

        oDb.AddInParameter(oCmmd, "Descripcion", DbType.String, Descripcion)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarCiudadDescripcion(ByVal DescripcionCiudad As String, ByVal Pais As String) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarCiudadDescripcion")

        oDb.AddInParameter(oCmmd, "DescripcionCiudad", DbType.String, DescripcionCiudad)
        oDb.AddInParameter(oCmmd, "Pais", DbType.String, Pais)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTipoVehiculoDescripcion(ByVal DescripcionTipoVehiculo As String, ByVal IdGrupo As String) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarTipoVehiculoDescripcion")

        oDb.AddInParameter(oCmmd, "DescripcionTipoVehiculo", DbType.String, DescripcionTipoVehiculo)
        oDb.AddInParameter(oCmmd, "IdGrupo", DbType.Int16, IdGrupo)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarMarcaVehiculoDescripcion(ByVal DescripcionMarcaVehiculo As String) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarMarcaVehiculoDescripcion")

        oDb.AddInParameter(oCmmd, "DescripcionMarcaVehiculo", DbType.String, DescripcionMarcaVehiculo)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarModeloVehiculoDescripcion(ByVal DescripcionModeloVehiculo As String, ByVal IdMarcaVehiculo As String) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarModeloVehiculoDescripcion")

        oDb.AddInParameter(oCmmd, "DescripcionModeloVehiculo", DbType.String, DescripcionModeloVehiculo)
        oDb.AddInParameter(oCmmd, "IdMarcaVehiculo", DbType.String, IdMarcaVehiculo)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTipoIdentificadorDescripcion(ByVal Descripcion As String, ByVal NroIdentificador As String, ByVal Placa As String, ByVal IdGrupo As Int16) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarTipoIdentificadorDescripcion")

        oDb.AddInParameter(oCmmd, "Descripcion", DbType.String, Descripcion)
        oDb.AddInParameter(oCmmd, "NroIdentificador", DbType.String, NroIdentificador)
        oDb.AddInParameter(oCmmd, "Placa", DbType.String, Placa)
        oDb.AddInParameter(oCmmd, "IdGrupo", DbType.Int16, IdGrupo)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTipoCreditoDescripcion(ByVal Descripcion As String, ByVal IdCliente As Int16) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarTipoCreditoDescripcion")

        oDb.AddInParameter(oCmmd, "Descripcion", DbType.String, Descripcion)
        oDb.AddInParameter(oCmmd, "IdCliente", DbType.Int16, IdCliente)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarIdCreditoPorPlaca(ByVal Placa As String, ByVal IdGrupo As Int16) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarIdCreditoPorPlaca")

        oDb.AddInParameter(oCmmd, "Placa", DbType.String, Placa)
        oDb.AddInParameter(oCmmd, "IdGrupo", DbType.Int16, IdGrupo)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarIdCreditoPorIdentificacion(ByVal TipoDocumento As String, ByVal Identificacion As String, ByVal IdGrupo As Int16, ByVal ClienteExisteHojaCliente As Boolean) As IDataReader

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarIdCreditoPorIdentificacion")

        oDb.AddInParameter(oCmmd, "TipoDocumento", DbType.String, TipoDocumento)
        oDb.AddInParameter(oCmmd, "Identificacion", DbType.String, Identificacion)
        oDb.AddInParameter(oCmmd, "IdGrupo", DbType.Int16, IdGrupo)
        oDb.AddInParameter(oCmmd, "ClienteExisteHojaCliente", DbType.Boolean, ClienteExisteHojaCliente)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteReader(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


#Region "Configuracion Credito Tercero"
    Public Sub InsertarActualizarConfiguracionCreditoTercero(ByVal IdConfig As Int32, ByVal Usuario As String, ByVal Clave As String, IdEstacion As Int32, ByVal IdTercero As Int16, ByVal UrlServicio As String)

        Dim Transaction As DbTransaction = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim DatabaseCommand As DbCommand = db.GetStoredProcCommand("InsertarActualizarConfiguracionCreditoTercero")

        db.AddInParameter(DatabaseCommand, "IdConfig", DbType.Int32, IdConfig)
        db.AddInParameter(DatabaseCommand, "Usuario", DbType.String, Usuario)
        db.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        db.AddInParameter(DatabaseCommand, "IdEstacion", DbType.Int32, IdEstacion)
        db.AddInParameter(DatabaseCommand, "IdTercero", DbType.Int16, IdTercero)
        db.AddInParameter(DatabaseCommand, "UrlServicio", DbType.String, UrlServicio)

        Using Connection As DbConnection = db.CreateConnection
            Connection.Open()
            Try
                Transaction = Connection.BeginTransaction()
                db.ExecuteNonQuery(DatabaseCommand)
                Transaction.Commit()
            Catch ex As Exception
                If Not Transaction Is Nothing Then Transaction.Rollback()
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarConfiguracionCreditoTerceroPorEstacionId(ByVal IdConfig As Int32, ByVal IdEstacion As Int32) As IDataReader

        Dim Transaction As DbTransaction = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim DatabaseCommand As DbCommand = db.GetStoredProcCommand("RecuperarConfiguracionCreditoTerceroPorEstacionId")

        db.AddInParameter(DatabaseCommand, "IdConfig", DbType.Int32, IdConfig)
        db.AddInParameter(DatabaseCommand, "IdEstacion", DbType.Int32, IdEstacion)

        Using Connection As DbConnection = db.CreateConnection
            Connection.Open()
            Try
                Transaction = Connection.BeginTransaction()
                Return db.ExecuteReader(DatabaseCommand)
                Transaction.Commit()
            Catch ex As Exception
                If Not Transaction Is Nothing Then Transaction.Rollback()
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function
#End Region

#Region "Kilometraje venta"
    Public Sub ActualizarKilometrajeVenta(ByVal Recibo As String, ByVal IdEstacion As Int32, ByVal Kilometraje As String)

        Dim Transaction As DbTransaction = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim DatabaseCommand As DbCommand = db.GetStoredProcCommand("ActualizarKilometrajeVenta")

        db.AddInParameter(DatabaseCommand, "Recibo", DbType.String, Recibo)
        db.AddInParameter(DatabaseCommand, "IdEstacion", DbType.Int32, IdEstacion)
        db.AddInParameter(DatabaseCommand, "Kilometraje", DbType.String, Kilometraje)

        Using Connection As DbConnection = db.CreateConnection
            Connection.Open()
            Try
                Transaction = Connection.BeginTransaction()
                db.ExecuteNonQuery(DatabaseCommand)
                Transaction.Commit()
            Catch ex As Exception
                If Not Transaction Is Nothing Then Transaction.Rollback()
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub
#End Region

    Public Function RecuperarDatosFacturaPos(ByVal Recibo As Int64, ByVal IdEstacion As Int32) As DataSet

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("RecuperarDatosFacturaPos")

        oDb.AddInParameter(oCmmd, "Recibo", DbType.Int64, Recibo)
        oDb.AddInParameter(oCmmd, "IdEstacion", DbType.Int64, IdEstacion)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                Return oDb.ExecuteDataSet(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Sub AnularFacturaCombustiblePorReciboST(ByVal Recibo As Int64, ByVal IdEstacion As Int32)

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("AnularFacturaCombustiblePorReciboST")

        oDb.AddInParameter(oCmmd, "Recibo", DbType.Int64, Recibo)
        oDb.AddInParameter(oCmmd, "IdEstacion", DbType.Int64, IdEstacion)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                oDb.ExecuteNonQuery(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

#Region "Metodos SW Gases del caribe"

    Public Sub InsertarConsumoGNV(ByVal Placa As String, ByVal Volumen As Decimal, ByVal FechaInicioConsumo As DateTime, ByVal FechaFinConsumo As DateTime, ByVal FechaRegistro As DateTime, ByVal IdTurno As Int32, ByVal CodEstacion As Int32, ByVal Rom As String, ByVal Surtidor As Int32, ByVal Manguera As Int32, ByVal Recibo As Int64)
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarConsumoGNV"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Placa", DbType.String, Placa)
        DB.AddInParameter(DatabaseCommand, "Volumen", DbType.Decimal, Volumen)
        DB.AddInParameter(DatabaseCommand, "FechaInicioConsumo", DbType.DateTime, FechaInicioConsumo)
        DB.AddInParameter(DatabaseCommand, "FechaFinConsumo", DbType.DateTime, FechaFinConsumo)
        DB.AddInParameter(DatabaseCommand, "FechaRegistro", DbType.DateTime, FechaRegistro)
        DB.AddInParameter(DatabaseCommand, "IdTurno", DbType.Int32, IdTurno)
        DB.AddInParameter(DatabaseCommand, "CodEstacion", DbType.Int32, CodEstacion)
        DB.AddInParameter(DatabaseCommand, "Rom", DbType.String, Rom)
        DB.AddInParameter(DatabaseCommand, "Surtidor", DbType.Int32, Surtidor)
        DB.AddInParameter(DatabaseCommand, "Manguera", DbType.Int32, Manguera)
        DB.AddInParameter(DatabaseCommand, "Recibo", DbType.Int64, Recibo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarTurno(ByVal IdTurno As Int32, ByVal NumeroTurno As Int32, ByVal CodEstacion As Int32, ByVal CedulaEmpleado As String)
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarTurnoGNV"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdTurno", DbType.Int32, IdTurno)
        DB.AddInParameter(DatabaseCommand, "NumeroTurno", DbType.Int32, NumeroTurno)
        DB.AddInParameter(DatabaseCommand, "CodEstacion", DbType.Int32, CodEstacion)
        DB.AddInParameter(DatabaseCommand, "CedulaEmpleado", DbType.String, CedulaEmpleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarEmpleado(ByVal Cedula As String, ByVal NombreEmpleado As String)
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)
        DB.AddInParameter(DatabaseCommand, "NombreEmpleado", DbType.String, NombreEmpleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    'Anexado, 18/02/2021
    Public Function ExisteVentaEstacion(ByVal Recibo As Long, ByVal CodEstacion As Integer) As Boolean
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Crea un sqlComand a partir del nombre del procedimiento almacenado
                Dim SqlCommand As String = "ExisteVentaEstacion"
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

                DB.AddInParameter(DatabaseCommand, "Recibo", DbType.Int64, Recibo)
                DB.AddInParameter(DatabaseCommand, "CodEstacion", DbType.Int32, CodEstacion)

                'Ejecuta el Procedimiento Almacenado
                Return CBool(DB.ExecuteScalar(DatabaseCommand))
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using

    End Function

#End Region

#Region "DataTrack"

    Public Function ConsultarEstacionesDataTrack(ByVal TipoCredencial As Int16) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ConsultarEstacionesDataTrack"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "TipoCredencial", DbType.Int16, TipoCredencial)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)

            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Function RecuperarDatosDataTrack() As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado

        Dim SqlCommand As String = "RecuperarDatosDataTrack"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        'DB.AddInParameter(DatabaseCommand, "IdRegistroVentaActual", DbType.Int64, IdRegistroVentaActual)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch Ex As Exception
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Sub ActualizarEstadoVentaDataTrack(ByVal IdRegistroVenta As Int64)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Crea un sqlComand a partir del nombre del procedimiento almacenado
                Dim SqlCommand As String = "ActualizarEstadoVentaDataTrack"
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

                DB.AddInParameter(DatabaseCommand, "IdRegistroVenta", DbType.Int64, IdRegistroVenta)

                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

#End Region

#Region "SICOM"
    Public Sub CargarPlanoSicom(ByVal Delimited_FilePath As String)

        Dim oDb As Database = DatabaseFactory.CreateDatabase()
        Dim oCmmd As DbCommand = oDb.GetStoredProcCommand("CargarPlanoSicom")

        oDb.AddInParameter(oCmmd, "Delimited_FilePath", DbType.String, Delimited_FilePath)

        Using Connection As DbConnection = oDb.CreateConnection()
            Connection.Open()
            Try
                oDb.ExecuteNonQuery(oCmmd)
            Catch ex As Exception
                Throw ex
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarOperacionSICOMPorNombre(ByVal Operacion As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand("RecuperarOperacionSICOMPorNombre")

                DB.AddInParameter(DatabaseCommand, "Operacion", DbType.String, Operacion)

                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteScalar(DatabaseCommand).ToString()
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarMetodoHttpPorOperacion(ByVal Operacion As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand("RecuperarMetodoHttpPorOperacion")

                DB.AddInParameter(DatabaseCommand, "Operacion", DbType.String, Operacion)

                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteScalar(DatabaseCommand).ToString()
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDatosConfiguracionSicom() As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand("RecuperarDatosConfiguracionSicom")

                'DB.AddInParameter(DatabaseCommand, "Operacion", DbType.String, Operacion)

                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region

End Class