import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryArticlesComponent } from './category-articles.component';

describe('CategoryArticlesComponent', () => {
  let component: CategoryArticlesComponent;
  let fixture: ComponentFixture<CategoryArticlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryArticlesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryArticlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
