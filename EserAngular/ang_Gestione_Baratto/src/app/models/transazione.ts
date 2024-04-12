import { Proposta } from './proposta';

export class Transizione extends Proposta {
  static idCounte = 0;
  idT: number;
  dataTransizione: Date;

  constructor(proposta: Proposta) {
    super(
      proposta.oggettoProposto,
      proposta.oggettoRichiesto,
      proposta.utentePropone,
      proposta.utentePropone,
      'Accettata'
    );
    this.idT = Transizione.idCounter++;
    this.dataTransizione = new Date();
  }
}
