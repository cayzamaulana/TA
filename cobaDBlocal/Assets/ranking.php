<?php
$Server = "localhost";
$User = "root";
$Pass = "";
$Db = "unity";
$Connection = mysql_connect($Server, $User, $Pass, $Db);

if(mysql_error()){
	die("Connection Failed!=". mysql_error());
}
mysql_select_db("unity", $Connection) or die("Could not load to database" . mysql_error());

$check = "SELECT username, nilai FROM peserta ORDER BY nilai DESC";
$result=mysql_query($check);
$numrows = mysql_num_rows($result);

if($numrows > 0 ){ 
	while($row=mysql_fetch_array($result))
	{ 
		echo " " .$row['username']. " : " .$row['nilai']. "\n" ;
	}
}

?>


