import { Component, Input, OnChanges } from '@angular/core';
import { FoodItem, FoodNutrient } from 'src/app/models/foods';

@Component({
  selector: 'app-recipe-foods',
  templateUrl: './recipe-foods.component.html',
  styleUrls: ['./recipe-foods.component.scss']
})
export class RecipeFoodsComponent implements OnChanges {

  @Input() foods: Array<FoodItem>;

  nutritionAggregate: SumarizedNutrients;

  constructor() {
    
  }

  ngOnChanges() {
    this.aggregateNutrients(this.foods)
  }

  aggregateNutrients(foods: Array<FoodItem>) {

    // clears any previous
    this.nutritionAggregate = { calories: 0, carbs: 0, sugar: 0, fat: 0 }

    console.log(this.nutritionAggregate);

    for (let food of foods) { 
      for (let nutrient of food.foodNutrients) {

        if (nutrient.number == 208) // 208 = calories
          this.nutritionAggregate.calories += nutrient.amount;
          
        if (nutrient.number == 205) // carbs
          this.nutritionAggregate.carbs += nutrient.amount;

        if (nutrient.number == 269) //sugar
          this.nutritionAggregate.sugar += nutrient.amount;

        if (nutrient.number == 204) //fat
          this.nutritionAggregate.fat += nutrient.amount;
        
      }
    }
    console.log(this.nutritionAggregate);

  }

}

export interface SumarizedNutrients {
  calories: number | null,
  carbs: number | null,
  sugar: number | null,
  fat: number | null
}
