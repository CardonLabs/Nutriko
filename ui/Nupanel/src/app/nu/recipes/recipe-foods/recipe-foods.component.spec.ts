import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeFoodsComponent } from './recipe-foods.component';

describe('RecipeIngredientsComponent', () => {
  let component: RecipeFoodsComponent;
  let fixture: ComponentFixture<RecipeFoodsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeFoodsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeFoodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
