import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NuToolbarComponent } from './nu-toolbar.component';

describe('NuToolbarComponent', () => {
  let component: NuToolbarComponent;
  let fixture: ComponentFixture<NuToolbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuToolbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuToolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
