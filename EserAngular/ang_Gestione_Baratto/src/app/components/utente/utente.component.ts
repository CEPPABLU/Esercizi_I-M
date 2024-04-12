import { Component } from '@angular/core';
import { Utente } from '../../models/utente';
import { UtenteService } from '../../services/utente.service';

@Component({
  selector: 'app-utente',
  templateUrl: './utente.component.html',
  styleUrl: './utente.component.css',
})
export class UtenteComponent {
  utenti: Utente[] = [];

  constructor(private utenteService: UtenteService) {}

  ngOnInit(): void {
    this.utenti = this.utenteService.getUtenti();
  }

  eliminaUtente(id: number): void {
    this.utenteService.eliminaUtente(id);
    this.utenti = this.utenteService.getUtenti();
  }

  creaUtente(nominativo: string): void {
    let newUt = this.utenteService.creaUtente(nominativo);
    this.utenti.push(newUt);
  }
}
