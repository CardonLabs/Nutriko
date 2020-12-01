import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { PlansComponent } from './nu/plans/plans.component';
import { RecipesComponent } from './nu/recipes/recipes.component'

const routes: Routes = [
  { path: 'Plans', component: PlansComponent },
  { path: 'Recipes', component: RecipesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
