import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pokemon } from '../models/pokemon';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class PokemonService {
  protected url = 'https://localhost:5001/api/pokemon';
  constructor(private request: HttpClient) { }

  getAllPokemons(): Observable<Pokemon[]> {
    return this.request.get(this.url).pipe(map((response: any) =>
      response
    ));
  }
  createPokemon(pokemon: Pokemon) {
    return this.request.post(this.url, pokemon);
  }
}
