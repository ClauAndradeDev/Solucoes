using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;

namespace Solucoes.Api.Service.Cadastro
{
    public class SetorEmpresaService : CrudServices<Setor, SetorDto>
    {
        //public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        public SetorEmpresaService(SetorEmpresaRepositorio setorEmpresaRepositorio,
                            //, LogMovimentacaoService logMovimentacaoService
                            EmpresaRepositorio empresaRepositorio
                            , Mapper.Mapper mapper) :
        base(setorEmpresaRepositorio, mapper)
        {
            EmpresaRepositorio = empresaRepositorio;
            //  LogMovimentacaoService = logMovimentacaoService;
        }

        //public async Task<SetorDto> InsertSetor(SetorDto setor)
        //{

        //    var setorModel = Mapper.Map<Setor>(setor);
        //    setorModel.DataCadastro = DateTime.Now;

        //    await Repositorio.Add(setorModel);

        //    //    //await LogMovimentacaoService.InserirLogMov(setorModel, 1, "Setor", setorModel.Id);

        //    var result = await base.FindByCodigo(setor.Codigo);

        //    return result;
        //}

        public async Task<SetorDto> InsertSetorEmpresa(int codEmpresa, SetorDto setor)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);

            var setorModel = Mapper.Map<Setor>(setor);
            var result = new SetorDto();


            if (empresaModel != null)
            {
                var setorJaExiste = empresaModel.Setores.Where(x => x.Descricao == setorModel.Descricao).Any();
                var setorCodigo = empresaModel.Setores.FirstOrDefault(x => x.Descricao == setorModel.Descricao);
                if (setorJaExiste)
                {
                    result = await base.FindByCodigo(setorCodigo.Id);
                    //throw new Exception("Setor já cadastrado para essa empresa");

                }
                else
                {
                    setorModel.DataCadastro = DateTime.Now;
                    setorModel.EmpresaId = empresaModel.Id;

                    setorModel = await Repositorio.Add(setorModel);
                    result = await base.FindByCodigo(setorModel.Id);
                }


                //await LogMovimentacaoService.InserirLogMov(setorModel, 1, "Setor", setorModel.Id);

            }

            return result;
        }

        public async Task<SetorDto> AlterarSetorEmpresa(int codEmpresa, SetorDto setor)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);

            var setorModel = await Repositorio.FindById(setor.Codigo);
            if ((empresaModel != null) && (empresaModel.Id == setorModel.EmpresaId))
            {
                setorModel.Descricao = setor.Descricao;
                setorModel.Situacao = setor.Situacao;

                await Repositorio.Replace(setorModel.Id, setorModel);
            }

            //await LogMovimentacaoService.InserirLogMov(setorModel, 2, "Setor", setorModel.Id);

            var result = Mapper.Map<SetorDto>(setorModel);
            return result;
        }

        //public override async Task Delete(int id)
        //{
        //    await base.Delete(id);
        //}

        public async Task ExcluirSetorEmpresa(int codEmpresa, int codSetor)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);
            var setorModel = await Repositorio.FindById(codSetor);
            //var setorModel = empresaModel.Setores.FirstOrDefault(st=>st.Id == codSetor);
            //futuramente se setor estirver vinculado com Reunião, precisa fazer validação
            if ((empresaModel != null) && (setorModel != null))
            {
                await Repositorio.Remove(codSetor);
            }
        }

        public async Task<SetorEmpresaDto[]> BuscarSetorPorEmpresa(int codEmpresa)
        {
            var empresa = await EmpresaRepositorio.FindById(codEmpresa);
            var setores = empresa.Setores;
            setores ??= new Setor[] { };

            var result = Mapper.Map<SetorEmpresaDto[]>(setores);
            return result;

        }
    }
}
