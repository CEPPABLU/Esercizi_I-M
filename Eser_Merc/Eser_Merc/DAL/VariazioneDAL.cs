using Eser_Merc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eser_Merc.DAL
{
    internal class VariazioneDAL : IDAL<Variazione>
    {
        private VariazioneDAL() { }

        private static VariazioneDAL? istanza;

        public static VariazioneDAL getIstanza()
        {
            if (istanza == null)
                istanza = new VariazioneDAL();
            return istanza;
        }

        public List<Variazione> GetAll()
        {
            List<Variazione> risultato = new List<Variazione>();

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Variaziones.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Insert(Variazione t)
        {
            bool risultato = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    ctx.Variaziones.Add(t);
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

        public bool Update(Variazione t)
        {
            bool controllo = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    var variazioneEs = ctx.Variaziones.FirstOrDefault(e => e.VariazioneId == t.VariazioneId);
                    if (variazioneEs != null)
                    {
                        ctx.Variaziones.Remove(t);
                        ctx.Variaziones.Add(t);
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

        public Variazione findById(int id)
        {
            Variazione risultato = null;
            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Variaziones.Single(e => e.VariazioneId == id);
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
                    Variazione variazione = ctx.Variaziones.Single(e => e.VariazioneId == id);
                    ctx.Variaziones.Remove(variazione);
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
