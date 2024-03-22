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
        public string? CodPres { get; set; }
        public DateTime? DataPrestito { get; set; }
        public DateTime? FinePrestito { get; set; }
        public Libro? libroCoinvolto {  get; set; }
        public Utente? utenteCoinvolto { get; set; }

        public Prestito() { }

        public Prestito(string? CodPres, DateTime? DataPrestito, DateTime? FinePrestito Libro? libroCoinvolto, Utente? utenteCoinvolto)
        {
            this.CodPres = CodPres;
            this.DataPrestito = DataPrestito;
            this.FinePrestito = FinePrestito;
            Libro = LibroCoinvolto;
            Utente = UtenteCoinvolto;
        }
        public Prestito(int Id, string? CodPres, DateTime? DataPrestito, DateTime? FinePrestito)
        {
            this.Id = Id;
            this.CodPres = CodPres;
            this.DataPrestito = DataPrestito;
            this.FinePrestito = FinePrestito;
        }
    }
}
