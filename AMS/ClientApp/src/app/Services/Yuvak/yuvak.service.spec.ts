import { TestBed } from '@angular/core/testing';

import { YuvakService } from './yuvak.service';

describe('YuvakService', () => {
  let service: YuvakService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(YuvakService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
