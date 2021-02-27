Public Class TipoImpresion
    Private _IdTipoImpresora As String
    Public Property IdTipoImpresora() As String
        Get
            Return _IdTipoImpresora
        End Get
        Set(ByVal value As String)
            _IdTipoImpresora = value
        End Set
    End Property

    Private _Texto As String
    Public Property Texto() As String
        Get
            Return _Texto
        End Get
        Set(ByVal value As String)
            _Texto = value
        End Set
    End Property

    Private _IdIsla As String
    Public Property Isla() As String
        Get
            Return _IdIsla
        End Get
        Set(ByVal value As String)
            _IdIsla = value
        End Set
    End Property
End Class
