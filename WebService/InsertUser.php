<?php

require 'Database.php';

echo 'Estas a insertar usuari';
if( isset($_GET['email']) &&  isset($_GET['passwd'])) {
    $name = Database::insertUser($_GET['email'], $_GET['passwd']);
    if($name){
         $datos["estado"] = 1;
        $datos["account"] = $name;

        echo json_encode($datos);
    }
    else{
          print json_encode(array(
        "estado" => 2,
        "mensaje" => "pot ser que no sigui error"
    ));
    }
}
