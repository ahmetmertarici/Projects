import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuArticleHighScoreComponent } from './menu-article-high-score.component';

describe('MenuArticleHighScoreComponent', () => {
  let component: MenuArticleHighScoreComponent;
  let fixture: ComponentFixture<MenuArticleHighScoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuArticleHighScoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenuArticleHighScoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
