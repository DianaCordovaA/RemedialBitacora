<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificar_ProE.aspx.cs" Inherits="Sistema_Bitacora_.Edicion_PE" %>

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
      
    <nav class="navbar navbar-light bg-dark" style="margin-bottom:75px;">
      <div class="container-fluid d-flex justify-content-center">
        <a class="navbar-brand" href="#" style="color: #ffff; font-size:20px; ">Bitácora de laboratorio</a>
          
      </div>
        <div class="container-fluid d-flex justify-content-center">
      <p style="color: #ffff; font-size:15px; ">Elaborado por Diana Cordova Aguila</p>
          
      </div>
        </nav>

    <form id="form1" runat="server">
        <div class="form-floating text-center">
       <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control mb-2" ></asp:TextBox>
     <label for="TextBox1">Inserta el nuevo nombre del Programa Educativo:</label>   
         
</div>

           <div class="form-floating text-center"> 
         <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select mb-2"></asp:DropDownList>
            <label for="DropDownList1">Carreras disponibles:</label>
</div>
        <div class="form-floating text-center" style="margin-bottom:80px;">
             <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <label for="TextBox2">Nueva información extra:</label>
       <asp:Button ID="Button1" runat="server" Text="Actualizar nuevos datos" CssClass="btn btn-dark btn-lg mt-3" OnClick="Button1_Click" />
</div>
    </form>
</body>
</html>
