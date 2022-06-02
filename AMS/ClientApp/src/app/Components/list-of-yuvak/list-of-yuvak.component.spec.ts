import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfYuvakComponent } from './list-of-yuvak.component';

describe('ListOfYuvakComponent', () => {
  let component: ListOfYuvakComponent;
  let fixture: ComponentFixture<ListOfYuvakComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListOfYuvakComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOfYuvakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
