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
    public class LogicaGrupo
    {
        private ClassAccesoSQL objectoDeAcceso =
         new ClassAccesoSQL("Data Source=ROMANISIDOR;Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true");
        public Boolean InsertarGrupo(EntidadGrupo entidadGrupo, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter
            {
                ParameterName = "Grado",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = entidadGrupo.grado
            };
            parametros[1] = new SqlParameter
            {
                ParameterName = "Letra",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 1,
                Value = entidadGrupo.letra
            };
            parametros[2] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadGrupo.extra
            };

            string sentencia = "insert into Grupo values (@Grado,@Letra,@Extra);";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }
        public DataTable ObtenerGruposGrid(ref string msj_salida)
        {

            string query = "select Id_grupo as Codigo, Grado, Letra, extra as Extra from Grupo";

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
        public string EliminarGrupo(string id, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = id
            };

            string sentencia = "delete from Grupo where Id_Grupo=@id";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }
        public List<EntidadGrupo> ObtenerGrupoPorID(string id, ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from Grupo where Id_grupo='" + id + "'";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadGrupo> lista = new List<EntidadGrupo>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntidadGrupo
                    {
                        in_Grupo =(short)ObtenerDatos[0],
                        grado =(Byte)ObtenerDatos[1],
                        letra = (string)ObtenerDatos[2],
                        extra =(string)ObtenerDatos[3]
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
        public string ModificarGrupoPorId(string id, EntidadGrupo entidadGrupo, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter
            {
                ParameterName = "Id_grupo",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = id
            };
            parametros[1] = new SqlParameter
            {
                ParameterName = "Grado",
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Input,
                Value = entidadGrupo.grado
            };
            parametros[2] = new SqlParameter
            {
                ParameterName = "Letra",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 1,
                Value = entidadGrupo.letra
            };
            parametros[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadGrupo.extra
            };


            string sentencia = "update Grupo set Grado=@Grado, Letra=@Letra, Extra=@Extra where Id_grupo=@Id_grupo;";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }
    }
}
