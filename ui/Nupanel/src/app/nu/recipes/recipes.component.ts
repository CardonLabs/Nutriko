import { Component, OnInit, ViewChild } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource}  from '@angular/material/table';
import { MockingService } from 'src/app/mock/mocking.service';
import { Recipe, RecipeBasic } from 'src/app/models/recipes';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})

export class RecipesComponent implements OnInit {

  displayedColumns: string[] = ['name', 'cusine', 'rating', 'popularity', 'calories', 'carbs'];
  recipesDataSource = new MatTableDataSource<Recipe>();
  recipeData: Array<Recipe>;
  mockService$: Observable<RecipeBasic[]>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private MockingService: MockingService) { }

  ngOnInit() {
    this.MockingService.getRecipes().subscribe( response => {
      console.log('full');
      console.log(response);
      this.recipesDataSource.data = response;
      this.recipesDataSource.paginator = this.paginator;

    });
  }

  applyFilter(event: Event) {
    
    const filterValue = (event.target as HTMLInputElement).value;
    this.recipesDataSource.filter = filterValue.trim().toLowerCase();
    
  }


}
