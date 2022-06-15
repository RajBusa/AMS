import { TestBed } from '@angular/core/testing';

import { SabhaService } from './sabha.service';

describe('SabhaService', () => {
  let service: SabhaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SabhaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
