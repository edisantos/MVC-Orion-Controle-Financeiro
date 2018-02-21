using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using OrionSystem.DAO;
using Orion.DAL;

namespace Orion.BLL
{
    public class DropdownListGenerico:Contexto
    {
        public List<Contas> GetTipoConta()
        {
            try
            {
                openCon();
                String str = string.Format(@"SELECT TipoContaid,TipoConta FROM dbo.TipoConta");
                using (cmd = new SqlCommand(str,con))
                {
                    List<Contas> lista = new List<Contas>();
                    using (Dr = cmd.ExecuteReader())
                    {
                        Contas mod = null;
                        while(Dr.Read())
                        {
                            mod = new Contas();
                            mod.TipoContaId = Convert.ToInt32(Dr[0]);
                            mod.TipoConta = Convert.ToString(Dr[1]);
                            lista.Add(mod);
                        }
                        return lista;
                    }
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
