<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LogRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.StartStopButton = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PCNameTextbox = New System.Windows.Forms.TextBox()
        Me.PCAddressTextbox = New System.Windows.Forms.TextBox()
        Me.PCPasswordTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AddToListButton = New System.Windows.Forms.Button()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MySQLServerTextbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MySQLPortTextbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MySQLDatabaseTextbox = New System.Windows.Forms.TextBox()
        Me.MySQLUsernameTextbox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MySQLPasswordTextbox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimeUpDownBox = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PCPortTextbox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EraseLogCheckbox = New System.Windows.Forms.CheckBox()
        Me.DonateButton = New System.Windows.Forms.Button()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.UpdatePCButton = New System.Windows.Forms.Button()
        CType(Me.TimeUpDownBox,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'LogRichTextBox
        '
        Me.LogRichTextBox.Location = New System.Drawing.Point(363, 25)
        Me.LogRichTextBox.Name = "LogRichTextBox"
        Me.LogRichTextBox.Size = New System.Drawing.Size(402, 325)
        Me.LogRichTextBox.TabIndex = 0
        Me.LogRichTextBox.Text = ""
        '
        'StartStopButton
        '
        Me.StartStopButton.Location = New System.Drawing.Point(191, 281)
        Me.StartStopButton.Name = "StartStopButton"
        Me.StartStopButton.Size = New System.Drawing.Size(157, 23)
        Me.StartStopButton.TabIndex = 14
        Me.StartStopButton.Text = "Fetch Tasks!"
        Me.StartStopButton.UseVisualStyleBackColor = true
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = true
        Me.ListBox1.Location = New System.Drawing.Point(15, 222)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(158, 121)
        Me.ListBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "BOINC PC Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "BOINC PC IP Address:"
        '
        'PCNameTextbox
        '
        Me.PCNameTextbox.Location = New System.Drawing.Point(15, 25)
        Me.PCNameTextbox.Name = "PCNameTextbox"
        Me.PCNameTextbox.Size = New System.Drawing.Size(158, 20)
        Me.PCNameTextbox.TabIndex = 1
        '
        'PCAddressTextbox
        '
        Me.PCAddressTextbox.Location = New System.Drawing.Point(15, 67)
        Me.PCAddressTextbox.Name = "PCAddressTextbox"
        Me.PCAddressTextbox.Size = New System.Drawing.Size(158, 20)
        Me.PCAddressTextbox.TabIndex = 2
        '
        'PCPasswordTextbox
        '
        Me.PCPasswordTextbox.Location = New System.Drawing.Point(15, 159)
        Me.PCPasswordTextbox.Name = "PCPasswordTextbox"
        Me.PCPasswordTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.PCPasswordTextbox.Size = New System.Drawing.Size(158, 20)
        Me.PCPasswordTextbox.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(12, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "BOINC PC Password:"
        '
        'AddToListButton
        '
        Me.AddToListButton.Location = New System.Drawing.Point(15, 185)
        Me.AddToListButton.Name = "AddToListButton"
        Me.AddToListButton.Size = New System.Drawing.Size(158, 23)
        Me.AddToListButton.TabIndex = 5
        Me.AddToListButton.Text = "Add to List"
        Me.AddToListButton.UseVisualStyleBackColor = true
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(12, 381)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(161, 23)
        Me.RemoveButton.TabIndex = 7
        Me.RemoveButton.Text = "Remove PC"
        Me.RemoveButton.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(187, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "MySQL Server:"
        '
        'MySQLServerTextbox
        '
        Me.MySQLServerTextbox.Location = New System.Drawing.Point(190, 25)
        Me.MySQLServerTextbox.Name = "MySQLServerTextbox"
        Me.MySQLServerTextbox.Size = New System.Drawing.Size(158, 20)
        Me.MySQLServerTextbox.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(187, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "MySQL Port:"
        '
        'MySQLPortTextbox
        '
        Me.MySQLPortTextbox.Location = New System.Drawing.Point(190, 67)
        Me.MySQLPortTextbox.Name = "MySQLPortTextbox"
        Me.MySQLPortTextbox.Size = New System.Drawing.Size(158, 20)
        Me.MySQLPortTextbox.TabIndex = 9
        Me.MySQLPortTextbox.Text = "3306"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(187, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "MySQL Database:"
        '
        'MySQLDatabaseTextbox
        '
        Me.MySQLDatabaseTextbox.Location = New System.Drawing.Point(190, 115)
        Me.MySQLDatabaseTextbox.Name = "MySQLDatabaseTextbox"
        Me.MySQLDatabaseTextbox.Size = New System.Drawing.Size(158, 20)
        Me.MySQLDatabaseTextbox.TabIndex = 10
        '
        'MySQLUsernameTextbox
        '
        Me.MySQLUsernameTextbox.Location = New System.Drawing.Point(190, 159)
        Me.MySQLUsernameTextbox.Name = "MySQLUsernameTextbox"
        Me.MySQLUsernameTextbox.Size = New System.Drawing.Size(158, 20)
        Me.MySQLUsernameTextbox.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(187, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "MySQL Username:"
        '
        'MySQLPasswordTextbox
        '
        Me.MySQLPasswordTextbox.Location = New System.Drawing.Point(190, 207)
        Me.MySQLPasswordTextbox.Name = "MySQLPasswordTextbox"
        Me.MySQLPasswordTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.MySQLPasswordTextbox.Size = New System.Drawing.Size(158, 20)
        Me.MySQLPasswordTextbox.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(187, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "MySQL Password:"
        '
        'Timer1
        '
        '
        'TimeUpDownBox
        '
        Me.TimeUpDownBox.Location = New System.Drawing.Point(191, 255)
        Me.TimeUpDownBox.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.TimeUpDownBox.Name = "TimeUpDownBox"
        Me.TimeUpDownBox.Size = New System.Drawing.Size(48, 20)
        Me.TimeUpDownBox.TabIndex = 13
        Me.TimeUpDownBox.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(188, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Time To Fetch Tasks:"
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(245, 262)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Minutes"
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(360, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Status:"
        '
        'PCPortTextbox
        '
        Me.PCPortTextbox.Location = New System.Drawing.Point(15, 115)
        Me.PCPortTextbox.Name = "PCPortTextbox"
        Me.PCPortTextbox.Size = New System.Drawing.Size(158, 20)
        Me.PCPortTextbox.TabIndex = 3
        Me.PCPortTextbox.Text = "31416"
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(12, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "BOINC PC Port:"
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Location = New System.Drawing.Point(622, 365)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 39)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Developed by Moisés Cardona"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"v1.3 (dev)"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"http://moisescardona.me"
        '
        'EraseLogCheckbox
        '
        Me.EraseLogCheckbox.AutoSize = true
        Me.EraseLogCheckbox.Location = New System.Drawing.Point(363, 356)
        Me.EraseLogCheckbox.Name = "EraseLogCheckbox"
        Me.EraseLogCheckbox.Size = New System.Drawing.Size(194, 17)
        Me.EraseLogCheckbox.TabIndex = 15
        Me.EraseLogCheckbox.Text = "Erase Log when updating database"
        Me.EraseLogCheckbox.UseVisualStyleBackColor = true
        '
        'DonateButton
        '
        Me.DonateButton.Location = New System.Drawing.Point(363, 378)
        Me.DonateButton.Name = "DonateButton"
        Me.DonateButton.Size = New System.Drawing.Size(253, 23)
        Me.DonateButton.TabIndex = 16
        Me.DonateButton.Text = "Like this software? DONATE!"
        Me.DonateButton.UseVisualStyleBackColor = true
        '
        'TrayIcon
        '
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"),System.Drawing.Icon)
        Me.TrayIcon.Text = "BOINC To Web Software"
        '
        'UpdatePCButton
        '
        Me.UpdatePCButton.Location = New System.Drawing.Point(12, 349)
        Me.UpdatePCButton.Name = "UpdatePCButton"
        Me.UpdatePCButton.Size = New System.Drawing.Size(161, 23)
        Me.UpdatePCButton.TabIndex = 28
        Me.UpdatePCButton.Text = "Update PC"
        Me.UpdatePCButton.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 413)
        Me.Controls.Add(Me.UpdatePCButton)
        Me.Controls.Add(Me.DonateButton)
        Me.Controls.Add(Me.EraseLogCheckbox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PCPortTextbox)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TimeUpDownBox)
        Me.Controls.Add(Me.MySQLPasswordTextbox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.MySQLUsernameTextbox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.MySQLDatabaseTextbox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.MySQLPortTextbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MySQLServerTextbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.AddToListButton)
        Me.Controls.Add(Me.PCPasswordTextbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PCAddressTextbox)
        Me.Controls.Add(Me.PCNameTextbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.StartStopButton)
        Me.Controls.Add(Me.LogRichTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.Text = "BOINC to Database to show tasks on web"
        CType(Me.TimeUpDownBox,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents LogRichTextBox As RichTextBox
    Friend WithEvents StartStopButton As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PCNameTextbox As TextBox
    Friend WithEvents PCAddressTextbox As TextBox
    Friend WithEvents PCPasswordTextbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents AddToListButton As Button
    Friend WithEvents RemoveButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents MySQLServerTextbox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents MySQLPortTextbox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents MySQLDatabaseTextbox As TextBox
    Friend WithEvents MySQLUsernameTextbox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents MySQLPasswordTextbox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TimeUpDownBox As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PCPortTextbox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents EraseLogCheckbox As CheckBox
    Friend WithEvents DonateButton As Button
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents UpdatePCButton As Button
End Class
