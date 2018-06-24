<?php
/**
 * Created by PhpStorm.
 * User: cardo
 * Date: 6/24/2018
 * Time: 9:00 AM
 */
global $mysqli;

$mysqlserver = '';
$mysqluser = '';
$mysqlpass = '';
$mysqldatabase = '';

$mysqli = new mysqli($mysqlserver, $mysqluser, $mysqlpass, $mysqldatabase);
if ($mysqli->connect_error) {
    exit('Error connecting to database');
}