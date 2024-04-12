using EserEsa.Models;

namespace EserEsa.Repos
{
    public class OggettoRepo : IRepo<OggettoCeleste>
    {
        private readonly EsaContext _context;

        public OggettoRepo(EsaContext context)
        {
            _context = context;
        }

        public bool Create(OggettoCeleste entity)
        {
            try
            {
                _context.Oggetti.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OggettoCeleste? Get(int id)
        {
            return _context.Oggetti.Find(id);
        }

        public IEnumerable<OggettoCeleste> GetAll()
        {
            return _context.Oggetti.ToList();
        }

        public bool Update(OggettoCeleste entity)
        {
            throw new NotImplementedException();
        }
    }
}
