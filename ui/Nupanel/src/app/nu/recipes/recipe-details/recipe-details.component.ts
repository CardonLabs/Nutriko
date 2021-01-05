import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Recipe, RecipeIngridient } from 'src/app/models/recipes';
import { Subscription } from 'rxjs';
import { RecipeService } from 'src/app/nu/recipes/recipe.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.scss']
})
export class RecipeDetailsComponent implements OnInit, OnDestroy {

  @Input() recipeItem: Recipe;
  @Input() recipeItemIngredients: Array<RecipeIngridient>;
  
  subscription: Subscription;

  constructor(private RecipeSvc: RecipeService) { 
    this.subscription = RecipeSvc.recipeSelectedSource$.subscribe( recipe => {
      this.recipeItem = recipe;
      this.recipeItemIngredients = recipe.ingridients;
    })
  }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
