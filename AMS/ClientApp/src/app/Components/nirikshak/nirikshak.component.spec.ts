import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NirikshakComponent } from './nirikshak.component';

describe('NirikshakComponent', () => {
  let component: NirikshakComponent;
  let fixture: ComponentFixture<NirikshakComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NirikshakComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NirikshakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
