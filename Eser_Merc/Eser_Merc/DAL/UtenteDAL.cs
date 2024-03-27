using Eser_Merc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Merc.DAL
{
    internal class UtenteDAL : IDAL<Utente>
    {
        private UtenteDAL() { }

        private static UtenteDAL? istanza;

        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();
            return istanza;
        }
        public List<Utente> GetAll()
        {
            List<Utente> risultato = new List<Utente>();

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Utentes.ToList();
                
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Insert(Utente t)
        {
            bool risultato = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    ctx.Utentes.Add(t);
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

        public bool Update(Utente t)
        {
            bool controllo = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    var utenteEs = ctx.Utentes.FirstOrDefault(e => e.UtenteId == t.UtenteId);
                    if (utenteEs != null)
                    {
                        ctx.Utentes.Remove(t);
                        ctx.Utentes.Add(t);
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

        public Utente findById(int id)
        {
            Utente risultato = null;
            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Utentes.Single(e => e.UtenteId == id);
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
                    Utente utente = ctx.Utentes.Single(e => e.UtenteId == id);
                    ctx.Utentes.Remove(utente);
                    ctx.SaveChanges();
                    utente.Deleted = DateTime.Now;
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
