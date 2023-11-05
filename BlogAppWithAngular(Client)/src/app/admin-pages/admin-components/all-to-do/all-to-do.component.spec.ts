import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllToDoComponent } from './all-to-do.component';

describe('AllToDoComponent', () => {
  let component: AllToDoComponent;
  let fixture: ComponentFixture<AllToDoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllToDoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllToDoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
