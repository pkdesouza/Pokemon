import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pokemon } from '../models/pokemon';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class PokemonService {
  protected url = 'https://localhost:44333/api/pokemon';
  constructor(private request: HttpClient) { }

  // getAllPokemons() {
  //   return this.request.get<any[]>(this.url);
  // }

  getAllPokemons(): Observable<Pokemon[]> {
    return this.request.get(this.url).pipe(map((response: any) =>
      response
    ));
  }
}
