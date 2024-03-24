using Microsoft.Extensions.Logging;
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
        #region Metodo Opzioni
        public void Opzioni()
        {

            bool insAbi = true;
            while (insAbi)
            {
                Console.WriteLine("Digita cosa vuoi fare:\n" +
                                   "1 - Per gestire un evento\n" +
                                   "2 - Per gestire un partecipante\n" +
                                   "3 - Per gestire una risorsa\n" +
                                   "4 - Per salvare il file in CSV\n" +
                                   "Q - Per uscire"
                                   );
                string? inputUtente = Console.ReadLine().ToUpper();

                switch (inputUtente)
                {
                    #region SwitchCase Evento
                    case ("1"):
                        Console.WriteLine("Digita cosa vuoi fare:\n" +
                                   "1 - Per inserire un evento\n" +
                                   "2 - Per la lista degli eventi\n" +
                                   "3 - Per aggiornare un evento\n" +
                                   "4 - Per rimuovere un evento"
                                   );
                        string? inputUtente1 = Console.ReadLine();
                        switch (inputUtente1)
                        {
                            case ("1"):
                                this.addEvento();
                                break;
                            case ("2"):
                                this.readEventi();
                                break;
                            case ("3"):
                                this.modEvento();
                                break;
                            case ("4"):
                                this.removeEvento();
                                break;
                            default:
                                Console.WriteLine("Errore digitazione");
                                break;
                        }
                        break;


                    #endregion

                    #region SwitchCase Partecipante
                    case ("2"):
                        Console.WriteLine("Digita cosa vuoi fare:\n" +
                                   "1 - Per inserire un partecipante\n" +
                                   "2 - Per la lista dei partecipanti\n" +
                                   "3 - Per aggiornare un partecipante\n" +
                                   "4 - Per rimuovere un partecipante"
                                   );
                        string? inputUtente2 = Console.ReadLine();

                        switch (inputUtente2)
                        {
                            case ("1"):
                                this.addPartecipante();
                                break;
                            case ("2"):
                                this.readPartecipanti();
                                break;
                            case ("3"):
                                this.modPartecipanti();
                                break;
                            case ("4"):
                                this.removePartecipante();
                                break;
                            default:
                                Console.WriteLine("Errore digitazione");
                                break;
                        }
                        break;
                    #endregion

                    #region Switchcase Risorsa
                    case ("3"):
                        Console.WriteLine("Digita cosa vuoi fare:\n" +
                                   "1 - Per inserire un una risorsa\n" +
                                   "2 - Per la lista delle risorse\n" +
                                   "3 - Per aggiornare una risorsa\n" +
                                   "4 - Per rimuovere una risorsa"
                                   );
                        string? inputUtente3 = Console.ReadLine();

                        switch (inputUtente3)
                        {
                            case ("1"):
                                this.addRisorsa();
                                break;
                            case ("2"):
                                this.readRisorse();
                                break;
                            case ("3"):
                                this.modRisorsa();
                                break;
                            case ("4"):
                                this.removeRisorsa();
                                break;
                            default:
                                Console.WriteLine("Errore digitazione");
                                break;
                        }
                        break;
                    #endregion

                    case ("4"):
                        this.esportaCSV();
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
        #endregion
        #region Metodi del Programma

        #region Aggiungi Partecipante
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
                    Console.WriteLine("Inserisci l'ID dell'evento a cui associare il partecipante");
                    int inputRif = int.Parse(Console.ReadLine());
                    if (inputRif < 0)
                    {
                        Console.WriteLine("ID dell'evento non valido. Inserisci un numero intero.");
                        return;
                    }
                    var eventoEsistente = ctx.Eventos.FirstOrDefault(e => e.EventoId == inputRif);
                    if (eventoEsistente != null)
                    {
                        Console.WriteLine($"Evento esistente: {eventoEsistente.Nome}");
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
                    else
                    {
                        Console.WriteLine("Evento non trovato.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion

        #region Aggiungi Evento
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
                    Console.WriteLine($"Evento inserito con successo. ID: {ev.EventoId}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion

        #region Aggiungi Risorsa
        public void addRisorsa()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    this.readEventi();
                    Console.WriteLine("Inserisci il tipo di risorsa");
                    string? inputTipo = Console.ReadLine().ToUpper();
                    Console.WriteLine("Inserisci la quantità della risorsa");
                    int inputQuan = int.Parse(Console.ReadLine()); ;
                    Console.WriteLine("Inserisci il costo della risorsa");
                    decimal inputCos = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il fornitore");
                    string? inputFor = (Console.ReadLine().ToUpper());
                    Console.WriteLine("Inserisci l'ID dell'evento a cui associare il partecipante");
                    int inputRif = int.Parse(Console.ReadLine());
                    if (inputRif < 0)
                    {
                        Console.WriteLine("ID dell'evento non valido. Inserisci un numero intero.");
                        return;
                    }
                    var eventoEsistente = ctx.Eventos.FirstOrDefault(e => e.EventoId == inputRif);
                    if (eventoEsistente != null)
                    {
                        Console.WriteLine($"Evento esistente: {eventoEsistente.Nome}");
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
                    else
                    {
                        Console.WriteLine("Non può essere vuota la casella");
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion

        #region Rimuovi Partecipante
        public void removePartecipante()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    Console.WriteLine("Inserisci l'ID del partecipante da rimuovere");
                    int parDaRim = int.Parse(Console.ReadLine());

                    var parEs = ctx.Partecipantes.FirstOrDefault(p => p.PartecipanteId == parDaRim);
                    if (parEs != null)
                    {
                        Console.WriteLine($"Il nome del partecipante è: {parEs.Nome}");
                        //ctx.Partecipantes.Remove(parEs);
                        parEs.Deleted = DateTime.Now;
                        ctx.SaveChanges();
                        Console.WriteLine($"Il partecipante con ID {parDaRim} è stato rimosso.");
                    }
                    else
                    {
                        Console.WriteLine($"Partecipante con ID {parDaRim} non trovato.");
                    }

                }
                catch (Exception e)
                {
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
        }
        #endregion

        #region Rimuovi Evento
        public void removeEvento()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    Console.WriteLine("Inserisci l'ID del partecipante da rimuovere");
                    int evDaRim = int.Parse(Console.ReadLine());

                    var evEs = ctx.Eventos.FirstOrDefault(e => e.EventoId == evDaRim);
                    if (evEs != null)
                    {
                        Console.WriteLine($"Il nome dell'evento è: {evEs.Nome}");
                        ctx.Eventos.Remove(evEs);
                        ctx.SaveChanges();
                        Console.WriteLine($"Il partecipante con ID {evDaRim} è stato rimosso.");
                    }
                    else
                    {
                        Console.WriteLine($"Partecipante con ID {evDaRim} non trovato.");
                    }

                }
                catch (Exception e)
                {
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
        }
        #endregion

        #region Rimuove Risorsa
        public void removeRisorsa()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    this.readEventi();
                    this.readRisorse();
                    Console.WriteLine("Inserisci l'ID della risorsa da rimuovere");
                    int risDaRim = int.Parse(Console.ReadLine());

                    var risEs = ctx.Risorsas.FirstOrDefault(r => r.RisorsaId == risDaRim);
                    if (risEs != null)
                    {
                        Console.WriteLine($"Il Tipo di risorsa è: {risEs.Tipo}");
                        //ctx.Risorsa.Remove(parEs);
                        risEs.Deleted = DateTime.Now;
                        ctx.SaveChanges();
                        Console.WriteLine($"La risorsa con ID {risDaRim} è stato rimosso.");
                    }
                    else
                    {
                        Console.WriteLine($"Risorsa con ID {risDaRim} non trovato.");
                    }

                }
                catch (Exception e)
                {
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

        }
        #endregion

        #region Leggi Eventi
        public void readEventi()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    foreach (Evento e in ctx.Eventos.ToList())
                    {
                        Console.WriteLine($"IdEvento: {e.EventoId} Nome: {e.Nome} Descrizione: {e.Descrizione} Capacità : {e.Capacita} Data: {e.DataOra} Luogo : {e.Luogo}");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        #endregion

        #region Leggi Risorse
        public void readRisorse()
        {
            using (var ctx = new EserEventiContext())
            {
                Console.WriteLine("Di quale evento vuoi sapere tutte le risorse?");
                int inpUt = int.Parse(Console.ReadLine());

                try
                {
                    var risEv = ctx.Risorsas.Where(r => r.EventoRif == inpUt).ToList();
                    if (risEv.Any())
                    {
                        Console.WriteLine("Lista delle risorse: ");
                        foreach (Risorsa r in ctx.Risorsas.ToList())
                        {
                            Console.WriteLine($"RisorsaID: {r.RisorsaId} Quantità: {r.Quantita} Tipo: {r.Tipo} Costo: {r.Costo} Fornitore: {r.Fornitore} ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessuna risorsa trovata.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        #endregion

        #region Leggi Partecipanti
        public void readPartecipanti()
        {
            using (var ctx = new EserEventiContext())
            {
                Console.WriteLine("Di quale evento vuoi sapere tutti i partecipanti?");
                int inpUt = int.Parse(Console.ReadLine());

                try
                {
                    var parEv = ctx.Partecipantes.Where(p => p.EventoRif == inpUt).ToList();
                    if (parEv.Any())
                    {
                        Console.WriteLine("Lista delle risorse: ");
                        foreach (Partecipante p in ctx.Partecipantes.ToList())
                        {
                            Console.WriteLine($"PartecipanteID: {p.PartecipanteId} Nome: {p.Nome} Contatto: {p.Contatto} Biglietto: {p.Biglietto} ");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessuna risorsa trovata.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        #endregion

        #region Modifica Evento
        public void modEvento()
        {
            using (var ctx = new EserEventiContext())
            {
                this.readEventi();

                try
                {
                    Console.WriteLine("Inserisci l'ID dell'evento da modificare");
                    int evDaMod = int.Parse(Console.ReadLine());
                    if (evDaMod < 0)
                    {
                        Console.WriteLine("ID dell'utente non valido. Inserisci un numero esistente.");
                        return;
                    }

                    var evEsistente = ctx.Eventos.FirstOrDefault(r => r.EventoId == evDaMod);
                    Console.WriteLine("Digita cosa vuoi fare:\n" +
                                "1 - Per modificare il nome\n" +
                                "2 - Per modificare la descrizione\n" +
                                "3 - Per modificare la capacità\n" +
                                "4 - Per modificare la data\n" +
                                "5 - Per modificare il luogo");
                    string? inputUtente = Console.ReadLine();
                    switch (inputUtente)
                    {
                        case "1":
                            Console.WriteLine("Inserisci il nuovo Tipo");
                            string? newNome = Console.ReadLine();
                            if (evEsistente is not null && newNome is not null)
                            {
                                evEsistente.Nome = newNome;
                                ctx.SaveChanges();
                                Console.WriteLine($"Nuovo nome inserito {evEsistente.Nome}");
                            }
                            break;//Nome
                        case "2":
                            Console.WriteLine("Inserisci la nuova quantità");
                            try
                            {
                                string? newDes = Console.ReadLine();
                                if (evEsistente is not null)
                                {
                                    evEsistente.Descrizione = newDes;
                                    ctx.SaveChanges();
                                    Console.WriteLine($"Nuova descrizione inserita {evEsistente.Descrizione}");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;//Descrizione
                        case "3":
                            Console.WriteLine("Inserisci la nuova capacità");
                            try
                            {
                                int newCap = int.Parse(Console.ReadLine());
                                if (evEsistente is not null)
                                {
                                    evEsistente.Capacita = newCap;
                                    ctx.SaveChanges();
                                    Console.WriteLine($"Nuovo capacità inserita {evEsistente.Capacita}");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;//Capacità
                        case "4":
                            Console.WriteLine("Inserisci la nuova data eg:(e.g. anno/mese/giorno)");
                            try
                            {
                                DateTime inputDate = DateTime.Parse(Console.ReadLine());
                                if (evEsistente is not null)
                                {
                                    evEsistente.DataOra = inputDate;
                                    ctx.SaveChanges();
                                    Console.WriteLine($"Nuova data inserita {evEsistente.DataOra}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;//Data
                        case "5":
                            Console.WriteLine("Inserisci il nuovo fornitore");
                            string? newLug = Console.ReadLine();
                            if (evEsistente is not null && newLug is not null)
                            {
                                evEsistente.Luogo = newLug;
                                ctx.SaveChanges();
                                Console.WriteLine($"Nuovo luogo inserito {evEsistente.Luogo}");
                            }
                            break;//Luogo
                        default:
                            Console.WriteLine("Errore di digitazione!");
                            break;
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Modifica Partecipanti
        public void modPartecipanti()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    this.readEventi();
                    this.readPartecipanti();
                    Console.WriteLine("Inserisci l'ID del partecipante da modificare");
                    int parDaMod = int.Parse(Console.ReadLine());
                    if (parDaMod < 0)
                    {
                        Console.WriteLine("ID dell'utente non valido. Inserisci un numero esistente.");
                        return;
                    }
                    var parEsistente = ctx.Partecipantes.FirstOrDefault(e => e.PartecipanteId == parDaMod);
                    Console.WriteLine("Digita cosa vuoi fare:\n" +
                                "1 - Per modificare il nome\n" +
                                "2 - Per modificare il contatto");
                    string? inputUtente = Console.ReadLine();


                    switch (inputUtente)
                    {
                        case "1":
                            Console.WriteLine("Inserisci il nuovo nome");
                            string? newName = Console.ReadLine();
                            if (parEsistente is not null && newName is not null)
                            {
                                parEsistente.Nome = newName;
                                ctx.SaveChanges();
                                Console.WriteLine($"Nuovo nome inserito {parEsistente.Nome}");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Inserisci il nuovo nome");
                            string? newContatto = Console.ReadLine();
                            if (parEsistente is not null && newContatto is not null)
                            {
                                parEsistente.Contatto = newContatto;
                                ctx.SaveChanges();
                                Console.WriteLine($"Nuovo contatto inserito {parEsistente.Contatto}");
                            }
                            break;
                        default:
                            Console.WriteLine("Errore di digitazione!");
                            break;
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        #endregion

        #region Modifica Risorsa
        public void modRisorsa()
        {
            using (var ctx = new EserEventiContext())
            {
                try
                {
                    this.readEventi();
                    this.readRisorse();
                    Console.WriteLine("Inserisci l'ID della risorsa da modificare");
                    int risDaMod = int.Parse(Console.ReadLine());
                    if (risDaMod < 0)
                    {
                        Console.WriteLine("ID dell'utente non valido. Inserisci un numero esistente.");
                        return;
                    }

                    var risEsistente = ctx.Risorsas.FirstOrDefault(r => r.RisorsaId == risDaMod);
                    Console.WriteLine("Digita cosa vuoi fare:\n" +
                                "1 - Per modificare il tipo\n" +
                                "2 - Per modificare la quantità\n" +
                                "3 - Per modificare il costo\n" +
                                "4 - Per modificare il fornitore");
                    string? inputUtente = Console.ReadLine();
                    switch (inputUtente)
                    {
                        case "1":
                            Console.WriteLine("Inserisci il nuovo Tipo");
                            string? newType = Console.ReadLine();
                            if (risEsistente is not null && newType is not null)
                            {
                                risEsistente.Tipo = newType;
                                ctx.SaveChanges();
                                Console.WriteLine($"Nuovo nome inserito {risEsistente.Tipo}");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Inserisci la nuova quantità");
                            try
                            {
                                int newQuan = int.Parse(Console.ReadLine());
                                if (risEsistente is not null)
                                {
                                    risEsistente.Quantita = newQuan;
                                    ctx.SaveChanges();
                                    Console.WriteLine($"Nuova quantità inserita {risEsistente.Quantita}");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "3":
                            Console.WriteLine("Inserisci il nuovo costo");
                            try
                            {
                                decimal newCost = decimal.Parse(Console.ReadLine());
                                if (risEsistente is not null)
                                {
                                    risEsistente.Costo = newCost;
                                    ctx.SaveChanges();
                                    Console.WriteLine($"Nuovo costo inserito {risEsistente.Costo}");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "4":
                            Console.WriteLine("Inserisci il nuovo fornitore");
                            string? newFor = Console.ReadLine();
                            if (risEsistente is not null && newFor is not null)
                            {
                                risEsistente.Fornitore = newFor;
                                ctx.SaveChanges();
                                Console.WriteLine($"Nuovo nome inserito {risEsistente.Fornitore}");
                            }
                            break;
                        default:
                            Console.WriteLine("Errore di digitazione!");
                            break;
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Esporta CSV

        public void esportaCSV()
        {
            string path = "C:\\Users\\utente\\Desktop\\Esercitazioni\\Eser_Eventi\\Eventi.txt";

            try
            {
                using(var ctx = new EserEventiContext())
                {

                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (Evento e in ctx.Eventos.ToList())
                        {
                            sw.WriteLine($"IdEvento: {e.EventoId} Nome: {e.Nome} Descrizione: {e.Descrizione} Capacità : {e.Capacita} Data: {e.DataOra} Luogo : {e.Luogo}");
                        }

                        foreach (Partecipante p in ctx.Partecipantes.ToList())
                        {
                            sw.WriteLine($"PartecipanteID: {p.PartecipanteId} Nome: {p.Nome} Contatto: {p.Contatto} Biglietto: {p.Biglietto} ");
                        }     
                        foreach (Risorsa r in ctx.Risorsas.ToList())
                        {
                            sw.WriteLine($"RisorsaID: {r.RisorsaId} Quantità: {r.Quantita} Tipo: {r.Tipo} Costo: {r.Costo} Fornitore: {r.Fornitore} ");
                        }

                    }

                }
                Console.WriteLine("Stappo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #endregion
    }
}