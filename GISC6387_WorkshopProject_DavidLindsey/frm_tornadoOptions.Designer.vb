<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_tornadoOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txt_torn_outputFolderpath = New System.Windows.Forms.TextBox()
        Me.btn_torn_options_Cancel = New System.Windows.Forms.Button()
        Me.btn_torn_options_OK = New System.Windows.Forms.Button()
        Me.btn_torn_options_browse = New System.Windows.Forms.Button()
        Me.lbl_torn_options_outputPath = New System.Windows.Forms.Label()
        Me.cb_torn_options_timespan = New System.Windows.Forms.ComboBox()
        Me.lbl_torn_options_timespan = New System.Windows.Forms.Label()
        Me.txt_torn_url = New System.Windows.Forms.TextBox()
        Me.lbl_torn_options_url = New System.Windows.Forms.Label()
        Me.lbl_torn_message = New System.Windows.Forms.Label()
        Me.checkbox_torn_addData = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txt_torn_outputFolderpath
        '
        Me.txt_torn_outputFolderpath.Location = New System.Drawing.Point(100, 149)
        Me.txt_torn_outputFolderpath.Name = "txt_torn_outputFolderpath"
        Me.txt_torn_outputFolderpath.ReadOnly = True
        Me.txt_torn_outputFolderpath.Size = New System.Drawing.Size(216, 20)
        Me.txt_torn_outputFolderpath.TabIndex = 17
        '
        'btn_torn_options_Cancel
        '
        Me.btn_torn_options_Cancel.Location = New System.Drawing.Point(247, 225)
        Me.btn_torn_options_Cancel.Name = "btn_torn_options_Cancel"
        Me.btn_torn_options_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_torn_options_Cancel.TabIndex = 16
        Me.btn_torn_options_Cancel.Text = "Cancel"
        Me.btn_torn_options_Cancel.UseVisualStyleBackColor = True
        '
        'btn_torn_options_OK
        '
        Me.btn_torn_options_OK.Location = New System.Drawing.Point(150, 225)
        Me.btn_torn_options_OK.Name = "btn_torn_options_OK"
        Me.btn_torn_options_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_torn_options_OK.TabIndex = 15
        Me.btn_torn_options_OK.Text = "OK"
        Me.btn_torn_options_OK.UseVisualStyleBackColor = True
        '
        'btn_torn_options_browse
        '
        Me.btn_torn_options_browse.Location = New System.Drawing.Point(19, 147)
        Me.btn_torn_options_browse.Name = "btn_torn_options_browse"
        Me.btn_torn_options_browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_torn_options_browse.TabIndex = 14
        Me.btn_torn_options_browse.Text = "Browse..."
        Me.btn_torn_options_browse.UseVisualStyleBackColor = True
        '
        'lbl_torn_options_outputPath
        '
        Me.lbl_torn_options_outputPath.AutoSize = True
        Me.lbl_torn_options_outputPath.Location = New System.Drawing.Point(16, 130)
        Me.lbl_torn_options_outputPath.Name = "lbl_torn_options_outputPath"
        Me.lbl_torn_options_outputPath.Size = New System.Drawing.Size(131, 13)
        Me.lbl_torn_options_outputPath.TabIndex = 13
        Me.lbl_torn_options_outputPath.Text = "Select Folder to Save File:"
        '
        'cb_torn_options_timespan
        '
        Me.cb_torn_options_timespan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_torn_options_timespan.FormattingEnabled = True
        Me.cb_torn_options_timespan.Location = New System.Drawing.Point(19, 34)
        Me.cb_torn_options_timespan.Name = "cb_torn_options_timespan"
        Me.cb_torn_options_timespan.Size = New System.Drawing.Size(93, 21)
        Me.cb_torn_options_timespan.TabIndex = 11
        '
        'lbl_torn_options_timespan
        '
        Me.lbl_torn_options_timespan.AutoSize = True
        Me.lbl_torn_options_timespan.Location = New System.Drawing.Point(16, 16)
        Me.lbl_torn_options_timespan.Name = "lbl_torn_options_timespan"
        Me.lbl_torn_options_timespan.Size = New System.Drawing.Size(89, 13)
        Me.lbl_torn_options_timespan.TabIndex = 9
        Me.lbl_torn_options_timespan.Text = "Select Timespan:"
        '
        'txt_torn_url
        '
        Me.txt_torn_url.Location = New System.Drawing.Point(19, 89)
        Me.txt_torn_url.Name = "txt_torn_url"
        Me.txt_torn_url.ReadOnly = True
        Me.txt_torn_url.Size = New System.Drawing.Size(297, 20)
        Me.txt_torn_url.TabIndex = 18
        '
        'lbl_torn_options_url
        '
        Me.lbl_torn_options_url.AutoSize = True
        Me.lbl_torn_options_url.Location = New System.Drawing.Point(16, 72)
        Me.lbl_torn_options_url.Name = "lbl_torn_options_url"
        Me.lbl_torn_options_url.Size = New System.Drawing.Size(102, 13)
        Me.lbl_torn_options_url.TabIndex = 19
        Me.lbl_torn_options_url.Text = "URL Download File:"
        '
        'lbl_torn_message
        '
        Me.lbl_torn_message.AutoSize = True
        Me.lbl_torn_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_torn_message.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbl_torn_message.Location = New System.Drawing.Point(61, 186)
        Me.lbl_torn_message.Name = "lbl_torn_message"
        Me.lbl_torn_message.Size = New System.Drawing.Size(206, 16)
        Me.lbl_torn_message.TabIndex = 23
        Me.lbl_torn_message.Text = "...Processing...Please Wait..."
        '
        'checkbox_torn_addData
        '
        Me.checkbox_torn_addData.AutoSize = True
        Me.checkbox_torn_addData.Location = New System.Drawing.Point(12, 232)
        Me.checkbox_torn_addData.Name = "checkbox_torn_addData"
        Me.checkbox_torn_addData.Size = New System.Drawing.Size(97, 17)
        Me.checkbox_torn_addData.TabIndex = 24
        Me.checkbox_torn_addData.Text = "Add to ArcMap"
        Me.checkbox_torn_addData.UseVisualStyleBackColor = True
        '
        'frm_tornadoOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 261)
        Me.Controls.Add(Me.checkbox_torn_addData)
        Me.Controls.Add(Me.lbl_torn_message)
        Me.Controls.Add(Me.lbl_torn_options_url)
        Me.Controls.Add(Me.txt_torn_url)
        Me.Controls.Add(Me.txt_torn_outputFolderpath)
        Me.Controls.Add(Me.btn_torn_options_Cancel)
        Me.Controls.Add(Me.btn_torn_options_OK)
        Me.Controls.Add(Me.btn_torn_options_browse)
        Me.Controls.Add(Me.lbl_torn_options_outputPath)
        Me.Controls.Add(Me.cb_torn_options_timespan)
        Me.Controls.Add(Me.lbl_torn_options_timespan)
        Me.Name = "frm_tornadoOptions"
        Me.Text = "Tornado Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_torn_outputFolderpath As Windows.Forms.TextBox
    Friend WithEvents btn_torn_options_Cancel As Windows.Forms.Button
    Friend WithEvents btn_torn_options_OK As Windows.Forms.Button
    Friend WithEvents btn_torn_options_browse As Windows.Forms.Button
    Friend WithEvents lbl_torn_options_outputPath As Windows.Forms.Label
    Friend WithEvents cb_torn_options_timespan As Windows.Forms.ComboBox
    Friend WithEvents lbl_torn_options_timespan As Windows.Forms.Label
    Friend WithEvents txt_torn_url As Windows.Forms.TextBox
    Friend WithEvents lbl_torn_options_url As Windows.Forms.Label
    Friend WithEvents lbl_torn_message As Windows.Forms.Label
    Friend WithEvents checkbox_torn_addData As Windows.Forms.CheckBox
End Class
