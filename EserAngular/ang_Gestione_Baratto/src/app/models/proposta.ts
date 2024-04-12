import { Oggetto } from './oggetto';
import { Utente } from './utente';

export class Proposta {
  static idCounter = 0;
  id: number;
  oggettoProposto: Oggetto | undefined;
  oggettoRichiesto: Oggetto | undefined;
  utentePropone: Utente | undefined;
  utenteRiceve: Utente | undefined;
  stato: 'Accettata' | 'Rifiutata' | 'In attesa';

  constructor(
    oggettoProposto: Oggetto,
    oggettoRichiesto: Oggetto,
    utentePropone: Utente,
    utenteRiceve: Utente,
    stato: 'Accettata' | 'Rifiutata' | 'In attesa' = 'In attesa'
  ) {
    this.id = Proposta.idCounter++;
    this.oggettoProposto = oggettoProposto;
    this.oggettoRichiesto = oggettoRichiesto;
    this.utentePropone = utentePropone;
    this.utenteRiceve = utenteRiceve;
    this.stato = stato;
  }
}
