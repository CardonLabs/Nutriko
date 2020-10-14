import { TestBed } from '@angular/core/testing';

import { MockingService } from './mocking.service';

describe('MockingService', () => {
  let service: MockingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MockingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
