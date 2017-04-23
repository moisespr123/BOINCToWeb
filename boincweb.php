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
error_reporting(E_ALL);
$mysql= new mysqli('server', 'username', 'password', 'database');
$sql="SELECT * FROM tasks ORDER BY Status DESC";
$result=mysqli_query($mysql, $sql);
$o='';
while(list($taskname, $project, $percent, $status, $pkey, $pcname, $elapsedtime, $remainingtime, $deadline) = mysqli_fetch_row($result))
$o .= '<tr id="tabletr"><td>'.$project.'</td><td>'.$taskname.'</td><td>'.$percent.'%</td><td>'.$status.'</td><td>'.$elapsedtime.'</td><td>'.$remainingtime.'</td><td>'.$deadline.'</td><td>'.$pcname.'</td></tr>';
echo $o;
?>
</tbody>
</table>
<br><br>

