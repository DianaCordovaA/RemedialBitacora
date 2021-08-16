using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassCapaEntidades;
using CapaDeAccesoADatos;
using System.Data;
using System.Data.SqlClient;

namespace ClassCapaLogicaNegocios
{
    public class LogicaMateria
    {
        private ClassAccesoSQL objectoDeAcceso =
         new ClassAccesoSQL("Data Source=ROMANISIDOR;Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true");

        //Operaciones CRUD de la tabla Materia

        public string UpdateMateriaById(string id, EntidadMateria entidad, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_Materia",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = id
            };


            string sentencia = "update Materia set NombeMateria='" + entidad.NombreMateria + "', HorasSemana=" + entidad.HorasSemana + ", Extra='" + entidad.Extra + "'  where Id_Materia=@id_Materia";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }

        public DataTable getMaterias(ref string msj_salida)
        {

            string query = "select id_Materia as Codigo, NombeMateria as Nombre, HorasSemana as Horas, Extra from Materia";

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



        public Boolean InsertMateria(EntidadMateria entidadMateria, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter
            {
                ParameterName = "NombreMateria",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = entidadMateria.NombreMateria
            };
            parametros[1] = new SqlParameter
            {
                ParameterName = "HorasSemana",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = entidadMateria.HorasSemana
            };
            parametros[2] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadMateria.Extra
            };

            string sentencia = "insert into Materia values (@nombreMateria,@HorasSemana,@Extra);";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }

        
        public string DeleteMateria(string id, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_Carrera",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = id
            };

            string sentencia = "delete from Materia where Id_Materia='" + id + "'";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }

        public List<EntidadMateria> getMateriaById(string id, ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from Materia where Id_Materia='" + id + "'";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadMateria> lista = new List<EntidadMateria>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntidadMateria
                    {
                        id_Materia = (short)ObtenerDatos[0],
                        NombreMateria = (string)ObtenerDatos[1],
                        HorasSemana = (byte)ObtenerDatos[2],
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
