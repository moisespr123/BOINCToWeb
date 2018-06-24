<head>

<script src="tablesorter/docs/js/jquery-latest.min.js"></script>
<link rel="stylesheet" href="tablesorter/css/theme.blue.css"/>
<script src="tablesorter/js/jquery.tablesorter.js"></script> 
<script type="text/javascript">
$(document).ready(function() 
    { 
        $("table").tablesorter({ theme : 'blue' });; 
    } 
); 
</script>
</head>

<body>
<table id="myTable" class="tablesorter">
<thead> 
<tr> 
    <th>Project</th> 
    <th>Workunit Name</th> 
    <th>Percent Done</th> 
    <th>Status</th> 
    <th>Elapsed Time</th> 
    <th>Remaining Time</th>
    <th>Deadline</th>
	<th>Host</th>
</tr> 
</thead> 
<tbody> 
<?php
require_once 'config.php';
global $mysqli;
$result = $mysqli->query("SELECT * FROM tasks ORDER BY Status DESC");
if (mysqli_num_rows($result) > 0){
    $o='';
    while($row = mysqli_fetch_assoc($result))
        $o .= "<tr id='tabletr'><td>".$row['Project']."</td><td>".$row['TaskName']."</td><td>".$row['PercentDone']."%</td><td>".$row['Status']."</td><td>".$row['ElapsedTime']."</td><td>".$row['RemainingTime']."</td><td>".$row['ReportDeadline']."</td><td>".$row['PCName']."</td></tr>";
    echo $o;
}
?>
</tbody>
</table>
</body>