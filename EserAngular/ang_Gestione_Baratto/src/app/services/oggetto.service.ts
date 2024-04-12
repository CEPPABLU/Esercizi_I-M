import { Injectable } from '@angular/core';
import { Oggetto } from '../models/oggetto';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root',
})
export class OggettoService {
  private oggetti: Oggetto[] = new Array();

  constructor() {}

  // Crea un nuovo oggetto e lo aggiunge alla lista
  inserisciOgg(
    nome: string,
    descrizione: string,
    proprietario: Utente
  ): Oggetto {
    let oggetto = new Oggetto(nome, descrizione, proprietario);
    this.oggetti.push(oggetto);
    proprietario.oggetti.push(oggetto);
    return oggetto;
  }

  // Ottiene tutti gli oggetti
  getOgg(): Oggetto[] {
    return this.oggetti;
  }

  getOggetto(id: number): Oggetto | undefined {
    return this.oggetti.find((oggetto) => oggetto.id === id);
  }

  rimuoviOgg(id: number): void {
    let index = this.oggetti.findIndex((oggetto) => oggetto.id === id);
    if (index !== -1) {
      let oggetto = this.oggetti[index];
      oggetto.proprietario.oggetti = oggetto.proprietario.oggetti.filter(
        (o) => o.id !== id
      );
      this.oggetti.splice(index, 1);
    }
  }
}
