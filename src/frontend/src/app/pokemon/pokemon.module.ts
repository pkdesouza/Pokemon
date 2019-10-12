import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PokemonCreateComponent } from './create/pokemon-create.component';
import { PokemonRoutingModule } from './pokemon-routing.module';
import { PokemonComponent } from './list/pokemon.component';

@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    PokemonRoutingModule,
    CommonModule
  ],
  declarations: [PokemonComponent, PokemonCreateComponent],
  providers: []
})
export class PokemonModule { }
