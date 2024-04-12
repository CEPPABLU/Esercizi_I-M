import { Oggetto } from './oggetto';
import { Proposta } from './proposta';

export class Utente {
  static idCounter = 0;
  id: number;
  nominativo: string | undefined;
  oggetti: Oggetto[] = new Array();
  proposteRicevute: Proposta[] = new Array();
  proposteFatte: Proposta[] = new Array();

  constructor(nominativo: string) {
    this.id = Utente.idCounter++;
    this.nominativo = nominativo;
  }
}
