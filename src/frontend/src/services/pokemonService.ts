import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pokemon } from '../models/pokemon';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PokemonService {
  protected url = `${environment.urlApiPokemon}api/pokemon`;
  constructor(private http: HttpClient) { }

  public httpOptions: any = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getAllPokemons(): Observable<Pokemon[]> {
    return this.http.get(this.url).pipe(map((response: any) =>
      response
    ));
  }
  getByIdPokemon(id: string) {
    return this.http.get(`${this.url}/${id}`).pipe(map((response: any) =>
      response
    ));
  }
  createPokemon(pokemon: Pokemon) {
    return this.http.post(this.url, pokemon);
  }
  editPokemon(pokemon: Pokemon) {
    return this.http.put(`${this.url}/${pokemon.id}`, JSON.stringify(pokemon));
  }
  deletePokemon(ids: string[]) {
    return this.http.request('delete', `${this.url}/deleteMany`, { body: ids });
  }
}
