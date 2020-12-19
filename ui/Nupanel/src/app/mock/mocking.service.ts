import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Recipe, RecipeBasic } from 'src/app/models/recipes';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MockingService {

  recipesFull: Observable<Array<Recipe>>;
  recipesBasic: Observable<Array<RecipeBasic>>;
  recipeItem: Observable<Recipe>;

  httpHeaders = new HttpHeaders({
    'Accept':  'application/json'
  });

  constructor(private http: HttpClient) { }

  getRecipes() {
    this.recipesFull = this.http.get<Array<Recipe>>('/assets/sampleData/sample-recipes.json');

    return this.recipesFull;
  }

  getRecipesBasic() {
    this.recipesBasic = this.http.get<Array<RecipeBasic>>('/assets/sampleData/sample-recipeBasic.json');

    return this.recipesBasic;
  }

  getRecipeById(itemId: number | string) {
    this.recipeItem = this.getRecipes().pipe(
      map(txs => txs.find(txn => txn.id === itemId))
    )

    return this.recipeItem;
  }
}
