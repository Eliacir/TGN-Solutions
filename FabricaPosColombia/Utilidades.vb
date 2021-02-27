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

    Public Shared Function SeccionarTexto(ByVal texto As String) As List(Of String)
        Dim Lineas As List(Of String) = New List(Of String)
        Dim linea As String = texto
        Dim Posicion As Integer = 40
        Dim PorcionTexto As String


        PorcionTexto = texto
        While PorcionTexto.Length > 25
            Lineas.Add(PorcionTexto.Substring(0, 25))
            PorcionTexto = PorcionTexto.Substring(25)
        End While
        Lineas.Add(PorcionTexto)
        Return Lineas
    End Function


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
            Throw New System.Exception("RUT INVALIDO")
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

        Dim Numero As Double
        Dim Entero As Decimal = 0
        Dim Fraccion As Decimal = 0
        Dim Vector As String()
        Dim r As Char() = {CChar(".")}

        If valor.IndexOf(".") > 0 Then
            Vector = valor.Split(r)

            Entero = CDec(Vector(0))
            Fraccion = CDec(Vector(1))

            Numero = System.Math.Pow(10.0, CDbl(CStr(Fraccion).Length))

            Fraccion = Fraccion / CInt(Numero)
        Else
            Entero = CDec(valor)
        End If

        Return CStr(Entero + Fraccion)

    End Function
End Class