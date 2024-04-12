import { Injectable } from '@angular/core';
import { Proposta } from '../models/proposta';
import { Oggetto } from '../models/oggetto';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root',
})
export class PropostaService {
  private proposte: Proposta[] = [];

  constructor() {}

  // Crea una nuova proposta e la aggiunge alla lista
  creaProposta(
    oggettoProposto: Oggetto,
    oggettoRichiesto: Oggetto,
    utentePropone: Utente,
    utenteRiceve: Utente
  ): Proposta {
    let proposta = new Proposta(
      oggettoProposto,
      oggettoRichiesto,
      utentePropone,
      utenteRiceve
    );
    this.proposte.push(proposta);
    utentePropone.proposteFatte.push(proposta);
    utenteRiceve.proposteRicevute.push(proposta);
    return proposta;
  }

  getProposta(id: number): Proposta | undefined {
    return this.proposte.find((proposta) => proposta.id === id);
  }

  // Ottiene tutte le proposte
  getProposte(): Proposta[] {
    return this.proposte;
  }

  // Accetta una proposta
  accettaProposta(proposta: Proposta): void {
    proposta.stato = 'Accettata';
  }

  // Rifiuta una proposta
  rifiutaProposta(proposta: Proposta): void {
    proposta.stato = 'Rifiutata';
  }
}
