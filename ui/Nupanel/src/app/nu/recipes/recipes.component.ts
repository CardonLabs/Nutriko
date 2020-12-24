import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';


import { MockingService } from 'src/app/mock/mocking.service';
import { Recipe, RecipeBasic } from 'src/app/models/recipes';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss'],
  
})

export class RecipesComponent implements OnInit {

  recipeData: Array<Recipe>;
  mockService$: Observable<RecipeBasic[]>;
  currentRecipe: Recipe;

  constructor(private MockingService: MockingService) { }

  ngOnInit() {
    this.MockingService.getRecipes().subscribe( response => {
      this.recipeData = response;
    });
  }

  recipeSelect(recipe: Recipe) {
    this.currentRecipe = recipe;
  }


}
