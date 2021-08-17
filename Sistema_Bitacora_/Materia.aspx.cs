using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaLogicaNegocios;
using ClassCapaEntidades;

namespace Sistema_Bitacora_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaMateria objMateria = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (IsPostBack == false)
            {
                objMateria = new LogicaMateria();
                Session["objMateria"] = objMateria;

                string msj = "";
                GridView1.DataSource = objMateria.MostrarMaterias(ref msj);
                if (GridView1.DataSource != null)
                {
                    GridView1.DataBind();
                }


            }
            else
            {
                objMateria = (LogicaMateria)Session["objMateria"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadMateria entidad = new EntidadMateria
            {
                NombreMateria = TextBox1.Text,
                HorasSemana = Convert.ToByte(TextBox2.Text),
                Extra = TextBox3.Text
            };
            string mensaje = "";
            objMateria.AgregarMateria(entidad, ref mensaje);
            Response.Write("<script>alert('" + mensaje + "');</script>");
           

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            string msj = "";
            GridView1.DataSource = objMateria.MostrarMaterias(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }
        protected void EliminarMateria(object sender, EventArgs e)
        {
            string msj = "";
            string x = ((Button)sender).CommandArgument;
            string id = x.ToString();
            objMateria.BorrarMateria(id, ref msj);


            GridView1.DataSource = objMateria.MostrarMaterias(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }
        protected void EditarMateria(object sender, EventArgs e)
        {
            string x = ((Button)sender).CommandArgument;
            Session["id_seleccionado"] = Convert.ToInt32(x);
            Server.Transfer("Materia.aspx");

        }




    }
}