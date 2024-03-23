using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Eventi.Models
{
    internal class VIsta
    {
        private static VIsta istanza;

        public static VIsta getIstanza()
        {
            if (istanza == null)
            {
                istanza = new VIsta();
            }
            return istanza;
        }
        private VIsta() { }

        public void Opzioni()
        {

            bool insAbi = true;

            while (insAbi)
            {
                Console.WriteLine("Digita cosa vuoi fare:\n" +
                                   "1 - Per inserire un evento\n" +
                                   "2 - Per inserire un partecipante\n"+
                                   "3 - Per inserire una risorsa\n"+
                                   "4 - Per rimuovere un partecipante\n"
                                   +"Q - Per uscire"
                                   );
                string? inputUtente = Console.ReadLine();

                switch (inputUtente)
                { 
                    case ("1"):
                        this.addEvento();
                        break;
                    case ("2"):
                        this.addPartecipante();
                        break;
                    case ("3"):
                        this.addRisorsa();
                        break;
                    case ("4"):
                        this.removePartecipante();
                        break;
                    case ("Q"):
                        insAbi = false;
                        break;
                    default:
                        Console.WriteLine("Errore digitazione");
                        break;
                }
            }
        }
        #region Inserimento Evento
        public void addEvento()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    Console.WriteLine("Inserisci il nome dell'evento");
                    string? inputNomeEv = Console.ReadLine().ToUpper();
                    Console.WriteLine("Inserisci la descrizione dell'evento");
                    string? inputDesEv = Console.ReadLine().ToUpper();
                    Console.WriteLine("Inserisci la capacità dell'evento");
                    int capEv = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci la data dell'evento (e.g. anno/mese/giorno)");
                    DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il luogo dell'evento");
                    string? inputLuogEv = Console.ReadLine().ToUpper();
                    Evento ev = new Evento()
                    {
                        Nome = inputNomeEv,
                        Descrizione = inputDesEv,
                        Capacita = capEv,
                        DataOra = inputtedDate,
                        Luogo = inputLuogEv,
                    };
                    ctx.Eventos.Add(ev);
                    ctx.SaveChanges();
                    Console.WriteLine($"Il nome dell'evento inserito è: {ev.Nome}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        #endregion

        #region Inserimento Partecipante
        public void addPartecipante()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    Console.WriteLine("Inserisci il nome del partecipante");
                    string? inputNomePar = Console.ReadLine().ToUpper();
                    Console.WriteLine("Inserisci il contatto del partecipante");
                    string? inputConPar = Console.ReadLine().ToUpper();
                    Console.WriteLine("Inserisci il codice del biglietto");
                    string? inputTick = (Console.ReadLine().ToUpper());
                    Console.WriteLine("Inserisci il riferimento all'evento");
                    int inputRif = int.Parse(Console.ReadLine());
                    Partecipante par = new Partecipante()
                    {
                        Nome = inputNomePar,
                        Contatto = inputConPar,
                        Biglietto = inputTick,
                        EventoRif = inputRif,
                    };
                    ctx.Partecipantes.Add(par);
                    ctx.SaveChanges();
                    Console.WriteLine($"Il partecipante {par.Nome} è stato inserito");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion

        #region Inserimento Risorsa
        public void addRisorsa()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    Console.WriteLine("Inserisci il tipo di risorsa");
                    string? inputTipo = Console.ReadLine().ToUpper();
                    Console.WriteLine("Inserisci la quantità della risorsa");
                    int inputQuan = int.Parse(Console.ReadLine());;
                    Console.WriteLine("Inserisci il costo della risorsa");
                    decimal inputCos = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il fornitore");
                    string? inputFor = (Console.ReadLine().ToUpper());
                    Console.WriteLine("Inserisci il riferimento all'evento");
                    int inputRif = int.Parse(Console.ReadLine());
                    Risorsa ris = new Risorsa()
                    {
                        Tipo = inputTipo,
                        Quantita = inputQuan,
                        Costo = inputCos,
                        Fornitore = inputFor,
                        EventoRif = inputRif,
                    };
                    ctx.Risorsas.Add(ris);
                    ctx.SaveChanges();
                    Console.WriteLine($"La risorsa {ris.Tipo} è stata inserita");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion

        public void removePartecipante()
        {
            using (var ctx = new EserEventiContext())
            {
                ICollection<Partecipante> elencoPar = ctx.Partecipantes.ToList();
                foreach (Partecipante p in elencoPar)
                {
                    if (p.PartecipanteId == id)
                    {
                        ctx.Partecipantes.Remove(p);
                        ctx.SaveChanges();
                        return;
                    }
                    if (!manage)
                    {
                        Console.WriteLine("Partecipante non trovato!");
                    }
                }

            }
        }
    }
}