''' <summary>
''' Facilita el manejo de informcion referente al preset
''' </summary>
''' <remarks></remarks>
Public Class Preset
    Inherits Disposable

    Public Enum Tipo
        PorValor = 0
        PorVolumen = 1
    End Enum

    Private ValorP As String
    Private TipoPresetP As Tipo
    Private _HoraPredeterminacion As System.Nullable(Of Date)
    Private _IdProducto As Int16 = -1

    Public Property IdProducto() As Int16
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Int16)
            _IdProducto = value
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

    Public Property TipoPreset() As Tipo
        Get
            Return TipoPresetP
        End Get
        Set(ByVal value As Tipo)
            TipoPresetP = value
        End Set
    End Property

    Public Property HoraPredeterminacion() As System.Nullable(Of Date)
        Get
            Return _HoraPredeterminacion
        End Get
        Set(ByVal value As System.Nullable(Of Date))
            _HoraPredeterminacion = value
        End Set
    End Property

    Public Sub New(ByVal valorPredeterminado As String, ByVal tipoP As Tipo)
        ValorP = valorPredeterminado
        TipoPresetP = tipoP
        _HoraPredeterminacion = Nothing
    End Sub

    Public Sub New(ByVal valorPredeterminado As String, ByVal tipoP As Tipo, ByVal horaPredeterminacion As Date)
        ValorP = valorPredeterminado
        TipoPresetP = tipoP
        Me._HoraPredeterminacion = horaPredeterminacion
    End Sub

    Public Sub New(ByVal valorPredeterminado As String, ByVal tipoP As Tipo, ByVal horaPredeterminacion As Date, ByVal idproducto As Int16)
        ValorP = valorPredeterminado
        TipoPresetP = tipoP
        Me._HoraPredeterminacion = horaPredeterminacion
        Me._IdProducto = idproducto
    End Sub
End Class