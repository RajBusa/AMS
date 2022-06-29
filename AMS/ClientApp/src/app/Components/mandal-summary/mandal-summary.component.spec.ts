import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MandalSummaryComponent } from './mandal-summary.component';

describe('MandalSummaryComponent', () => {
  let component: MandalSummaryComponent;
  let fixture: ComponentFixture<MandalSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MandalSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MandalSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
