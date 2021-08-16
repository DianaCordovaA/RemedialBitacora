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
    public partial class GrupoMateria : System.Web.UI.Page
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

                string msj = "";
                GridView1.DataSource = accesoGrupCuatri.ObtenerGrupoCuatrimestreGrid(ref msj);
                if (GridView1.DataSource != null)
                {
                    GridView1.DataBind();
                }
            }
            else
            {
                accesoGrupCuatri = (LogicaGrupoCuatrimestre)Session["accesoGrupCuatri"];
                accesoPrograma = (LogicaProgramaEducativo)Session["accesoPrograma"];
                accesoGrupo = (LogicaGrupo)Session["accesoGrupo"];
                accesoCuatri = (LogicaCuatrimestre)Session["accesoCuatri"];
            }

            //Carga de datos en los dropdownList
            if (!IsPostBack)
            {

                List<EntidadProgramaEducativo> Programas = null;
                string msj = "";
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

                List<EntidadCuatrimestre> Cuatrimestres = null;
                Cuatrimestres = accesoCuatri.ListadoDeCuatrimestre(ref msj);
                if (Cuatrimestres != null)
                {
                    foreach (EntidadCuatrimestre cuatrimestre in Cuatrimestres)
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
            accesoGrupCuatri.InsertarGrupoCuatrimestre(entidad, ref msj);

            GridView1.DataSource = accesoGrupCuatri.ObtenerGrupoCuatrimestreGrid(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }

        }

        protected void EliminarGroupCuatrimestre(object sender, EventArgs e)
        {

            string msj = "";
            string x = ((Button)sender).CommandArgument;
            string id = x.ToString();
            accesoGrupCuatri.EliminarGrupoCuatrimestre(id, ref msj);


            GridView1.DataSource = accesoGrupCuatri.ObtenerGrupoCuatrimestreGrid(ref msj);
            if (GridView1.DataSource != null)
            {
                GridView1.DataBind();
            }
        }

        protected void EditarGroupCuatrimestre(object sender, EventArgs e)
        {
            string x = ((Button)sender).CommandArgument;
            Session["id_seleccionado"] = Convert.ToInt32(x);
            Server.Transfer("Editar_GrupoCuatri.aspx");
        }
    }
    }
