Imports System.Threading
Imports ServicioComunicadorTGN



Module TestService

    Sub Main(ByVal args() As String)


        Dim oCore As New ServicioComunicadorTGN.CoreServicio 'Autorizador


        While True
            Thread.Sleep(10000)
        End While
    End Sub

End Module
