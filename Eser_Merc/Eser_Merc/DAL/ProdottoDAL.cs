using Eser_Merc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Merc.DAL
{
    internal class ProdottoDAL : IDAL<Prodotto>
    {
        private ProdottoDAL() { }

        private static ProdottoDAL? istanza;

        public static ProdottoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new ProdottoDAL();
            return istanza;
        }
        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    elenco = ctx.Prodottos.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return elenco;
        }
        public bool Delete(Prodotto t)
        {
            throw new NotImplementedException();
        }


        public bool Insert(Prodotto t)
        {
            bool risultato = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    ctx.Prodottos.Add(t);
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

        public bool Update(Prodotto t)
        {
            bool controllo = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    var prodottoEs = ctx.Prodottos.FirstOrDefault(e => e.ProdottoId == t.ProdottoId);
                    if (prodottoEs != null)
                    {
                        ctx.Prodottos.Remove(t);
                        ctx.Prodottos.Add(t);
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

        public Prodotto findById(int id)
        {
            Prodotto risultato = null;
            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Prodottos.Single(e => e.ProdottoId == id);
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
                    Prodotto prodotto = ctx.Prodottos.Single(e => e.ProdottoId == id);
                    ctx.Prodottos.Remove(prodotto);
                    ctx.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex); 
                }
            }
            return controllo;
        }
    }
}
