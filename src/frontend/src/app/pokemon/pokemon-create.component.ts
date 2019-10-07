import { HttpClient } from '@angular/common/http';
import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Pokemon } from './pokemon';

@Component({
  selector: 'app-pokemon-create',
  templateUrl: './pokemon-create.component.html',
  styleUrls: ['./pokemon-create.component.scss']
})
export class PokemonCreateComponent implements OnInit {
  pokemonForm = new FormGroup({
    name: new FormControl(''),
    attack: new FormControl(''),
    defense: new FormControl(''),
    height: new FormControl(''),
    hp: new FormControl(''),
    speed : new FormControl(''),
    types : new FormControl('')
  });  

  protected url = 'https://localhost:5001/api/pokemon';

  constructor(protected httpClient: HttpClient, private router: Router) {}

  ngOnInit() {}

  create() {
    const pokemonModel : Pokemon = this.pokemonForm.value;    
    pokemonModel.types = ['normal'];
    this.httpClient
      .post(`${this.url}`, pokemonModel)
      .subscribe(
        () => this.router.navigate(['/pokemon']),
        error => alert('Error adding pokemon: ' + JSON.stringify(error))
      );
  }
}
