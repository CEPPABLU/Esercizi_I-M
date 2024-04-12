import { Component } from '@angular/core';
import { Oggetto } from '../../models/oggetto';
import { Utente } from '../../models/utente';
import { OggettoService } from '../../services/oggetto.service';
import { UtenteService } from '../../services/utente.service';

@Component({
  selector: 'app-oggetto',
  templateUrl: './oggetto.component.html',
  styleUrl: './oggetto.component.css',
})
export class OggettoComponent {
  oggetti: Oggetto[] = [];
  utenti: Utente[] = [];

  constructor(
    private oggettoService: OggettoService,
    private utenteService: UtenteService
  ) {}

  ngOnInit(): void {
    this.oggetti = this.oggettoService.getOgg();
    this.utenti = this.utenteService.getUtenti();
  }

  creaOggetto(nome: string, descrizione: string, idProprietario: number): void {
    let proprietario = this.utenteService.getUtente(idProprietario);
    if (proprietario) {
      let nuovoOggetto = this.oggettoService.inserisciOgg(
        nome,
        descrizione,
        proprietario
      );
      this.oggetti.push(nuovoOggetto);
    }
  }

  eliminaOggetto(id: number): void {
    this.oggettoService.rimuoviOgg(id);
    this.oggetti = this.oggettoService.getOgg();
  }
}
