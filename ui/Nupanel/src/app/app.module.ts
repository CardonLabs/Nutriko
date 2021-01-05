import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';

import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NuToolbarComponent } from './core/nu-toolbar/nu-toolbar.component';
import { NuSidenavComponent } from './core/nu-sidenav/nu-sidenav.component';
import { PlansComponent } from './nu/plans/plans.component';
import { RecipesComponent } from './nu/recipes/recipes.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MockerComponent } from './mock/mocker/mocker.component';
import { HttpClientModule } from '@angular/common/http';
import { RecipeDetailsComponent } from './nu/recipes/recipe-details/recipe-details.component';
import { RecipeListComponent } from './nu/recipes/recipe-list/recipe-list.component';
import { RecipeIngredientsComponent } from './nu/recipes/recipe-ingredients/recipe-ingredients.component';


@NgModule({
  declarations: [
    AppComponent,
    NuToolbarComponent,
    NuSidenavComponent,
    PlansComponent,
    RecipesComponent,
    MockerComponent,
    RecipeDetailsComponent,
    RecipeListComponent,
    RecipeIngredientsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    LayoutModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule,
    MatTabsModule,
    MatExpansionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
