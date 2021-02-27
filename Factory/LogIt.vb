Imports Microsoft.Practices.EnterpriseLibrary.Logging

Public Class LogIt
    Inherits Disposable

    Public Shared Sub Loguear(ByVal mensaje As String, ByVal propiedades As PropiedadesExtendidas, ByVal categorias As CategoriasLog)
        Try
            Dim log As LogEntry = New LogEntry
            log.Message = String.Format(mensaje & " " & Now.ToString("dd/MM/yyyy HH:mm:ss ff"))
            log.Priority = 1

            Dim propiedad As PropiedadExtendida

            For I As Int32 = 0 To propiedades.Item.Count - 1
                propiedad = CType(propiedades.Item(I), PropiedadExtendida)
                log.ExtendedProperties.Add(propiedad.Nombre, propiedad.Valor & "||")
            Next I

            Dim categoria As CategoriaLog

            For I As Int32 = 0 To categorias.Item.Count - 1
                categoria = CType(categorias.Item(I), CategoriaLog)
                log.Categories.Add(categoria.Nombre)
            Next I

            Logger.Write(log)



        Catch

        End Try
    End Sub
End Class

Public Class PropiedadesExtendidas
    Inherits Disposable

    Private Items As New ArrayList

    Public Property Item() As ArrayList
        Get
            Return Items
        End Get
        Set(ByVal value As ArrayList)
            Items = value
        End Set
    End Property

    Public Sub Agregar(ByVal nombre As String, ByVal valor As String)
        Try
            Dim p As New PropiedadExtendida
            p.Nombre = nombre
            p.Valor = valor
            Items.Add(p)
        Catch

        End Try
    End Sub

    Public Sub Clear()
        Items.Clear()
    End Sub
End Class

Public Class PropiedadExtendida
    Inherits Disposable

    Private NombreP As String
    Private ValorP As String

    Public Property Nombre() As String
        Get
            Return NombreP
        End Get
        Set(ByVal value As String)
            NombreP = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return ValorP
        End Get
        Set(ByVal value As String)
            ValorP = value
        End Set
    End Property
End Class

Public Class CategoriasLog
    Inherits Disposable

    Private Items As New ArrayList

    Public Property Item() As ArrayList
        Get
            Return Items
        End Get
        Set(ByVal value As ArrayList)
            Items = value
        End Set
    End Property

    Public Sub Agregar(ByVal nombre As String)
        Dim p As New CategoriaLog
        p.Nombre = nombre
        Items.Add(p)
    End Sub

    Public Sub Clear()
        Items.Clear()
    End Sub
End Class

Public Class CategoriaLog
    Inherits Disposable

    Private NombreC As String
    Public Property Nombre() As String
        Get
            Return NombreC
        End Get
        Set(ByVal value As String)
            NombreC = value
        End Set
    End Property
End Class