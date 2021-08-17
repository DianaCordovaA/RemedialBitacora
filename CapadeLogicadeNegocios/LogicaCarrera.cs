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
    public class LogicaCarrera
    {
        private ClassAccesoSQL objectoDeAcceso =
         new ClassAccesoSQL("Data Source=LAPTOP-26L6KOL2;Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true");

       
        public List<EntidadCarrera> MostrarCarreras(ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from Carrera";



            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadCarrera> lista = new List<EntidadCarrera>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntidadCarrera
                    {
                        id_carrera =(Byte)ObtenerDatos[0],
                        nombre = (string)ObtenerDatos[1]
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

        public List<EntidadCarrera> MostrarCarreraEspecifica(string id,ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from Carrera where id_Carrera='"+id+"'";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadCarrera> lista = new List<EntidadCarrera>();


            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    lista.Add(new EntidadCarrera
                    {
                        id_carrera = (Byte)ObtenerDatos[0],
                        nombre = (string)ObtenerDatos[1]
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
        public string CambiosIdCarrera(string id, string Nuevonombre, ref string mensajeSalida)
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
           

            string sentencia = "update Carrera set nombreCarrea='"+Nuevonombre+"' where id_Carrera=@id_Carrera";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }


        public DataTable CarrerasGrid(ref string msj_salida)
        {
            
            string query = "select id_Carrera as Codigo, nombreCarrea as Nombre from Carrera;";

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
        public string BorrarCarrera(string id, ref string mensajeSalida)
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

            string sentencia = "delete from Carrera where id_Carrera='" +id+"'";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }


        public Boolean AgregarCarrera(EntidadCarrera entidadCarrera, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];

            parametros[0] = new SqlParameter
            {
                ParameterName = "nombreCarrera",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = entidadCarrera.nombre
            };


            string sentencia = "insert into Carrera values(@nombreCarrera)";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);

            return salida;
        }


    }
}
