<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grupo.aspx.cs" Inherits="Sistema_Bitacora_.Grupo" %>

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
      <p style="color: #ffff; font-size:15px; ">Elaborado por Diana Cordova Aguilar</p>
          
      </div>
        
    </nav>


    <form id="form1" runat="server">
        <div class="form-floating text-center">
       <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control mb-3" MaxLength="1" ></asp:TextBox>
  <label for="TextBox1">Inserte el grado de su grupo:</label>
</div>

               <div class="form-floating text-center">
       <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control mb-3" MaxLength="1" ></asp:TextBox>
  <label for="TextBox2">Inserte el letra de su grupo:</label>
</div>

        
               <div class="form-floating text-center" style="margin-bottom: 80px;">
       <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ></asp:TextBox>
  <label for="TextBox3">Ingrese información extra:</label>
   <asp:Button ID="Button1" runat="server" Text="Insertar nuevo grupo" CssClass="btn btn-dark btn-lg mt-3" OnClick="Button1_Click" />

</div>

        <asp:GridView ID="GridView1" runat="server" CssClass="table table-dark table-striped">
        
             <Columns>
           
            <asp:TemplateField HeaderText="Edición" SortExpression="[Id Especifico]">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-outline-warning m-2" OnClick="EditarGrupo" ID='LinkButton2' runat="server" Text="Editar registro" CommandArgument='<%# Bind("[Codigo]")%>'></asp:Button>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminación" SortExpression="[Id Especifico]">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-outline-danger m-2" OnClick="EliminarGrupo" ID='LinkButton3' runat="server" Text="Eliminar registro" CommandArgument='<%# Bind("[Codigo]")%>'></asp:Button>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>                   
        
        
        
        </asp:GridView>

    </form>
</body>
</html>
