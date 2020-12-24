<?php

include("connection.php");
$db = new dbObj();
$connection =  $db->getConnstring();
$request_method=$_SERVER["REQUEST_METHOD"];
//which method

switch($request_method)
{
  case 'GET':
   // GET with id
   if(!empty($_GET["id"]))
   {
    $id=intval($_GET["id"]);
    get_allatoksid($id);
   }
   else
   {
     get_allatoks(); //all allatoks
   }
   break;
 case 'POST':
  // Insert new allatoke with POST
  insert_allatok();
  break;

 case 'PUT':
   // Update an allatok (with id) and PUT method
   $id=intval($_GET["id"]);
   update_allatok($id);
   break;
 case 'DELETE':
   // Delete an allatok with ID, DELETE method
   $id=intval($_GET["id"]);
   delete_allatok($id);
   break;
 default:
  // Invalid Request Method
    header("HTTP/1.0 405 Method Not Allowed");
    break;
} 



function get_allatoks()
{
  global $connection;
  $query="SELECT * FROM allatok";
  $response=array();
  $result=mysqli_query($connection, $query);
  while($row=mysqli_fetch_array($result))
  {
    $response[]=$row;
  }
  header('Content-Type: application/json'); //send the header
  echo json_encode($response); //data in JSON format
}

function get_allatoksid($id=0)
{
  global $connection;
  $query="SELECT * FROM allatok";
  if($id != 0)
  {
    $query.=" WHERE id=".$id." LIMIT 1"; //get allatok with a given id
  }
  $response=array();
  $result=mysqli_query($connection, $query);
  while($row=mysqli_fetch_array($result))
  {
    $response[]=$row;
  }
  header('Content-Type: application/json'); //header
  echo json_encode($response); //in JSON format
}

function insert_allatok()
 {
  global $connection;
   
    $data = json_decode(file_get_contents('php://input'), true); //getting data from the client
    $name=$data["name"]; //separate them
    $classs=$data["classs"];
    $lovewinter=$data["lovewinter"];
	$lovechrismas=$data["lovechrismas"];
	
    echo $query="INSERT INTO allatok SET name='".$name."', classs='".$classs."', lovewinter='".$lovewinter."', lovechrismas='".$lovechrismas."'";
    if(mysqli_query($connection, $query))
    {
       $response=array(
             'status' => 1,
             'status_message' =>'allatok Added Successfully.'
              );
    }
    else
    {
       $response=array(
             'status' => 0,
             'status_message' =>'allatok Addition Failed.'
             );
    }
    header('Content-Type: application/json');
    echo json_encode($response); //response with header 
                         }
function delete_allatok($id)
{
   global $connection;
  $query="DELETE FROM allatok WHERE id=".$id;
   if(mysqli_query($connection, $query))
   {
     $response=array(
      'status' => 1,
       'status_message' =>'allatok Deleted Successfully.'
      );
   }
   else
   {
      $response=array(
         'status' => 0,
         'status_message' =>'allatok Deletion Failed.'
      );
   }
   header('Content-Type: application/json');
   echo json_encode($response);
}
                  

function update_allatok($id)
 {
   global $connection;
   $post_vars = json_decode(file_get_contents("php://input"),true);
   $name=$post_vars["name"];
   $classs=$post_vars["classs"];
   $lovewinter=$post_vars["lovewinter"];
   $lovechrismas=$post_vars["lovechrismas"];
   $query="UPDATE allatok SET name='".$name."', classs='".$classs."', lovewinter='".$lovewinter."', lovechrismas='".$lovechrismas."' WHERE id=".$id;
   if(mysqli_query($connection, $query))
   {
      $response=array(
         'status' => 1,
         'status_message' =>'allatok Updated Successfully.'
      );
    }
    else
    {
        $response=array(
            'status' => 0,
           'status_message' =>'allatok Updation Failed.'
        );
    }
    header('Content-Type: application/json');
    echo json_encode($response);
}                  
       
?>