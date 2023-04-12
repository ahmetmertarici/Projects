import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutMeUpdateComponent } from './about-me-update.component';

describe('AboutMeUpdateComponent', () => {
  let component: AboutMeUpdateComponent;
  let fixture: ComponentFixture<AboutMeUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutMeUpdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AboutMeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
