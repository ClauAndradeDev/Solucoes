import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridviewEnderecoComponent } from './gridview-endereco.component';

describe('GridviewEnderecoComponent', () => {
  let component: GridviewEnderecoComponent;
  let fixture: ComponentFixture<GridviewEnderecoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridviewEnderecoComponent]
    });
    fixture = TestBed.createComponent(GridviewEnderecoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
