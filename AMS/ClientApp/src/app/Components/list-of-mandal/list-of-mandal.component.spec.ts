import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfMandalComponent } from './list-of-mandal.component';

describe('ListOfMandalComponent', () => {
  let component: ListOfMandalComponent;
  let fixture: ComponentFixture<ListOfMandalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListOfMandalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOfMandalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
