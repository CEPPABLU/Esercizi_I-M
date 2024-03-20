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
    internal class LibroDAL : IDAL<Libro>
    {
        private static LibroDAL? istanza;

        public static LibroDAL getIstanza()
        {
            if (istanza == null)
                istanza = new LibroDAL();

            return istanza;
        }

        private LibroDAL() { }

        public bool Delete(Libro t)
        {
            throw new NotImplementedException();
        }

        public List<LibroDAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public Libro GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Libro t)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Libro(titolo, anno_pubblicazione, isDisp) VALUES (@valNom, @valMat, @valIsDisp)";
                sqlCommand.Parameters.AddWithValue("@valNom", t.Titolo);
                sqlCommand.Parameters.AddWithValue("@valMat", t.Anno_pub);
                sqlCommand.Parameters.AddWithValue("@valMat", t.isDisp);

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

        public bool Update(Libro t)
        {
            throw new NotImplementedException();
        }

        List<Libro> IDAL<Libro>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
