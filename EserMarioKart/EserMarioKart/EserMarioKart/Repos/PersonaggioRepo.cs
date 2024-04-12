using EserMarioKart.Models;

namespace EserMarioKart.Repos
{
    public class PersonaggioRepo : IRepo<Personaggio>
    {
        private readonly MarioKartContext _context;

        public PersonaggioRepo(MarioKartContext context)
        {
            _context = context;
        }

        public bool Create(Personaggio entity)
        {
            try
            {
                _context.Personaggio.Add(entity);
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
                Personaggio? temp = GetByCodice(codice);
                if (temp != null)
                {
                    _context.Personaggio.Remove(temp);
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

        public IEnumerable<Personaggio> GetAll()
        {
            return _context.Personaggio.ToList();
        }

        public bool Update(Personaggio entity)
        {
            try
            {
                _context.Personaggio.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Personaggio? GetByCodice(string codice)
        {
            try
            {
                return _context.Personaggio.FirstOrDefault(p => p.CodiceP == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
