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
                                   "1 - Per inserire un evento");
                string? inputUtente = Console.ReadLine();

                switch (inputUtente)
                {
                    case ("1"):
                        try
                        {
                            this.addEvento();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);

                        }
                    break;
                }
            }
        }
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
                    Console.WriteLine("Inserisci la data dell'evento (e.g. 10/22/1987)");
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
    }            //CicloWhile
}