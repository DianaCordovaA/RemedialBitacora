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
    public partial class Editar_Carrera : System.Web.UI.Page
    {
        LogicaCarrera objCarrera = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es falso se está realizando la carga por primera vez
            if (IsPostBack == false)
            {
                objCarrera = new LogicaCarrera();
                Session["objCarrera"] = objCarrera;


            }
            else
            {
                objCarrera = (LogicaCarrera)Session["objCarrera"];
            }

            if (!IsPostBack)
            {
                List<EntidadCarrera> mostrarCarreras = null;
                string msj = "";
                string id = Convert.ToString(Session["id_seleccionado"]);
                mostrarCarreras = objCarrera.ObtenerCarreraPorID(id, ref msj);
                if (mostrarCarreras != null)
                {
                    foreach (EntidadCarrera carrera in mostrarCarreras)
                    {
                        TextBox1.Text = carrera.nombre;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string msj = "";
            string id = Session["id_seleccionado"].ToString();
            string nombreeditado = TextBox1.Text;
            objCarrera.ModificarCarreraPorId(id, nombreeditado, ref msj);
            Response.Write("<script>alert('Registro actualizado');</script>");
            Server.Transfer("Carrera.aspx");
        }
    }
}