<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sistema_Bitacora_.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Prompt:ital,wght@0,100;0,200;0,300;0,400;0,700;0,800;0,900;1,100;1,200;1,300;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet">
    <title>Bitacora</title>
</head>

<body>
    <style>
        *{
            font-family: 'Prompt', sans-serif;
        }
    </style>
      
    <nav class="navbar navbar-light bg-dark">
      <div class="container-fluid d-flex justify-content-center">
        <a class="navbar-brand" href="#" style="color: #ffff; font-size:20px; ">Bitácora de laboratorio</a>
          
      </div>
        <div class="container-fluid d-flex justify-content-center">
      <p style="color: #ffff; font-size:15px; ">Elaborado por Diana Cordova Aguilar</p>
          
      </div>
        
    </nav>

    <form id="form1" runat="server">
        
        <div class="" style="margin-top: 25px;"> 

            <div class="row">

            <div class="col d-flex justify-content-center">
                <div class="card text-center" style="width: 18rem;">
                <div class="text-center">
                  </div>
                <div class="card-body">
                    <h5 class="card-title" style="font-weight:500;">Carreras</h5>
                    <p class="card-text">Operaciones CRUD en la tabla Carreras</p>
                    <a href="Carrera.aspx" style="background-color:#212529" class="btn btn-dark btn-lg">Realizar operaciones</a>
                </div>
                
            </div> <%--Primera Card--%>
            </div> <%--Fin de primera col--%>


            <div  class="col d-flex justify-content-center">
                <div class="card text-center" style="width: 18rem;">
                <div class="text-center">
                  </div>
                <div class="card-body">
                    <h5 class="card-title" style="font-weight:500;">Programas educativos</h5>
                    <p class="card-text">Operaciones CRUD en la tabla Programas Educativos</p>
                    <a href="ProgramasEducativos.aspx" style="background-color:#212529" class="btn btn-dark btn-lg">Realizar operaciones</a>
                </div>
                
            </div> <%--Segunda Card--%>

            </div>

                <div  class="col d-flex justify-content-center">
                <div class="card text-center" style="width: 18rem;">
                <div class="text-center">
                  </div>
                <div class="card-body">
                    <h5 class="card-title" style="font-weight:500;">Cuatrimestre</h5>
                    <p class="card-text">Operaciones CRUD en la tabla Cuatrimestre</p>
                    <a href="Cuatrimestre.aspx" style="background-color:#212529" class="btn btn-dark btn-lg">Realizar operaciones</a>
                </div>
                
            </div> <%--Tercera Card--%>
            </div>

        <div class="col d-flex justify-content-center">
                <div class="card text-center" style="width: 18rem;">
                <div class="text-center">
                  </div>
                <div class="card-body">
                    <h5 class="card-title" style="font-weight:500;">Grupos</h5>
                    <p class="card-text">Operaciones CRUD en la tabla Grupos</p>
                    <a href="Grupo.aspx" style="background-color:#212529" class="btn btn-dark btn-lg">Realizar operaciones</a>
                </div>
                
            </div> <%--Cuarta Card--%>

            </div>

        <div class="col-md-3 mt-5" style="margin-left:17px; margin-bottom:20px;">
                <div class="card text-center" style="width: 18rem;">
                <div class="text-center">
                  </div>
                <div class="card-body">
                    <h5 class="card-title" style="font-weight:500;">Materias</h5>
                    <p class="card-text">Operaciones CRUD en la tabla Materias</p>
                    <a href="Materia.aspx" style="background-color:#212529" class="btn btn-dark btn-lg">Realizar operaciones</a>
                </div>
                
            </div> <%--Quinta Card--%>

            </div>

                <div class="col-md-3  mt-5">
                    <div class="card text-center" style="width: 18rem;">
                        <div class="text-center">
                        </div>
                        <div class="card-body">
                            <h5 class="card-title" style="font-weight: 500;">Grupo - Cuatrimestre</h5>
                            <p class="card-text">Operaciones CRUD en la tabla Grupo - Cuatrimestre</p>
                            <a href="GrupoCuatrimestre.aspx" style="background-color: #212529" class="btn btn-dark btn-lg">Realizar operaciones</a>
                        </div>

                    </div>
                    <%--Sexta Card--%>
                </div>


            
              

             
  
        </div>
    </form>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj" crossorigin="anonymous"></script>

    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-eMNCOe7tC1doHpGoWe/6oMVemdAVTMs2xqW4mwXrXsW0L84Iytr2wi5v2QjrP/xp" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
</body>
</html>