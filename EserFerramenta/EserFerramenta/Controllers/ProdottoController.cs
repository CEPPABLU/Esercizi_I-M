using EserFerramenta.Models;
using EserFerramenta.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EserFerramenta.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult ElencoProdotti()          //https://localhost:7279/api/prodotti
        {
            return Ok(ProdottoRepo.getIstanza().GetAll());
        }

        [HttpGet("{valCodice}")]
        public IActionResult DettaglioProdotto(string valCodice)
        {
            Prodotto? prod = ProdottoRepo.getIstanza().GetByCodice(valCodice);
            if (prod is not null)
                return Ok(prod);

            return NotFound();
        }

        [HttpPost]
        public IActionResult InserisciProdotto(Prodotto objLib)
        {
            if (ProdottoRepo.getIstanza().insert(objLib))
                return Ok();

            return BadRequest();
        }

        private IActionResult EliminaProdotto(int varId)
        {
            if (ProdottoRepo.getIstanza().delete(varId))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("codice/{varCodice}"), HttpPost("codice/{varCodice}")]
        public IActionResult EliminaPerCodiceProdotto(string varCodice)
        {
            Prodotto? prod = ProdottoRepo.getIstanza().GetByCodice(varCodice);
            if (prod is null)
                return BadRequest();

            return EliminaProdotto(prod.ProdottoId);
        }

        [HttpPut]
        public IActionResult ModificaProdotto(Prodotto objLib)
        {
            if (ProdottoRepo.getIstanza().update(objLib))
                return Ok();

            return BadRequest();
        }

    }
}
