import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { Recipe } from 'src/app/models/recipes';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.scss']
})
export class RecipeDetailsComponent implements OnInit, OnChanges {

  @Input() recipeItem: Recipe;

  constructor() { }

  ngOnInit(): void {
    console.log(this.recipeItem);
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log("changes");
    console.log(changes.recipeItem);
  }

}
