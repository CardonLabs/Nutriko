import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

import { NUCOLLECTIONS } from 'src/app/mock/datamock';

@Component({
  selector: 'app-nu-sidenav',
  templateUrl: './nu-sidenav.component.html',
  styleUrls: ['./nu-sidenav.component.scss']
})
export class NuSidenavComponent implements OnInit {

  collections = NUCOLLECTIONS;


  constructor() {}

  ngOnInit(): void {
  }

}
