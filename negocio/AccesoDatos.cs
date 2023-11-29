using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Negocio
{
    public class AccesoDatos
    {
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        public AccesoDatos()
        {
            conn = new SqlConnection("Server=.\\SQLExpress;Database=TP_ECOMMERCE;Trusted_Connection=True;");
            //conn = new SqlConnection("Server=.;Database=TP_ECOMMERCE;Trusted_Connection=True;");

            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;   
        }

        private void Preparar(string consulta)
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = consulta;
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    //Session["Msg_error"] = "No se ha podido guardar los cambios. Intente de nuevo";
                    throw ex;
                }
            }
        }

        public void setearConsulta(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }

        public void setearParametro(string nombre, object valor)
        {
            cmd.Parameters.AddWithValue(nombre, valor);
        }

        public SqlDataReader Leer(string consulta) 
        {
            Preparar(consulta);
            return cmd.ExecuteReader();
        }

        public void ejecutarAccion()
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public int Ejecutar(string consulta)
        {
            try
            {
                Preparar(consulta);
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EjecutarConID(string consulta)
        {
            try
            {
                Preparar(consulta);
                return (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Ejecutar(List<string> consultas)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int ejecutados = 0;
                
                cmd.Connection = conn;
                var trans = conn.BeginTransaction();
                cmd.Transaction = trans;

                foreach (var consulta in consultas)
                {
                    cmd.CommandText = consulta;
                    cmd.ExecuteNonQuery();
                    ejecutados++;
                }

                trans.Commit();

                return ejecutados;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public void Close()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}