using EserEsa.Models;
using EserEsa.Repos;

namespace EserEsa.Services
{
    public class OggettoService : IService<OggettoCeleste>
    {
        private readonly OggettoRepo _repository;

        public OggettoService(OggettoRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<OggettoCeleste> PrendiliTutti()
        {
            return _repository.GetAll();
        }

    }
}
