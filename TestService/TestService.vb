Imports System.Threading
Imports ServicioComunicadorTGN
Imports Facturacion



Module TestService

    Sub Main(ByVal args() As String)


        Dim oCore As New ServicioComunicadorTGN.CoreServicio 'Autorizador

        'Dim api As New Facturacion.GetApiSatrack

        While True
            Thread.Sleep(10000)
        End While
    End Sub

End Module
