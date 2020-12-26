import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, OnDestroy } from '@angular/core';
import { Recipe } from 'src/app/models/recipes';
import { Subscription } from 'rxjs';
import { RecipeService } from 'src/app/nu/recipes/recipe.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.scss']
})
export class RecipeDetailsComponent implements OnInit, OnChanges {

  @Input() recipeItem: Recipe;
  subscription: Subscription;

  constructor(private RecipeSvc: RecipeService) { 
    this.subscription = RecipeSvc.recipeSelectedSource$.subscribe( recipe => {
      this.recipeItem = recipe;
      console.log(this.recipeItem);
    })
  }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
