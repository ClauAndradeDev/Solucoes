using Microsoft.Identity.Client;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;

namespace Solucoes.Api.Service.Cadastro
{
    public class PlataformaService : CrudServices<Plataforma, PlataformaDto>
    {
        //public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }

        public PlataformaService(
                PlataformaRepositorio plataformaRepositorio,
                 //LogMovimentacaoService logMovimentacaoService,
                 EmpresaRepositorio empresaRepositorio,
                Mapper.Mapper mapper) :
            base(plataformaRepositorio, mapper)
        {
            EmpresaRepositorio = empresaRepositorio;
            // LogMovimentacaoService = logMovimentacaoService;
        }

        public async Task<PlataformaDto> InsertPlataformaEmpresa(int codEmpresa, PlataformaDto plataforma)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);

            var plataformaModel = Mapper.Map<Plataforma>(plataforma);
            var result = new PlataformaDto();

            if (empresaModel != null)
            {
                var plataformaJaExiste = empresaModel.Plataforma.Where(p => p.Descricao == plataformaModel.Descricao).Any();
                var plataformaCodigo = empresaModel.Setores.FirstOrDefault(x => x.Descricao == plataformaModel.Descricao);
                if (plataformaJaExiste)
                {
                    result = await base.FindByCodigo(plataformaCodigo.Id);
                }
                else
                {
                    plataformaModel.DataCadastro = DateTime.Now;
                    plataformaModel.EmpresaId = empresaModel.Id;

                    plataformaModel = await Repositorio.Add(plataformaModel);
                    result = await base.FindByCodigo(plataformaModel.Id);
                }


            }

            return result;

        }

        public async Task<PlataformaDto> AlterarPlataformaEmpresa(int codEmpresa, PlataformaDto plataforma)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);
            var plataformaModel = await Repositorio.FindById(plataforma.Codigo);

            if ((empresaModel != null) && (empresaModel.Id == plataformaModel.EmpresaId))
            {
                plataformaModel.Descricao = plataforma.Descricao;
                plataformaModel.Situacao = plataforma.Situacao;

                await Repositorio.Replace(plataformaModel.Id, plataformaModel);
            }
            //colocar uma forma de tratamento, caso não encontre a empresa informada.

            var result = Mapper.Map<PlataformaDto>(plataformaModel);
            return result;
        }

        public async Task<PlataformaEmpresaDto[]> BuscarPlataformaPorEmpresa(int codEmpresa)
        {
            var empresa = await EmpresaRepositorio.FindById(codEmpresa);
            var plataformas = empresa.Plataforma;
            plataformas ??= new Plataforma[] { };

            var result = Mapper.Map<PlataformaEmpresaDto[]>(plataformas);
            return result;
        }

        public async Task ExcluirPlataformaEmpresa(int codPlataforma, int codEmpresa)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);
            var plataformaModel = await Repositorio.FindById(codPlataforma);

            if ((empresaModel != null) && (plataformaModel != null))
            {
                await Repositorio.Remove(plataformaModel.Id);
            }

        }

        //public override async Task<PlataformaDto> Insert(PlataformaDto plataforma)
        //{
        //    plataforma.DataCadastro = DateTime.Now;
        //    var plataformaDto = await base.Insert(plataforma);
        //    var plataformaModel = await base.ReturnModel(plataformaDto.Codigo);

        //    var result = await base.FindByCodigo(plataformaModel.Id);

        //    //var logMovPlataforma = await LogMovimentacaoService.InserirLogMov(plataformaModel, 1, "Plataforma", plataformaModel.Id);

        //    return result;
        //}

        //public override async Task<PlataformaDto> Update(int id, PlataformaDto plataforma)
        //{
        //    plataforma.DataCadastro = DateTime.Now;
        //    var plataformaDto = await base.Update(id, plataforma);
        //    var plataformaModel = await base.ReturnModel(plataformaDto.Codigo);

        //    var result = await base.FindByCodigo(plataformaModel.Id);

        //    //var logMovUsuario = await LogMovimentacaoService.InserirLogMov(plataformaModel, 2, "Usuario", plataformaModel.Id);

        //    return result;
        //}

        //public override async Task Delete(int id)
        //{
        //    var plataformaDto = await base.FindByCodigo(id);
        //    var plataformaModel = await base.ReturnModel(plataformaDto.Codigo);

        //    //var logMovUsuario = await LogMovimentacaoService.InserirLogMov(plataformaModel, 3, "Usuario", plataformaModel.Id);

        //    //if (logMovUsuario != null)
        //    //{
        //    await base.Delete(plataformaDto.Codigo);
        //    //}

        //}
    }
}
