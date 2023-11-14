import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilPessoaComponent } from './perfilpessoa.component';

describe('PerfilpessoaComponent', () => {
  let component: PerfilPessoaComponent;
  let fixture: ComponentFixture<PerfilPessoaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PerfilPessoaComponent]
    });
    fixture = TestBed.createComponent(PerfilPessoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
