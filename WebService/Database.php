<?php 
	
class Database{
    
    //Abrir la sesion de usuario
    //session_start();

    /**
     * Mensajes de error
     */
    public static function mensajesError($e) {

        switch ($e->errorInfo[1]) {
                case 1062:
                        $mensaje = "Registro duplicado";
                        break;
                case 1451:
                        $mensaje = "Tiene registros relacionados";
                        break;
                default:
                        $mensaje = $e->getMessage();
                        break;
        }

        return $mensaje;
    }

    /**
     * Abrir la conexiÃ³n
     */

    public static  function abrirConexion()
    {			
        //Creamos la conexiÃ³n
        //Bd::$conexion = new PDO("mysql:host=$servername;dbname=$database", $username, $password, array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES  \'UTF8\''));

        //$db = ['host' => '192.168.0.10', 'database' => 'capraboacasa', 'username' => 'root', 'password' => ''];

    $conexion = new PDO("mysql:dbname=equip4; host=localhost", 'root', '', array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES  \'UTF8\''));

        // set the PDO error mode to exception
        $conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

            return $conexion;
    }

    /**
     * Cerrar la conexiÃ³n
     */

    public static function cerrarConexion ()
    {
        return null;
    }
    
 

/**
 * Metode per comprobar si un usuari existeix
 * @param type $email
 * @param type $password
 * @return type
 */
    public static function getByUsuPas($email, $password){
        try {
            $conexion =  Database::abrirConexion();
            $sentencia = $conexion->prepare('select * from account where email= :name and password= :password');
            $sentencia->bindParam(':name', $email);
            $sentencia->bindParam(':password', $password);
            $sentencia->execute();
            $row = $sentencia->fetch(PDO::FETCH_ASSOC);
            
            return $row;

        } catch (PDOException $e) {
                //$_SESSION['mensaje'] =  mensajesError($e);
        }
        $conexion = Database::cerrarConexion();    
    }

 /**
  * Metode per registrar un usuari
  * @param type $email
  * @param type $passwd
  * @return type
  */
    public static function insertUser($email, $password)
    {
            //unset($_SESSION['mensaje']);
            try {
                $conexion = Database::abrirConexion();

//                $sentencia = $conexion->prepare('select email from account  where email = (:email)');
//                if($result = $sentencia->execute()){
//                    if($row = $sentencia->rowCount() > 0){
                        $sentencia = $conexion->prepare('insert into account (email, password) values (:email, :password)');
                        
                        $sentencia->bindParam(':email', $email);
                        $sentencia->bindParam(':passwd', $password);
                        $sentencia->execute();
                        $row = $sentencia->fetch(PDO::FETCH_ASSOC);
                        
//                    }
//                }
                
            return $row;
            } catch (PDOException $e) {
                    //$_SESSION['mensaje'] =  mensajesError($e);
                    //$_SESSION['seccion'] = array('desc_seccion' => $desc_seccion);
            }

            $conexion = Database::cerrarConexion();
    }
    
     public static function getUsuarios(){
        try {
            $conexion =  Database::abrirConexion();
            $sentencia = $conexion->prepare('select email, password from account');
            $sentencia->execute();
            while($row = $sentencia->fetch(PDO::FETCH_ASSOC)){
                $data[] = $row;
            }
            
            return $data;

        } catch (PDOException $e) {
                //$_SESSION['mensaje'] =  mensajesError($e);
        }
        $conexion = Database::cerrarConexion();    
    }


   
    function selectSecciones()
    {
            //Recuperamos todas las secciones
            try {
                    $conexion = abrirConexion();

                    $texto = "select * from secciones";

                    $sentencia = $conexion->prepare($texto);
                    $sentencia->execute();
            } catch (PDOException $e) {
                    $_SESSION['mensaje'] =  mensajesError($e);
            }

            $conexion = cerrarConexion();

            return $sentencia;
    }

    /*
     * Buscar una secciÃ³n por su clave primaria
     */
    function selectSeccionById ($id_seccion) {
            try {
                    $conexion = abrirConexion();

                    $sentencia = $conexion->prepare('select * from secciones where id_seccion = :id_seccion');
                    $sentencia->bindParam(':id_seccion', $id_seccion);
                    $sentencia->execute();

            } catch (PDOException $e) {
                    $_SESSION['mensaje'] =  mensajesError($e);
            }

            $conexion = cerrarConexion();

            return $sentencia;
    }



    /**
     ** Modificar una secciÃ³n
     **/
    function updateSeccion($id_seccion, $desc_seccion)
    {
            try {
                    $conexion = abrirConexion();

                    $sentencia = $conexion->prepare('update secciones set desc_seccion = :desc_seccion where id_seccion = :id_seccion');
                    $sentencia->bindParam(':desc_seccion', $desc_seccion);
                    $sentencia->bindParam(':id_seccion', $id_seccion);
                    $sentencia->execute();
            } catch (PDOException $e) {
                    $_SESSION['mensaje'] =  mensajesError($e);
                    $_SESSION['seccion'] = 
                            array('id_seccion' => $id_seccion,
                                      'desc_seccion' => $desc_seccion);
            }

            $conexion = cerrarConexion();
    }

    /**
     * Borrar una secciÃ³n
     */

    function deleteSeccion($id_seccion)
    {
            try {
                    $conexion = abrirConexion();

                    $sentencia = $conexion->prepare('delete from secciones where id_seccion = :id_seccion');
                    $sentencia->bindParam(':id_seccion', $id_seccion);
                    $sentencia->execute();
            } catch (PDOException $e) {
                    $_SESSION['mensaje'] =  mensajesError($e);
            }

            $conexion = cerrarConexion();
    }
}

 ?>