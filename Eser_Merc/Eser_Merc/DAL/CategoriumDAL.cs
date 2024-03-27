using Eser_Merc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Eser_Merc.DAL
{
    internal class CategoriumDAL : IDAL<Categorium>
    {
        private CategoriumDAL() { }

        private static CategoriumDAL? istanza;

        public static CategoriumDAL getIstanza()
        {
            if (istanza == null)
                istanza = new CategoriumDAL();
            return istanza;
        }

        public List<Categorium> GetAll()
        {
            List<Categorium> risultato = new List<Categorium>();

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Categoria.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Insert(Categorium t)
        {
            bool risultato = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    ctx.Categoria.Add(t);
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

        public bool Update(Categorium t)
        {
            bool controllo = false;

            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    var categoriaEs = ctx.Categoria.FirstOrDefault(e => e.CategoriaId == t.CategoriaId);
                    if (categoriaEs != null)
                    {
                        ctx.Categoria.Remove(t);
                        ctx.Categoria.Add(t);
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

        public Categorium findById(int id)
        {
            Categorium risultato = null;
            using (var ctx = new TaskMercolediContext())
            {
                try
                {
                    risultato = ctx.Categoria.Single(e => e.CategoriaId == id);
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
                    Categorium categoria = ctx.Categoria.Single(e => e.CategoriaId == id);
                    ctx.Categoria.Remove(categoria);
                    ctx.SaveChanges();
                    categoria.Deleted = DateTime.Now;
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}

