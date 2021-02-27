Public Class Disposable
    Implements IDisposable

    Private _disposed As Boolean = False

    Public Property Disposed() As Boolean
        Get
            Return _disposed
        End Get
        Set(ByVal value As Boolean)
            _disposed = value
        End Set
    End Property

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.Disposed Then
            If disposing Then
                ' Insert code to free unmanaged resources.
            End If
            ' Insert code to free shared resources.
        End If
        Me.Disposed = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
End Class
