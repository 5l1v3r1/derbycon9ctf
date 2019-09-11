<?php

$req_dump = print_r($_REQUEST, TRUE);

foreach (getallheaders() as $name => $value) {
$req_dump = $req_dump . "$name: $value\n";
}

$fp = fopen('request.log', 'a');
fwrite($fp, $req_dump);
fclose($fp);
?>
