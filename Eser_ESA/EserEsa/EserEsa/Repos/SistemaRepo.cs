using EserEsa.Models;

namespace EserEsa.Repos
{
    public class SistemaRepo : IRepo<Sistema>
    {
        private readonly EsaContext _context;

        public SistemaRepo(EsaContext context)
        {
            _context = context;
        }

        public IEnumerable<Sistema> GetAll()
        {
            return _context.Sistemi.ToList();

        }

        public Sistema? Get(int id)
        {
            return _context.Sistemi.Find(id);
        }

        public bool Create(Sistema entity)
        {
            try
            {
                _context.Sistemi.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Update(Sistema entity)
        {
            try
            {
                _context.Sistemi.Update(entity);
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

    }
}
