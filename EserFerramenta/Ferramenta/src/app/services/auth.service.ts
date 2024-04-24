import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RisToken } from '../models/ris-token';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(User: string, PassUt: string): Observable<RisToken> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    let invio = {
      User,
      PassUt,
    };

    return this.http.post<any>('https://localhost:7020/Utente/login', invio, {
      headers: headerCustom,
    });
  }
}
