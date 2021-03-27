Imports System.IO
Imports System.Net.NetworkInformation
Imports Microsoft.VisualBasic
Imports System.Globalization

Public Class Utilidades


    Public Shared Function HayConexion(servidorremoto As String, Timeout As Int32) As Boolean        
        Dim res As Boolean = False
        Dim index As Integer = 1
        For index = 1 To 3
            Dim servidor As String = servidorremoto
            Dim objUrl As New System.Uri(servidor)
            ' Setup WebRequest 
            Dim objWebReq As System.Net.WebRequest
            objWebReq = System.Net.WebRequest.Create(objUrl)
            Dim objResp As System.Net.WebResponse
            Try
                'Attempt to get response and return True 
                objWebReq.Timeout = Timeout
                objResp = objWebReq.GetResponse
                objResp.Close()
                objWebReq = Nothing
                Return True

            Catch ex As System.Exception               
                objWebReq = Nothing
            End Try
        Next
        Return res
    End Function

End Class