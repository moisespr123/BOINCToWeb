Imports BoincRpc

Public Class Form1
    Private Timer1 As New Timers.Timer
    Private Running As Boolean = False
    Private Sub StartStopButton_Click(sender As Object, e As EventArgs) Handles StartStopButton.Click
        My.Settings.MySQLServer = MySQLServerTextbox.Text
        My.Settings.MySQLPort = MySQLPortTextbox.Text
        My.Settings.MySQLDatabase = MySQLDatabaseTextbox.Text
        My.Settings.MySQLUsername = MySQLUsernameTextbox.Text
        My.Settings.MySQLPassword = MySQLPasswordTextbox.Text
        My.Settings.TimeToWait = TimeUpDownBox.Value
        My.Settings.Save()
        RunOrStop()
    End Sub
    Private Sub RunOrStop()
        If TimeUpDownBox.Value > 0 Then
            If Not Running Then
                Running = True
                StartStopButton.Text = "Stop Fetching"
                Timer1 = New Timers.Timer(TimeUpDownBox.Value * 60 * 1000)
                AddHandler Timer1.Elapsed, New Timers.ElapsedEventHandler(AddressOf Timer1_Tick)
                Timer1.Start()
                CheckAndEraseLogIfEnabled()
                Dim StartTask As New Threading.Thread(Sub() UpdateTasks())
                StartTask.Start()
            Else
                Running = False
                Timer1.Stop()
                StatusLog("Stopped fetching tasks. Press the button again to start fetching tasks again")
                StartStopButton.Text = "Fetch Tasks!"
            End If
        Else
            MessageBox.Show("Timer cannot be 0")
        End If
    End Sub

    Private Async Sub AddToListButton_Click(sender As Object, e As EventArgs) Handles AddToListButton.Click
       Await AddOrUpdateHost()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.PCName Is Nothing Then My.Settings.PCName = New Specialized.StringCollection
        If My.Settings.PCIPAddress Is Nothing Then My.Settings.PCIPAddress = New Specialized.StringCollection
        If My.Settings.PCPassword Is Nothing Then My.Settings.PCPassword = New Specialized.StringCollection
        If My.Settings.PCPort Is Nothing Then My.Settings.PCPort = New Specialized.StringCollection
        If My.Settings.PCName.Count > 0 Then
            For Each item In My.Settings.PCName
                ListBox1.Items.Add(item)
            Next
        End If
        If My.Settings.EraseLog = True Then EraseLogCheckbox.Checked = True Else EraseLogCheckbox.Checked = False
        MySQLServerTextbox.Text = My.Settings.MySQLServer
        MySQLPortTextbox.Text = My.Settings.MySQLPort
        MySQLDatabaseTextbox.Text = My.Settings.MySQLDatabase
        MySQLUsernameTextbox.Text = My.Settings.MySQLUsername
        MySQLPasswordTextbox.Text = My.Settings.MySQLPassword
        If Not String.IsNullOrEmpty(My.Settings.TimeToWait) Then TimeUpDownBox.Value = My.Settings.TimeToWait
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            If vars(1) = "-s" Then
                RunOrStop()
                Me.WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            PCNameTextbox.Text = ListBox1.SelectedItem
            PCAddressTextbox.Text = My.Settings.PCIPAddress.Item(ListBox1.SelectedIndex)
            PCPasswordTextbox.Text = My.Settings.PCPassword.Item(ListBox1.SelectedIndex)
            PCPortTextbox.Text = My.Settings.PCPort.Item(ListBox1.SelectedIndex)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        My.Settings.PCName.RemoveAt(ListBox1.SelectedIndex)
        My.Settings.PCIPAddress.RemoveAt(ListBox1.SelectedIndex)
        My.Settings.PCPassword.RemoveAt(ListBox1.SelectedIndex)
        My.Settings.PCPort.RemoveAt(ListBox1.SelectedIndex)
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        My.Settings.Save()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As Timers.ElapsedEventArgs)
        CheckAndEraseLogIfEnabled()
        Dim StartTask As New Threading.Thread(Sub() UpdateTasks())
        StartTask.Start()
    End Sub

    Private Async Sub UpdateTasks()
        StatusLog("Starting MySQL Database Update test")
        Try
            Timer1.Stop()
            Dim NumberOfHosts As Integer = ListBox1.Items.Count
            StatusLog("Starting MySQL Database Update")
            If TruncateTables() Then
                StatusLog("Number of hosts: " & NumberOfHosts)
                If NumberOfHosts > 0 Then
                    For i = 0 To NumberOfHosts - 1
                        Await GetHostTasks(My.Settings.PCName.Item(i), My.Settings.PCIPAddress.Item(i), My.Settings.PCPort.Item(i), My.Settings.PCPassword.Item(i))
                    Next
                End If
            End If
            Timer1.Start()
        Catch ex As Exception
            StatusLog("Couldn't update Database")
            StatusLog(ex.ToString())
        End Try
    End Sub
    Private Delegate Sub CheckAndEraseLogIfEnabledHandler()
    Private Sub CheckAndEraseLogIfEnabled()
        If LogRichTextBox.InvokeRequired Then
            LogRichTextBox.Invoke(New CheckAndEraseLogIfEnabledHandler(AddressOf CheckAndEraseLogIfEnabled))
            Exit Sub
        End If
        If EraseLogCheckbox.Checked Then
            LogRichTextBox.Text = String.Empty
        End If
    End Sub
    Private Delegate Sub StatusLogInvoker(text As String)
    Private Sub StatusLog(text As String)
        If LogRichTextBox.InvokeRequired Then
            LogRichTextBox.Invoke(New StatusLogInvoker(AddressOf StatusLog), text)
            Exit Sub
        End If
        LogRichTextBox.AppendText(Date.Now & " || " & text & vbNewLine)
            LogRichTextBox.SelectionStart = LogRichTextBox.Text.Length - 1
        LogRichTextBox.ScrollToCaret()
    End Sub
    Private Async Function AddOrUpdateHost(Optional Update As Boolean = False) As Task
        Dim BOINCClient As New RpcClient
        Try
            Await BOINCClient.ConnectAsync(PCAddressTextbox.Text, PCPortTextbox.Text)
            Dim Authorized = Await BOINCClient.AuthorizeAsync(PCPasswordTextbox.Text)
            If Authorized = True Then
                If Update Then
                    My.Settings.PCName.Item(ListBox1.SelectedIndex) = PCNameTextbox.Text
                    My.Settings.PCIPAddress.Item(ListBox1.SelectedIndex) = PCAddressTextbox.Text
                    My.Settings.PCPassword.Item(ListBox1.SelectedIndex) = PCPasswordTextbox.Text
                    My.Settings.PCPort.Item(ListBox1.SelectedIndex) = PCPortTextbox.Text
                    ListBox1.Items.Item(ListBox1.SelectedIndex) = PCNameTextbox.Text
                Else
                    My.Settings.PCName.Add(PCNameTextbox.Text)
                    My.Settings.PCIPAddress.Add(PCAddressTextbox.Text)
                    My.Settings.PCPassword.Add(PCPasswordTextbox.Text)
                    My.Settings.PCPort.Add(PCPortTextbox.Text)
                    ListBox1.Items.Add(PCNameTextbox.Text)
                End If
                My.Settings.Save()
            Else
                MsgBox("Could not connect. Please check the PC details and try again")
            End If
        Catch ex As Exception
            MsgBox("Could not connect. Please check the PC details and try again")
        End Try
    End Function
    Private Function TruncateTables() As Boolean
        Try
            StatusLog("Truncating Table")
            Dim MySQLConnString = "server=" & My.Settings.MySQLServer & ";Port=" & My.Settings.MySQLPort & ";Database=" & My.Settings.MySQLDatabase & ";Uid=" & My.Settings.MySQLUsername & ";Pwd=" & My.Settings.MySQLPassword & ";Check Parameters=false;default command timeout=999;Connection Timeout=999;Pooling=false;allow user variables=true;sslmode=none"
            Dim truncateSQL = "TRUNCATE TABLE tasks"
            Dim SQLConnection = New MySql.Data.MySqlClient.MySqlConnection(MySQLConnString)
            SQLConnection.Open()
            Dim SQLCommand1 As New MySql.Data.MySqlClient.MySqlCommand(truncateSQL, SQLConnection)
            SQLCommand1.ExecuteNonQuery()
            StatusLog("Table truncated")
            SQLConnection.Close()
            Return True
        Catch ex As Exception
            StatusLog("Coudn't truncate table")
            Return False
        End Try
    End Function
    Private Sub InsertFinishedTask(Workunit As String, Project As String, ElapsedTime As String, Host As String, Optional PlanClass As String = "CPU")
        If Not CheckIfTaskInFinishedTable(Workunit) Then
            Dim MySQLConnString = "server=" & My.Settings.MySQLServer & ";Port=" & My.Settings.MySQLPort & ";Database=" & My.Settings.MySQLDatabase & ";Uid=" & My.Settings.MySQLUsername & ";Pwd=" & My.Settings.MySQLPassword & ";Check Parameters=false;default command timeout=999;Connection Timeout=999;Pooling=false;allow user variables=true;sslmode=none"
            Dim Query = "INSERT INTO finishedtasks (Project, TaskName, PCName, ElapsedTime, PlanClass, AddedDate, AddedTime) VALUES ('" + Project + "','" + Workunit + "','" + Host + "','" + ElapsedTime + "','" + PlanClass + "','" + Now.ToUniversalTime.ToString("MM/dd/yyyy") + "','" + Now.ToUniversalTime.ToString("HH:mm:ss") + "')"
            Dim SQLConnection = New MySql.Data.MySqlClient.MySqlConnection(MySQLConnString)
            SQLConnection.Open()
            Dim SQLCommand As New MySql.Data.MySqlClient.MySqlCommand(Query, SQLConnection)
            SQLCommand.ExecuteNonQuery()
            SQLConnection.Close()
        End If
    End Sub

    Private Function CheckIfTaskInFinishedTable(Task As String) As Boolean
        Dim MySQLConnString = "server=" & My.Settings.MySQLServer & ";Port=" & My.Settings.MySQLPort & ";Database=" & My.Settings.MySQLDatabase & ";Uid=" & My.Settings.MySQLUsername & ";Pwd=" & My.Settings.MySQLPassword & ";Check Parameters=false;default command timeout=999;Connection Timeout=999;Pooling=false;allow user variables=true;sslmode=none"
        Dim Query = "SELECT TaskName FROM finishedtasks WHERE TaskName = '" + Task + "'"
        Dim SQLConnection = New MySql.Data.MySqlClient.MySqlConnection(MySQLConnString)
        SQLConnection.Open()
        Dim SQLCommand As New MySql.Data.MySqlClient.MySqlCommand(Query, SQLConnection)
        Dim Results As MySql.Data.MySqlClient.MySqlDataReader = SQLCommand.ExecuteReader
        Dim HasTask = Results.HasRows()
        SQLConnection.Close()
        Return HasTask
    End Function
    Private Async Function GetHostTasks(host As String, ip As String, port As Integer, password As String) As Task
        StatusLog("Getting Tasks for host " & host)
        Dim MySQLConnString = "server=" & My.Settings.MySQLServer & ";Port=" & My.Settings.MySQLPort & ";Database=" & My.Settings.MySQLDatabase & ";Uid=" & My.Settings.MySQLUsername & ";Pwd=" & My.Settings.MySQLPassword & ";Check Parameters=false;default command timeout=999;Connection Timeout=999;Pooling=false;allow user variables=true;sslmode=none"
        Dim BOINCClient As New RpcClient
        Try
            Await BOINCClient.ConnectAsync(ip, port)
            Dim Authorized As Boolean = Await BOINCClient.AuthorizeAsync(password)
            Dim SQLInsert As String = ""
            If Authorized Then
                Dim ProjectList() As Project = Await BOINCClient.GetProjectStatusAsync
                For Each result In Await BOINCClient.GetResultsAsync()
                    Dim Percent As Double
                    Dim Status As String = ""
                    Dim ProjectName As String = ""
                    For Each project In ProjectList
                        If project.MasterUrl = result.ProjectUrl Then
                            ProjectName = project.ProjectName
                            Exit For
                        End If
                    Next
                    Dim ElapsedTime As TimeSpan
                    If result.ElapsedTime.TotalMilliseconds = 0 Then
                        ElapsedTime = result.FinalElapsedTime
                    Else
                        ElapsedTime = result.ElapsedTime
                    End If
                    Dim FormattedElapsedTime As String = String.Format("{0}:{1:mm}:{1:ss}", CInt(Math.Truncate(ElapsedTime.TotalHours)), ElapsedTime)
                    Dim RemainingTime As TimeSpan = result.EstimatedCpuTimeRemaining
                    If result.ActiveTask = True And result.ReadyToReport = False And (result.ActiveTaskState <> 9 And result.ActiveTaskState <> 0) Then
                        If String.IsNullOrEmpty(result.PlanClass) Then
                            Status = "Running"
                        Else
                            Status = "Running (" & result.PlanClass & ")"
                        End If
                        Percent = result.FractionDone * 100
                    ElseIf result.ActiveTask = True And result.ReadyToReport = False And (result.ActiveTaskState = 9 Or result.ActiveTaskState = 0) Then
                        If String.IsNullOrEmpty(result.PlanClass) Then
                            Status = "Suspended"
                        Else
                            Status = "Suspended (" & result.PlanClass & ")"
                        End If
                        Percent = result.FractionDone * 100
                    ElseIf result.ActiveTask = False And result.ReadyToReport = False Then
                        If String.IsNullOrEmpty(result.PlanClass) Then
                            Status = "Ready to start"
                        Else
                            Status = "Ready to start (" & result.PlanClass & ")"
                        End If
                        Percent = 0
                    ElseIf result.ActiveTask = False And result.ReadyToReport = True Then
                        If String.IsNullOrEmpty(result.PlanClass) Then
                            Status = "Ready to report"
                            InsertFinishedTask(result.WorkunitName, ProjectName, FormattedElapsedTime, host)
                        Else
                            Status = "Ready to report (" & result.PlanClass & ")"
                            InsertFinishedTask(result.WorkunitName, ProjectName, FormattedElapsedTime, host, result.PlanClass)
                        End If
                        Percent = 100
                    End If
                    SQLInsert += "INSERT INTO tasks (TaskName, Project, PercentDone, Status, PCName, ElapsedTime, RemainingTime, ReportDeadline) VALUES ('" & result.WorkunitName & "', '" & ProjectName & "', '" & Percent & "', '" & Status & "', '" & host & "', '" & FormattedElapsedTime & "', '" & String.Format("{0}:{1:mm}:{1:ss}", CInt(Math.Truncate(RemainingTime.TotalHours)), RemainingTime) & "', '" & result.ReportDeadline.ToString("MM/dd/yyyy hh:mm:ss tt") & " UTC');"
                Next
            End If
            Dim SQLConnection = New MySql.Data.MySqlClient.MySqlConnection(MySQLConnString)
            SQLConnection.Open()
            Dim SQLCommand As New MySql.Data.MySqlClient.MySqlCommand(SQLInsert, SQLConnection)
            SQLCommand.ExecuteNonQuery()
            StatusLog("Finished getting tasks for host " & host)
            SQLConnection.Close()
        Catch ex As Exception
            StatusLog("Failed getting tasks for host " & host)
        End Try
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles EraseLogCheckbox.CheckedChanged
        If EraseLogCheckbox.Checked Then
            My.Settings.EraseLog = True
            My.Settings.Save()
        Else
            My.Settings.EraseLog = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles LogRichTextBox.TextChanged
        LogRichTextBox.SelectionStart = LogRichTextBox.Text.Length
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles DonateButton.Click
        Donations_Addresses.ShowDialog()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
            Me.Hide()
            TrayIcon.Visible = True
        End If
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        TrayIcon.Visible = False
    End Sub

    Private Async Sub UpdatePCButton_Click(sender As Object, e As EventArgs) Handles UpdatePCButton.Click
        Await AddOrUpdateHost(True)
    End Sub
End Class
