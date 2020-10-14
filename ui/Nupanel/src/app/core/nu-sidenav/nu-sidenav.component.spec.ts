import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuSidenavComponent } from './nu-sidenav.component';

describe('NuSidenavComponent', () => {
  let component: NuSidenavComponent;
  let fixture: ComponentFixture<NuSidenavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuSidenavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuSidenavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
