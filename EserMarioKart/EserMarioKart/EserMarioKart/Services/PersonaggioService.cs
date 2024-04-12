using EserMarioKart.DTO;
using EserMarioKart.Models;
using EserMarioKart.Repos;

namespace EserMarioKart.Services
{
    public class PersonaggioService
    {
        private readonly PersonaggioRepo _repository;

        public PersonaggioService(PersonaggioRepo repository)
        {
            _repository = repository;
        }

        public List<PersonaggioDTO> GetAllPer()
        {
            List<PersonaggioDTO> elenco = _repository.GetAll().Select(p => new PersonaggioDTO()
            {
                Code = p.CodiceP,
                Nome = p.NomeP,
                Cate = p.Categoria,
                Cost = p.Costo,
                SqRif = p.SquadraRIF,
                Squa = p.SquadraRIFNavigation
            }).ToList();

            return elenco;
        }

        public bool InsPersonaggio(PersonaggioDTO oPer)
        {
            Personaggio per = new Personaggio()
            {
                CodiceP = oPer.Code,
                NomeP = oPer.Nome,
                Categoria = oPer.Cate,
                Costo = oPer.Cost
            };

            return _repository.Create(per);
        }
        public bool ModPersonaggio(PersonaggioDTO oPer)
        {
            if (oPer.Code != null)
            {
                Personaggio? per = _repository.GetByCodice(oPer.Code);
                if (per != null)
                {
                    per.NomeP = oPer.Nome;
                    per.Categoria = oPer.Cate;
                    per.Costo = oPer.Cost;
                    return _repository.Update(per);
                }
            }
            return false;
        }
        public bool EliminaPersonaggio(PersonaggioDTO oPer)
        {
            if (oPer.Code is not null)
            {
                Personaggio? temp = _repository.GetByCodice(oPer.Code);

                if (temp is not null)
                    return _repository.DeleteByCodice(temp.CodiceP);
            }
            return false;
        }
    }
}
