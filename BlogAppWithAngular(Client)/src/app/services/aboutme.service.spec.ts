import { TestBed } from '@angular/core/testing';

import { AboutmeService } from './aboutme.service';

describe('AboutmeService', () => {
  let service: AboutmeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AboutmeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
