<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_hurricaneOptions
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
        Me.lbl_hurr_options_url = New System.Windows.Forms.Label()
        Me.txt_hurr_url = New System.Windows.Forms.TextBox()
        Me.txt_hurr_outputFolderpath = New System.Windows.Forms.TextBox()
        Me.btn_hurr_options_Cancel = New System.Windows.Forms.Button()
        Me.btn_hurr_options_OK = New System.Windows.Forms.Button()
        Me.btn_hurr_options_browse = New System.Windows.Forms.Button()
        Me.lbl_hurr_options_outputPath = New System.Windows.Forms.Label()
        Me.cb_hurr_options_timespan = New System.Windows.Forms.ComboBox()
        Me.lbl_hurr_options_timespan = New System.Windows.Forms.Label()
        Me.lbl_hurr_message = New System.Windows.Forms.Label()
        Me.checkbox_hurr_addData = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lbl_hurr_options_url
        '
        Me.lbl_hurr_options_url.AutoSize = True
        Me.lbl_hurr_options_url.Location = New System.Drawing.Point(19, 78)
        Me.lbl_hurr_options_url.Name = "lbl_hurr_options_url"
        Me.lbl_hurr_options_url.Size = New System.Drawing.Size(102, 13)
        Me.lbl_hurr_options_url.TabIndex = 30
        Me.lbl_hurr_options_url.Text = "URL Download File:"
        '
        'txt_hurr_url
        '
        Me.txt_hurr_url.Location = New System.Drawing.Point(22, 96)
        Me.txt_hurr_url.Name = "txt_hurr_url"
        Me.txt_hurr_url.ReadOnly = True
        Me.txt_hurr_url.Size = New System.Drawing.Size(314, 20)
        Me.txt_hurr_url.TabIndex = 29
        '
        'txt_hurr_outputFolderpath
        '
        Me.txt_hurr_outputFolderpath.Location = New System.Drawing.Point(105, 160)
        Me.txt_hurr_outputFolderpath.Name = "txt_hurr_outputFolderpath"
        Me.txt_hurr_outputFolderpath.ReadOnly = True
        Me.txt_hurr_outputFolderpath.Size = New System.Drawing.Size(231, 20)
        Me.txt_hurr_outputFolderpath.TabIndex = 28
        '
        'btn_hurr_options_Cancel
        '
        Me.btn_hurr_options_Cancel.Location = New System.Drawing.Point(261, 226)
        Me.btn_hurr_options_Cancel.Name = "btn_hurr_options_Cancel"
        Me.btn_hurr_options_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_hurr_options_Cancel.TabIndex = 27
        Me.btn_hurr_options_Cancel.Text = "Cancel"
        Me.btn_hurr_options_Cancel.UseVisualStyleBackColor = True
        '
        'btn_hurr_options_OK
        '
        Me.btn_hurr_options_OK.Location = New System.Drawing.Point(164, 226)
        Me.btn_hurr_options_OK.Name = "btn_hurr_options_OK"
        Me.btn_hurr_options_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_hurr_options_OK.TabIndex = 26
        Me.btn_hurr_options_OK.Text = "OK"
        Me.btn_hurr_options_OK.UseVisualStyleBackColor = True
        '
        'btn_hurr_options_browse
        '
        Me.btn_hurr_options_browse.Location = New System.Drawing.Point(22, 158)
        Me.btn_hurr_options_browse.Name = "btn_hurr_options_browse"
        Me.btn_hurr_options_browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_hurr_options_browse.TabIndex = 25
        Me.btn_hurr_options_browse.Text = "Browse..."
        Me.btn_hurr_options_browse.UseVisualStyleBackColor = True
        '
        'lbl_hurr_options_outputPath
        '
        Me.lbl_hurr_options_outputPath.AutoSize = True
        Me.lbl_hurr_options_outputPath.Location = New System.Drawing.Point(19, 142)
        Me.lbl_hurr_options_outputPath.Name = "lbl_hurr_options_outputPath"
        Me.lbl_hurr_options_outputPath.Size = New System.Drawing.Size(131, 13)
        Me.lbl_hurr_options_outputPath.TabIndex = 24
        Me.lbl_hurr_options_outputPath.Text = "Select Folder to Save File:"
        '
        'cb_hurr_options_timespan
        '
        Me.cb_hurr_options_timespan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_hurr_options_timespan.FormattingEnabled = True
        Me.cb_hurr_options_timespan.Location = New System.Drawing.Point(22, 37)
        Me.cb_hurr_options_timespan.Name = "cb_hurr_options_timespan"
        Me.cb_hurr_options_timespan.Size = New System.Drawing.Size(93, 21)
        Me.cb_hurr_options_timespan.TabIndex = 23
        '
        'lbl_hurr_options_timespan
        '
        Me.lbl_hurr_options_timespan.AutoSize = True
        Me.lbl_hurr_options_timespan.Location = New System.Drawing.Point(19, 21)
        Me.lbl_hurr_options_timespan.Name = "lbl_hurr_options_timespan"
        Me.lbl_hurr_options_timespan.Size = New System.Drawing.Size(89, 13)
        Me.lbl_hurr_options_timespan.TabIndex = 22
        Me.lbl_hurr_options_timespan.Text = "Select Timespan:"
        '
        'lbl_hurr_message
        '
        Me.lbl_hurr_message.AutoSize = True
        Me.lbl_hurr_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hurr_message.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbl_hurr_message.Location = New System.Drawing.Point(71, 194)
        Me.lbl_hurr_message.Name = "lbl_hurr_message"
        Me.lbl_hurr_message.Size = New System.Drawing.Size(206, 16)
        Me.lbl_hurr_message.TabIndex = 31
        Me.lbl_hurr_message.Text = "...Processing...Please Wait..."
        '
        'checkbox_hurr_addData
        '
        Me.checkbox_hurr_addData.AutoSize = True
        Me.checkbox_hurr_addData.Location = New System.Drawing.Point(12, 232)
        Me.checkbox_hurr_addData.Name = "checkbox_hurr_addData"
        Me.checkbox_hurr_addData.Size = New System.Drawing.Size(97, 17)
        Me.checkbox_hurr_addData.TabIndex = 32
        Me.checkbox_hurr_addData.Text = "Add to ArcMap"
        Me.checkbox_hurr_addData.UseVisualStyleBackColor = True
        '
        'frm_hurricaneOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 261)
        Me.Controls.Add(Me.checkbox_hurr_addData)
        Me.Controls.Add(Me.lbl_hurr_message)
        Me.Controls.Add(Me.lbl_hurr_options_url)
        Me.Controls.Add(Me.txt_hurr_url)
        Me.Controls.Add(Me.txt_hurr_outputFolderpath)
        Me.Controls.Add(Me.btn_hurr_options_Cancel)
        Me.Controls.Add(Me.btn_hurr_options_OK)
        Me.Controls.Add(Me.btn_hurr_options_browse)
        Me.Controls.Add(Me.lbl_hurr_options_outputPath)
        Me.Controls.Add(Me.cb_hurr_options_timespan)
        Me.Controls.Add(Me.lbl_hurr_options_timespan)
        Me.Name = "frm_hurricaneOptions"
        Me.Text = "Hurricane Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_hurr_options_url As Windows.Forms.Label
    Friend WithEvents txt_hurr_url As Windows.Forms.TextBox
    Friend WithEvents txt_hurr_outputFolderpath As Windows.Forms.TextBox
    Friend WithEvents btn_hurr_options_Cancel As Windows.Forms.Button
    Friend WithEvents btn_hurr_options_OK As Windows.Forms.Button
    Friend WithEvents btn_hurr_options_browse As Windows.Forms.Button
    Friend WithEvents lbl_hurr_options_outputPath As Windows.Forms.Label
    Friend WithEvents cb_hurr_options_timespan As Windows.Forms.ComboBox
    Friend WithEvents lbl_hurr_options_timespan As Windows.Forms.Label
    Friend WithEvents lbl_hurr_message As Windows.Forms.Label
    Friend WithEvents checkbox_hurr_addData As Windows.Forms.CheckBox
End Class
