import { Component, OnInit } from '@angular/core';
import { PokemonService } from 'src/services/pokemonService';
import * as $ from 'jquery';
import 'bootstrap-table/dist/bootstrap-table.min.js';

@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemonListComponent.html',
  styleUrls: ['./pokemonListComponent.scss']
})

export class PokemonListComponent implements OnInit {
  constructor(protected service: PokemonService) {}

  ngOnInit() {
    let table: any = $('#table');
    let button: any = $('#remove');
    let scope = this;

    button.click(function () {
      let ids = $.map(table.bootstrapTable('getSelections'), row => row.id);
      scope.deletePokemons(ids);
      table.bootstrapTable('remove', {
        field: 'id',
        values: ids
      });
    })
  }

  deletePokemons(ids: string[]) {
    this.service.deletePokemon(ids).subscribe(
      () => console.log('delete pokemons successfully'),
      error => alert('Error deleting pokemons: ' + JSON.stringify(error))
    );
  }
}
