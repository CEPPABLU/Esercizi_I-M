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
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Mail { get; set; }

        public Utente(string? Nome, string? Cognome, string? Mail)
        {
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Mail = Mail;
        }
        public Utente(int ID, string? Nome, string? Cognome, string? Mail)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Mail = Mail;
        }
    }
}
