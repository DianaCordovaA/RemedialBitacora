using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassCapaEntidades;
using ClassCapaLogicaNegocios;
namespace Sistema_Bitacora_
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        LogicaCarrera accesoCarrera = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                accesoCarrera = new LogicaCarrera();
                Session["objAccesoCarrera"] = accesoCarrera;

                string msj = "";
                GridView1.DataSource = accesoCarrera.CarrerasGrid(ref msj);
                if (GridView1.DataSource != null)
                {
                    GridView1.DataBind();
                }
            }
            else
            {
                accesoCarrera = (LogicaCarrera)Session["objAccesoCarrera"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadCarrera entidad = new EntidadCarrera
            {
                nombre = TextBox1.Text
            };
            string mensaje = "";
            Boolean isSuccess = accesoCarrera.AgregarCarrera(entidad, ref mensaje);

            if (isSuccess == true)
            {
                Response.Write("<script>alert('"+mensaje+"');</script>");
            }
            GridView1.DataSource = accesoCarrera.CarrerasGrid(ref mensaje);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }

        protected void EliminarCarrera(object sender, EventArgs e)
        {
            string msj = "";
            string x = ((Button)sender).CommandArgument;
            string id = x.ToString();
            accesoCarrera.BorrarCarrera(id, ref msj);


            GridView1.DataSource = accesoCarrera.CarrerasGrid(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }

        public void EditarCarrera(object sender, EventArgs e)
        {
            string x = ((Button)sender).CommandArgument;
            Session["id_seleccionado"] = Convert.ToInt32(x);
            Server.Transfer("ModificarCarrera.aspx");
        }

        public void VerProgramasEducativos(object sender, EventArgs e)
        {
            string x = ((Button)sender).CommandArgument;
            Session["id_seleccionado"] = Convert.ToInt32(x);
            Server.Transfer("ProgramasEducativos.aspx");
        }
    }
}