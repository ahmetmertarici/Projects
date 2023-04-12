import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutMeListComponent } from './about-me-list.component';

describe('AboutMeListComponent', () => {
  let component: AboutMeListComponent;
  let fixture: ComponentFixture<AboutMeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutMeListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AboutMeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
