import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfMandalPeopleComponent } from './list-of-mandal-people.component';

describe('ListOfMandalPeopleComponent', () => {
  let component: ListOfMandalPeopleComponent;
  let fixture: ComponentFixture<ListOfMandalPeopleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListOfMandalPeopleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOfMandalPeopleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
