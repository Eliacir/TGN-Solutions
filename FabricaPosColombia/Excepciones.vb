Imports System
Imports System.Runtime.Serialization

<Serializable()> _
Public Class GasolutionsHaspException
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsEstadoCreditoVehiculoException
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class


<Serializable()> _
Public Class GasolutionsFidelizacionPgn
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsAbonoException
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class ChipNoConectadoException
    Inherits ApplicationException

    Public Sub New()
        MyBase.New("No hay un Chip Conectado")
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsException
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class


<Serializable()> _
Public Class GasolutionCancelacionProceso
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsCreditoConsumoException
    Inherits ApplicationException

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsItemExistException
    Inherits ApplicationException
    Dim IdProducto_ As Int32

    Public Property IdProducto() As Int32
        Get
            Return IdProducto_
        End Get
        Set(ByVal value As Int32)
            IdProducto_ = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal producto As Int32)
        IdProducto_ = producto
    End Sub
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsLoginException
    Inherits ApplicationException
    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

<Serializable()> _
Public Class GasolutionsTurnoException
    Inherits ApplicationException
    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As System.Exception)
        MyBase.New(message, inner)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class