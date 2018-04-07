<?php
/**
 * Obtiene todas las metas de la base de datos
 */

require 'Database.php';

   if( isset($_GET['email']) &&  isset($_GET['password'])) {
        $name = Database::getByUsuPas($_GET['email'], $_GET['password']);
        if ($name) {

        $datos["estado"] = 1;
        $datos["account"] = $name;

        echo json_encode($datos);
    } else {
        print json_encode(array(
            "estado" => 2,
            "mensaje" => "Ha ocurrido un error"
        ));
    }
    } 
    else {
        die("Solicitud no válida.");
    }



