import { Component, OnInit, Input, OnDestroy, OnChanges } from '@angular/core';
import { Recipe, RecipeIngridient, RecipeDirection, RecipeStep } from 'src/app/models/recipes';
import { FoodItem } from 'src/app/models/foods';
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
  recipeFoods: Array<FoodItem>;
  recipeSteps: Array<RecipeStep>;
  
  subscription: Subscription;

  constructor(private RecipeSvc: RecipeService) { 
    this.subscription = RecipeSvc.recipeSelectedSource$.subscribe( recipe => {
      this.recipeItem = recipe;
      this.recipeDirections = recipe.directions;
      this.recipeFoods = recipe.foods;
      this.recipeSteps = recipe.steps;
    })
  }

  ngOnInit(): void {
  }

  ngOnChanges() {
    this.recipeDirections = this.recipeItem.directions;
    this.recipeFoods = this.recipeItem.foods;
    this.recipeSteps = this.recipeItem.steps;
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
