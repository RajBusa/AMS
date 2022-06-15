import { TestBed } from '@angular/core/testing';

import { SabhaAttendanceService } from './sabha-attendance.service';

describe('SabhaAttendanceService', () => {
  let service: SabhaAttendanceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SabhaAttendanceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
