using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eser_Libri_Prestiti.Models
{
    internal class Utente
    {
        public int ID { get; set; }
        public int CodUt { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Mail { get; set; }

        public List<Prestito> ElencoPrestiti { get; set; } = new List<Prestito>();
        //Non serve il SOFT DELETE

        public Utente() { }
        public Utente(int CodUt, string? Nome, string? Cognome, string? Mail)
        {
            this.CodUt = CodUt;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Mail = Mail;
        }
        public Utente(int ID, int CodUt, string? Nome, string? Cognome, string? Mail)
        {
            this.ID = ID;
            this.CodUt = CodUt;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Mail = Mail;
        }
    }
}
