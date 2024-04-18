import { TestBed } from '@angular/core/testing';

import { AdmindllService } from './admindll.service';

describe('AdmindllService', () => {
  let service: AdmindllService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdmindllService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
