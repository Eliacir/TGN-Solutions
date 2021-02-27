#Region "UnHandledErrorHandler Class"
Public Class UnHandledErrorHandler
    Inherits Disposable

    Public Sub OnThreadException( _
                      ByVal sender As Object, _
                      ByVal e As System.Threading.ThreadExceptionEventArgs)

        Dim strLocation As String = e.Exception.StackTrace
        Dim intRetryCount As Integer = 0
        Dim bolRetry As Boolean = True

        While bolRetry
            Try
                Dim frm As New frmManejadorError
                Dim intResult As Integer = _
                frm.DisplayErrors(e.Exception, intRetryCount, "N/A", "An Unhandled Exception Occured")
                frm.Dispose()
                ' Check All User Responses
                Select Case intResult
                    Case 0 ' Abort
                        bolRetry = False
                        'Application.Exit()  ' Hide for Demo purposes
                    Case 1 ' Retry
                        intRetryCount += 1
                        If intRetryCount > 3 Then
                            MsgBox("The Maximum Retries Attempted" & vbCrLf & "The Application will now be Aborted", MsgBoxStyle.Critical, "Retry Max Out")
                            bolRetry = False
                        End If
                    Case 2 ' Report It
                        bolRetry = False
                        'Application.Exit()  ' Hide for Demo purposes
                End Select
            Catch
                ' Fatal error, terminate the program
                MsgBox("Fatal Error, Reinicie La Aplicación", MsgBoxStyle.OkOnly, "Fatal Error")
            End Try
        End While
    End Sub

End Class
#End Region