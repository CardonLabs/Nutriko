import { Component, OnInit, Input } from '@angular/core';
import { RecipeDirection } from 'src/app/models/recipes';

@Component({
  selector: 'app-recipe-directions',
  templateUrl: './recipe-directions.component.html',
  styleUrls: ['./recipe-directions.component.scss']
})
export class RecipeDirectionsComponent implements OnInit {

  @Input() directions: Array<RecipeDirection>;
  
  constructor() { }

  ngOnInit(): void {
  }

}
