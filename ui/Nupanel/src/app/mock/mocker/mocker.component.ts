import { Component, OnInit } from '@angular/core';
import { MockingService } from 'src/app/mock/mocking.service';
import { Recipe, RecipeBasic } from 'src/app/models/recipes';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-mocker',
  templateUrl: './mocker.component.html',
  styleUrls: ['./mocker.component.scss']
})
export class MockerComponent implements OnInit {

  recipeData: Array<Recipe>;
  recipeBasicData: Array<RecipeBasic>;

  mockService$: Observable<RecipeBasic[]>;

  constructor(private MockingService: MockingService) { }

  ngOnInit(): void {
    this.getRecipesItem(105555);
  }

  getAllRecipes() {
    this.MockingService.getRecipes().subscribe( response => {
      console.log('full');
      console.log(response);
    });
  }

  getRecipesBasic() {
    this.MockingService.getRecipesBasic().subscribe( response => {
      console.log('basic');
      console.log(response);
    });
  }

  getRecipesItem(id: number | string) {
    this.MockingService.getRecipeById(id).subscribe( response => {
      console.log('single item');
      console.log(response);
    });
  }

}
