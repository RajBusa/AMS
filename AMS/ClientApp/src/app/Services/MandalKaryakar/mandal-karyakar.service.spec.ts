import { TestBed } from '@angular/core/testing';

import { MandalKaryakarService } from './mandal-karyakar.service';

describe('MandalKaryakarService', () => {
  let service: MandalKaryakarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MandalKaryakarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
