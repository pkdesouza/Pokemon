import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Pokemon } from 'src/models/pokemon';
import { PokemonService } from 'src/services/pokemonService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pokemon-edit',
  templateUrl: './pokemonCreateEditComponent.html',
  styleUrls: ['./pokemonCreateEditComponent.scss']
})

export class PokemonCreateEditComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: PokemonService, private router: Router) { }

  pokemonForm = new FormGroup({
    name: new FormControl(''),
    attack: new FormControl(''),
    defense: new FormControl(''),
    height: new FormControl(''),
    hp: new FormControl(''),
    speed: new FormControl(''),
    types: new FormControl('')
  });
  public pokemon: Pokemon;

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id)
      this.service.getByIdPokemon(id).subscribe(result => {
          this.pokemon = result as Pokemon;
          this.pokemonForm.patchValue(this.pokemon);
      });
  }

  saveOrUpdate() {
    const pokemonModel: Pokemon = this.pokemonForm.value;
    if (!this.pokemonForm.get('types').value)
      pokemonModel.types = ['normal'];
    else
      pokemonModel.types = this.pokemonForm.get('types').value.split(',');

    if (this.pokemon.id)
      this.service.editPokemon(pokemonModel).subscribe(
        () => this.router.navigateByUrl('/pokemon'),
        error => alert('Error editing pokemon: ' + JSON.stringify(error))
      );
    else
      this.service.createPokemon(pokemonModel).subscribe(
        () => this.router.navigateByUrl('/pokemon'),
        error => alert('Error adding pokemon: ' + JSON.stringify(error))
      );
  }
}
