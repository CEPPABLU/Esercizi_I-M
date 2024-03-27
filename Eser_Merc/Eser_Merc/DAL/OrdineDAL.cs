using Eser_Merc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Merc.DAL
{
    internal class OrdineDAL : IDAL<Ordine>
    {
        private OrdineDAL() { }

        private static OrdineDAL? istanza;

        public static OrdineDAL getIstanza()
        {
            if (istanza == null)
                istanza = new OrdineDAL();
            return istanza;
        }

        public List<Ordine> GetAll()
        {
            List<Ordine> risultato = new List<Ordine>();

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Ordines.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Insert(Ordine t)
        {
            bool risultato = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    ctx.Ordines.Add(t);
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Update(Ordine t)
        {
            bool controllo = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    var ordineEs = ctx.Ordines.FirstOrDefault(e => e.OrdineId == t.);
                    if (ordineEs != null)
                    {
                        ctx.Ordines.Remove(t);
                        ctx.Ordines.Add(t);
                        ctx.SaveChanges();
                        controllo = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return controllo;
        }

        public Ordine findById(int id)
        {
            Ordine risultato = null;
            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                   risultato = ctx.Ordines.Single(e => e.OrdineId == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return risultato;
        }

        public bool DeleteById(int id)
        {
            bool controllo = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    Ordine ordine = ctx.Ordines.Single(e => e.OrdineId == id);
                    ctx.Ordines.Remove(ordine);
                    ctx.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
