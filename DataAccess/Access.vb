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


    Public Sub TMS_ActualizarRegistroEvento(ByVal Placa As String, ByVal IdEventoARA As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Crea un sqlComand a partir del nombre del procedimiento almacenado
                Dim SqlCommand As String = "TMS_ActualizarRegistroEvento"
                Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

                DB.AddInParameter(DatabaseCommand, "Placa", DbType.String, Placa)
                DB.AddInParameter(DatabaseCommand, "IdEventoARA", DbType.Int32, IdEventoARA)

                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

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


End Class