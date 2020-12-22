<?php
$postDATA = $_POST["postDATA"];
if ($postDATA=="hash_wifi_password"){
	$brand=$_POST["brand"];
	$branch=$_POST["branch"];
	$pos=$_POST["pos"];
	$year=$_POST["year"];
	$month=$_POST["month"];
	$day=$_POST["day"];
	$hour=$_POST["hour"];
	$min=$_POST["min"];
	$sec=$_POST["sec"];
	$hash = encrypt($brand, $branch, $pos, $year, $month, $day, $hour, $min, $sec) ; 
	echo $hash;
	}

function binFrom32($data){
	$data = strtoupper($data);
	switch($data){
	    case "2" : return "00000"; break;
		case "3" : return "00001"; break;
	    case "4" : return "00010"; break;
		case "5" : return "00011"; break;
	    case "6" : return "00100"; break;
		case "7" : return "00101"; break;
	    case "8" : return "00110"; break;
		case "9" : return "00111"; break;
	    case "A" : return "01000"; break;
		case "B" : return "01001"; break;
	    case "C" : return "01010"; break;
		case "D" : return "01011"; break;
	    case "E" : return "01100"; break;
		case "F" : return "01101"; break;
	    case "G" : return "01110"; break;
		case "H" : return "01111"; break;
		case "J" : return "10000"; break;
	    case "K" : return "10001"; break;
		case "L" : return "10010"; break;
	    case "M" : return "10011"; break;
		case "N" : return "10100"; break;
		case "P" : return "10101"; break;
	    case "Q" : return "10110"; break;
		case "R" : return "10111"; break;
	    case "S" : return "11000"; break;
		case "T" : return "11001"; break;
	    case "U" : return "11010"; break;
		case "V" : return "11011"; break;
	    case "W" : return "11100"; break;
		case "X" : return '11101'; break;
	    case "Y" : return '11110'; break;
		case "Z" : return '11111'; break;
	}
}

function bin32($bin){
	switch($bin){
		case "00000"; return "2"; break;
		case "00001"; return "3"; break;
	    case "00010"; return "4"; break;
		case "00011"; return "5"; break;
	    case "00100"; return "6"; break;
		case "00101"; return "7"; break;
	    case "00110"; return "8"; break;
		case "00111"; return "9"; break;
	    case "01000"; return "A"; break;
		case "01001"; return "B"; break;
	    case "01010"; return "C"; break;
		case "01011"; return "D"; break;
	    case "01100"; return "E"; break;
		case "01101"; return "F"; break;
	    case "01110"; return "G"; break;
		case "01111"; return "H"; break;
		case "10000"; return "J"; break;
	    case "10001"; return "K"; break;
		case "10010"; return "L"; break;
	    case "10011"; return "M"; break;
		case "10100"; return "N"; break;
		case "10101"; return "P"; break;
	    case "10110"; return "Q"; break;
		case "10111"; return "R"; break;
	    case "11000"; return "S"; break;
		case "11001"; return "T"; break;
	    case "11010"; return "U"; break;
		case "11011"; return "V"; break;
	    case "11100"; return "W"; break;
		case '11101'; return "X"; break;
	    case '11110'; return "Y"; break;
		case '11111'; return "Z"; break;
	
	}
}
function dec2bin($dec, $maxLen){
	$bin = decbin($dec);
	$len = strlen($bin);
	if($len % $maxLen > 0){
		for($i = 0; $i < $maxLen - ($len % $maxLen); $i++){
			$bin = "0" . $bin;
		}
	}
	return $bin;
}
function shiftBitLeft($bin, $shift){
	for($i = 0; $i < $shift;$i++){
		$first_bit = substr($bin, 0, 1);
		$bin = substr($bin, 1, strlen($bin) - 1) . $first_bit;
	}
	return $bin;
}
function shiftBitRight($bin, $shift){
	for($i = 0; $i < $shift;$i++){
		$last_bit = substr($bin, strlen($bin) - 1, 1);
		$bin = $last_bit . substr($bin, 0, strlen($bin) - 1);
	}
	return $bin;
}
function brand($brand_id){
	switch($brand_id){
		case 0 : return "KFC"; break;
		case 1 : return "MK"; break;
		case 2 : return "McDonald"; break;
		case 3 : return "Yayoi"; break;
		case 4 : return "Swensen"; break;
	}
}
function branch($b_id){
	switch($b_id){
		case 0 : return "Central World"; break;
		case 1 : return "Rama 3"; break;
		case 2 : return "Piyarom"; break;
		case 3 : return "Terminal 21"; break;
		case 4 : return "Siam Center"; break;
	}
}
function encrypt($brand, $branch, $pos, $year, $month, $day, $hour, $min, $sec){
	$csc = ($sec*9+$brand*8+$branch*7+$pos*6+$year*5+$month*4+$day*3+$hour*2+$min)%16;
	$binYear =  dec2bin($year, 7);
	$binMonth = dec2bin($month, 4);
	$binDay = dec2bin($day, 5);
	$binBrand = dec2bin($brand, 3);
	$binBranch = dec2bin($branch, 12);
	$binPos = dec2bin($pos, 3);
	$binHour = dec2bin($hour, 5);
	$binMin = dec2bin($min, 6);
	$binSec = dec2bin($sec, 6);
	$binCSC = dec2bin($csc, 4);
	$allbin = $binDay.$binPos.$binBrand.$binMin.$binYear.$binBranch.$binHour.$binMonth.$binSec;
	$allbin = shiftBitLeft($allbin, $csc*5).$binCSC;
	$encypt = bin32(substr($allbin,0,5));
	$encypt .= bin32(substr($allbin,5,5));
	$encypt .= bin32(substr($allbin,10,5));
	$encypt .= bin32(substr($allbin,15,5));
	$encypt .= bin32(substr($allbin,20,5));
	$encypt .= bin32(substr($allbin,25,5));
	$encypt .= bin32(substr($allbin,30,5));
	$encypt .= bin32(substr($allbin,35,5));
	$encypt .= bin32(substr($allbin,40,5));
	$encypt .= bin32(substr($allbin,45,5));
	$encypt .= bin32(substr($allbin,50,5));
	return $encypt;
}
function decrypt($encypt){

	$lastChar = binFrom32(substr($encypt,10,1));
	$binData = substr($lastChar, 0, 1); 
	$binCSC = substr($lastChar, 1, 4);
	$csc = bindec($binCSC);

	$binText = binFrom32(substr($encypt,0,1));
	$binText .= binFrom32(substr($encypt,1,1));
	$binText .= binFrom32(substr($encypt,2,1));
	$binText .= binFrom32(substr($encypt,3,1));
	$binText .= binFrom32(substr($encypt,4,1));
	$binText .= binFrom32(substr($encypt,5,1));
	$binText .= binFrom32(substr($encypt,6,1));
	$binText .= binFrom32(substr($encypt,7,1));
	$binText .= binFrom32(substr($encypt,8,1));
	$binText .= binFrom32(substr($encypt,9,1));
	$binText .= $binData;

	$binText = shiftBitRight($binText, $csc*5) . $binCSC;

	$data = array();
	$data['decry'] = bindec(substr($binText,0,5));
	$data['day'] = bindec(substr($binText,0,5));
	$data['pos'] = bindec(substr($binText,5,3));
	$data['brand'] = bindec(substr($binText,8,3));
	$data['min'] = bindec(substr($binText,11,6));
	$data['year'] = bindec(substr($binText,17,7));
	$data['branch'] = bindec(substr($binText,24,12));
	$data['hour'] = bindec(substr($binText,36,5));
	$data['month'] = bindec(substr($binText,41,4));
	$data['sec'] = bindec(substr($binText,45,6));
	$data['csc'] = bindec(substr($binText,51,4));
	$check_csc = ($data['sec']*9+$data['brand']*8+$data['branch']*7+$data['pos']*6+$data['year']*5+$data['month']*4+$data['day']*3+$data['hour']*2+$data['min'])%16;
	if($csc == $check_csc){
	
		
	}else{

		$data['decry'] = "Invalid";
		$data['day'] = "";
		$data['pos'] = "Invalid";
		$data['brand'] = "Invalid";
		$data['min'] = "";
		$data['price'] = "Invalid";
		$data['year'] = "";
		$data['branch'] = "Invalid";
		$data['hour'] = "Invalid";
		$data['month'] = "";
		$data['csc'] = "Invalid";

	}
	echo json_encode($data);
}

if($_POST['action'] == "encrypt"){
	$year = date("y");
	$month = date("m");
	$day = date("d");
	$hour = date("H") - 1 ;
	$min = date("i");
	$sec = date("s");
	$encypt = encrypt($_POST['brand'], $_POST['branch'], $_POST['pos'], $year, $month, $day, $hour, $min, $sec);
	$data = array();
	$data['encrypt'] = $encypt;
	echo json_encode($data);
}
if($_POST['action'] == "decrypt"){
	decrypt($_POST['encrypt']);
}
?>
