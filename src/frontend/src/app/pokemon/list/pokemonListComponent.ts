import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/models/pokemon';
import { PokemonService } from 'src/services/pokemonService';

@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemonListComponent.html',
  styleUrls: ['./pokemonListComponent.scss']
})
export class PokemonListComponent implements OnInit {
  // public pokemons: Pokemon[] = [];
  constructor(protected service: PokemonService) { }

  ngOnInit() {
    // this.service.getAllPokemons().subscribe(result => {
    //   console.log(result);
    //   this.pokemons = result as Pokemon[];
    // });

  }
}
