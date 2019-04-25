using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wwwplanoestudos._class
{
    public class DAL
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAL()
        {

        }

        public DataTable ValidaCoordenador(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT DISTINCT
                                           SH.CODCOLIGADA,
                                           SH.CODFILIAL,
                                           PP.NOME,
                                           SC.CODCURSO,
                                           SC.NOME CURSO

                                      FROM
                                           SCOORDENADOR SCO (NOLOCK)

                                           INNER JOIN SHABILITACAOFILIAL SH (NOLOCK)
                                           ON SCO.IDHABILITACAOFILIAL = SH.IDHABILITACAOFILIAL
                                           AND SCO.CODCOLIGADA = SH.CODCOLIGADA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SCO.CODPESSOA = PP.CODIGO

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SCO.CODCOLIGADA = SC.CODCOLIGADA
                                           AND SH.CODCURSO = SC.CODCURSO

                                           INNER JOIN GUSUARIO GU (NOLOCK)
                                           ON PP.CODUSUARIO = GU.CODUSUARIO

                                     WHERE
                                           GU.CODUSUARIO = @CODUSUARIO
                                           AND SCO.DTFIM IS NULL

                                  ORDER BY
                                           SC.NOME";

                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("CODCOLIGADA", coordenador.CodColigada);
                cmd.Parameters.AddWithValue("CODUSUARIO", coordenador.CodUsuario);

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return dt;
        }
    }
}