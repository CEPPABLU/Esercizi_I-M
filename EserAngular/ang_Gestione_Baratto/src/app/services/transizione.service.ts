import { Injectable } from '@angular/core';
import { Transizione } from '../models/transazione';
import { Proposta } from '../models/proposta';

@Injectable({
  providedIn: 'root',
})
export class TransizioneService {
  private transizioni: Transizione[] = new Array();

  constructor() {}

  // Crea una nuova transizione da una proposta accettata e la aggiunge alla lista
  creaTransizione(proposta: Proposta): Transizione {
    if (proposta.stato !== 'Accettata') {
      throw new Error(
        'Solo le proposte accettate possono diventare transizioni'
      );
    }
    let transizione = new Transizione(proposta);
    this.transizioni.push(transizione);
    return transizione;
  }

  // Ottiene tutte le transizioni
  getTransizioni(): Transizione[] {
    return this.transizioni;
  }
}
