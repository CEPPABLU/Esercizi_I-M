using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eser_Libri_Prestiti.Models
{
    internal class Libro
    {
        public int ID { get; set; }
        public string? CodIsbn { get; set;}
        public string? Titolo { get; set; }
        public DateTime Anno_pub { get; set; }
        public bool isDisp { get; set; }

        public List<Prestito> ElencoPrestiti { get; set; } = new List<Prestito>();
        public Libro() { }
        public Libro(string? CodIsbn, string? Titolo, DateTime Anno_pub, bool isDisp)
        {
             this.CodIsbn = CodIsbn;
             this.Titolo = Titolo;
             this.Anno_pub = Anno_pub;
             this.isDisp = isDisp;
        }
        public Libro(int ID, int CodIsbn, string? Titolo, DateTime Anno_pub, bool isDisp)
        {
            this.ID = ID;
            this.CodIsbn = CodIsbn;
            this.Titolo = Titolo;
            this.Anno_pub = Anno_pub;
            this.isDisp = isDisp;
        }
    }
}
