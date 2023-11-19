import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformacaoPessoaComponent } from './informacao-pessoa.component';

describe('InformacaoPessoaComponent', () => {
  let component: InformacaoPessoaComponent;
  let fixture: ComponentFixture<InformacaoPessoaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InformacaoPessoaComponent]
    });
    fixture = TestBed.createComponent(InformacaoPessoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
