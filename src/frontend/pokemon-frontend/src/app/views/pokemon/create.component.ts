import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Pokemon } from './pokemon';

@Component({
  selector: 'app-pokemon-create',
  templateUrl: './create.html'
})
export class PokemonCreateComponent implements OnInit {
  public name = new FormControl('');
  public price = new FormControl('');
  protected url = 'http://localhost:5000/api/pokemon';
  constructor(protected httpClient: HttpClient, private router: Router) {}

  ngOnInit() {}

  create() {
    const pokemon: Pokemon = {
      name: this.name.value
    };
    this.httpClient
      .post<Pokemon>(`${this.url}`, pokemon)
      .subscribe(
        () => this.router.navigate(['/pokemon']),
        error => alert('Error adding pokemon: ' + JSON.stringify(error))
      );
  }
}
