using Eser_Libri_Prestiti.Models;
using Eser_Libri_Prestiti.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Libri_Prestiti.DAL
{
    internal class PrestitoDAL : IDAL<Prestito>
    {
        private static PrestitoDAL? istanza;

        public static PrestitoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new PrestitoDAL();

            return istanza;
        }

        private PrestitoDAL() { }


        public bool Delete(Prestito t)
        {
            throw new NotImplementedException();
        }

        public List<Prestito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prestito GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Prestito t)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Prestito(data_prestito, data_ritorno, utenteRIF, libroRIF) VALUES (@datPre, @datRit, @utRIF, @libRIF)";
                sqlCommand.Parameters.AddWithValue("@datPre", t.DataPrestito);
                sqlCommand.Parameters.AddWithValue("@datRit", t.FinePrestito);
                sqlCommand.Parameters.AddWithValue("@utRIF", t.UtenteRIF);
                sqlCommand.Parameters.AddWithValue("@libRIF", t.LibroRIF);

                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return risultato;
        }

        public bool Update(Prestito t)
        {
            throw new NotImplementedException();
        }
    }
}
