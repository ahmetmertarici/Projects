import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutMeAddComponent } from './about-me-add.component';

describe('AboutMeAddComponent', () => {
  let component: AboutMeAddComponent;
  let fixture: ComponentFixture<AboutMeAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutMeAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AboutMeAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
