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
        SqlTransaction trans = null;

        public DAL()
        {

        }

        /* Valida se o coordenador é ativo. */
        public bool ValidaCoordenador(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

            try
            {
                cmd.CommandText = @"SELECT DISTINCT
                                           PP.NOME

                                      FROM
                                           SCOORDENADOR SCO (NOLOCK)

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SCO.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL
                                           AND SCO.CODCOLIGADA = SHF.CODCOLIGADA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SCO.CODPESSOA = PP.CODIGO

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SCO.CODCOLIGADA = SC.CODCOLIGADA
                                           AND SHF.CODCURSO = SC.CODCURSO

										   INNER JOIN PFUNC PF (NOLOCK)
											ON SCO.CODCOLIGADA = PF.CODCOLIGADA
											AND SCO.CODPESSOA = PF.CODPESSOA

                                     WHERE
                                           PP.CODUSUARIO = @CODUSUARIO
                                           AND SCO.DTFIM IS NULL
										   AND PF.CODSITUACAO NOT IN ('D', 'P', 'L', 'Z', 'T', 'I')

                                  ORDER BY
                                           PP.NOME";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODUSUARIO", coordenador.CodUsuario);

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    coordenador.Nome = reader["NOME"].ToString();
                }
                else
                    return false;

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

            return true;
        }

        /* Instituição do coordenador */
        public DataTable InstituicaoCoordenador(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT DISTINCT
                                           SHF.CODCOLIGADA,
                                           CASE
											   WHEN SHF.CODCOLIGADA = 1 THEN 'Centro Universitário de Jaguariúna'
											   WHEN SHF.CODCOLIGADA = 5 THEN 'Centro Universitário Max Planck'
										   END INSTITUICAO

                                      FROM
                                           SCOORDENADOR SCO (NOLOCK)

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SCO.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL
                                           AND SCO.CODCOLIGADA = SHF.CODCOLIGADA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SCO.CODPESSOA = PP.CODIGO

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SCO.CODCOLIGADA = SC.CODCOLIGADA
                                           AND SHF.CODCURSO = SC.CODCURSO

                                           INNER JOIN GUSUARIO GU (NOLOCK)
                                           ON PP.CODUSUARIO = GU.CODUSUARIO

                                     WHERE
                                           GU.CODUSUARIO = @CODUSUARIO
										   AND SCO.CODCOLIGADA IN (1,5)
                                           AND SCO.DTFIM IS NULL

                                  ORDER BY
                                           INSTITUICAO";

                cmd.Parameters.Clear();
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

        /* Campus do coordenador */
        public DataTable CampusCoordenador(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT DISTINCT
                                           SCA.CODCAMPUS,
										   CASE
											   WHEN SCA.CODCAMPUS = '0001' THEN 'Campus I'
											   WHEN SCA.CODCAMPUS = '0002' THEN 'Campus II'
											   WHEN SCA.CODCAMPUS = '008' THEN 'FAAGROH'
										   END CAMPUS

                                      FROM
                                           SCOORDENADOR SCO (NOLOCK)

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SCO.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL
                                           AND SCO.CODCOLIGADA = SHF.CODCOLIGADA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SCO.CODPESSOA = PP.CODIGO

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SCO.CODCOLIGADA = SC.CODCOLIGADA
                                           AND SHF.CODCURSO = SC.CODCURSO

                                           INNER JOIN GUSUARIO GU (NOLOCK)
                                           ON PP.CODUSUARIO = GU.CODUSUARIO

										   INNER JOIN SHABILITACAOFILIALCAMPUS SHFC (NOLOCK)
										   ON SCO.CODCOLIGADA = SHFC.CODCOLIGADA
										   AND SCO.IDHABILITACAOFILIAL = SHFC.IDHABILITACAOFILIAL

										   INNER JOIN SCAMPUS SCA (NOLOCK)
										   ON SHFC.CODCAMPUS = SCA.CODCAMPUS

                                     WHERE
										   SCO.CODCOLIGADA = @CODCOLIGADA
                                           AND GU.CODUSUARIO = @CODUSUARIO
                                           AND SCO.DTFIM IS NULL

                                  ORDER BY
                                           CAMPUS";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODCOLIGADA", coordenador.CodColigada);
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

        /* Contexto disponível para o coordenador. */
        public DataTable Contexto(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT DISTINCT
                                       STC.NOME,
                                       STC.CODTIPOCURSO

                                  FROM
                                       SCOORDENADOR SCO (NOLOCK)

                                       INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK) ON
                                       SCO.CODCOLIGADA = SHF.CODCOLIGADA
                                       AND SCO.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL

                                       INNER JOIN PPESSOA PP (NOLOCK) ON
                                       SCO.CODPESSOA = PP.CODIGO

                                       INNER JOIN SCURSO SC (NOLOCK) ON
                                       SCO.CODCOLIGADA = SC.CODCOLIGADA
                                       AND SHF.CODCURSO = SC.CODCURSO
                                       AND SHF.CODTIPOCURSO = SC.CODTIPOCURSO

                                       INNER JOIN STIPOCURSO STC (NOLOCK) ON
                                       SCO.CODCOLIGADA = STC.CODCOLIGADA
                                       AND SHF.CODTIPOCURSO = STC.CODTIPOCURSO

                                       INNER JOIN SHABILITACAOFILIALCAMPUS SHFC (NOLOCK)
									   ON SCO.CODCOLIGADA = SHFC.CODCOLIGADA
									   AND SCO.IDHABILITACAOFILIAL = SHFC.IDHABILITACAOFILIAL

                                 WHERE
                                       STC.CODCOLIGADA = @CODCOLIGADA
                                       AND SHFC.CODCAMPUS = @CODCAMPUS
                                       AND PP.CODUSUARIO = @CODUSUARIO
                                       AND SCO.DTFIM IS NULL";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("CODCOLIGADA", SqlDbType.SmallInt).Value = coordenador.CodColigada;
                cmd.Parameters.Add("CODCAMPUS", SqlDbType.VarChar, 10).Value = coordenador.CodCampus;
                cmd.Parameters.Add("CODUSUARIO", SqlDbType.VarChar, 20).Value = coordenador.CodUsuario;

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

        /* Curso(s) do coordenador */
        public DataTable CursoCoordenador(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = @"SELECT DISTINCT
                                           SC.CODCURSO,
                                           SC.NOME CURSO

                                      FROM
                                           SCOORDENADOR SCO (NOLOCK)

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SCO.IDHABILITACAOFILIAL = SHF.IDHABILITACAOFILIAL
                                           AND SCO.CODCOLIGADA = SHF.CODCOLIGADA

                                           INNER JOIN PPESSOA PP (NOLOCK)
                                           ON SCO.CODPESSOA = PP.CODIGO

                                           INNER JOIN SCURSO SC (NOLOCK)
                                           ON SCO.CODCOLIGADA = SC.CODCOLIGADA
                                           AND SHF.CODCURSO = SC.CODCURSO

                                           INNER JOIN GUSUARIO GU (NOLOCK)
                                           ON PP.CODUSUARIO = GU.CODUSUARIO

										   INNER JOIN SHABILITACAOFILIALCAMPUS SHFC (NOLOCK)
										   ON SCO.CODCOLIGADA = SHFC.CODCOLIGADA
										   AND SCO.IDHABILITACAOFILIAL = SHFC.IDHABILITACAOFILIAL

										   INNER JOIN SCAMPUS SCA (NOLOCK)
										   ON SHFC.CODCAMPUS = SCA.CODCAMPUS

                                     WHERE
										   SHF.CODCOLIGADA = @CODCOLIGADA
                                           AND SHFC.CODCAMPUS = @CODCAMPUS
                                           AND GU.CODUSUARIO = @CODUSUARIO
                                           AND SCO.DTFIM IS NULL

                                  ORDER BY
                                           CURSO";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODCOLIGADA", coordenador.CodColigada);
                cmd.Parameters.AddWithValue("CODCAMPUS", coordenador.CodCampus);
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
								           SD.NOME DISCIPLINA,
                                           SC.NOME CURSO,
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
                cmd.Parameters.Add("CODCOLIGADA", SqlDbType.SmallInt).Value = aluno.CodColigada;
                cmd.Parameters.Add("RA", SqlDbType.VarChar, 20).Value = aluno.RA;
                cmd.Parameters.Add("CODPERLET", SqlDbType.VarChar, 10).Value = aluno.CodPerlet;

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
                cmd.CommandText = @"SELECT DISTINCT
                                           CASE
                                               WHEN SH.CODDISC = (SELECT TOP 1 coddisc1 FROM zEquivalencias (NOLOCK) WHERE CODCOL = SDG.CODCOLIGADA AND coddisc2 = SDG.CODDISC) THEN  (SELECT coddisc2 FROM zEquivalencias (NOLOCK) WHERE CODCOL = SDG.CODCOLIGADA AND coddisc1 = SH.CODDISC)
                                               ELSE SDG.CODDISC
                                           END CODDISC,
                                           SD.NOME DISCIPLINA,
                                           CASE
											   WHEN SH.CODPERLET IS NULL THEN 'CURSAR'
											   ELSE (SELECT TOP 1 CODPERLET FROM SHISTORICO (NOLOCK) WHERE CODCOLIGADA = SH.CODCOLIGADA AND RA = SH.RA AND CODDISC = SH.CODDISC ORDER BY CODPERLET DESC)
										   END CODPERLET
                                            
									  FROM
                                           SDISCGRADE SDG (NOLOCK)

                                           INNER JOIN SHABILITACAOFILIAL SHF (NOLOCK)
                                           ON SDG.CODCOLIGADA = SHF.CODCOLIGADA
                                           AND SDG.CODGRADE = SHF.CODGRADE
                                           AND SDG.CODHABILITACAO = SHF.CODHABILITACAO                                       

                                           INNER JOIN SDISCIPLINA SD (NOLOCK)
                                           ON SDG.CODCOLIGADA = SD.CODCOLIGADA
                                           AND SDG.CODDISC = SD.CODDISC

                                           INNER JOIN SHABILITACAOALUNO SHA (NOLOCK)
                                           ON SHF.CODCOLIGADA = SHA.CODCOLIGADA
                                           AND SHF.IDHABILITACAOFILIAL = SHA.IDHABILITACAOFILIAL
                                           
                                           INNER JOIN SSTATUS SS (NOLOCK)
                                           ON SHA.CODCOLIGADA = SS.CODCOLIGADA
                                           AND SHA.CODSTATUS = SS.CODSTATUS

                                           INNER JOIN SMATRICPL SMPL (NOLOCK)
                                           ON SDG.CODCOLIGADA = SMPL.CODCOLIGADA
                                           AND SHF.CODCOLIGADA = SMPL.CODCOLIGADA
                                           AND SHF.IDHABILITACAOFILIAL = SMPL.IDHABILITACAOFILIAL
                                           AND SHA.RA = SMPL.RA

                                           INNER JOIN SPLETIVO SPL (NOLOCK)
                                           ON SMPL.CODCOLIGADA = SPL.CODCOLIGADA
                                           AND SMPL.IDPERLET = SPL.IDPERLET
                                           AND SMPL.PERIODO > =  SDG.CODPERIODO

                                           LEFT JOIN SHISTORICO SH (NOLOCK)
                                           ON SDG.CODCOLIGADA = SH.CODCOLIGADA
                                           AND SDG.CODDISC = SH.CODDISC
                                           AND SHA.RA = SH.RA

                                     WHERE
										   SDG.CODCOLIGADA = @CODCOLIGADA
                                           AND SHA.RA = @RA
										   AND SPL.CODTIPOCURSO = @CODTIPOCURSO
										   AND SDG.CODCURSO = @CODCURSO
                                           AND (SH.CODPERLET <> @CODPERLET OR SH.CODPERLET IS NULL)
										   AND SDG.CODPERIODO <> @CODPERIODO
										   AND SS.DESCRICAO IN ('Cursando','Plano_pago','Plano', 'Cursado', 'Confirmação', 'Fies-Cursando', 'Inadimplente')
                                           AND (SH.RESULTADO IN ('Reprovado por Falta', 'Reprovado por Nota', 'Reprovado por Exame', 'A Cursar') OR SH.RESULTADO IS NULL)
                                           
										   AND NOT EXISTS (SELECT T2.coddisc2 FROM SHISTORICO T1 (NOLOCK) INNER JOIN zEquivalencias T2 (NOLOCK) ON T1.CODCOLIGADA = T2.CODCOL AND T1.CODDISC = T2.coddisc1  WHERE T1.CODCOLIGADA = SDG.CODCOLIGADA AND T1.RA = SHA.RA AND T1.RESULTADO IN ('Aprovado','AE') and T2.coddisc2 = SDG.CODDISC)
										   AND NOT EXISTS (SELECT CODDISC FROM SHISTORICO (NOLOCK) WHERE CODCOLIGADA = SDG.CODCOLIGADA AND RA = SHA.RA AND CODDISC = SDG.CODDISC AND RESULTADO IN ('Aprovado','AE') )
                                           AND NOT EXISTS (SELECT Z.coddisc2 FROM SMATRICULA SM (NOLOCK) INNER JOIN STURMADISC STD (NOLOCK) ON SM.CODCOLIGADA = STD.CODCOLIGADA AND SM.IDPERLET = STD.IDPERLET AND SM.IDTURMADISC = STD.IDTURMADISC INNER JOIN zEquivalencias Z (NOLOCK) ON Z.codcol = STD.CODCOLIGADA AND Z.coddisc1 = STD.CODDISC INNER JOIN SSTATUS SS (NOLOCK) ON SS.CODCOLIGADA = SM.CODCOLIGADA AND SS.CODSTATUS = SM.CODSTATUS WHERE SM.CODCOLIGADA = SDG.CODCOLIGADA AND SM.RA = SH.RA AND Z.coddisc2 = SDG.CODDISC AND SS.DESCRICAO IN ('Cursando','Plano_pago','Plano', 'Confirmação', 'Inadimplente'))
                                           AND NOT EXISTS (SELECT STD.CODDISC FROM SMATRICULA SM (NOLOCK) INNER JOIN STURMADISC STD (NOLOCK) ON SM.CODCOLIGADA = STD.CODCOLIGADA AND SM.IDPERLET = STD.IDPERLET AND SM.IDTURMADISC = STD.IDTURMADISC INNER JOIN SSTATUS SS (NOLOCK) ON SS.CODCOLIGADA = SM.CODCOLIGADA AND SS.CODSTATUS = SM.CODSTATUS WHERE SM.CODCOLIGADA = SDG.CODCOLIGADA AND SM.RA = SH.RA AND STD.CODDISC = SDG.CODDISC AND SS.DESCRICAO  IN ('Cursando','Plano_pago','Plano', 'Confirmação', 'Inadimplente')) 		
                                           
								  ORDER BY
										   SD.NOME";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("CODCOLIGADA", SqlDbType.SmallInt).Value = aluno.CodColigada;
                cmd.Parameters.Add("RA", SqlDbType.VarChar, 20).Value = aluno.RA;
                cmd.Parameters.Add("CODTIPOCURSO", SqlDbType.SmallInt).Value = aluno.CodTipoCurso;
                cmd.Parameters.Add("CODCURSO", SqlDbType.VarChar, 10).Value = aluno.CodCurso;
                cmd.Parameters.Add("CODPERLET", SqlDbType.VarChar, 10).Value = aluno.CodPerlet;
                cmd.Parameters.Add("CODPERIODO", SqlDbType.SmallInt).Value = 0;

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandTimeout = 180;

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
                cmd.CommandText = @"SELECT
                                           STD.CODDISC,
                                           SD.NOME DISCIPLINA,
                                           SP.CODPERLET

                                      FROM
                                           SMATRICULA SM (NOLOCK)

                                           INNER JOIN STURMADISC STD (NOLOCK)
                                           ON SM.CODCOLIGADA = STD.CODCOLIGADA
                                           AND SM.IDTURMADISC = STD.IDTURMADISC
                                           AND SM.IDPERLET = STD.IDPERLET 

                                           INNER JOIN SSTATUS SS (NOLOCK)
                                           ON SS.CODCOLIGADA = SM.CODCOLIGADA
                                           AND SS.CODSTATUS = SM.CODSTATUS
                                           AND STD.CODTIPOCURSO = SS.CODTIPOCURSO

                                           INNER JOIN SDISCIPLINA SD (NOLOCK)
                                           ON SD.CODCOLIGADA = STD.CODCOLIGADA
                                           AND SD.CODDISC = STD.CODDISC
                                           AND STD.CODTIPOCURSO = SD.CODTIPOCURSO

                                           INNER JOIN SPLETIVO SP (NOLOCK)
                                           ON SP.CODCOLIGADA = STD.CODCOLIGADA
                                           AND SP.IDPERLET = STD.IDPERLET
                                           AND STD.CODTIPOCURSO = SP.CODTIPOCURSO

                                     WHERE
                                           SM.RA = @RA
                                           AND SP.CODPERLET = @CODPERLET
                                           AND SS.DESCRICAO IN ('Cursando', 'Confirmação', 'Fies-Cursando', 'Inadimplente')

                                  ORDER BY
                                           SD.NOME";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("RA", SqlDbType.VarChar, 20).Value = aluno.RA;
                cmd.Parameters.Add("CODPERLET", SqlDbType.VarChar, 10).Value = aluno.CodPerlet;

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

        /* Retorna o valor do IDPERLET referente ao CODPERLET ativo na aplicação. */
        public int IdPerlet(Coordenador coordenador)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

            try
            {
                cmd.CommandText = @"SELECT
                                           IDPERLET

                                      FROM
                                           SPLETIVO (NOLOCK)

                                     WHERE
                                           CODCOLIGADA = @CODCOLIGADA
                                           AND CODTIPOCURSO = @CODTIPOCURSO
                                           AND CODPERLET = @CODPERLET";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("CODCOLIGADA", SqlDbType.SmallInt).Value = coordenador.CodColigada;
                cmd.Parameters.Add("CODTIPOCURSO", SqlDbType.SmallInt).Value = coordenador.CodTipoCurso;
                cmd.Parameters.Add("CODPERLET", SqlDbType.VarChar, 10).Value = coordenador.CodPerlet;

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    coordenador.IdPerlet = Convert.ToInt32(reader["IDPERLET"]);
                }

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

            return coordenador.IdPerlet;
        }

        /* Retorna o valor do CODSTATUS referente aos status de matrícula 'Plano', 'Plano_pago', 'Confirmação'. */
        public Aluno CodigoStatus(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

            try
            {
                cmd.CommandText = @"SELECT
                                           CODSTATUS,
                                           DESCRICAO

                                      FROM
                                           SSTATUS (NOLOCK)

                                     WHERE
                                           CODCOLIGADA = @CODCOLIGADA
                                           AND CODTIPOCURSO = @CODTIPOCURSO
                                           AND DESCRICAO IN ('Plano', 'Plano_pago', 'Confirmação')";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("RA", SqlDbType.VarChar, 20).Value = aluno.RA;
                cmd.Parameters.Add("CODPERLET", SqlDbType.VarChar, 10).Value = aluno.CodPerlet;

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    while(reader.Read())
                    {
                        if (reader["DESCRICAO"].ToString() == "Plano")
                            aluno.CodStatusPlano = Convert.ToInt32(reader["DESCRICAO"]);

                        if (reader["DESCRICAO"].ToString() == "Plano_pago")
                            aluno.CodStatusPlanoPago = Convert.ToInt32(reader["DESCRICAO"]);

                        if (reader["DESCRICAO"].ToString() == "Confirmação")
                            aluno.CodStatusConfirmacao = Convert.ToInt32(reader["DESCRICAO"]);
                    }

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

            return aluno;
        }

        /* Atualiza o CODSTATUS da SMATRICPL. */
        public bool AtualizaStatusSMatricPl(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

            try
            {
                cmd.CommandText = @"UPDATE SMATRICPL
                                       SET
                                           CODSTATUS = @CODSTATUSCONFIRMACAO,
                                           RECMODIFIEDBY = @RECMODIFIEDBY,
                                           RECMODIFIEDON = @RECMODIFIEDON

                                     WHERE
                                           RA = @RA
                                           AND CODCOLIGADA = @CODCOLIGADA
                                           AND IDPERLET = @IDPERLET
                                           AND CODSTATUS IN (@CODSTATUSPLANO, @CODSTATUSPLANO_PAGO)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODSTATUSCONFIRMACAO", aluno.CodStatusConfirmacao);
                cmd.Parameters.AddWithValue("RECMODIFIEDBY", aluno.UsuarioAlteracao);
                cmd.Parameters.AddWithValue("RECMODIFIEDON", DateTime.Now);
                cmd.Parameters.AddWithValue("RA", aluno.RA);
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("IDPERLET", aluno.IdPerlet);
                cmd.Parameters.AddWithValue("CODSTATUSPLANO", aluno.CodStatusPlano);
                cmd.Parameters.AddWithValue("CODSTATUSPLANO_PAGO", aluno.CodStatusPlanoPago);

                cmd.CommandType = CommandType.Text;
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.Transaction = trans;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return true;
        }

        /* Atualiza o CODSTATUS da SMATRICULA. */
        public bool AtualizaStatusSMatricula(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

            try
            {
                cmd.CommandText = @"UPDATE SMATRICULA
                                       SET
                                           CODSTATUS = @CODSTATUSCONFIRMACAO,
                                           RECMODIFIEDBY = @RECMODIFIEDBY,
                                           RECMODIFIEDON = @RECMODIFIEDON

                                     WHERE
                                           RA = @RA
                                           AND CODCOLIGADA = @CODCOLIGADA
                                           AND IDPERLET = @IDPERLET
                                           AND CODSTATUS IN (@CODSTATUSPLANO, @CODSTATUSPLANO_PAGO)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODSTATUSCONFIRMACAO", aluno.CodStatusConfirmacao);
                cmd.Parameters.AddWithValue("RECMODIFIEDBY", aluno.UsuarioAlteracao);
                cmd.Parameters.AddWithValue("RECMODIFIEDON", DateTime.Now);
                cmd.Parameters.AddWithValue("RA", aluno.RA);
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("IDPERLET", aluno.IdPerlet);
                cmd.Parameters.AddWithValue("CODSTATUSPLANO", aluno.CodStatusPlano);
                cmd.Parameters.AddWithValue("CODSTATUSPLANO_PAGO", aluno.CodStatusPlanoPago);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return true;
        }

        /* Atualiza o CODSTATUS da SHABILITACAOALUNO. */
        public bool AtualizaStatusSHabilitacaoAluno(Aluno aluno)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;

            try
            {
                cmd.CommandText = @"UPDATE SHABILITACAOALUNO
                                       SET
                                           CODSTATUS = @CODSTATUSCONFIRMACAO,
                                           RECMODIFIEDBY = @RECMODIFIEDBY,
                                           RECMODIFIEDON = @RECMODIFIEDON

                                     WHERE
                                           RA = @RA
                                           AND CODCOLIGADA = @CODCOLIGADA
                                           AND CODSTATUS IN (@CODSTATUSPLANO, @CODSTATUSPLANO_PAGO)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("CODSTATUSCONFIRMACAO", aluno.CodStatusConfirmacao);
                cmd.Parameters.AddWithValue("RECMODIFIEDBY", aluno.UsuarioAlteracao);
                cmd.Parameters.AddWithValue("RECMODIFIEDON", DateTime.Now);
                cmd.Parameters.AddWithValue("RA", aluno.RA);
                cmd.Parameters.AddWithValue("CODCOLIGADA", aluno.CodColigada);
                cmd.Parameters.AddWithValue("IDPERLET", aluno.IdPerlet);
                cmd.Parameters.AddWithValue("CODSTATUSPLANO", aluno.CodStatusPlano);
                cmd.Parameters.AddWithValue("CODSTATUSPLANO_PAGO", aluno.CodStatusPlanoPago);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    trans.Dispose();
                }
            }

            return true;
        }
    }
}