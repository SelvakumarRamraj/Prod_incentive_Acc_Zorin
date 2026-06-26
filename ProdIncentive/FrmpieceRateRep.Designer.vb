<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmpieceRateRep
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Mskdateto = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mskdatefr = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.btnxl = New System.Windows.Forms.Button()
        Me.btndisp = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.Chkday = New System.Windows.Forms.CheckBox()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Mskdateto
        '
        Me.Mskdateto.Location = New System.Drawing.Point(212, 23)
        Me.Mskdateto.Mask = "##-##-####"
        Me.Mskdateto.Name = "Mskdateto"
        Me.Mskdateto.Size = New System.Drawing.Size(72, 20)
        Me.Mskdateto.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(184, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "To"
        '
        'mskdatefr
        '
        Me.mskdatefr.Location = New System.Drawing.Point(106, 23)
        Me.mskdatefr.Mask = "##-##-####"
        Me.mskdatefr.Name = "mskdatefr"
        Me.mskdatefr.Size = New System.Drawing.Size(72, 20)
        Me.mskdatefr.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Date From"
        '
        'Dg
        '
        Me.Dg.AllowUserToAddRows = False
        Me.Dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg.Location = New System.Drawing.Point(12, 68)
        Me.Dg.Name = "Dg"
        Me.Dg.Size = New System.Drawing.Size(1146, 518)
        Me.Dg.TabIndex = 13
        '
        'btnxl
        '
        Me.btnxl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxl.Location = New System.Drawing.Point(575, 27)
        Me.btnxl.Name = "btnxl"
        Me.btnxl.Size = New System.Drawing.Size(103, 23)
        Me.btnxl.TabIndex = 19
        Me.btnxl.Text = "Excel Export"
        Me.btnxl.UseVisualStyleBackColor = True
        '
        'btndisp
        '
        Me.btndisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndisp.Location = New System.Drawing.Point(494, 27)
        Me.btndisp.Name = "btndisp"
        Me.btndisp.Size = New System.Drawing.Size(75, 23)
        Me.btndisp.TabIndex = 18
        Me.btndisp.Text = "Display"
        Me.btndisp.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(684, 27)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 20
        Me.btnexit.Text = "Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'Chkday
        '
        Me.Chkday.AutoSize = True
        Me.Chkday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkday.Location = New System.Drawing.Point(349, 27)
        Me.Chkday.Name = "Chkday"
        Me.Chkday.Size = New System.Drawing.Size(73, 17)
        Me.Chkday.TabIndex = 21
        Me.Chkday.Text = "Daywise"
        Me.Chkday.UseVisualStyleBackColor = True
        '
        'FrmpieceRateRep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 731)
        Me.Controls.Add(Me.Chkday)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.btnxl)
        Me.Controls.Add(Me.btndisp)
        Me.Controls.Add(Me.Dg)
        Me.Controls.Add(Me.Mskdateto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mskdatefr)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmpieceRateRep"
        Me.Text = "FrmpieceRateRep"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Mskdateto As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents mskdatefr As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Dg As DataGridView
    Friend WithEvents btnxl As Button
    Friend WithEvents btndisp As Button
    Friend WithEvents btnexit As Button
    Friend WithEvents Chkday As CheckBox
End Class
