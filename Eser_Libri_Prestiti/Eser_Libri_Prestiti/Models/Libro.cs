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
        public string? Titolo { get; set; }
        public DateTime Anno_pub { get; set; }
        public bool isDisp { get; set; }

        public Libro(string? Titolo, DateTime Anno_pub, bool isDisp)
        {
             this.Titolo = Titolo;
             this.Anno_pub = Anno_pub;
             this.isDisp = isDisp;
        }

        //void Docente(int, string, strina, string, string)
        public Libro(int ID, string? Titolo, DateTime Anno_pub, bool isDisp)
        {
            this.ID = ID;
            this.Titolo = Titolo;
            this.Anno_pub = Anno_pub;
            this.isDisp = isDisp;
        }
    }
}
