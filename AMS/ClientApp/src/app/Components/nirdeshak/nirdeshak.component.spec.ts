import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NirdeshakComponent } from './nirdeshak.component';

describe('NirdeshakComponent', () => {
  let component: NirdeshakComponent;
  let fixture: ComponentFixture<NirdeshakComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NirdeshakComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NirdeshakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
