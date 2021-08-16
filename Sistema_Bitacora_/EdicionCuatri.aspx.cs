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
    public partial class EdicionCuatri : System.Web.UI.Page
    {
        LogicaCuatrimestre accessoCuatri = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Si es falso se está realizando la carga por primera vez
            if (IsPostBack == false)
            {
                accessoCuatri = new LogicaCuatrimestre();
                Session["accessoCuatri"] = accessoCuatri;


            }
            else
            {
                accessoCuatri = (LogicaCuatrimestre)Session["accessoCuatri"];
            }

            if (!IsPostBack)
            {
                List<EntidadCuatrimestre> mostrarCuatrimestre = null;
                string msj = "";
                string id = Convert.ToString(Session["id_seleccionado"]);
                mostrarCuatrimestre = accessoCuatri.ObtenerCuatrimestrePorId(id, ref msj);
                if (mostrarCuatrimestre != null)
                {
                    foreach (EntidadCuatrimestre cuatrimestre in mostrarCuatrimestre)
                    {
                        TextBox1.Text = cuatrimestre.periodo;
                        TextBox2.Text = cuatrimestre.anio.ToString();
                        TextBox3.Text = cuatrimestre.inicio;
                        TextBox4.Text = cuatrimestre.fin;
                        TextBox5.Text = cuatrimestre.extra;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadCuatrimestre entidad = new EntidadCuatrimestre
            {
                periodo = TextBox1.Text,
                anio = Convert.ToInt32(TextBox2.Text),
                inicio = TextBox3.Text,
                fin = TextBox4.Text,
                extra = TextBox5.Text
            };
            string msj = "";
            string id = Session["id_seleccionado"].ToString();
            accessoCuatri.ModificarCuatriPorId(entidad, id, ref msj);
            Response.Write("<script>alert('Información actualizada con éxito');</script>");
            Server.Transfer("Cuatrimestre.aspx");
        }
    }
}