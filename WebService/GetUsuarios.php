<?php
/**
 * Obtiene todas las metas de la base de datos
 */

require 'Database.php';
    $name = Database::getUsuarios();
    if ($name) {

        
         $name;

        echo json_encode($name);
    } else {
        print json_encode(array(
            
            "mensaje" => "Ha ocurrido un error"
        ));
    }
    
   