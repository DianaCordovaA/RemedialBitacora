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
    public class LogicaCuatrimestre
    {
        private ClassAccesoSQL objectoDeAcceso =
         new ClassAccesoSQL("Data Source=LAPTOP-26L6KOL2;Initial Catalog=Bitacora2021LabsUTP; Integrated Security=true");


        public Boolean AgregarCuatrimestre(EntidadCuatrimestre entidadCuatri, ref string msj)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter
            {
                ParameterName = "periodo",
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.periodo
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "anio",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.anio
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "inicio",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.inicio
            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "fin",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.fin
            };


            parametros[4] = new SqlParameter
            {
                ParameterName = "extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.extra

            };






            string sentencia = "insert into Cuatrimestre values(@periodo, @anio, @inicio, @fin, @extra)";

            Boolean salida = false;

            salida = objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref msj), ref msj, parametros);

            return salida;
        }

        public DataTable CuatrimestreGrid(ref string msj_salida)
        {

            string query = "select id_Cuatrimestre as Codigo, Periodo, Anio as Año,  CONVERT(VARCHAR(10), Inicio, 103) as Inicio, CONVERT(VARCHAR(10), Fin, 103) as Fin, Extra from Cuatrimestre;";

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


        public string BorrarCuatrimestre(string id, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_Cuatrimestre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = id
            };

            string sentencia = "delete from Cuatrimestre where id_Cuatrimestre='" + id + "'";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }



        public List<EntidadCuatrimestre> CuatriEspecifico(string id, ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from Cuatrimestre where id_Cuatrimestre='" + id + "'";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadCuatrimestre> lista = new List<EntidadCuatrimestre>();


            DateTime fec;


            DateTime fec2;

            string var1;

            string var2;

            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    fec = (DateTime)ObtenerDatos[3];
                    fec2 = (DateTime)ObtenerDatos[4];


                    //Conversión de formato

                    var1 = fec.ToString("dd-MM-yyyy");


                    var2 = fec2.ToString("dd-MM-yyyy");

                    lista.Add(new EntidadCuatrimestre
                    {
                        id_cuatri = (short)ObtenerDatos[0],
                        periodo = (string)ObtenerDatos[1],
                        anio = (int)ObtenerDatos[2],
                        inicio = var1,
                        fin = var2,
                        extra = (string)ObtenerDatos[5]
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
        public string CambiarCuatrimestreId(EntidadCuatrimestre entidadCuatri, string id, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter
            {
                ParameterName = "id_Cuatrimestre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = id
            };

            parametros[1] = new SqlParameter
            {
                ParameterName = "periodo",
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.periodo
            };

            parametros[2] = new SqlParameter
            {
                ParameterName = "anio",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.anio
            };

            parametros[3] = new SqlParameter
            {
                ParameterName = "inicio",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.inicio
            };

            parametros[4] = new SqlParameter
            {
                ParameterName = "fin",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.fin
            };


            parametros[5] = new SqlParameter
            {
                ParameterName = "extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = entidadCuatri.extra

            };




            string sentencia = "update Cuatrimestre set Periodo=@periodo, Anio=@anio, Inicio=@inicio, Fin=@fin, Extra=@extra  where id_Cuatrimestre=@id_Cuatrimestre";

            objectoDeAcceso.OperacionesSQLConParametros(sentencia, objectoDeAcceso.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }

        public List<EntidadCuatrimestre> ListaCuatri(ref string msj_salida)
        {
            SqlConnection conexion = null;

            string query = "select * from Cuatrimestre";
            conexion = objectoDeAcceso.AbrirConexion(ref msj_salida);

            SqlDataReader ObtenerDatos = null;

            ObtenerDatos = objectoDeAcceso.ConsultarReader(query, conexion, ref msj_salida);

            List<EntidadCuatrimestre> lista = new List<EntidadCuatrimestre>();


            DateTime fechainicio;


            DateTime fechasalida;

            string inicio_;

            string fin_;

            if (ObtenerDatos != null)
            {
                while (ObtenerDatos.Read())
                {
                    fechainicio = (DateTime)ObtenerDatos[3];
                    fechasalida = (DateTime)ObtenerDatos[4];

                    inicio_ = fechainicio.ToString("dd-MM-yyyy");


                    fin_ = fechasalida.ToString("dd-MM-yyyy");

                    lista.Add(new EntidadCuatrimestre
                    {
                        id_cuatri = (short)ObtenerDatos[0],
                        periodo = (string)ObtenerDatos[1],
                        anio = (int)ObtenerDatos[2],
                        inicio = inicio_,
                        fin = fin_,
                        extra = (string)ObtenerDatos[5]
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
