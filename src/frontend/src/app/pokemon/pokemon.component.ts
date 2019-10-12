import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Pokemon } from './pokemon';

@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemon.component.html',
  styleUrls: ['./pokemon.component.scss']
})
export class PokemonComponent implements OnInit {
  protected url = 'https://localhost:44333/api/pokemon';
  public pokemons: Pokemon[] = [];
  constructor(protected httpClient: HttpClient) { }

  ngOnInit() {
    this.httpClient
      .get<Pokemon[]>(this.url)
      .subscribe(pokemons => (this.pokemons = pokemons));
  }
}
