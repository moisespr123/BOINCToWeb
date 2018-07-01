Imports BoincRpc

Public Class Form1

    Private Running As Boolean = False
    Private Sub StartStopButton_Click(sender As Object, e As EventArgs) Handles StartStopButton.Click
        My.Settings.MySQLServer = TextBox4.Text
        My.Settings.MySQLPort = TextBox5.Text
        My.Settings.MySQLDatabase = TextBox6.Text
        My.Settings.MySQLUsername = TextBox7.Text
        My.Settings.MySQLPassword = TextBox8.Text
        My.Settings.TimeToWait = NumericUpDown1.Value
        My.Settings.Save()
        RunOrStop()
    End Sub
    Private Sub RunOrStop()
        If NumericUpDown1.Value > 0 Then
            If Not Running Then
                Running = True
                StartStopButton.Text = "Stop Fetching"
                Timer1.Interval = NumericUpDown1.Value * 60 * 1000
                Timer1.Start()
                UpdateTasks()
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
        Dim BOINCClient As New RpcClient
        Try
            Await BOINCClient.ConnectAsync(TextBox2.Text, TextBox9.Text)
            Dim Authorized = Await BOINCClient.AuthorizeAsync(TextBox3.Text)
            If Authorized = True Then
                My.Settings.PCName.Add(TextBox1.Text)
                My.Settings.PCIPAddress.Add(TextBox2.Text)
                My.Settings.PCPassword.Add(TextBox3.Text)
                My.Settings.PCPort.Add(TextBox9.Text)
                ListBox1.Items.Add(TextBox1.Text)
                My.Settings.Save()
            Else
                MsgBox("Could not connect. Please check the PC details and try again")
            End If
        Catch ex As Exception
            MsgBox("Could not connect. Please check the PC details and try again")
        End Try
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
        If My.Settings.EraseLog = True Then CheckBox1.Checked = True Else CheckBox1.Checked = False
        TextBox4.Text = My.Settings.MySQLServer
        TextBox5.Text = My.Settings.MySQLPort
        TextBox6.Text = My.Settings.MySQLDatabase
        TextBox7.Text = My.Settings.MySQLUsername
        TextBox8.Text = My.Settings.MySQLPassword
        If Not String.IsNullOrEmpty(My.Settings.TimeToWait) Then NumericUpDown1.Value = My.Settings.TimeToWait
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
            TextBox1.Text = ListBox1.SelectedItem
            TextBox2.Text = My.Settings.PCIPAddress.Item(ListBox1.SelectedIndex)
            TextBox3.Text = My.Settings.PCPassword.Item(ListBox1.SelectedIndex)
            TextBox9.Text = My.Settings.PCPort.Item(ListBox1.SelectedIndex)
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateTasks()
    End Sub

    Private Sub UpdateTasks()
        Try
            If CheckBox1.Checked Then
                RichTextBox1.Text = ""
            End If
            Dim NumberOfHosts As Integer = ListBox1.Items.Count
            StatusLog("Starting MySQL Database Update")
            If TruncateTables() Then
                StatusLog("Number of hosts: " & NumberOfHosts)
                If NumberOfHosts > 0 Then
                    For i = 0 To NumberOfHosts - 1
                        GetHostTasks(My.Settings.PCName.Item(i), My.Settings.PCIPAddress.Item(i), My.Settings.PCPort.Item(i), My.Settings.PCPassword.Item(i))
                    Next
                End If
            End If
        Catch ex As Exception
            StatusLog("Couldn't update Database")
        End Try
    End Sub
    Private Sub StatusLog(text As String)
        RichTextBox1.AppendText(Date.Now & " || " & text & vbNewLine)
        RichTextBox1.ScrollToCaret()
    End Sub
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
            Return True
        Catch ex As Exception
            StatusLog("Coudn't truncate table")
            Return False
        End Try
    End Function
    Private Sub InsertFinishedTask(Workunit As String, Project As String, ElapsedTime As String, Host As String, Optional PlanClass As String = "CPU")
        If Not CheckIfTaskInFinishedTable(Workunit) Then

        End If
    End Sub

    Private Function CheckIfTaskInFinishedTable(Task As String) As Boolean
        Dim MySQLConnString = "server=" & My.Settings.MySQLServer & ";Port=" & My.Settings.MySQLPort & ";Database=" & My.Settings.MySQLDatabase & ";Uid=" & My.Settings.MySQLUsername & ";Pwd=" & My.Settings.MySQLPassword & ";Check Parameters=false;default command timeout=999;Connection Timeout=999;Pooling=false;allow user variables=true;sslmode=none"
        Dim Query = "SELECT TaskName FROM finishedtasks WHERE TaskName = '" + Task + "'"
        Dim SQLConnection = New MySql.Data.MySqlClient.MySqlConnection(MySQLConnString)
        SQLConnection.Open()
        Dim SQLReader As New MySql.Data.MySqlClient.MySqlCommand(Query, SQLConnection)
        Dim Results As MySql.Data.MySqlClient.MySqlDataReader = SQLReader.ExecuteReader
        Return Results.HasRows()
    End Function
    Private Async Sub GetHostTasks(host As String, ip As String, port As Integer, password As String)
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
                        Else
                            Status = "Ready to report (" & result.PlanClass & ")"
                        End If
                        Percent = 100
                    End If
                    Dim ElapsedTime As TimeSpan
                    If result.ElapsedTime.TotalMilliseconds = 0 Then
                        ElapsedTime = result.FinalElapsedTime
                    Else
                        ElapsedTime = result.ElapsedTime
                    End If

                    Dim RemainingTime As TimeSpan = result.EstimatedCpuTimeRemaining
                    Dim ProjectName As String = ""
                    For Each project In ProjectList
                        If project.MasterUrl = result.ProjectUrl Then
                            ProjectName = project.ProjectName
                            Exit For
                        End If
                    Next
                    SQLInsert += "INSERT INTO tasks (TaskName, Project, PercentDone, Status, PCName, ElapsedTime, RemainingTime, ReportDeadline) VALUES ('" & result.WorkunitName & "', '" & ProjectName & "', '" & Percent & "', '" & Status & "', '" & host & "', '" & String.Format("{0}:{1:mm}:{1:ss}", CInt(Math.Truncate(ElapsedTime.TotalHours)), ElapsedTime) & "', '" & String.Format("{0}:{1:mm}:{1:ss}", CInt(Math.Truncate(RemainingTime.TotalHours)), RemainingTime) & "', '" & result.ReportDeadline.ToString("MM/dd/yyyy hh:mm:ss tt") & " UTC');"
                Next
            End If
            Dim SQLConnection = New MySql.Data.MySqlClient.MySqlConnection(MySQLConnString)
            SQLConnection.Open()
            Dim SQLCommand As New MySql.Data.MySqlClient.MySqlCommand(SQLInsert, SQLConnection)
            SQLCommand.ExecuteNonQuery()
            StatusLog("Finished getting tasks for host " & host)
        Catch ex As Exception
            StatusLog("Failed getting tasks for host " & host)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            My.Settings.EraseLog = True
            My.Settings.Save()
        Else
            My.Settings.EraseLog = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = RichTextBox1.Text.Length
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
End Class
