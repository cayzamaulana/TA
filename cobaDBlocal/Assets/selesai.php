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

$username = $_GET["r_username"];
$nilai = $_GET["r_nilai"];

$check = mysql_query("SELECT * FROM peserta WHERE `username` = '".$username."'");
$numrows = mysql_num_rows($check);

if($numrows == 0)
{
	die("Error");
}
else
{
	while($row = mysql_fetch_assoc($check))
	{
		if($username == $row['username'])
		{ 
			$sql = mysql_query("UPDATE `peserta` SET `nilai` = '".$nilai."' WHERE `username` = '".$username."'");
		}
		else
		{
			die("error");
		}
	}
}

?>