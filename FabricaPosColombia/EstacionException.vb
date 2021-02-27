Imports System.Data.SqlClient

Public Class EstacionException
    Inherits Disposable

    Private _FechaHora, _Metodo, _Args, _Fuente, _MensajeBase, _TipoExcepcionBase, _Target As String
    Private _Excepcion As System.Exception
    Private _SQLExcepcion As System.Data.SqlClient.SqlException

    Private LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog

    Public Property FechaHora() As String
        Get
            Return _FechaHora
        End Get
        Set(ByVal value As String)
            _FechaHora = value
        End Set
    End Property


    Public Property Metodo() As String
        Get
            Return _Metodo
        End Get
        Set(ByVal value As String)
            _Metodo = value
        End Set
    End Property

    Public Property Excepcion() As System.Exception
        Get
            Return _Excepcion
        End Get
        Set(ByVal value As System.Exception)
            _Excepcion = value
        End Set
    End Property

    Public Property Args() As String
        Get
            Return _Args
        End Get
        Set(ByVal value As String)
            _Args = value
        End Set
    End Property

    Public Property Fuente() As String
        Get
            Return _Fuente
        End Get
        Set(ByVal value As String)
            _Fuente = value
        End Set
    End Property


    Public Property MensajeBase() As String
        Get
            Return _MensajeBase
        End Get
        Set(ByVal value As String)
            _MensajeBase = value
        End Set
    End Property

    Public Property SQLExcepcion() As System.Data.SqlClient.SqlException
        Get
            Return _SQLExcepcion
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlException)
            _SQLExcepcion = value
        End Set
    End Property

    Public Property TipoExcepcionBase() As String
        Get
            Return _TipoExcepcionBase
        End Get
        Set(ByVal value As String)
            _TipoExcepcionBase = value
        End Set
    End Property


    Public Property Target() As String
        Get
            Return _Target
        End Get
        Set(ByVal value As String)
            _Target = value
        End Set
    End Property


    Public Sub New()


    End Sub


    Public Shared Function GetErrorCode(ByVal err As SqlException) As Integer
        Dim Codigo As Integer
        'For Each Falla As SqlClient.SqlError In err.Errors
        'Codigo = Falla.Number
        'Next
        Codigo = CInt(err.Message.Substring(0, 6))
        Return Codigo
    End Function


    Public Sub ReportarError(ByVal excepcion As System.Exception, ByVal metodoNombre As String, ByVal args As String, ByVal categorias As String)
        Try
            Me.Excepcion = excepcion
            Me.FechaHora = Now.ToString
            Me.Metodo = metodoNombre
            Me.TipoExcepcionBase = excepcion.GetType.ToString
            Me.MensajeBase = excepcion.Message
            While Not Me.Excepcion.InnerException Is Nothing
                Me.Excepcion = Me.Excepcion.InnerException
            End While
            Me.Args = args

            LogCategorias.Clear()
            LogCategorias.Agregar(categorias)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString)
            LogPropiedades.Agregar("Metodo", Me.Metodo)
            LogPropiedades.Agregar("Parametros", args)
            LogPropiedades.Agregar("MensajeOriginal", Me.Excepcion.Message)
            LogPropiedades.Agregar("TipoExcepcion", Me.Excepcion.GetType().ToString)
            LogPropiedades.Agregar("Fuente", Me.Excepcion.Source)
            LogPropiedades.Agregar("Target", Me.Excepcion.TargetSite.Name)
            LogPropiedades.Agregar("StackTrace", Me.Excepcion.StackTrace)

            LogIt.Loguear("Error en Estacion", LogPropiedades, LogCategorias)
        Catch ex As System.Exception

        End Try

    End Sub

    Public Sub ReportarError(ByVal sExcepcion As SqlException, ByVal metodoNombre As String, ByVal args As String, ByVal categorias As String)


        Try
            Me.SQLExcepcion = sExcepcion
            For Each Err As SqlClient.SqlError In Me.SQLExcepcion.Errors
                LogCategorias.Clear()
                LogCategorias.Agregar(categorias)
                LogPropiedades.Clear()
                LogPropiedades.Agregar("FechaHora", Now.ToString)
                LogPropiedades.Agregar("Metodo", metodoNombre)
                LogPropiedades.Agregar("Parametros", args)
                LogPropiedades.Agregar("MensajeOriginal", "Servidor: " & Err.Server & " , Procedimiento: " & Err.Procedure & " , Linea: " & Err.LineNumber & " , Nivel: " & Err.Class & " , Estado: " & Err.State & " , Mensaje: " & Err.Message)
                LogIt.Loguear("Error en Estacion", LogPropiedades, LogCategorias)
            Next
        Catch ex As System.Exception

        End Try
  
    End Sub
End Class
