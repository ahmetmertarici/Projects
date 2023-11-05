import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { HomeComponent } from './pages/home/home.component';
import { AboutMeComponent } from './pages/about-me/about-me.component';
import { ContactComponent } from './pages/contact/contact.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { ArticleComponent } from './pages/article/article.component';
import { CategoryArticlesComponent } from './pages/category-articles/category-articles.component';
import { SearchComponent } from './pages/search/search.component';
import { AdminHomeComponent } from './admin-pages/admin-home/admin-home.component';
import { ArticleListComponent } from './admin-pages/article/article-list/article-list.component';
import { ArticleUpdateComponent } from './admin-pages/article/article-update/article-update.component';
import { ArticleAddComponent } from './admin-pages/article/article-add/article-add.component';
import { AdminArticleComponent } from './admin-pages/article/article/article.component';
import { AdminLoginComponent } from './pages/admin-login/admin-login.component';
import { CategoryComponent } from './admin-pages/category/category/category.component';
import { CategoryListComponent } from './admin-pages/category/category-list/category-list.component';
import { CategoryUpdateComponent } from './admin-pages/category/category-update/category-update.component';
import { CategoryAddComponent } from './admin-pages/category/category-add/category-add.component';
import { AdminAboutMeComponent } from './admin-pages/about-me/admin-about-me/admin-about-me.component';
import { AboutMeListComponent } from './admin-pages/about-me/about-me-list/about-me-list.component';
import { AboutMeUpdateComponent } from './admin-pages/about-me/about-me-update/about-me-update.component';
import { AboutMeAddComponent } from './admin-pages/about-me/about-me-add/about-me-add.component';
import { AccountComponent } from './admin-pages/account/account/account.component';
import { AccountAddComponent } from './admin-pages/account/account-add/account-add.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AdminToDoListComponent } from './admin-pages/toDoList/admin-to-do-list/admin-to-do-list.component';
import { ToDoListListComponent } from './admin-pages/toDoList/to-do-list-list/to-do-list-list.component';
import { ToDoListUpdateComponent } from './admin-pages/toDoList/to-do-list-update/to-do-list-update.component';
import { ToDoListAddComponent } from './admin-pages/toDoList/to-do-list-add/to-do-list-add.component';

const routes: Routes = [
  {path:'', component:MainLayoutComponent, children:[
    {path:'', component:HomeComponent},
    {path:"sayfa/:page", component:HomeComponent},
    { path: 'Articles/:title/:id', component: ArticleComponent },
    { path: 'kategori/:name/:id', component: CategoryArticlesComponent },
    { path: 'kategori/:name/:id/sayfa/:page', component: CategoryArticlesComponent },
    { path: "arama/sayfa/:page", component: SearchComponent },
    {path:'hakkimda', component:AboutMeComponent},
    {path:'iletisim', component:ContactComponent},
    {path:'adminlogin', component:AdminLoginComponent}
  ]},
  {path:'admin', component:AdminLayoutComponent, canActivate: [AuthGuardService], children:[
    {path:'', component:AdminHomeComponent},
    {path:'anasayfa', component:AdminHomeComponent},
    {path:'makale', component:AdminArticleComponent, children:[
      {path:'liste', component:ArticleListComponent},
      {path:'guncelle/:id', component:ArticleUpdateComponent},
      {path:'ekle', component:ArticleAddComponent},
    ]},
    {path:'kategori', component:CategoryComponent, children:[
      {path:'liste', component:CategoryListComponent},
      {path:'guncelle/:id', component:CategoryUpdateComponent},
      {path:'ekle', component:CategoryAddComponent}
    ]},
    {path:'hakkimda', component:AdminAboutMeComponent, children:[
      {path:'liste', component:AboutMeListComponent},
      {path:'guncelle/:id', component:AboutMeUpdateComponent},
      {path:'ekle', component:AboutMeAddComponent}
    ]},
    {path:'yapilacaklar', component:AdminToDoListComponent, children:[
      {path:'liste', component:ToDoListListComponent},
      {path:'guncelle/:id', component:ToDoListUpdateComponent},
      {path:'ekle', component:ToDoListAddComponent}
    ]},
    {path:'hesap', component:AccountComponent, children:[
      {path:'ekle',component:AccountAddComponent}
    ]}
  ]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
