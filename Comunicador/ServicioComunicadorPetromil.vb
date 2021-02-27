Imports System.Threading
Imports System.ComponentModel
Imports System.IO

Public Class ServicioComunicadorPetromil

    Public Sub test()
        ocore = New CoreServicio
    End Sub
    Private ocore As CoreServicio

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregue el código aquí para iniciar el servicio. Este método debería poner
        ' en movimiento los elementos para que el servicio pueda funcionar.

        '    '*****************************************************************************
        Try
            If Not args Is Nothing Then
                If args.Length > 0 Then
                    If args.GetLength(0) > 0 And args(0).Equals("DEBUG") Then
                        System.Diagnostics.Debugger.Launch()
                    End If
                End If
            End If
            ocore = New CoreServicio
        Catch ex As System.Exception
            AlmacenarEnArchivo("Error Iniciando el servicio comunicador terceros: " & ex.Message)
            Try
                ocore.Terminar()
                ocore = Nothing
            Catch ex2 As System.Exception
            End Try
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        Try
            ocore.Terminar()
            ocore = Nothing
        Catch ex As System.Exception
            AlmacenarEnArchivo("Error deteniendo el servicio comunicador HO: " & ex.Message)
        End Try
        ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
        AlmacenarEnArchivo("Se Detuvo la ejecucion del Comunicador terceros")
    End Sub

    Private Sub AlmacenarEnArchivo(ByVal Mensaje As String)
        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Depuracion") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Depuracion")
            End If
            Using sw As StreamWriter = File.AppendText(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt")
                sw.WriteLine(DateTime.Now & "|" & Mensaje)
                sw.Close()
            End Using
        Catch ex As Exception
            'LogFallas.ReportarError(ex, "AlmacenarEnArchivo", "", "Comunicador")
        End Try
    End Sub

End Class
