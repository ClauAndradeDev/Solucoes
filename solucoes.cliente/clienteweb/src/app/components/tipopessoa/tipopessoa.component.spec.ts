import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipopessoaComponent } from './tipopessoa.component';

describe('TipopessoaComponent', () => {
  let component: TipopessoaComponent;
  let fixture: ComponentFixture<TipopessoaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TipopessoaComponent]
    });
    fixture = TestBed.createComponent(TipopessoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
