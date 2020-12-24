import { Component, OnInit, Input, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { MatTableDataSource}  from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { Recipe } from 'src/app/models/recipes';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit, OnChanges {

  @Input() recipeList: Array<Recipe>;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['name', 'rating', 'popularity', 'calories', 'carbs'];
  recipeTableDataSource = new MatTableDataSource<Recipe>();

  constructor() { }

  ngOnInit() {
    this.recipeTableDataSource.data = this.recipeList;
    this.recipeTableDataSource.paginator = this.paginator;
  }

  ngOnChanges(changes: SimpleChanges) {
    this.recipeTableDataSource.data = this.recipeList;
    this.recipeTableDataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.recipeTableDataSource.filter = filterValue.trim().toLowerCase();
  }

  recipeSelect(recipe: Recipe) {
    console.log(recipe);
  }

}
