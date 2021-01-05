import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Recipe, RecipeIngridient } from 'src/app/models/recipes';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private recipeSelectedSource = new Subject<Recipe>();
  recipeSelectedSource$ = this.recipeSelectedSource.asObservable();

  private ingredientsSelectedSource = new Subject<Array<RecipeIngridient>>();
  ingredientsSelectedSource$ = this.ingredientsSelectedSource.asObservable();

  constructor() { }

  selectRecipe(recipe: Recipe) {
    this.recipeSelectedSource.next(recipe);
  }

  selectRecipeIngredients(ingredients: Array<RecipeIngridient>) {
    this.ingredientsSelectedSource.next(ingredients);
  }
}
