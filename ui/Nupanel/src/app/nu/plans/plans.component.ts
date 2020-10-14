import { Component, OnInit } from '@angular/core';
import { NUPLANS } from 'src/app/mock/datamock';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.scss']
})
export class PlansComponent implements OnInit {

  plans = NUPLANS;
  displayedColumns: string[] = ['name', 'description', 'duration', 'price'];

  constructor() { }

  ngOnInit(): void {
  }

}
