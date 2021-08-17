using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeAccesoADatos;
using ClassCapaEntidades;
using System.Data;
using System.Data.SqlClient;
namespace ClassCapaLogicaNegocios
{
    public class LogicaGrupoCuatrimestre
    {



        private ClassAccesoSQL objectoDeAcceso =
        new ClassAccesoSQL("Data Source=LAPTOP-26L6KOL2;Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true");

        public string AgregarGrupoCuatri(EntidadGrupoCuatrimestre entidadGrupoCuatri, ref string msj)
        {
            SqlParameter[] parametros = new SqlParameter[6];

            parametros[0] = new SqlParameter
            {
                ParameterName = "F_ProgEd",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = entidadGrupoCuatri.F_ProgEd
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "F_Grupo",
                SqlDbType = SqlDbType.SmallInt,
                Value = entidadGrupoCuatri.F_Grupo
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "F_Cuatri",
                SqlDbType = SqlDbType.SmallInt,
                Value = entidadGrupoCuatri.F_Cuatri
            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Turno",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = entidadGrupoCuatri.Turno
            };


            parametros[4] = new SqlParameter
            {
                ParameterName = "Modalidad",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadGrupoCuatri.Modalidad

            };
            parametros[5] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadGrupoCuatri.Extra

            };

            string sentencia = "insert into GrupoCuatrimestre values( @F_ProgEd ,@F_Grupo ,@F_Cuatri ,@Turno ,@Modalidad ,@Extra)";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref msj), ref msj, parametros);

            return msj;
        }

        public DataTable GrupoCuatriGrid(ref string msj_salida)
        {

            string query = "Select GP.Id_GruCuat as Codigo,PE.ProgramaEd, G.Grado , G.Letra as Grupo, C.Periodo , GP.Turno, GP.Modalidad , GP.Extra From GrupoCuatrimestre as GP inner join ProgramaEducativo as PE on PE.Id_pe= Gp.F_ProgEd inner join Grupo as G on G.Id_grupo = GP.F_Grupo inner join Cuatrimestre as C on C.id_Cuatrimestre = Gp.F_Cuatri;";

            DataSet ObtencionCarreras = null;
            DataTable Datos_salida = null;
            ObtencionCarreras = objectoDeAcceso.ConsultaDS(query, objectoDeAcceso.AbrirConexion(ref msj_salida), ref msj_salida);

            if (ObtencionCarreras != null)
            {
                Datos_salida = ObtencionCarreras.Tables[0];
                if (Datos_salida.Rows.Count == 0)
                {
                  


                }

            }

            return Datos_salida;
        }

        public string BorrarGrupoCuatri(string id, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };

            string sentencia = "delete from GrupoCuatrimestre where Id_GruCuat='" + id + "'";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }
        public List<EntidadGrupoCuatrimestre> MostrarGrupoCuatriEspecifico(string id, ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from GrupoCuatrimestre where Id_GruCuat='" + id + "'";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadGrupoCuatrimestre> lista = new List<EntidadGrupoCuatrimestre>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntidadGrupoCuatrimestre
                    {
                        Turno = (string)ObtenerDatos[4],
                        Modalidad = (string)ObtenerDatos[5],
                        Extra = (string)ObtenerDatos[6]
                    });
                }
            }
            else
            {
                lista = null;
            }
            conexion.Close();
            conexion.Dispose();

            return lista;

        }

        public string ModiGrupoCuatri(EntidadGrupoCuatrimestre entidadGrupoCuatri, string id, ref string msj)
        {
            SqlParameter[] parametros = new SqlParameter[6];

            parametros[0] = new SqlParameter
            {
                ParameterName = "F_ProgEd",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = entidadGrupoCuatri.F_ProgEd
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "F_Grupo",
                SqlDbType = SqlDbType.SmallInt,
                Value = entidadGrupoCuatri.F_Grupo
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "F_Cuatri",
                SqlDbType = SqlDbType.SmallInt,
                Value = entidadGrupoCuatri.F_Cuatri
            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "Turno",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = entidadGrupoCuatri.Turno
            };


            parametros[4] = new SqlParameter
            {
                ParameterName = "Modalidad",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadGrupoCuatri.Modalidad

            };
            parametros[5] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadGrupoCuatri.Extra

            };

            string sentencia = "Update GrupoCuatrimestre set F_ProgEd=@F_ProgEd , F_Grupo=@F_Grupo, F_Cuatri=@F_Cuatri, Turno=@Turno, Modalidad=@Modalidad, Extra=@Extra where Id_GruCuat='" + id + "'";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref msj), ref msj, parametros);

            return msj;
        }



    }
}
