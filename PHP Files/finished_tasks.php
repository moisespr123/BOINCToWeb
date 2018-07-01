<head>

    <script src="tablesorter/docs/js/jquery-latest.min.js"></script>
    <link rel="stylesheet" href="tablesorter/css/theme.blue.css"/>
    <script src="tablesorter/js/jquery.tablesorter.js"></script> 
    <script type="text/javascript">
        $(document).ready(function()
            {
                $("table").tablesorter({ theme : 'blue' });
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
        <th>Elapsed Time</th> 
        <th>Aprox. Finished time</th>
        <th>Task Type</th>
        <th>Host</th>
    </tr> 
    </thead> 
    <tbody> 
<?php
/**
 * Created by PhpStorm.
 * User: cardo
 * Date: 7/1/2018
 * Time: 1:03 PM
 */
require_once 'config.php';
global $mysqli;
$result = $mysqli->query("SELECT * FROM finishedtasks ORDER BY AddedDate DESC, AddedTime DESC");
if (mysqli_num_rows($result) > 0){
    $o='';
    while($row = mysqli_fetch_assoc($result))
        $o .= "<tr id='tabletr'><td>".$row['Project']."</td><td>".$row['TaskName']."</td><td>".$row['ElapsedTime']."</td><td>".$row['AddedDate']." ".$row['AddedTime']." UTC</td><td>".$row['PlanClass']."</td><td>".$row['PCName']."</td></tr>";
    echo $o;
}
?>
    </tbody>
</table>
</body>