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
            //conn = new SqlConnection("Server=.\\SQLExpress;Da<tabase=TP_ECOMMERCE;Trusted_Connection=True;");
            conn = new SqlConnection("Server=.;Database=TP_ECOMMERCE;Trusted_Connection=True;");

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

        public SqlDataReader Leer(string consulta) 
        {
            Preparar(consulta);
            return cmd.ExecuteReader();
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