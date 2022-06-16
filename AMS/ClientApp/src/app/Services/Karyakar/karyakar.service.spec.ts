import { TestBed } from '@angular/core/testing';

import { KaryakarService } from './karyakar.service';

describe('KaryakarService', () => {
  let service: KaryakarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KaryakarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
