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
    public partial class Grupo : System.Web.UI.Page
    {
        LogicaGrupo accesoGrupo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                accesoGrupo = new LogicaGrupo();
                Session["accesoGrupo"] = accesoGrupo;

                string msj = "";

                //Carga de datos en el gridview
                GridView1.DataSource = accesoGrupo.GruposGrid(ref msj);
                if (GridView1.DataSource != null)
                {
                    GridView1.DataBind();
                }


            }
            else
            {
                accesoGrupo = (LogicaGrupo)Session["accesoGrupo"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadGrupo entidad = new EntidadGrupo
            {
                grado = Convert.ToByte(TextBox1.Text),
                letra = TextBox2.Text,
                extra = TextBox3.Text
            };
            string mensaje = "";
            Boolean isSuccess = accesoGrupo.AgregarGrupo(entidad, ref mensaje);
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void EliminarGrupo(object sender, EventArgs e)
        {
            string msj = "";
            string x = ((Button)sender).CommandArgument;
            string id = x.ToString();
            accesoGrupo.BorrarGrupo(id, ref msj);
            

            GridView1.DataSource = accesoGrupo.GruposGrid(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }
        protected void EditarGrupo(object sender, EventArgs e)
        {
            string x = ((Button)sender).CommandArgument;
            Session["id_seleccionado"] = Convert.ToInt32(x);
            Server.Transfer("ModificarGrupo.aspx");

        }


    }
}