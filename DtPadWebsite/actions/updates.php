<?php
/*  
Version: 1.0.0.0 - build 20121030
Created by: Marco Macciò
Website: http://dtpad.codeplex.com/
*/
$data = date('d/m/Y');
$from = $_GET['from'];
$to = $_GET['to'];
$environment = $_GET['env'];
$outcome = $_GET['out'];
$remote_addr = $_SERVER['REMOTE_ADDR'];
$http_user_agent = $_SERVER['HTTP_USER_AGENT'];

if ($http_user_agent == "DtPad Updater")
{
	$file_updates = fopen("../data/updates.dat", "a+");
	fwrite($file_updates, ">> Date: $data | Remote address: $remote_addr | User agent: $http_user_agent | From: $from | To: $to | Environment: $environment | Outcome: $outcome \n\r");
	fclose($file_updates);
}
?>
