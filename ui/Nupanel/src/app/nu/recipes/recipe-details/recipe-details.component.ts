import { Component, OnInit, Input, OnDestroy, OnChanges } from '@angular/core';
import { Recipe, RecipeIngridient, RecipeDirection, RecipeStep } from 'src/app/models/recipes';
import { Subscription } from 'rxjs';
import { RecipeService } from 'src/app/nu/recipes/recipe.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.scss']
})
export class RecipeDetailsComponent implements OnInit, OnDestroy, OnChanges {

  @Input() recipeItem: Recipe;

  recipeDirections: Array<RecipeDirection>;
  recipeIngredients: Array<RecipeIngridient>;
  recipeSteps: Array<RecipeStep>;
  
  subscription: Subscription;

  constructor(private RecipeSvc: RecipeService) { 
    this.subscription = RecipeSvc.recipeSelectedSource$.subscribe( recipe => {
      this.recipeItem = recipe;
      this.recipeDirections = recipe.directions;
      this.recipeIngredients = recipe.ingridients;
      this.recipeSteps = recipe.steps;
    })
  }

  ngOnInit(): void {
  }

  ngOnChanges() {
    this.recipeDirections = this.recipeItem.directions;
    this.recipeIngredients = this.recipeItem.ingridients;
    this.recipeSteps = this.recipeItem.steps;
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
