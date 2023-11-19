import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridviewComponent } from './gridviewContato.component';

describe('GridviewComponent', () => {
  let component: GridviewComponent;
  let fixture: ComponentFixture<GridviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridviewComponent]
    });
    fixture = TestBed.createComponent(GridviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
