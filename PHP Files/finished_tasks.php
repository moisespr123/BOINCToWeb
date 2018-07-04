<head>
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="tablesorter/js/jquery.tablesorter.js"></script> 
    <link rel="stylesheet" href="tablesorter/css/theme.blue.css"/>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

</head>

<body>
<script type="text/javascript">
    $(document).ready(function()
        {
            $("table").tablesorter({theme: 'blue'});
        }
    );
</script>
<script type="text/javascript">
    $(function() {
        $("#datepicker").datepicker({dateFormat: 'mm/dd/yy'});
    });
</script>
<?php
require_once 'config.php';
global $mysqli;
$hostsresult = $mysqli->query("SELECT DISTINCT PCName FROM finishedtasks ORDER BY PCName ASC");
$hosts = '';

$selecteddate = "";
$selectedhost = "all";
if (isset($_POST['viewtasks'])) {
    $selecteddate = $_POST['date'];
    $selectedhost = $_POST['host'];
}
$hosts = "<option value='all' "; if ($selectedhost == "all") $hosts .= "selected='selected'"; $hosts .= ">All</option>";

if (mysqli_num_rows($hostsresult) > 0) {
    while ($row = mysqli_fetch_assoc($hostsresult)) {
        $hosts .= "<option value='" . $row['PCName'] . "' "; if ($selectedhost == $row['PCName']) $hosts .= "selected='selected'"; $hosts .= ">" . $row['PCName'] . "</option>";
    }
}
echo "<form method='post'>
        Date to see tasks (None for all): <input type='text' id='datepicker' name='date'  autocomplete='off' value='$selecteddate' /></br>
        Host: <select name='host'>" . $hosts . "</select></br>
        <input name='viewtasks' type='submit' value='View tasks' />
      </form>
      <table id=\"myTable\" class=\"tablesorter\">
        <thead> 
        <tr> 
            <th>Project</th> 
            <th>Workunit Name</th> 
            <th>Elapsed Time</th> 
            <th>Aprox. Finished time</th>
            <th>Task Type</th>
            <th>Host</th>
        </tr> 
        </thead> 
        <tbody>";
$date_to_use = '%';
$host_to_use = '%';
if (isset($_POST['viewtasks'])) {
    if (!empty($_POST['date']))
        $date_to_use = $_POST['date'];
    if ($_POST['host'] != "all")
        $host_to_use = $_POST['host'];
}
$stmt = $mysqli->prepare("SELECT * FROM finishedtasks WHERE AddedDate LIKE ? AND PCName LIKE ?");
$stmt->bind_param("ss", $date_to_use, $host_to_use);
$stmt->execute();
$result = $stmt->get_result();
if (mysqli_num_rows($result) > 0) {
    $o = '';
    while ($row = mysqli_fetch_assoc($result))
        $o .= "<tr id='tabletr'><td>" . $row['Project'] . "</td><td>" . $row['TaskName'] . "</td><td>" . $row['ElapsedTime'] . "</td><td>" . $row['AddedDate'] . " " . $row['AddedTime'] . " UTC</td><td>" . $row['PlanClass'] . "</td><td>" . $row['PCName'] . "</td></tr>";
    echo $o;
}
$stmt->close();
echo "</tbody>
</table>
</body>";
?>
