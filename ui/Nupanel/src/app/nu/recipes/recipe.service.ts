import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Recipe } from 'src/app/models/recipes';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private recipeSelectedSource = new Subject<Recipe>();
  recipeSelectedSource$ = this.recipeSelectedSource.asObservable();

  constructor() { }

  selectRecipe(recipe: Recipe) {
    this.recipeSelectedSource.next(recipe);
  }
}
