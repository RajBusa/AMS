import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SamparkKaryakarComponent } from './sampark-karyakar.component';

describe('SamparkKaryakarComponent', () => {
  let component: SamparkKaryakarComponent;
  let fixture: ComponentFixture<SamparkKaryakarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SamparkKaryakarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SamparkKaryakarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
