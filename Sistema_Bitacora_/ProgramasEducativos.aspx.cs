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
    public partial class ProgramasEducativos : System.Web.UI.Page
    {
        LogicaCarrera accesoCarrera = null;
        LogicaProgramaEducativo accesoPrograma = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es falso se está realizando la carga por primera vez
            if (IsPostBack == false)
            {
                accesoCarrera = new LogicaCarrera();
                Session["accesoCarrera"] = accesoCarrera;

                accesoPrograma = new LogicaProgramaEducativo();
                Session["accesoPrograma"] = accesoPrograma;

                string msj = "";
                GridView1.DataSource = accesoPrograma.ProgramasGrid(ref msj);
                if (GridView1.DataSource != null)
                {
                    GridView1.DataBind();
                }
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
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadProgramaEducativo entidadPrograma = new EntidadProgramaEducativo
            {
                ProgramaEd = TextBox1.Text,
                Extra = TextBox2.Text
            };
            if (DropDownList1.SelectedItem != null)
            {

                Session["id_Carrera"] = Convert.ToInt32(DropDownList1.SelectedValue);
            };

            EntidadCarrera entidadCarrera = new EntidadCarrera
            {
                id_carrera = Convert.ToInt32(Session["id_Carrera"])
            };

            string mensaje = "";


            Boolean isSucces = accesoPrograma.AgregarPrograma(entidadPrograma, entidadCarrera, ref mensaje);
            Server.Transfer("ProgramasEducativos.aspx");
        }

        public void EliminarPrograma(object sender, EventArgs e)
        {
            string msj = "";
            string x = ((Button)sender).CommandArgument;
            string id = x.ToString();
            accesoPrograma.BorrarPrograma(id, ref msj);

            GridView1.DataSource = accesoPrograma.ProgramasGrid(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }
        public void EditarPrograma(object sender, EventArgs e)
        {
            string x = ((Button)sender).CommandArgument;
            Session["id_seleccionado"] = Convert.ToInt32(x);
            Server.Transfer("Modificar_ProE.aspx");
        }
    }
}