
Public Class LimiteMenu
    Inherits Disposable

    Dim _desde As Integer
    Public Property Desde As Integer
        Get
            Return _desde
        End Get
        Set(ByVal value As Integer)
            _desde = value
        End Set
    End Property

    Dim _hasta As Integer
    Public Property Hasta As Integer
        Get
            Return _hasta
        End Get
        Set(ByVal value As Integer)
            _hasta = value
        End Set
    End Property
End Class

Public Class Siguiente
    Inherits Disposable

    Dim _comando As String
    Public Property Comando As String
        Get
            Return _comando
        End Get
        Set(ByVal value As String)
            _comando = value
        End Set
    End Property
    Dim _menu As Int16
    Public Property Menu As Int16
        Get
            Return _menu
        End Get
        Set(ByVal value As Int16)
            _menu = value
        End Set
    End Property

    Dim _Esmenu As Boolean
    Public Property EsMenu As Boolean
        Get
            Return _Esmenu
        End Get
        Set(ByVal value As Boolean)
            _Esmenu = value
        End Set
    End Property
End Class
