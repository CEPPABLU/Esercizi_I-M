using EserMarioKart.DTO;
using EserMarioKart.Models;
using EserMarioKart.Repos;

namespace EserMarioKart.Services
{
    public class SquadraService
    {
        private readonly SquadraRepo _repository;

        public SquadraService(SquadraRepo repository)
        {
            _repository = repository;
        }

        public List<SquadraDTO> GetAllPer()
        {
            List<SquadraDTO> elenco = _repository.GetAll().Select(s => new SquadraDTO()
            {
                Code = s.CodiceS,
                Nome = s.NomeS,
                Budg = s.Budget,
                Pers = s.Personaggios,
            }).ToList();

            return elenco;
        }

        public bool InsSquadra(SquadraDTO oSqu)
        {
            Squadra per = new Squadra()
            {
                CodiceS = oSqu.Code,
                NomeS = oSqu.Nome,
                Budget = oSqu.Budg,
            };

            return _repository.Create(per);
        }
        public bool ModSquadra(SquadraDTO oSqu)
        {
            if (oSqu.Code != null)
            {
                Squadra? squ = _repository.GetByCodice(oSqu.Code);
                if (squ != null)
                {
                    squ.NomeS = oSqu.Nome;
                    return _repository.Update(squ);
                }
            }
            return false;
        }
        public bool EliminaPersonaggio(SquadraDTO oSqu)
        {
            if (oSqu.Code is not null)
            {
                Squadra? temp = _repository.GetByCodice(oSqu.Code);

                if (temp is not null)
                    return _repository.DeleteByCodice(temp.CodiceS);
            }
            return false;
        }
    }
}
