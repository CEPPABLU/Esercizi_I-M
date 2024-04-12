using EserMarioKart.Models;

namespace EserMarioKart.Repos
{
    public class SquadraRepo : IRepo<Squadra>
    {
            private readonly MarioKartContext _context;

            public SquadraRepo(MarioKartContext context)
            {
                _context = context;
            }

            public bool Create(Squadra entity)
            {
                try
                {
                    _context.Squadra.Add(entity);
                    _context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            public bool DeleteByCodice(string codice)
            {

                try
                {
                    Squadra? temp = GetByCodice(codice);
                    if (temp != null)
                    {
                        _context.Squadra.Remove(temp);
                        _context.SaveChanges();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                return false;
            }

            public IEnumerable<Squadra> GetAll()
            {
                return _context.Squadra.ToList();
            }

            public bool Update(Squadra entity)
            {
                try
                {
                    _context.Squadra.Update(entity);
                    _context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            public Squadra? GetByCodice(string codice)
            {
                try
                {
                    return _context.Squadra.FirstOrDefault(p => p.CodiceS == codice);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }



        //public List<Personaggio> GetByAllFields(string query)
        //{
        //    return _context.Personaggio.Where(p =>
        //        (p.NomeP != null && p.NomeP.Contains($"{query}")) ||
        //        (p.Descrizione != null && p.Descrizione.Contains($"{query}"))
        //        ).ToList();
        //}
    }
}
