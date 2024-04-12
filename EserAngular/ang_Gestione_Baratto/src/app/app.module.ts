import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UtenteComponent } from './components/utente/utente.component';
import { PropostaComponent } from './components/proposta/proposta.component';
import { OggettoComponent } from './components/oggetto/oggetto.component';
import { TransizioneComponent } from './components/transizione/transizione.component';

@NgModule({
  declarations: [
    AppComponent,
    UtenteComponent,
    PropostaComponent,
    OggettoComponent,
    TransizioneComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
