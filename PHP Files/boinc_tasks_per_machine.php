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
<?php
require_once 'config.php';
global $mysqli;

function getTasksPerMachine($mysqli, $machine){
    $query = $mysqli->prepare("SELECT * FROM tasks WHERE PCname=? ORDER BY Status DESC");
    $query->bind_param("s", $machine);
    $query->execute();
    $result = $query->get_result();
    if (mysqli_num_rows($result) > 0){
        $o='<table id="myTable" class="tablesorter">
            <thead> 
            <tr> 
                    <th>Project</th> 
                    <th>Workunit Name</th> 
                    <th>Percent Done</th> 
                    <th>Status</th> 
                    <th>Elapsed Time</th> 
                <th>Remaining Time</th>
                <th>Deadline</th>
            </tr> 
            </thead> 
            <tbody> ';
        echo '<h2 id="'.$machine.'">' . $machine . '</h2>';
        while($row = mysqli_fetch_assoc($result))
            $o .= "<tr id='tabletr'><td>".$row['Project']."</td><td>".$row['TaskName']."</td><td>".$row['PercentDone']."%</td><td>".$row['Status']."</td><td>".$row['ElapsedTime']."</td><td>".$row['RemainingTime']."</td><td>".$row['ReportDeadline']."</td></tr>";
        echo $o . '</tbody></table></br></br>';
    }
}
function getTasksFromMachines($mysqli){
    $result = $mysqli->query("SELECT DISTINCT PCName FROM tasks ORDER BY PCName ASC");
    if (mysqli_num_rows($result) > 0)
        while ($row = mysqli_fetch_assoc($result))
            getTasksPerMachine($mysqli, $row['PCName']);
}
function printMachinesLinks($mysqli){
    $result = $mysqli->query("SELECT DISTINCT PCName FROM tasks ORDER BY PCName ASC");
    if (mysqli_num_rows($result) > 0) {
        echo "<h1>Machine list</h1></br><ul>";
        while ($row = mysqli_fetch_assoc($result))
            echo '<li><a href="#' . $row['PCName'] . '">' . $row['PCName'] . '</a></li>';
        echo '</ul></br></br>';
    }
    else
        echo "There's no machines configured to display their BOINC Tasks.";
}

printMachinesLinks($mysqli);
getTasksFromMachines($mysqli);

?>
</body>