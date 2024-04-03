using EserFerramenta.Models;

namespace EserFerramenta.Repositories
{
    public class ProdottoRepo : IRepo<Prodotto>
    {
        private static ProdottoRepo? istanza;

        public static ProdottoRepo getIstanza()
        {
            if(istanza == null)
                istanza = new ProdottoRepo();
            return istanza;
        }

        private ProdottoRepo() { }

        public bool delete(int id)
        {
            bool risultato = false;
            using (EserMerc03Context ctx = new EserMerc03Context())
            {
                try
                {
                    Prodotto prod = ctx.Prodottos.Single(c => c.ProdottoId == id);
                    ctx.Prodottos.Remove(prod);
                    ctx.SaveChanges();

                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

            using (EserMerc03Context ctx = new EserMerc03Context())
            {
                elenco = ctx.Prodottos.ToList();
            }

            return elenco;
        }

        public Prodotto GetById(int id)
        {
            Prodotto? prod = null;

            using (EserMerc03Context ctx = new EserMerc03Context())
                prod = ctx.Prodottos.FirstOrDefault(l => l.ProdottoId == id);

            return prod;
        }

        public bool insert(Prodotto t)
        {
            bool risultato = false;
            using (EserMerc03Context ctx = new EserMerc03Context())
            {
                try
                {
                    ctx.Prodottos.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public bool update(Prodotto t)
        {
            bool risultato = false;

            using (EserMerc03Context ctx = new EserMerc03Context())
            {
                try
                {
                    Prodotto temp = ctx.Prodottos.Single(l => l.Codice == t.Codice);

                    t.ProdottoId = temp.ProdottoId;
                    t.Nome = t.Nome is not null ? t.Nome : temp.Nome;
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : temp.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    t.Quantita = t.Quantita is null ? temp.Quantita : t.Quantita;
                    t.Categoria = t.Categoria is not null ? t.Categoria : temp.Categoria;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }
        public Prodotto? GetByCodice(string codice)
        {
            Prodotto? prod = null;

            using (EserMerc03Context ctx = new EserMerc03Context())
                prod = ctx.Prodottos.FirstOrDefault(l => l.Codice == codice);

            return prod;
        }
    }
}
