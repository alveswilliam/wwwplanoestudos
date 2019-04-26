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

        /* Cursos do coordenador */
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

        /* Alunos em Plano/Plano_pago */
        public DataTable AlunosPlano(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT
                                           SA.RA,
										   PP.NOME,
                                           PP.TELEFONE1,
                                           PP.EMAIL,
                                           SS.DESCRICAO,
                                           CASE
	                                           WHEN STATUS IS NULL THEN 'Não visto'
	                                           ELSE STATUS
                                           END STATUS

                                      FROM
                                           SALUNO SA (NOLOCK)

                                           INNER JOIN SMATRICPL SMP (NOLOCK)
                                           ON SA.CODCOLIGADA = SMP.CODCOLIGADA
                                           AND SA.RA = SMP.RA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SA.CODPESSOA = PP.CODIGO

                                           INNER JOIN SPLETIVO SP (NOLOCK)
                                           ON SA.CODCOLIGADA = SP.CODCOLIGADA
                                           AND SMP.IDPERLET = SP.IDPERLET

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SA.CODCOLIGADA = SHF.CODCOLIGADA
                                           AND SMP.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL
										   AND SA.CODTIPOCURSO = SHF.CODTIPOCURSO

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SA.CODCOLIGADA = SC.CODCOLIGADA
                                           AND SHF.CODCURSO = SC.CODCURSO

                                           INNER JOIN SSTATUS SS (NOLOCK)
                                           ON SA.CODCOLIGADA = SS.CODCOLIGADA
                                           AND SMP.CODSTATUS = SS.CODSTATUS

                                           LEFT JOIN POLIS_PLANOS PPL (NOLOCK)
                                           ON SA.CODCOLIGADA = PPL.CODCOLIGADA
                                           AND SA.RA = PPL.RA
                                           AND SP.CODPERLET = PPL.CODPERLET

                                     WHERE
                                           SC.CODCOLIGADA = @CODCOLIGADA
                                           AND sp.CODPERLET = @CODPERLET
                                           AND SC.CODCURSO = @CODCURSO
                                           AND SS.DESCRICAO IN ('Plano', 'Plano_pago')

                                  ORDER BY
                                           PP.NOME";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("CODPERLET", aluno.CodPerlet);
                cmd.Parameters.AddWithValue("CODCURSO", aluno.CodCurso);

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

        /* Disciplinas da grade do aluno */
        public DataTable DisciplinasGrade(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT
								           SHO.DIASEMANA,
                                           CASE
                                               WHEN SHO.DIASEMANA = 2 THEN 'Segunda-feira'
                                               WHEN SHO.DIASEMANA = 3 THEN 'Terça-feira'
                                               WHEN SHO.DIASEMANA = 4 THEN 'Quarta-feira'
                                               WHEN SHO.DIASEMANA = 5 THEN 'Quinta-feira'
                                               WHEN SHO.DIASEMANA = 6 THEN 'Sexta-feira'
                                               WHEN SHO.DIASEMANA = 7 THEN 'Sábado'
                                           END DIA,
								           SHO.HORAINICIAL,
								           STD.CODDISC,
								           SD.NOME AS DISCIPLINA,
                                           SC.NOME AS CURSO,
								           SM.IDPERLET
                                
								      FROM
								           SMATRICULA SM (NOLOCK)

                                           INNER JOIN SMATRICPL SMPL (NOLOCK)
                                           ON SM.CODCOLIGADA = SMPL.CODCOLIGADA
                                           AND SM.IDHABILITACAOFILIAL = SMPL.IDHABILITACAOFILIAL
                                           AND SM.RA = SMPL.RA
                                           AND SM.IDPERLET = SMPL.IDPERLET

                                           INNER JOIN SALUNO SA (NOLOCK)
                                           ON SM.CODCOLIGADA = SA.CODCOLIGADA
                                           AND SM.RA = SA.RA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SA.CODPESSOA = PP.CODIGO

                                           INNER JOIN SPLETIVO SP (NOLOCK)
                                           ON SM.CODCOLIGADA = SP.CODCOLIGADA
                                           AND SMPL.IDPERLET = SP.IDPERLET

                                           INNER JOIN SSTATUS SS (NOLOCK)
                                           ON SM.CODCOLIGADA = SS.CODCOLIGADA
                                           AND SMPL.CODSTATUS = SS.CODSTATUS

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SM.CODCOLIGADA = SC.CODCOLIGADA

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SM.CODCOLIGADA = SHF.CODCOLIGADA
                                           AND SC.CODCURSO = SHF.CODCURSO
                                           AND SA.CODTIPOCURSO = SHF.CODTIPOCURSO
                                           AND SMPL.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL

                                           INNER JOIN SHABILITACAO SH (NOLOCK)
                                           ON SM.CODCOLIGADA = SH.CODCOLIGADA
                                           AND SHF.CODCURSO = SH.CODCURSO
                                           AND SHF.CODHABILITACAO = SH.CODHABILITACAO

                                           INNER JOIN STURMADISC STD (NOLOCK)
                                           ON  SM.CODCOLIGADA = STD.CODCOLIGADA 
                                           AND SM.IDTURMADISC = STD.IDTURMADISC 
                                           AND SM.IDPERLET	= STD.IDPERLET	
                                           AND SMPL.CODFILIAL = STD.CODFILIAL	

                                           INNER JOIN SHORARIO SHO (NOLOCK)
                                           ON SM.CODCOLIGADA = SHO.CODCOLIGADA
                                           AND STD.CODTURNO = SHO.CODTURNO

                                           INNER JOIN SHORARIOTURMA SHT (NOLOCK)
                                           ON SM.CODCOLIGADA = SHT.CODCOLIGADA
                                           AND SHO.CODHOR = SHT.CODHOR
                                           AND STD.IDTURMADISC = SHT.IDTURMADISC

                                           INNER JOIN SDISCIPLINA SD (NOLOCK)
                                           ON SM.CODCOLIGADA = SD.CODCOLIGADA
                                           AND STD.CODDISC = SD.CODDISC

                                     WHERE
                                           SM.CODCOLIGADA = @CODCOLIGADA
                                           AND SMPL.RA = @RA
                                           AND SP.CODPERLET = @CODPERLET
                                           AND SS.DESCRICAO IN ('Plano','Plano_pago','Cursando','Fies-Cursando','Pré-Matrícula','Confirmação', 'Inadimplente')
                                
								  ORDER BY
								           SHO.DIASEMANA,
								           SHO.HORAINICIAL";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("RA", aluno.RA);
                cmd.Parameters.AddWithValue("CODPERLET", aluno.CodPerlet);

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

        /* Disciplinas em dependência do aluno */
        public DataTable DisciplinasDependencia(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("CODPERLET", aluno.CodPerlet);
                cmd.Parameters.AddWithValue("CODCURSO", aluno.CodCurso);

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

        /* Disciplinas que o aluno está cursando. */
        public DataTable DisciplinasCursando(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("CODPERLET", aluno.CodPerlet);
                cmd.Parameters.AddWithValue("CODCURSO", aluno.CodCurso);

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