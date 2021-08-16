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
    public partial class Editar_Grupo : System.Web.UI.Page
    {
        LogicaGrupo accesoGrupo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (IsPostBack == false)
            {
                accesoGrupo = new LogicaGrupo();
                Session["accesoGrupo"] = accesoGrupo;
            }
            else
            {
                accesoGrupo = (LogicaGrupo)Session["accesoGrupo"];

            }

            //Carga de datos en los inputs
            if (!IsPostBack)
            {
                List<EntidadGrupo> mostrarGrupos = null;
                string msj = "";
                string id = Convert.ToString(Session["id_seleccionado"]);
                mostrarGrupos = accesoGrupo.ObtenerGrupoPorID(id, ref msj);
                if (mostrarGrupos != null)
                {
                    foreach (EntidadGrupo grupo in mostrarGrupos)
                    {
                        TextBox1.Text = grupo.grado.ToString();
                        TextBox2.Text = grupo.letra;
                        TextBox3.Text = grupo.extra;
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string msj = "";
            string id = Session["id_seleccionado"].ToString();

            EntidadGrupo entidad = new EntidadGrupo
            {
                grado = Convert.ToByte(TextBox1.Text),
                letra = TextBox2.Text,
                extra = TextBox3.Text
            };

            accesoGrupo.ModificarGrupoPorId(id, entidad, ref msj);

            Server.Transfer("Grupo.aspx");
        }
    }
}