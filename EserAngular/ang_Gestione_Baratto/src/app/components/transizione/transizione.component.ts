import { Component } from '@angular/core';
import { Transizione } from '../../models/transazione';
import { TransizioneService } from '../../services/transizione.service';
import { PropostaService } from '../../services/proposta.service';

@Component({
  selector: 'app-transizione',
  templateUrl: './transizione.component.html',
  styleUrl: './transizione.component.css',
})
export class TransizioneComponent {
  transizioni: Transizione[] = [];

  constructor(
    private transizioneService: TransizioneService,
    private propostaService: PropostaService
  ) {}

  ngOnInit(): void {
    this.transizioni = this.transizioneService.getTransizioni();
  }

  creaTransizione(idProposta: number): void {
    const proposta = this.propostaService.getProposta(idProposta);
    if (proposta && proposta.stato === 'Accettata') {
      const nuovaTransizione =
        this.transizioneService.creaTransizione(proposta);
      this.transizioni.push(nuovaTransizione);
    }
  }
}
