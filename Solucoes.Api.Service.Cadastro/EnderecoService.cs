using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class EnderecoService : CrudServices<Endereco, EnderecoDto>
    {
        public PessoaRepositorio PessoaRepositorio { get; set; }
        //public PessoaService PessoaService { get; set; }

        public EnderecoService(EnderecoRepositorio enderecoRepositorio, 
                    PessoaRepositorio pessoaRepositorio, 
                    //PessoaService pessoaService,
                    Mapper.Mapper mapper) : 
            base(enderecoRepositorio, mapper)
        {
            PessoaRepositorio = pessoaRepositorio;
            //PessoaService = pessoaService;
        }

        public async Task<EnderecoDto> InserirEnderecoPessoa(int codPessoa, EnderecoDto endereco)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var enderecoModel = Mapper.Map<Endereco>(endereco);
            var result = new EnderecoDto();

            if (pessoaModel != null)
            {
                var existe = pessoaModel.Enderecos
                    .Where(e => e.TipoEndereco == endereco.TipoEndereco).Any();
                var enderecos = pessoaModel.Enderecos
                    .FirstOrDefault(s=>s.TipoEndereco ==endereco.TipoEndereco);

                if (existe)
                {
                    result = await base.FindByCodigo(enderecos.Id);
                }
                else
                {
                    enderecoModel.DataCadastro = DateTime.Now;
                    enderecoModel.PessoaId = pessoaModel.Id;

                    enderecoModel = await Repositorio.Add(enderecoModel);
                    result = await base.FindByCodigo(enderecoModel.Id);
                }
            }
            
            return result;
        }

        public async Task<EnderecoDto> AlterarEnderecoPessoa(int codPessoa, EnderecoDto endereco)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var enderecoModel = await Repositorio.FindById(endereco.Codigo);

            if((pessoaModel != null) && (pessoaModel.Id == enderecoModel.PessoaId)) 
            {
                enderecoModel.Logradouro = endereco.Logradouro;
                enderecoModel.Numero = endereco.Numero;
                enderecoModel.Bairro = endereco.Bairro;
                enderecoModel.CEP = endereco.CEP;
                enderecoModel.Cidade = endereco.Cidade;
                enderecoModel.Estado = endereco.Estado;
                enderecoModel.TipoEndereco = endereco.TipoEndereco;
                enderecoModel.PessoaId = pessoaModel.Id;

                await Repositorio.Replace(enderecoModel.Id, enderecoModel);
            }
            //fazer tratamento caso não localize a pessoa informada

            var result = Mapper.Map<EnderecoDto>(enderecoModel);
            return result;
        }

        public async Task ExcluirEnderecoPessoa(int codPessoa, int codEndereco)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var enderecoModel = await Repositorio.FindById(codEndereco);

            if ((pessoaModel != null) && (enderecoModel != null))
            {
                await Repositorio.Remove(enderecoModel.Id);
            }
        }

        public async Task<EnderecoPessoaDto[]> BuscarEnderecoPorPessoa(int codPessoa)
        {
            var pessoa = await PessoaRepositorio.FindById(codPessoa);
            var enderecos = pessoa.Enderecos;
            enderecos ??= new Endereco[] { };

            var result = Mapper.Map<EnderecoPessoaDto[]>(enderecos);
            return result;
        }
    }
}
