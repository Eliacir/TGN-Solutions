Imports System.IO
Imports Microsoft.VisualBasic

Public Class Utilidades
    Public Shared Function ValidarRut(ByVal Rut As String, ByVal Validador As String) As String
        Dim Digito As String = ""

        Try
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

            Return Digito

        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Shared Function StringXmlToDataTable(ByVal StrXML As String) As DataTable

        Dim ms As MemoryStream
        Dim buf() As Byte

        Try
            Dim ds As New DataSet
            buf = System.Text.ASCIIEncoding.ASCII.GetBytes(StrXML)
            ms = New MemoryStream(buf)

            ds.ReadXml(ms)

            Return ds.Tables(0)
        Catch ex As System.Exception
            Throw New System.Exception("Error en conversion del String a XML: " & ex.ToString)
        End Try
    End Function

    Public Shared Function ValidarCadenaVacia(ByVal Cadena As String) As Boolean
        'Temporal que guarda la nueva cadena y elimina sus espacios en blanco
        Dim temp As String = Cadena.Replace(" ", "")
        'Evaluamos si la cadena es valida, si es así retornamos true

        If String.IsNullOrEmpty(temp) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function ValidarLetrasYNumeros(ByVal Cadena As String) As Boolean
        Try

            Cadena = Cadena.Replace(" ", "")
            If Cadena.Length > 0 Then
                For Each caracter As Char In Cadena.ToCharArray
                    If Not Char.IsLetterOrDigit(caracter) Then
                        Return False
                    End If
                Next
            Else
                Return False
            End If
            Return True
        Catch ex As System.Exception
            Return False
        End Try

    End Function

    Public Shared Function ExtraerNumeros(ByVal Cadena As String) As String
        Dim numeros As String = ""

        Try
            Cadena = Cadena.Replace(" ", "")

            If Cadena.Length > 0 Then
                For Each caracter As Char In Cadena.ToCharArray
                    If Char.IsDigit(caracter) Then
                        numeros = numeros + caracter
                    End If
                Next
            Else
                Return numeros
            End If

            Return numeros
        Catch ex As System.Exception
            Return numeros
        End Try
    End Function

    Public Shared Function ModificarFormatoDecimal(ByVal valor As String) As String

       
        Dim resultado As Decimal = 0
        If valor.IndexOf(".") > 0 Then
            resultado = CDec(valor.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
        Else
            resultado = CDec(valor)
        End If
        Return resultado.ToString
    End Function
End Class