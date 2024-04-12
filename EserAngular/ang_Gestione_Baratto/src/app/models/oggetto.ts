import { Proposta } from './proposta';
import { Utente } from './utente';

export class Oggetto {
  static idCounter = 0;
  id: number;
  nome: string | undefined;
  descrizione?: string;
  proprietario: Utente | undefined;

  constructor(nome: string, descrizione: string, proprietario: Utente) {
    this.id = Oggetto.idCounter++;
    this.nome = nome;
    this.descrizione = descrizione;
    this.proprietario = proprietario;
  }
}
