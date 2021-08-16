using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeAccesoADatos
{
    public class ClassAccesoSQL
    {
        private string cadConexion;

        public ClassAccesoSQL(string cadenaBD)
        {
            cadConexion = cadenaBD;
        }
        public SqlConnection AbrirConexion(ref string mensaje) // Metodo con parametros de referencia
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = cadConexion;
            try
            {
                conexion1.Open();
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                conexion1 = null; //Devuelve una conexion nula
                mensaje = "Error: " + r.Message;
            }
            return conexion1;
        }


        public DataSet ConsultaDS(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                DS_salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(DS_salida, "Consulta1");
                    mensaje = "Consulta Correcta en DataSet";
                }
                catch (Exception a)
                {
                    mensaje = "Error!" + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return DS_salida;
        }

        public SqlDataReader ConsultarReader(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                try
                {
                    contenedor = carrito.ExecuteReader();
                    mensaje = "Consulta Correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    mensaje = "Error!" + a.Message;
                }

            }
            return contenedor;
        }

        public SqlDataReader EspecificoRepartidor(string querySql, SqlConnection conAbierta, ref string mensaje)
        {

            SqlCommand carrito = null;
            SqlDataReader contenedor = null;


            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
            }
            else
            {

                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                try
                {

                    contenedor = carrito.ExecuteReader();
                    mensaje = "Consulta Correcta DataReader";

                }
                catch (Exception a)
                {

                    contenedor = null;
                    mensaje = "Error!" + a.Message;
                }

            }
            return contenedor;
        }

        public Boolean MultiplesConsultasDataSet(string querySql, SqlConnection conAbierta, ref string mensaje, ref DataSet dataset1, string nomConsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(dataset1, nomConsulta);
                    mensaje = "Consulta correcta en el DataSet";
                    salida = true;
                }
                catch (Exception a)
                {
                    mensaje = "Error: " + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return salida;
        }

        public Boolean ModificaBDinsegura(string sentenciaSql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null; //referencia
            Boolean salida = false;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = sentenciaSql;
                carrito.Connection = conAbierta;

                try
                {
                    carrito.ExecuteNonQuery(); //Ejecuta sentencias que no son consultas en el servidor SQL
                    mensaje = "Modificación correcta a la BD";
                    salida = true;
                }
                catch (Exception a)
                {
                    salida = false;
                    mensaje = "Error!" + a.Message;
                }

                conAbierta.Close();
                conAbierta.Dispose();
            }
            return salida;
        }



        //Funcion que permite hacer modificaciones de forma generica (con parámetros)
        public Boolean OperacionesSQLConParametros(string sentenciaSQL, SqlConnection cnab,
            ref string mensaje, SqlParameter[] parametros)
        {
            Boolean salida = false;
            SqlCommand vocho = null;

            if (cnab != null)
            {
                vocho = new SqlCommand();
                vocho.CommandText = sentenciaSQL; //Aquí va la sentencia que se pasa por parametro
                //Agregar los parametros
                foreach (SqlParameter p in parametros)
                {
                    vocho.Parameters.Add(p);
                }
                vocho.Connection = cnab;


                try
                {
                    vocho.ExecuteNonQuery();
                    mensaje = "El registro ha sido exitoso";
                    salida = true;
                }
                catch (Exception w)
                {
                    mensaje = "Error!" + w.Message;

                }
                cnab.Close();
                cnab.Dispose();
            }
            else
            {
                mensaje = "No hay conexión a la BD";
            }

            return salida;
        }

    }
}
