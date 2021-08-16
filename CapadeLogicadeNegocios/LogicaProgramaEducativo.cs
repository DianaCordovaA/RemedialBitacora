using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassCapaEntidades;
using CapaDeAccesoADatos;
using System.Data.SqlClient;
using System.Data;

namespace ClassCapaLogicaNegocios
{
    public class LogicaProgramaEducativo
    {
        private ClassAccesoSQL objectoDeAcceso =
       new ClassAccesoSQL("Data Source=ROMANISIDOR;Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true");
        public Boolean InsertarProgramaEducativo( EntidadProgramaEducativo entidadPrograma, EntidadCarrera entidadCarrera, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter
            {
                ParameterName = "ProgramaEd",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = entidadPrograma.ProgramaEd
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "F_Carrera",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = entidadCarrera.id_carrera
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadPrograma.Extra

            };

        


            string sentencia = "insert into ProgramaEducativo values(@ProgramaEd,@F_Carrera,@Extra)";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }
        public DataTable ObtenerProgramasGrid(ref string msj_salida)
        {

            string query = "select id_pe as Codigo,  nombreCarrea as Carrera, ProgramaEd as Programa, Extra from ProgramaEducativo inner join Carrera on id_Carrera=F_Carrera";

            DataSet ObtencionCarreras = null;
            DataTable Datos_salida = null;
            ObtencionCarreras = objectoDeAcceso.ConsultaDS(query, objectoDeAcceso.AbrirConexion(ref msj_salida), ref msj_salida);

            if (ObtencionCarreras != null)
            {
                Datos_salida = ObtencionCarreras.Tables[0];
                if (Datos_salida.Rows.Count == 0)
                {
                    //La consulta es correcta pero el DataSet no está
                    //devolviendo registros

                }

            }

            return Datos_salida;
        }
        public DataTable ObtenerProgramasGridPorId(int id ,ref string msj_salida)
        {

            string query = "select nombreCarrea as Carrera, ProgramaEd as Programa, Extra from ProgramaEducativo inner join Carrera on id_Carrera='" + id+"' and F_Carrera='"+id+"';";

            DataSet ObtencionCarreras = null;
            DataTable Datos_salida = null;
            ObtencionCarreras = objectoDeAcceso.ConsultaDS(query, objectoDeAcceso.AbrirConexion(ref msj_salida), ref msj_salida);

            if (ObtencionCarreras != null)
            {
                Datos_salida = ObtencionCarreras.Tables[0];
                if (Datos_salida.Rows.Count == 0)
                {
                    //La consulta es correcta pero el DataSet no está
                    //devolviendo registros

                }

            }

            return Datos_salida;
        }
        public string EliminarPrograma(string id, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_pe",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = id
            };

            string sentencia = "delete from ProgramaEducativo where id_pe='" + id + "'";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }
        public string EditarPrograma(string id, EntidadProgramaEducativo programaEducativo, string idCarrera, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_pe",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = id
            };
            parametros[1] = new SqlParameter
            {
                ParameterName = "ProgramaEd",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = programaEducativo.ProgramaEd
            };
            parametros[2] = new SqlParameter
            {
                ParameterName = "F_Carrera",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = idCarrera
            };
            parametros[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = programaEducativo.Extra
            };

            string sentencia = "update ProgramaEducativo set ProgramaEd=@ProgramaEd, F_Carrera=@F_Carrera, Extra=@Extra where id_pe=@id_pe";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }
        public List<EntidadProgramaEducativo> ObtenerProgramaPorId(string id, ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from ProgramaEducativo where id_pe='" + id + "'";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadProgramaEducativo> lista = new List<EntidadProgramaEducativo>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntidadProgramaEducativo
                    {
                        ProgramaEd = (string)ObtenerDatos[1],
                        Extra = (string)ObtenerDatos[3]
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
    }
}
