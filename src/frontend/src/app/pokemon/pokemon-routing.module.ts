import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PokemonListComponent } from './list/pokemonListComponent';
import { PokemonCreateEditComponent } from './createEdit/pokemonCreateEditComponent';
import { HomeComponent } from './home/HomeComponent';

const routes: Routes = [
  { path: 'pokemon', component: PokemonListComponent },
  { path: 'pokemon/createEdit/:id', component: PokemonCreateEditComponent },
  { path: 'home', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PokemonRoutingModule { }
