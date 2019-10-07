import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PokemonCreateComponent } from './pokemon-create.component';
import { PokemonComponent } from './pokemon.component';

const routes: Routes = [
  { path: 'pokemon/create', component: PokemonCreateComponent },
  { path: 'pokemon', component: PokemonComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PokemonRoutingModule {}
