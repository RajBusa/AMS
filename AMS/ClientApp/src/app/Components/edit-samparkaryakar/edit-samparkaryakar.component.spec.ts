import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSamparkaryakarComponent } from './edit-samparkaryakar.component';

describe('EditSamparkaryakarComponent', () => {
  let component: EditSamparkaryakarComponent;
  let fixture: ComponentFixture<EditSamparkaryakarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditSamparkaryakarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSamparkaryakarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
