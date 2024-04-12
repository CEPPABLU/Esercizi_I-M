using EserEsa.Models;
using EserEsa.Repos;

namespace EserEsa.Services
{
    public class SistemaService : IService<Sistema>
    {
        private readonly SistemaRepo _repository;

        public SistemaService(SistemaRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Sistema> PrendiliTutti()
        {
            return _repository.GetAll();
        }
    }
}
