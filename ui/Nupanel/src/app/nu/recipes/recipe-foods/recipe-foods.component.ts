import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { MatTable, MatTableDataSource}  from '@angular/material/table';
import { FoodItem } from 'src/app/models/foods';
import { Subscription } from 'rxjs';
import { RecipeService } from 'src/app/nu/recipes/recipe.service';

@Component({
  selector: 'app-recipe-foods',
  templateUrl: './recipe-foods.component.html',
  styleUrls: ['./recipe-foods.component.scss']
})
export class RecipeFoodsComponent implements OnInit, OnChanges {

  @Input() foods: Array<FoodItem>;

  constructor() { 

  }

  ngOnInit(): void {
  }

  ngOnChanges() {
  }

}
