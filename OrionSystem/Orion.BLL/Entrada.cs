using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrionSystem.DAO;
using System.Data.SqlClient;
using Orion.DAL;
using System.Web;



namespace Orion.BLL
{
    public class Entrada:Contexto
    {
        public void RegistrarEntrada(EntradaConta obj)
        {
            try
            {
                openCon();
                string str = string.Format(@"INSERT INTO dbo.Entrada VALUES(@id,@date,@nome,@tipo,@valor,@comentario)");
                using (cmd = new SqlCommand(str, con))
                {
                    string data = DateTime.Now.ToString("yyyy/MM/dd");
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@date", data);
                    if(string.IsNullOrEmpty(obj.Nome))
                    {
                        cmd.Parameters.AddWithValue("@nome", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@nome", obj.Nome.ToUpper());
                    }
                    if(string.IsNullOrEmpty(obj.TipoEntrada))
                    {
                        cmd.Parameters.AddWithValue("@tipo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tipo", obj.TipoEntrada.ToUpper());
                    }
                    if (string.IsNullOrEmpty(obj.Valor))
                    {

                        cmd.Parameters.AddWithValue("@valor", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@valor", obj.Valor);
                    }
                    if(string.IsNullOrEmpty(obj.Comentario))
                    {
                        cmd.Parameters.AddWithValue("@comentario", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@comentario", obj.Comentario.ToUpper());
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseCon();
            }
        }
    }
}
