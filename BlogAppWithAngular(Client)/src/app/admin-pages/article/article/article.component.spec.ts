import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminArticleComponent } from './article.component';

describe('ArticleComponent', () => {
  let component: AdminArticleComponent;
  let fixture: ComponentFixture<AdminArticleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminArticleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminArticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
