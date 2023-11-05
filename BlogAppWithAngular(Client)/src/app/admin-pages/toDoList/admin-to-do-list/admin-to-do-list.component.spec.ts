import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminToDoListComponent } from './admin-to-do-list.component';

describe('AdminToDoListComponent', () => {
  let component: AdminToDoListComponent;
  let fixture: ComponentFixture<AdminToDoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminToDoListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminToDoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
