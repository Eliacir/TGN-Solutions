Imports System
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.Management
Imports System.Windows.Forms

Public Class frmManejadorError
    Inherits System.Windows.Forms.Form

    Dim m_exObject As System.Exception
    Dim m_strActiveControl As String
    Dim m_strOtherInfoNote As String
    Dim m_RetryCount As Integer
    Dim m_intDialogNumber As Integer
    Dim m_objRegEx As Regex
    Dim m_strMsg As String

    Enum ErrorTypes As Short
        Normal = 0
        SQLServer = 1
        OleDB = 2
        Oracle = 3
    End Enum

    Private Sub frmManejadorError_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lblDate.Text = "Fecha:" & Today.ToShortDateString
        lblTime.Text = "Hora:" & Now.ToShortTimeString & " :"
        lblUserID.Text = "Usuario:" & Environment.UserName.ToUpper
        'lblRetries.Text = "" & m_RetryCount.ToString & " :"
        rtbErrMessage.Text = _
                           "Mensaje: " & m_exObject.Message & vbCrLf & vbCrLf & _
                           "Fuente: " & m_exObject.Source & vbCrLf & vbCrLf & _
                           "Nota: " & m_strOtherInfoNote & vbCrLf & vbCrLf & _
                           "Pila de seguimiento:" & vbCrLf & m_exObject.StackTrace
    End Sub

    ' Entry point for Calling Routines.....Opens the Form snd returns the
    ' users selection
    '
    Public Function DisplayErrors(ByVal ex As System.Exception, ByVal iCount As Integer) As Integer
        m_exObject = ex
        m_RetryCount = iCount
        Me.ShowDialog()
        DisplayErrors = m_intDialogNumber

    End Function

    Public Function DisplayErrors(ByVal ex As System.Exception, ByVal iCount As Integer, _
                    ByVal sActiveCtl As String) As Integer
        m_exObject = ex
        m_RetryCount = iCount
        m_strActiveControl = sActiveCtl
        Me.ShowDialog()
        DisplayErrors = m_intDialogNumber

    End Function

    Public Function DisplayErrors(ByVal ex As System.Exception, ByVal iCount As Integer, _
                    ByVal sActiveCtl As String, _
                    ByVal sOtherInfo As String) As Integer
        m_exObject = ex
        m_RetryCount = iCount
        m_strActiveControl = sActiveCtl
        m_strOtherInfoNote = sOtherInfo
        Me.ShowDialog()
        DisplayErrors = m_intDialogNumber

    End Function
    '  
    Private Sub cmdAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbort.Click
        m_intDialogNumber = 0
        Me.Close()
    End Sub

  
    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        Call Reportit()
        m_intDialogNumber = 2
        Me.Close()
    End Sub


    Sub Reportit()

        Dim strErrFileName As String = My.Application.Info.DirectoryPath & "\ErrorRpt.htm"

        Dim fs As New System.IO.StreamWriter(strErrFileName)
        ' Write out our HTML Report
        fs.WriteLine(GenerateHTML)
        fs.Flush()
        fs.Close()
        ' Find Explorer and launch it using the file we just created
        Dim strBrowser As String = GetApplicationPath("IExplore.exe")
        If strBrowser.Length > 0 Then
            Dim lngTaskID As Long = Shell(strBrowser & " " & strErrFileName, AppWinStyle.NormalFocus, True)
        Else
            MsgBox("Internet Explorer Not Found - No Report Possible", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        End If
    End Sub

    Private Sub cmdDebug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Trigger a breakpoint.
        System.Diagnostics.Debugger.Break()
        ' Treat as if a Retry so we can follow along to the error
        m_intDialogNumber = 1
        Me.Close()
    End Sub

#Region "Generate the HTML code"

    ' Requires a reference to System.Management and the related Imports
    Private Function GenerateHTML() As String

        On Error Resume Next
        Dim i As Integer = 0
        Dim strValueLine, strHeading, strHtmlText As String
        Dim nvCollection As New NameValueCollection
        Dim strFullExeName As String = Application.ExecutablePath
        Dim strExeVersion, strExeName, strProductName As String
        Dim strExcType As String = m_exObject.GetType.ToString

        Dim ErrorType As Integer = ErrorTypes.Normal

        If strExcType.EndsWith("SqlException") Then
            ErrorType = ErrorTypes.SQLServer
        ElseIf strExcType.EndsWith("OleDbException") Then
            ErrorType = ErrorTypes.OleDB
        ElseIf strExcType.EndsWith("OracleException") Then
            ErrorType = ErrorTypes.Oracle
        End If

        ' Retrieve Product Name from the Assembly.VB
        strProductName = Application.ProductName()
        ' Get the EXE file name
        strExeName = System.IO.Path.GetFileName(strFullExeName)
        ' Get the Version and Date from the EXE file
        strExeVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & _
                        System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & _
                        System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & " - " & _
                        Format(FileDateTime(strFullExeName))
        If strProductName.Length = 0 Then strProductName = strExeName

        strHeading = "<p align=""center""><font face=""Arial"" size=""4"" color=""red"">Problem Report</font><br>"
        strHeading &= "<font face=""Arial"" size=""4"" color=""black"">For - " & strProductName & "</font></p>"

        strHeading &= "<table border=""0"" width=""100%"" cellpadding=""1"" cellspacing=""0""> "
        strHeading &= "<tr>"
        strHeading &= "<td bgcolor=""black"" colspan=""2"">"
        strHeading &= "<p align=""center""><font face=""Arial"" color=""white""><b>Program Related Information</b></font></p>"
        strHeading &= "</td>"
        strHeading &= "</tr>"
        strHeading &= "</table>"
        strHeading &= "<table border=""0"" cellpadding=""0"" cellspacing=""1"" width=""100%"">"
        strHeading &= "<tr>"
        strHeading &= "<td width=""33%"" bgcolor=""#C0C0C0""><b>User:</b> " & Environment.UserName.ToUpper & "</td>"
        strHeading &= "<td width=""34%"" bgcolor=""#C0C0C0""><p align=""center""><b>Machine:</b> " & Environment.MachineName.ToLower & "</p></td>"
        strHeading &= "<td width=""33%"" bgcolor=""#C0C0C0""><p align=""right""><b>Date:</b> " & Now & "</p></td>"
        strHeading &= "</tr>"
        strHeading &= "</table>"

        With nvCollection
            .Add("Program Name", strExeName)
            .Add("Program Version", strExeVersion)

            

            .Add("Error Message", ScrubHTML(m_exObject.Message))
            .Add("Error Source", m_exObject.Source)

            .Add("------Stack Trace-------", "First to Last Sequence - excludes Inner Exceptions")

            Dim st As New StackTrace(CType(m_exObject, System.Exception), True)
            Dim x As Integer = 0
            ' Get the stack frame in reverse order...
            ' So that the originating error is shown first
            For i = st.FrameCount - 1 To 0 Step -1
                Dim sf As StackFrame = st.GetFrame(i)
                Dim mi As System.Reflection.MemberInfo = sf.GetMethod
                .Add(CStr(x + 1) & "-Name Space", mi.DeclaringType.Namespace)
                .Add(CStr(x + 1) & "-Class Name", mi.DeclaringType.Name)
                .Add(CStr(x + 1) & "-Method", mi.Name)
                Dim objParameters() As System.Reflection.ParameterInfo = sf.GetMethod.GetParameters()
                Dim objParameter As System.Reflection.ParameterInfo
                strValueLine = "("
                For Each objParameter In objParameters
                    If strValueLine.Length <> 1 Then
                        strValueLine &= ", "
                    End If
                    strValueLine &= objParameter.Name & " As " & _
                        ScrubHTML(objParameter.ParameterType.Name)
                Next
                strValueLine &= ")"
                .Add(CStr(x + 1) & "-Parameters", strValueLine)

                If sf.GetFileName <> "" Then
                    .Add(CStr(x + 1) & "-FileName", sf.GetFileName)
                    .Add(CStr(x + 1) & "-Error Location", "Line " & sf.GetFileLineNumber & ", Col " & sf.GetFileColumnNumber)
                End If

                .Add(CStr(x + 1) & "-------End Group------", "")
                x += 1
            Next


            If m_strActiveControl.Length > 0 Then
                .Add("Active Control", m_strActiveControl)
            End If
            If m_strOtherInfoNote.Length > 0 Then
                .Add("Note", m_strOtherInfoNote)
            End If

            .Add("------Stack Dump-------", "Last to First Sequence - includes Inner Exceptions")

            i = 0
            Dim currEx As System.Exception = m_exObject
            Do While Not currEx Is Nothing
                .Add(CStr(i + 1) & "-Error Message", ScrubHTML(currEx.Message))
                .Add(CStr(i + 1) & "-Error Source", currEx.Source)
                .Add(CStr(i + 1) & "-Error Full Name", currEx.GetType.FullName)
                .Add(CStr(i + 1) & "-TargetSite", ScrubHTML(currEx.TargetSite.ToString))
                .Add(CStr(i + 1) & "-StackTrace", ScrubHTML(currEx.StackTrace.ToString))
                currEx = currEx.InnerException
                i += 1
            Loop
        End With

        strHtmlText &= strHeading
        strHtmlText &= ConvertCollectionToHtml(nvCollection)

        strHeading = "<table border=""0"" width=""100%"" cellpadding=""1"" cellspacing=""0""> "
        strHeading &= "<tr>"
        strHeading &= "<td bgcolor=""Black"" colspan=""2"">"
        strHeading &= "<p align=""center""><b><font face=""Arial"" color=""white"">Environment Related Information</font></b></p> "
        strHeading &= "</td> "
        strHeading &= "</tr> "
        strHeading &= "</table> "

        nvCollection.Clear()

        With nvCollection
            .Add("Machine Name", Environment.MachineName)
            .Add("Domain Name", Environment.UserDomainName)
            .Add("Current Directory", Environment.CurrentDirectory)
            .Add("Screen Size", SystemInformation.PrimaryMonitorSize.ToString)
            .Add("Network", SystemInformation.Network.ToString())
            .Add("Command Line ", Environment.CommandLine)
            .Add("OS Version", Environment.OSVersion.ToString)
            .Add("CLR Version", Environment.Version.ToString)
        End With

        Dim mos As New ManagementObjectSearcher
        Dim mosQuery As New SelectQuery
        Dim mo As ManagementObject
        mosQuery.QueryString = "SELECT * FROM Win32_ComputerSystem"
        mos.Query = mosQuery
        Dim lngLargeNr As Long
        i = 0
        ' Get the physical memory for each processor
        For Each mo In mos.Get()
            lngLargeNr = Long.Parse(mo("TotalPhysicalMemory").ToString)
            nvCollection.Add("Physical Memory" & CStr(i + 1), FormatSize(lngLargeNr)) 'Long
            i += 1
        Next

        mosQuery.QueryString = "SELECT * FROM Win32_OperatingSystem"
        mos.Query = mosQuery
        i = 0
        ' Get the free physical memory for each processor
        For Each mo In mos.Get()
            lngLargeNr = Long.Parse(mo("FreePhysicalMemory").ToString)
            nvCollection.Add("Free Memory" & CStr(i + 1), FormatSize(lngLargeNr)) 'Long
            i += 1
        Next

        nvCollection.Add("Memory Mapped", FormatSize(Environment.WorkingSet)) 'Long
        ' 
        Dim curProc As Process = Process.GetCurrentProcess()
        With curProc
            'The total working set of the current process is:
            nvCollection.Add("Memory Used", FormatSize(.WorkingSet)) 'Long

            nvCollection.Add("Virtual Memory Used", FormatSize(.VirtualMemorySize)) 'Long
            nvCollection.Add("Virtual Memory Peak", FormatSize(.PeakVirtualMemorySize)) 'Long
            ' The following Process Info is available but not all that usefull...
            ''The minimum working set of the current process is:
            'lngLargeNr = Long.Parse(.MinWorkingSet.ToString)
            'nvCollection.Add("Min WorkingSet", FormatSize(lngLargeNr))
            ''The max working set of the current process is:
            'lngLargeNr = Long.Parse(.MaxWorkingSet.ToString)
            'nvCollection.Add("Max WorkingSet", FormatSize(lngLargeNr))

            'The Start time of the current process is:
            nvCollection.Add("Start Time", .StartTime.ToLongTimeString)
            'The processor time used by the current process is:
            nvCollection.Add("Processor Time", .TotalProcessorTime.ToString)

        End With

        mosQuery.QueryString = "Select Name, Size, FreeSpace from Win32_LogicalDisk where DriveType=3"
        mos.Query = mosQuery

        i = 0
        For Each mo In mos.Get()
            lngLargeNr = Long.Parse(mo("Size").ToString)
            strValueLine = mo("Name").ToString() & " Size = " & FormatSize(lngLargeNr)
            lngLargeNr = Long.Parse(mo("FreeSpace").ToString)
            strValueLine &= ", Free Space = " & FormatSize(lngLargeNr)
            nvCollection.Add("Disk" & CStr(i + 1), strValueLine) 'Long
            i += 1
        Next

        mosQuery = Nothing
        mos.Dispose()
        mos = Nothing
        '         
        nvCollection.Add("----Running Tasks-----", "")
        Dim intTotModMem As Integer = 0
        Dim intMaxUsed As Integer = 0

        Dim strHiglightKey As String
        i = 0
        Dim proc As Process
        For Each proc In Process.GetProcesses
            proc.Refresh()
            strValueLine = " ID#: " & proc.Id.ToString & _
                           ", Memory: " & FormatSize(proc.WorkingSet)
            nvCollection.Add(proc.ProcessName, strValueLine)
            i += 1
            If proc.WorkingSet > intMaxUsed Then
                intMaxUsed = proc.WorkingSet
                strHiglightKey = proc.ProcessName
            End If

            intTotModMem += proc.WorkingSet
        Next

        nvCollection.Add("------Total Memory------", FormatSize(intTotModMem) & "   Note: Max Task is in Red*")

        strHtmlText &= strHeading
        strHtmlText &= ConvertCollectionToHtml(nvCollection, strHiglightKey)

        strHtmlText &= "<p align=""Left""><font face=""Arial"" size=""2"" color=""red"">" & _
                        "Please use the Browser's Email 'Send Page' function to send this report to the System Administrator</font></p>"

        nvCollection.Clear()
        nvCollection = Nothing

        Return strHtmlText

    End Function

#End Region         'Generate the HTML code

#Region "Convert the contents of the Collection to HTML"
    Private Function ConvertCollectionToHtml(ByVal nvCol As NameValueCollection, Optional ByVal sHiliteKey As String = "") As String 'System.Text.StringBuilder()
        Dim strTableCell1, strTableCell2 As String
        Dim sbHtmlText As New System.Text.StringBuilder(1000)
        Dim i As Integer, strForeColor As String
        Dim strColorRed As String = "Color=" & Chr(34) & "Red" & Chr(34)
        Dim strColorBlack As String = "Color=" & Chr(34) & "Black" & Chr(34)
        Dim strNoteFlag As String = ""

        strTableCell1 = "<TD Width=""20%""><FONT face=""Arial"" size=""2"" <!--COLOR--> ><!--VALUE--></FONT></TD>"
        strTableCell2 = "<TD Width=""80%""><FONT face=""Arial"" size=""2"" <!--COLOR--> ><!--VALUE--></FONT></TD>"

        sbHtmlText.Append("<TABLE width=""100%"">" & " <TR bgcolor=""#C0C0C0"">" & _
        strTableCell1.Replace("<!--VALUE-->", " <B>Name</B>").Replace("<!--COLOR-->", strColorBlack) & " " & _
        strTableCell2.Replace("<!--VALUE-->", " <B>Value</B>").Replace("<!--COLOR-->", strColorBlack) & "</TR> ")

        'No Body? -> N/A
        If (nvCol.Count <= 0) Then
            nvCol = New NameValueCollection
            nvCol.Add("N/A", "")
        End If
        'Table Body
        For i = 0 To nvCol.Count - 1
            If sHiliteKey = nvCol.Keys(i) Then
                strForeColor = strColorRed
                strNoteFlag = "*"
            Else
                strForeColor = strColorBlack
                strNoteFlag = ""
            End If

            sbHtmlText.Append("<TR valign=""top"" bgcolor=""#EEEEEE"">" & _
            strTableCell1.Replace("<!--VALUE-->", nvCol.Keys(i) & strNoteFlag).Replace("<!--COLOR-->", strForeColor) & " " & _
            strTableCell2.Replace("<!--VALUE-->", nvCol(i)).Replace("<!--COLOR-->", strForeColor) & "</TR> ")
        Next i

        'Table Footer
        sbHtmlText.Append("</TABLE>")
        ConvertCollectionToHtml = sbHtmlText.ToString
        sbHtmlText = Nothing


    End Function
#End Region 'Convert the contents of the Collection to HTML

#Region "Helper Routines"
    ' Finds the requested MS Application & return it location
    Function GetApplicationPath(ByVal sExeName As String) As String
        Dim regKey As Microsoft.Win32.RegistryKey
        Try
            regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey( _
                "Software\Microsoft\Windows\CurrentVersion\App Paths\" & sExeName)
            Return regKey.GetValue("").ToString()
        Catch ex As ArgumentNullException
            MsgBox("El argumento hizo referencia a un objeto cuyo estado es nulo.", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        Catch ex As ArgumentException
            MsgBox("El argumento supera la longitud máxima permitida (255 caracteres).", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        Catch ex As Security.SecurityException
            MsgBox("El usuario no tiene los permisos necesarios para leer la clave del Registro.", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        Catch e As System.Exception
            Return ""
        Finally
            If Not regKey Is Nothing Then regKey.Close()
        End Try
    End Function

    ' Replace any conflicting values with there HTML counterpart
    Private Function ScrubHTML(ByVal sStringInput As String) As String
        Dim i As Integer, strInputLine As String
        If sStringInput.Length <> 0 Then
            strInputLine = sStringInput
            Dim strScanValue() As String = {"&", "<", ">", "(\r\n)|(\n\r)"}
            Dim strHTMLValue() As String = {"&amp;", "&lt;", "&gt;", "<BR>"}
            For i = 0 To UBound(strScanValue)
                strInputLine = m_objRegEx.Replace(strInputLine, strScanValue(i), strHTMLValue(i), RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            Next i
            Return strInputLine
        Else
            Return ""
        End If

    End Function
    ' Format Memory and Disk space values...
    Private Function FormatSize(ByVal lValue As Long) As String
        Dim decValue As Decimal
        Try
            decValue = CDec(lValue / 1024)
        Catch ex As ArgumentNullException
            MsgBox("El argumento hizo referencia a un objeto cuyo estado es nulo.", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        Catch ex As FormatException
            MsgBox("El formato de la cadena a convertir no es válido", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        Catch ex As OverflowException
            MsgBox("La cadena a convertir representa un número menor que MinValue o mayor que MaxValue.", MsgBoxStyle.OkOnly, "Gasolutions Ltda")
        Catch ex As System.Exception
            decValue = 0
        End Try
        Return decValue.ToString("N0") & "K"
    End Function
#End Region     'Helper Routines
End Class


