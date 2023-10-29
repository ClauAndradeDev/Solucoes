using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class ContatoService : CrudServices<Contato, ContatoDto>
    {
        public PessoaRepositorio PessoaRepositorio { get; set; }
        //public PessoaService PessoaService { get; set; }

        public ContatoService(ContatoRepositorio contatoRepositorio,
                PessoaRepositorio pessoaRepositorio,
                //PessoaService pessoaService,
                Mapper.Mapper mapper) : 
                base(contatoRepositorio, mapper) 
        {
            PessoaRepositorio = pessoaRepositorio;
            //PessoaService = pessoaService;
        }

        public async Task<ContatoDto> InserirContatoPessoa(int codPessoa, ContatoDto contato)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var contatoModel = Mapper.Map<Contato>(contato);
            var result = new ContatoDto();

            if (pessoaModel  != null)
            {
                var existe = pessoaModel.Contatos
                    .Where(c=>c.TipoContato == contato.TipoContato).Any();
                var contatos = pessoaModel.Contatos
                    .FirstOrDefault(cc => cc.TipoContato == contato.TipoContato);

                if (existe)
                {
                    result = await base.FindByCodigo(contatos.Id);
                }
                else
                {
                    contatoModel.DataCadastro = DateTime.Now;
                    contatoModel.PessoaId = pessoaModel.Id;

                    contatoModel = await Repositorio.Add(contatoModel);
                    result = await base.FindByCodigo(contatoModel.Id);
                }
            }
            return result;
        }

        public async Task<ContatoDto> AlterarContatoPessoa(int codPessoa, ContatoDto contato)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var contatoModel = await Repositorio.FindById(contato.Codigo);

            if((pessoaModel !=  null) && (pessoaModel.Id == contatoModel.PessoaId))
            {
                contatoModel.Nome = contato.Nome;
                contatoModel.Telefone = contato.Telefone;
                contatoModel.Email = contato.Email;
                contatoModel.TipoContato = contato.TipoContato;
                contatoModel.Situacao = (Modelo.Enums.SituacaoCadastralEnum)contato.Situacao;

                await Repositorio.Replace(contatoModel.Id, contatoModel);
            }

            var result = Mapper.Map<ContatoDto>(contatoModel);
            return result;  
        }

        public async Task ExcluirContatoPessoa(int codPessoa, int codContato)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var contatoModel = await Repositorio.FindById(codContato);

            if ((pessoaModel != null) && (contatoModel != null))
            {
                await Repositorio.Remove(contatoModel.Id);
            }
            
        }

        public async Task<ContatoPessoaDto[]> BuscarContatoPorPessoa(int codPessoa)
        {
            var pessoa = await PessoaRepositorio.FindById(codPessoa);
            var contatos = pessoa.Contatos;
            contatos ??= new Contato[]{ };

            var result = Mapper.Map<ContatoPessoaDto[]>(contatos);
            return result;
        }
    }
}
