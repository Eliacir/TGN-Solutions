Public Class Validacion
    Public Sub New()

    End Sub

    Public Shared Sub ValidarNumeroEntero(ByVal num As String, ByVal texto As String)
        Dim temp As Int32 = 0

        If Int32.TryParse(num, temp) = False Then
            Throw New System.Exception(texto & " debe ser un número")
        Else
            If (temp < 0) Then
                Throw New System.Exception(texto & " debe ser un número no negativo")
            End If
        End If
    End Sub

    Public Shared Sub ValidarNumeroDecimal(ByVal num As String, ByVal texto As String)
        Dim temp As Decimal = 0

        If Decimal.TryParse(num, temp) = False Then
            Throw New System.Exception(texto & " debe ser un número")
        Else
            If (temp < 0) Then
                Throw New System.Exception(texto & " debe ser un número no negativo")
            End If
        End If
    End Sub

    Public Shared Function ValidarRUT(ByVal Rut As String) As Boolean
        Try
            Dim Digito As String = String.Empty
            Dim DigitoVerificacion As String = Rut.Substring(Rut.Length - 1, 1).ToUpper

            Rut = Rut.Replace(".", "")
            Rut = Rut.Replace(",", "")
            Rut = Rut.Replace("-", "")
            Rut = Rut.Substring(0, Rut.Length - 1)

            If Not String.IsNullOrEmpty(Rut.Trim()) Then
                Dim Vari1, Vari2, Vari3 As Integer
                Vari3 = 2
                For I As Integer = 0 To Rut.Length - 1
                    If Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(Rut, I + 1), 1) <> "." Then
                        Vari1 = CInt(Vari1 + CDbl(CDbl(Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(Rut, I + 1), 1)) * Vari3))
                        Vari2 = Vari1 Mod 11
                        Select Case Vari2
                            Case 0
                                Digito = "0"
                            Case 1
                                Digito = "K"
                            Case Else
                                Digito = (11 - Vari2).ToString
                        End Select
                        If Vari3 = 7 Then
                            Vari3 = 2
                        Else
                            Vari3 = Vari3 + 1
                        End If
                    End If
                Next
            End If

            Dim Validado As Boolean = False
            If DigitoVerificacion = Digito Then
                Validado = True
            End If

            Return Validado

        Catch ex As System.Exception
            Throw ex
        End Try
    End Function
End Class
