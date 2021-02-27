Public Class DtiInformacionChip

    Private _Room As String
    Public Property Rom() As String
        Get
            Return _Room
        End Get
        Set(ByVal value As String)
            _Room = value
        End Set
    End Property

    Private _Cara As Byte
    Public Property Cara() As Byte
        Get
            Return _Cara
        End Get
        Set(ByVal value As Byte)
            _Cara = value
        End Set
    End Property

    Private _Puerto As String
    Public Property Puerto() As String
        Get
            Return _Puerto
        End Get
        Set(ByVal value As String)
            _Puerto = value
        End Set
    End Property


    Private _Placa As String
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property


    Private _FechaConversion As String
    Public Property FechaConversion() As String
        Get
            Return _FechaConversion
        End Get
        Set(ByVal value As String)
            _FechaConversion = value
        End Set
    End Property


    Private _FechaMantenimiento As String
    Public Property FechaMantenimiento() As String
        Get
            Return _FechaMantenimiento
        End Get
        Set(ByVal value As String)
            _FechaMantenimiento = value
        End Set
    End Property





End Class
