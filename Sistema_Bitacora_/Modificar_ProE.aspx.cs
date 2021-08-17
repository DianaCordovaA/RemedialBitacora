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
    public partial class Edicion_PE : System.Web.UI.Page
    {
        LogicaCarrera accesoCarrera = null;

        LogicaProgramaEducativo accesoPrograma = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                accesoCarrera = new LogicaCarrera();
                Session["accesoCarrera"] = accesoCarrera;

                accesoPrograma = new LogicaProgramaEducativo();
                Session["accesoPrograma"] = accesoPrograma;


            }
            else
            {
                accesoCarrera = (LogicaCarrera)Session["accesoCarrera"];
                accesoPrograma = (LogicaProgramaEducativo)Session["accesoPrograma"];
            }


            if (!IsPostBack)
            {
                List<EntidadCarrera> mostrarCarreras = null;
                string msj = "";
                mostrarCarreras = accesoCarrera.MostrarCarreras(ref msj);
                if (mostrarCarreras != null)
                {
                    foreach (EntidadCarrera carrera in mostrarCarreras)
                    {
                        DropDownList1.Items.Add(new ListItem(carrera.nombre.ToString(), carrera.id_carrera.ToString()));
                        DropDownList1.DataBind();
                    }
                }

                List<EntidadProgramaEducativo> mostrarPrograma = null;

                string id = Convert.ToString(Session["id_seleccionado"]);
                mostrarPrograma = accesoPrograma.MostrarProgramaEspecifico(id, ref msj);
                if (mostrarPrograma != null)
                {
                    foreach (EntidadProgramaEducativo programa in mostrarPrograma)
                    {
                        TextBox1.Text = programa.ProgramaEd;
                        TextBox2.Text = programa.Extra;
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Session["id_seleccionado"].ToString();


            EntidadProgramaEducativo entidadPrograma = new EntidadProgramaEducativo
            {
                ProgramaEd = TextBox1.Text,
                Extra = TextBox2.Text
            };
            if (DropDownList1.SelectedItem != null)
            {

                Session["id_Carrera"] = Convert.ToInt32(DropDownList1.SelectedValue);
            };


            string idCarrera = Convert.ToString(DropDownList1.SelectedValue);
            string mensaje = "";


            mensaje = accesoPrograma.CambiarPrograma(id, entidadPrograma, idCarrera, ref mensaje);
            Server.Transfer("ProgramasEducativos.aspx");
        }
    }
}