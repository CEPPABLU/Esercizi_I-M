using Eser_Impiegato.Models;
using Eser_Impiegato.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eser_Impiegato.Controllers
{
    public class ImpiegatoController : Controller
    {
        private readonly ImpiegatoService _service;

        public ImpiegatoController(ImpiegatoService service)
        {
            _service = service;
        }

        public IActionResult Lista()
        {
            List<Impiegato> elenco = _service.ElencoTuttiImpiegati();

            return View(elenco);
        }

        public IActionResult Inserimento()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Impiegato objImpiegato)
        {
            if (_service.InserisciImpiegato(objImpiegato))
                return Redirect("/Impiegato/Lista");
            else
                return Redirect("/Impiegato/Errore");
        }

        public IActionResult Dettaglio(string varMatricola)
        {
            if (string.IsNullOrWhiteSpace(varMatricola))
                return Redirect("/Impiegato/Errore");

            Impiegato? impiegato = _service.RicercaImpiegatoPerMatricola(varMatricola);
            if (impiegato is null)
                return Redirect("/Impiegato/Errore");

            return View(impiegato);
        }

        [HttpDelete]
        public IActionResult Elimina(string varMatricola)
        {
            if (_service.EliminaImpiegatoPerMatricola(varMatricola))
                return Ok();

            return BadRequest();
        }

        public IActionResult Modifica(string varMatricola)
        {
            Impiegato? temp = _service.RicercaImpiegatoPerMatricola(varMatricola);
            if (temp is null)
                return Redirect("/Impiegato/Errore");

            return View(temp);
        }

        public IActionResult EffettuaModifica(Impiegato nuovo)
        {
            Impiegato? vecchio = _service.RicercaImpiegatoPerMatricola(nuovo.Matricola);
            if (vecchio is null)
                return Redirect("/Impiegato/Errore");

            if (!_service.ModificaImpiegato(vecchio, nuovo))
                return Redirect("/Impiegato/Errore");

            return Redirect("/Impiegato/Lista");
        }
    }
}
