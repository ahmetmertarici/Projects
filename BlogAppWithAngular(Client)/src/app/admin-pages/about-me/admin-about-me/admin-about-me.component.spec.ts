import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAboutMeComponent } from './admin-about-me.component';

describe('AdminAboutMeComponent', () => {
  let component: AdminAboutMeComponent;
  let fixture: ComponentFixture<AdminAboutMeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAboutMeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminAboutMeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
