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
            //Si es falso se está realizando la carga por primera vez
            if (IsPostBack == false)
            {
                objMateria = new LogicaMateria();
                Session["objMateria"] = objMateria;

            }
            else
            {
                objMateria = (LogicaMateria)Session["objMateria"];

            }
        }
    }
}