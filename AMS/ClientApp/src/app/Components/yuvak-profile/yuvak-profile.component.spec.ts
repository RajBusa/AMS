import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YuvakProfileComponent } from './yuvak-profile.component';

describe('YuvakProfileComponent', () => {
  let component: YuvakProfileComponent;
  let fixture: ComponentFixture<YuvakProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YuvakProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YuvakProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
