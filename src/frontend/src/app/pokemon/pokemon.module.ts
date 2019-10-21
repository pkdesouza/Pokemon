import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PokemonRoutingModule } from './pokemon-routing.module';
import { PokemonListComponent } from './list/pokemonListComponent';
import { PokemonCreateEditComponent } from './createEdit/pokemonCreateEditComponent';
import { HomeComponent} from './home/HomeComponent'
@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    PokemonRoutingModule,
    CommonModule
  ],
  declarations: [PokemonListComponent, PokemonCreateEditComponent, HomeComponent],
  providers: []
})
export class PokemonModule { }
