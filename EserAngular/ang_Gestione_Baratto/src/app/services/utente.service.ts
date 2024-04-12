import { Injectable } from '@angular/core';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root',
})
export class UtenteService {
  // private utenti: Utente[] = new Array();
  elenco: Utente[] = new Array();

  constructor() {
    let stringElenco = localStorage.getItem('elenco_persone');
    if (!stringElenco) {
      localStorage.setItem('elenco_persone', JSON.stringify([]));
    } else {
      this.elenco = JSON.parse(stringElenco);
    }
  }

  // Crea un nuovo utente e lo aggiunge alla lista
  creaUtente(nominativo: string): Utente {
    let utente = new Utente(nominativo);
    this.elenco.push(utente);
    return utente;
  }

  Insert(obj: Utente): boolean {
    this.elenco.push(obj);
    localStorage.setItem('elenco_persone', JSON.stringify([]));
    return true;
  }

  // Ottiene un utente dalla lista in base all'ID
  getUtente(id: number): Utente | undefined {
    return this.elenco.find((utente: { id: number }) => utente.id === id);
  }

  // Ottiene tutti gli utenti
  getUtenti(): Utente[] {
    return this.elenco;
  }

  // Rimuove un utente dalla lista in base all'ID
  eliminaUtente(id: number): void {
    const index = this.elenco.findIndex(
      (utente: { id: number }) => utente.id === id
    );
    if (index !== -1) {
      this.elenco.splice(index, 1);
    }
  }
}
