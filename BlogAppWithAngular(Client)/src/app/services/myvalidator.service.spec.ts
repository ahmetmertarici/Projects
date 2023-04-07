import { TestBed } from '@angular/core/testing';

import { MyvalidatorService } from './myvalidator.service';

describe('MyvalidatorService', () => {
  let service: MyvalidatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyvalidatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
