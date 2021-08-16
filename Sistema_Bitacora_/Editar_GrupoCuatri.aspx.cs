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
    public partial class Editar_GrupoCuatri : System.Web.UI.Page
    {
        LogicaGrupoCuatrimestre accesoGrupCuatri = null;
        LogicaProgramaEducativo accesoPrograma = null;
        LogicaGrupo accesoGrupo = null;
        LogicaCuatrimestre accesoCuatri = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //Acceso a las clases de las tras tablas
                accesoGrupCuatri = new LogicaGrupoCuatrimestre();
                accesoPrograma = new LogicaProgramaEducativo();
                accesoGrupo = new LogicaGrupo();
                accesoCuatri = new LogicaCuatrimestre();


                Session["accesoGrupCuatri"] = accesoGrupCuatri;
                Session["accesoPrograma"] = accesoPrograma;
                Session["accesoGrupo"] = accesoGrupo;
                Session["accesoCuatri"] = accesoCuatri;

                
            }
            else
            {
                accesoGrupCuatri = (LogicaGrupoCuatrimestre)Session["accesoGrupCuatri"];
                accesoPrograma = (LogicaProgramaEducativo)Session["accesoPrograma"];
                accesoGrupo = (LogicaGrupo)Session["accesoGrupo"];
                accesoCuatri = (LogicaCuatrimestre)Session["accesoCuatri"];
            }

            if (!IsPostBack)
            {
                List<EntidadGrupoCuatrimestre> grupoCuatrimestres = null;
                string msj = "";
                string id = Convert.ToString(Session["id_seleccionado"]);
                grupoCuatrimestres = accesoGrupCuatri.ObtenerGrupoCuatrimestrePorId(id, ref msj);
                if (grupoCuatrimestres != null)
                {
                    foreach (EntidadGrupoCuatrimestre entidadGC in grupoCuatrimestres)
                    {
                        TextBox1.Text = entidadGC.Turno;
                        TextBox2.Text = entidadGC.Modalidad;
                        TextBox3.Text = entidadGC.Extra;
                    }
                }

                List<EntidadProgramaEducativo> Programas = null;

                Programas = accesoPrograma.ListadoDeProgramas(ref msj);
                if (Programas != null)
                {
                    foreach (EntidadProgramaEducativo programa in Programas)
                    {
                        DropDownList1.Items.Add(new ListItem(programa.ProgramaEd.ToString(), programa.id_pe.ToString()));
                        DropDownList1.DataBind();
                    }
                }

                List<EntidadGrupo> Grupos = null;
                Grupos = accesoGrupo.ListadoDeGrupo(ref msj);
                if (Grupos != null)
                {
                    foreach (EntidadGrupo grupo in Grupos)
                    {
                        DropDownList2.Items.Add(new ListItem(grupo.grado.ToString() + grupo.letra.ToString(), grupo.in_Grupo.ToString()));
                        DropDownList2.DataBind();
                    }
                }

                List<EntidadCuatrimestre> Cuatrimestre = null;
                Cuatrimestre = accesoCuatri.ListadoDeCuatrimestre(ref msj);
                if (Cuatrimestre != null)
                {
                    foreach (EntidadCuatrimestre cuatrimestre in Cuatrimestre)
                    {
                        DropDownList3.Items.Add(new ListItem(cuatrimestre.periodo.ToString() + "  " + cuatrimestre.anio.ToString(), cuatrimestre.id_cuatri.ToString()));
                        DropDownList3.DataBind();
                    }
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadGrupoCuatrimestre entidad = new EntidadGrupoCuatrimestre
            {
                F_ProgEd = Convert.ToByte(DropDownList1.SelectedValue),
                F_Grupo = Convert.ToInt16(DropDownList2.SelectedValue),
                F_Cuatri = Convert.ToInt16(DropDownList3.SelectedValue),
                Turno = TextBox1.Text,
                Modalidad = TextBox2.Text,
                Extra = TextBox3.Text
            };
            string msj = "";
            string id = Convert.ToString(Session["id_seleccionado"]);
            accesoGrupCuatri.EdicionGrupoCuatri(entidad, id, ref msj);
            Response.Write("<script>alert('Datos editados correctamente');</script>");
            Server.Transfer("GrupoCuatrimestre.aspx");
        }
    }
}