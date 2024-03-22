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
    internal class UtenteDAL : IDAL<Utente>
    {
        private static UtenteDAL? istanza;

        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();

            return istanza;
        }

        private UtenteDAL() { }


        public bool Delete(Utente t)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Utente t)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Utente(nome, cognome, mail) VALUES (@valNom, @valCogn, @valMail)";
                sqlCommand.Parameters.AddWithValue("@valNom", t.Nome);
                sqlCommand.Parameters.AddWithValue("@valCogn", t.Cognome);
                sqlCommand.Parameters.AddWithValue("@valMail", t.Mail);

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

        public bool Update(Utente t)
        {
            throw new NotImplementedException();
        }
    }
}
