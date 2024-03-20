using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Libri_Prestiti.Models
{
    internal class Prestito
    {
           public int Id { get; set; }
           public string? DataPrestito { get; set; }
           public string? FinePrestito { get; set; }           
           public int UtenteRIF {  get; set; }
           public int LibroRIF {  get; set; }

        public Prestito() { }

        public Prestito(int Id, string? DataPrestito, string? FinePrestito, int UtenteRIF, int LibroRIF)
        {
            this.Id = Id;
            this.DataPrestito = DataPrestito;
            this.FinePrestito = FinePrestito;
            this.UtenteRIF = UtenteRIF;
            this.LibroRIF = LibroRIF;
        }
    }
}
