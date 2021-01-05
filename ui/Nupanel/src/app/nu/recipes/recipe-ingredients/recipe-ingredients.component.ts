import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { MatTable, MatTableDataSource}  from '@angular/material/table';
import { RecipeIngridient } from 'src/app/models/recipes';
import { Subscription } from 'rxjs';
import { RecipeService } from 'src/app/nu/recipes/recipe.service';

@Component({
  selector: 'app-recipe-ingredients',
  templateUrl: './recipe-ingredients.component.html',
  styleUrls: ['./recipe-ingredients.component.scss']
})
export class RecipeIngredientsComponent implements OnInit, OnChanges {

  @Input() ingredients: Array<RecipeIngridient>;

  constructor() { 

  }

  ngOnInit(): void {
  }

  ngOnChanges() {
    console.log(this.ingredients);

  }

}
