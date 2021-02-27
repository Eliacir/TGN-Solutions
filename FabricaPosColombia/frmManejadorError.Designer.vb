<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManejadorError
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtbErrMessage = New System.Windows.Forms.RichTextBox
        Me.lblTime = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.lblUserID = New System.Windows.Forms.Label
        Me.lblErrMsgHeader = New System.Windows.Forms.Label
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdAbort = New System.Windows.Forms.Button
        Me.lblRetries = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'rtbErrMessage
        '
        Me.rtbErrMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbErrMessage.Location = New System.Drawing.Point(33, 125)
        Me.rtbErrMessage.Name = "rtbErrMessage"
        Me.rtbErrMessage.ReadOnly = True
        Me.rtbErrMessage.Size = New System.Drawing.Size(438, 157)
        Me.rtbErrMessage.TabIndex = 32
        Me.rtbErrMessage.Text = ""
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.Color.Transparent
        Me.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTime.Location = New System.Drawing.Point(262, 79)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(216, 20)
        Me.lblTime.TabIndex = 38
        Me.lblTime.Text = "Hora:"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblDate.Location = New System.Drawing.Point(27, 79)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(232, 20)
        Me.lblDate.TabIndex = 37
        Me.lblDate.Text = "Fecha:"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(24, 34)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(457, 40)
        Me.lblHeader.TabIndex = 36
        Me.lblHeader.Text = "Problema Identificado"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHeader.UseMnemonic = False
        '
        'lblUserID
        '
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblUserID.Location = New System.Drawing.Point(27, 293)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(232, 20)
        Me.lblUserID.TabIndex = 33
        Me.lblUserID.Text = "User ID:"
        Me.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrMsgHeader
        '
        Me.lblErrMsgHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.lblErrMsgHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblErrMsgHeader.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrMsgHeader.ForeColor = System.Drawing.Color.White
        Me.lblErrMsgHeader.Location = New System.Drawing.Point(25, 101)
        Me.lblErrMsgHeader.Name = "lblErrMsgHeader"
        Me.lblErrMsgHeader.Size = New System.Drawing.Size(456, 189)
        Me.lblErrMsgHeader.TabIndex = 31
        Me.lblErrMsgHeader.Text = "Mensaje"
        Me.lblErrMsgHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblErrMsgHeader.UseMnemonic = False
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(27, 316)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(79, 24)
        Me.cmdReport.TabIndex = 30
        Me.cmdReport.Text = "&Informar"
        '
        'cmdAbort
        '
        Me.cmdAbort.Location = New System.Drawing.Point(112, 316)
        Me.cmdAbort.Name = "cmdAbort"
        Me.cmdAbort.Size = New System.Drawing.Size(79, 24)
        Me.cmdAbort.TabIndex = 28
        Me.cmdAbort.Text = "&Cancelar"
        '
        'lblRetries
        '
        Me.lblRetries.BackColor = System.Drawing.Color.Transparent
        Me.lblRetries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRetries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetries.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblRetries.Location = New System.Drawing.Point(262, 293)
        Me.lblRetries.Name = "lblRetries"
        Me.lblRetries.Size = New System.Drawing.Size(216, 20)
        Me.lblRetries.TabIndex = 34
        Me.lblRetries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRetries.UseMnemonic = False
        '
        'frmManejadorError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(513, 351)
        Me.Controls.Add(Me.rtbErrMessage)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblRetries)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.lblErrMsgHeader)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdAbort)
        Me.Name = "frmManejadorError"
        Me.Text = "Envie esta información a GASOLUTIONS LTDA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbErrMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents lblErrMsgHeader As System.Windows.Forms.Label
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdAbort As System.Windows.Forms.Button
    Friend WithEvents lblRetries As System.Windows.Forms.Label
End Class
