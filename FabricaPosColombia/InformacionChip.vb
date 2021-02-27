Public Class InformacionChip
    Inherits Disposable

    Dim PlacaAux As String
    Dim RomAux As String
    Dim FechaConversionAux As Date
    Dim FechaProximoMantenimientoAux As Date
    Dim NumeroAux As Long
    Dim SerieAux As String
    Dim CompañiaAux As String
    Dim _Contrato As String
    Dim _Formato As FormatoEncriptacion
   

    Public Property Formato() As FormatoEncriptacion
        Get
            Return _Formato
        End Get
        Set(ByVal value As FormatoEncriptacion)
            _Formato = value
        End Set
    End Property
    Public Property Placa() As String
        Get
            Return PlacaAux
        End Get
        Set(ByVal value As String)
            PlacaAux = value
        End Set
    End Property
    Public Property Rom() As String
        Get
            Return RomAux
        End Get
        Set(ByVal value As String)
            RomAux = value
        End Set
    End Property
    Public Property FechaConversion() As Date
        Get
            Return FechaConversionAux
        End Get
        Set(ByVal value As Date)
            FechaConversionAux = value
        End Set
    End Property
    Public Property FechaProximoMantenimiento() As Date
        Get
            Return FechaProximoMantenimientoAux
        End Get
        Set(ByVal value As Date)
            FechaProximoMantenimientoAux = value
        End Set
    End Property
    Public Property Numero() As Long
        Get
            Return NumeroAux
        End Get
        Set(ByVal value As Long)
            NumeroAux = value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return SerieAux
        End Get
        Set(ByVal value As String)
            SerieAux = value
        End Set
    End Property
    Public Property Compañia() As String
        Get
            Return CompañiaAux
        End Get
        Set(ByVal value As String)
            CompañiaAux = value
        End Set
    End Property

    Public Property Contrato() As String
        Get
            Return _Contrato
        End Get
        Set(ByVal value As String)
            _Contrato = value
        End Set
    End Property

    Private _ExisteLecturaChip As Boolean
    Public Property ExisteLecturaChip() As Boolean
        Get
            Return _ExisteLecturaChip
        End Get
        Set(ByVal value As Boolean)
            _ExisteLecturaChip = value
        End Set
    End Property

End Class


Public Class BytesLectura
    Public Property ArregloBytes() As Byte()
        Get
            Return m_ArregloBytes
        End Get
        Set(ByVal value As Byte())
            m_ArregloBytes = value
        End Set
    End Property
    Private m_ArregloBytes As Byte()

End Class



Public Class InformacionDispositivoLSIB4


    Private _Puerto As String
    Public Property Puerto() As String
        Get
            Return _Puerto
        End Get
        Set(ByVal value As String)
            _Puerto = value
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


    Private _IdPuerto As Integer
    Public Property IdPuerto() As Integer
        Get
            Return _IdPuerto
        End Get
        Set(ByVal value As Integer)
            _IdPuerto = value
        End Set
    End Property

    Private _IdDti As Integer
    Public Property IdDti() As Integer
        Get
            Return _IdDti
        End Get
        Set(ByVal value As Integer)
            _IdDti = value
        End Set
    End Property
End Class