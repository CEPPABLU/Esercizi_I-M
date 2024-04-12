import { Component } from '@angular/core';
import { PropostaService } from '../../services/proposta.service';
import { UtenteService } from '../../services/utente.service';
import { OggettoService } from '../../services/oggetto.service';
import { Proposta } from '../../models/proposta';

@Component({
  selector: 'app-proposta',
  templateUrl: './proposta.component.html',
  styleUrl: './proposta.component.css',
})
export class PropostaComponent {
  proposte: Proposta[] = [];

  constructor(
    private propostaService: PropostaService,
    private utenteService: UtenteService,
    private oggettoService: OggettoService
  ) {}

  ngOnInit(): void {
    this.proposte = this.propostaService.getProposte();
  }

  creaProposta(
    idOggettoProposto: number,
    idOggettoRichiesto: number,
    idUtentePropone: number,
    idUtenteRiceve: number
  ): void {
    let oggettoProposto = this.oggettoService.getOggetto(idOggettoProposto);
    let oggettoRichiesto = this.oggettoService.getOggetto(idOggettoRichiesto);
    let utentePropone = this.utenteService.getUtente(idUtentePropone);
    let utenteRiceve = this.utenteService.getUtente(idUtenteRiceve);

    if (oggettoProposto && oggettoRichiesto && utentePropone && utenteRiceve) {
      const nuovaProposta = this.propostaService.creaProposta(
        oggettoProposto,
        oggettoRichiesto,
        utentePropone,
        utenteRiceve
      );
      this.proposte.push(nuovaProposta);
    }
  }

  accettaProposta(id: number): void {
    const proposta = this.propostaService.getProposta(id);
    if (proposta) {
      this.propostaService.accettaProposta(proposta);
    }
  }

  rifiutaProposta(id: number): void {
    const proposta = this.propostaService.getProposta(id);
    if (proposta) {
      this.propostaService.rifiutaProposta(proposta);
    }
  }
}
