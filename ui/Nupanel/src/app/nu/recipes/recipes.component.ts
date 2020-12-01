import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource}  from '@angular/material/table';
import { RECIPES } from 'src/app/mock/datamock';
import { IMRecipe } from 'src/app/models/recipes';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent implements AfterViewInit {

  displayedColumns: string[] = ['name', 'cusine', 'rating', 'popularity', 'calories', 'carbs'];
  dataSource = new MatTableDataSource<IMRecipe>(RECIPES);
  //dataSource = RECIPES;

  @ViewChild(MatPaginator) set matPaginator(paginator: MatPaginator) {
      this.dataSource.paginator = paginator;
  }

  constructor() { }

  ngAfterViewInit() {


    console.log(this.dataSource);
    //console.log(this.paginator);
  }

  applyFilter(event: Event) {
    
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    
  }

}
