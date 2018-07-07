<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_hailOptions
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
        Me.lbl_hail_options_url = New System.Windows.Forms.Label()
        Me.txt_hail_url = New System.Windows.Forms.TextBox()
        Me.txt_hail_outputFolderpath = New System.Windows.Forms.TextBox()
        Me.btn_hail_options_Cancel = New System.Windows.Forms.Button()
        Me.btn_hail_options_OK = New System.Windows.Forms.Button()
        Me.btn_hail_options_browse = New System.Windows.Forms.Button()
        Me.lbl_hail_options_outputPath = New System.Windows.Forms.Label()
        Me.cb_hail_options_timespan = New System.Windows.Forms.ComboBox()
        Me.lbl_hail_options_timespan = New System.Windows.Forms.Label()
        Me.lbl_hail_message = New System.Windows.Forms.Label()
        Me.checkbox_hail_addData = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lbl_hail_options_url
        '
        Me.lbl_hail_options_url.AutoSize = True
        Me.lbl_hail_options_url.Location = New System.Drawing.Point(25, 77)
        Me.lbl_hail_options_url.Name = "lbl_hail_options_url"
        Me.lbl_hail_options_url.Size = New System.Drawing.Size(102, 13)
        Me.lbl_hail_options_url.TabIndex = 28
        Me.lbl_hail_options_url.Text = "URL Download File:"
        '
        'txt_hail_url
        '
        Me.txt_hail_url.Location = New System.Drawing.Point(28, 94)
        Me.txt_hail_url.Name = "txt_hail_url"
        Me.txt_hail_url.ReadOnly = True
        Me.txt_hail_url.Size = New System.Drawing.Size(297, 20)
        Me.txt_hail_url.TabIndex = 27
        '
        'txt_hail_outputFolderpath
        '
        Me.txt_hail_outputFolderpath.Location = New System.Drawing.Point(109, 154)
        Me.txt_hail_outputFolderpath.Name = "txt_hail_outputFolderpath"
        Me.txt_hail_outputFolderpath.ReadOnly = True
        Me.txt_hail_outputFolderpath.Size = New System.Drawing.Size(216, 20)
        Me.txt_hail_outputFolderpath.TabIndex = 26
        '
        'btn_hail_options_Cancel
        '
        Me.btn_hail_options_Cancel.Location = New System.Drawing.Point(256, 224)
        Me.btn_hail_options_Cancel.Name = "btn_hail_options_Cancel"
        Me.btn_hail_options_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_hail_options_Cancel.TabIndex = 25
        Me.btn_hail_options_Cancel.Text = "Cancel"
        Me.btn_hail_options_Cancel.UseVisualStyleBackColor = True
        '
        'btn_hail_options_OK
        '
        Me.btn_hail_options_OK.Location = New System.Drawing.Point(159, 224)
        Me.btn_hail_options_OK.Name = "btn_hail_options_OK"
        Me.btn_hail_options_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_hail_options_OK.TabIndex = 24
        Me.btn_hail_options_OK.Text = "OK"
        Me.btn_hail_options_OK.UseVisualStyleBackColor = True
        '
        'btn_hail_options_browse
        '
        Me.btn_hail_options_browse.Location = New System.Drawing.Point(28, 152)
        Me.btn_hail_options_browse.Name = "btn_hail_options_browse"
        Me.btn_hail_options_browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_hail_options_browse.TabIndex = 23
        Me.btn_hail_options_browse.Text = "Browse..."
        Me.btn_hail_options_browse.UseVisualStyleBackColor = True
        '
        'lbl_hail_options_outputPath
        '
        Me.lbl_hail_options_outputPath.AutoSize = True
        Me.lbl_hail_options_outputPath.Location = New System.Drawing.Point(25, 135)
        Me.lbl_hail_options_outputPath.Name = "lbl_hail_options_outputPath"
        Me.lbl_hail_options_outputPath.Size = New System.Drawing.Size(131, 13)
        Me.lbl_hail_options_outputPath.TabIndex = 22
        Me.lbl_hail_options_outputPath.Text = "Select Folder to Save File:"
        '
        'cb_hail_options_timespan
        '
        Me.cb_hail_options_timespan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_hail_options_timespan.FormattingEnabled = True
        Me.cb_hail_options_timespan.Location = New System.Drawing.Point(28, 39)
        Me.cb_hail_options_timespan.Name = "cb_hail_options_timespan"
        Me.cb_hail_options_timespan.Size = New System.Drawing.Size(93, 21)
        Me.cb_hail_options_timespan.TabIndex = 21
        '
        'lbl_hail_options_timespan
        '
        Me.lbl_hail_options_timespan.AutoSize = True
        Me.lbl_hail_options_timespan.Location = New System.Drawing.Point(25, 21)
        Me.lbl_hail_options_timespan.Name = "lbl_hail_options_timespan"
        Me.lbl_hail_options_timespan.Size = New System.Drawing.Size(89, 13)
        Me.lbl_hail_options_timespan.TabIndex = 20
        Me.lbl_hail_options_timespan.Text = "Select Timespan:"
        '
        'lbl_hail_message
        '
        Me.lbl_hail_message.AutoSize = True
        Me.lbl_hail_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hail_message.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbl_hail_message.Location = New System.Drawing.Point(68, 191)
        Me.lbl_hail_message.Name = "lbl_hail_message"
        Me.lbl_hail_message.Size = New System.Drawing.Size(206, 16)
        Me.lbl_hail_message.TabIndex = 29
        Me.lbl_hail_message.Text = "...Processing...Please Wait..."
        '
        'checkbox_hail_addData
        '
        Me.checkbox_hail_addData.AutoSize = True
        Me.checkbox_hail_addData.Location = New System.Drawing.Point(12, 230)
        Me.checkbox_hail_addData.Name = "checkbox_hail_addData"
        Me.checkbox_hail_addData.Size = New System.Drawing.Size(97, 17)
        Me.checkbox_hail_addData.TabIndex = 30
        Me.checkbox_hail_addData.Text = "Add to ArcMap"
        Me.checkbox_hail_addData.UseVisualStyleBackColor = True
        '
        'frm_hailOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 261)
        Me.Controls.Add(Me.checkbox_hail_addData)
        Me.Controls.Add(Me.lbl_hail_message)
        Me.Controls.Add(Me.lbl_hail_options_url)
        Me.Controls.Add(Me.txt_hail_url)
        Me.Controls.Add(Me.txt_hail_outputFolderpath)
        Me.Controls.Add(Me.btn_hail_options_Cancel)
        Me.Controls.Add(Me.btn_hail_options_OK)
        Me.Controls.Add(Me.btn_hail_options_browse)
        Me.Controls.Add(Me.lbl_hail_options_outputPath)
        Me.Controls.Add(Me.cb_hail_options_timespan)
        Me.Controls.Add(Me.lbl_hail_options_timespan)
        Me.Name = "frm_hailOptions"
        Me.Text = "Hail Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_hail_options_url As Windows.Forms.Label
    Friend WithEvents txt_hail_url As Windows.Forms.TextBox
    Friend WithEvents txt_hail_outputFolderpath As Windows.Forms.TextBox
    Friend WithEvents btn_hail_options_Cancel As Windows.Forms.Button
    Friend WithEvents btn_hail_options_OK As Windows.Forms.Button
    Friend WithEvents btn_hail_options_browse As Windows.Forms.Button
    Friend WithEvents lbl_hail_options_outputPath As Windows.Forms.Label
    Friend WithEvents cb_hail_options_timespan As Windows.Forms.ComboBox
    Friend WithEvents lbl_hail_options_timespan As Windows.Forms.Label
    Friend WithEvents lbl_hail_message As Windows.Forms.Label
    Friend WithEvents checkbox_hail_addData As Windows.Forms.CheckBox
End Class
