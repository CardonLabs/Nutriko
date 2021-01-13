import { Component, OnInit } from '@angular/core';

import { RecipeService } from 'src/app/nu/recipes/recipe.service';
import { MockingService } from 'src/app/mock/mocking.service';
import { Recipe, RecipeBasic, RecipeIngridient } from 'src/app/models/recipes';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss'],
  providers: [ RecipeService ]
  
})

export class RecipesComponent implements OnInit {

  recipeData: Array<Recipe>;
  mockService$: Observable<RecipeBasic[]>;
  currentRecipe: Recipe;
  currentRecipeIngredients: Array<RecipeIngridient>;

  constructor(private MockingService: MockingService, private RecipeSvc: RecipeService) { }

  ngOnInit() {
    this.MockingService.getRecipes().subscribe( response => {
      this.recipeData = response;
      this.currentRecipe = this.recipeData[0];
      this.currentRecipeIngredients = this.recipeData[0].ingridients;
    });
    
  }

  


}
