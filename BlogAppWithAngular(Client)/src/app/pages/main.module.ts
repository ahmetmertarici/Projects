import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { ComponentsModule } from '../components/components.module';
import { MaterialModule } from '../modules/material/material.module';

import { HomeComponent } from './home/home.component';
import { AboutMeComponent } from './about-me/about-me.component';
import { ContactComponent } from './contact/contact.component';
import { MainLayoutComponent } from '../layout/main-layout/main-layout.component';
import { MainNavComponent } from '../nav/main-nav/main-nav.component';
import { ArticleComponent } from './article/article.component';
import { CategoryArticlesComponent } from './category-articles/category-articles.component';
import { SearchComponent } from './search/search.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { RatingComponent } from './rating/rating.component';



@NgModule({
  declarations: [
    HomeComponent,
    AboutMeComponent,
    ContactComponent,
    MainLayoutComponent,
    MainNavComponent,
    ArticleComponent,
    CategoryArticlesComponent,
    SearchComponent,
    AdminLoginComponent,
    RatingComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ComponentsModule,
    MaterialModule
  ]
})
export class MainModule { }
