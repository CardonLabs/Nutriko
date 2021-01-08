import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { RecipeStep } from 'src/app/models/recipes';

@Component({
  selector: 'app-recipe-steps',
  templateUrl: './recipe-steps.component.html',
  styleUrls: ['./recipe-steps.component.scss']
})
export class RecipeStepsComponent implements OnInit, OnChanges {

  @Input() steps: Array<RecipeStep>;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges() {
  }

}
