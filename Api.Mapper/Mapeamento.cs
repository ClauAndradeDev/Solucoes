using AutoMapper;
using AutoMapper.Execution;
using Modelo.DTOs;
using Modelo.Entidades;
using Modelo.Extensoes;

namespace Api.Mapper
{
    public class Mapeamento
    {
        protected IMapper MapperConfig { get; set; }

        public Mapeamento()
        {
            ConfigureMapper(cfg =>
            {
                ConfigureModelToDto(cfg);
                ConfigureDtoToModel(cfg);
            });

        }

        protected void ConfigureMapper(Action<IMapperConfigurationExpression> configurationAction)
        {
            var config = new MapperConfiguration(configurationAction);
            MapperConfig = config.CreateMapper();
        }

        private void ConfigureModelToDto(IMapperConfigurationExpression cfg)
        {
            #region Agendamento -> AgendamentoDto
            cfg.CreateMap<Agendamento, AgendamentoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.CodChamado, opt => opt.MapFrom(model => model.IdChamado))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.DataPrevisaoInicializacao, opt => opt.MapFrom(model => model.DataPrevisaoInicializacao))
                .ForMember(dto => dto.DataPrevisaoFinalizacao, opt => opt.MapFrom(model => model.DataPrevisaoFinalizacao))
                .ForMember(dto => dto.DataAgendamento, opt => opt.MapFrom(model => model.DataAgendamento))
                .ForMember(dto => dto.HoraInicial, opt => opt.MapFrom(model => model.HoraInicial))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                .ForMember(dto => dto.Realizado, opt => opt.MapFrom(model => model.Realizado))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region AgendamentoItem -> AgendamentoItemDto
            cfg.CreateMap<AgendamentoItem, AgendamentoItemDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataAgendamento, opt => opt.MapFrom(model => model.DataAgendamento))
                .ForMember(dto => dto.HoraInicio, opt => opt.MapFrom(model => model.HoraInicio))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                .ForMember(dto => dto.DataRetorno, opt => opt.MapFrom(model => model.DataRetorno))
                .ForMember(dto => dto.CodSetorEmpresa, opt => opt.MapFrom(model => model.IdSetorEmpresa))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region Chamado -> ChamadoDto
            cfg.CreateMap<Chamado, ChamadoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataAbertura, opt => opt.MapFrom(model => model.DataAbertura))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.CodUsuario, opt => opt.MapFrom(model => model.IdUsuario))
                .ForMember(dto => dto.CodEmpresa, opt => opt.MapFrom(model => model.IdEmpresa))
                .ForMember(dto => dto.HoraInicio, opt => opt.MapFrom(model => model.HoraInicio))
                .ForMember(dto => dto.HoraFim, opt => opt.MapFrom(model => model.HoraFim))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ChamadoItem -> ChamadoItemDto
            cfg.CreateMap<ChamadoItem, ChamadoItemDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.CodChamado, opt => opt.MapFrom(model => model.IdChamado))
                .ForMember(dto => dto.CodUsuario, opt => opt.MapFrom(model => model.IdUsuario))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.HoraInicial, opt => opt.MapFrom(model => model.HoraInicial))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region Empresa -> EmpresaDto
            cfg.CreateMap<Empresa, EmpresaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.NomeRazaoSocial, opt => opt.MapFrom(model => model.NomeRazaoSocial))
                .ForMember(dto => dto.SobreNomeFantasia, opt => opt.MapFrom(model => model.SobreNomeFantasia))
                .ForMember(dto => dto.CPFCNPJ, opt => opt.MapFrom(model => model.CPFCNPJ))
                .ForMember(dto => dto.RGIE, opt => opt.MapFrom(model => model.RGIE))
                .ForMember(dto => dto.DataNascimento, opt => opt.MapFrom(model => model.DataNascimento))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.WhatsApp, opt => opt.MapFrom(model => model.WhatsApp))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Endereco -> EnderecoDto
            cfg.CreateMap<Endereco, EnderecoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Logradouro, opt => opt.MapFrom(model => model.Logradouro))
                .ForMember(dto => dto.Numero, opt => opt.MapFrom(model => model.Numero))
                .ForMember(dto => dto.Bairro, opt => opt.MapFrom(model => model.Bairro))
                .ForMember(dto => dto.Cidade, opt => opt.MapFrom(model => model.Cidade))
                .ForMember(dto => dto.Estado, opt => opt.MapFrom(model => model.Estado))
                .ForMember(dto => dto.CEP, opt => opt.MapFrom(model => model.CEP))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Pessoa -> PessoaDto
            cfg.CreateMap<Pessoa, PessoaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.NomeRazaoSocial, opt => opt.MapFrom(model => model.NomeRazaoSocial))
                .ForMember(dto => dto.SobreNomeFantasia, opt => opt.MapFrom(model => model.SobreNomeFantasia))
                .ForMember(dto => dto.CPFCNPJ, opt => opt.MapFrom(model => model.CPFCNPJ))
                .ForMember(dto => dto.RGIE, opt => opt.MapFrom(model => model.RGIE))
                .ForMember(dto => dto.DataNascimento, opt => opt.MapFrom(model => model.DataNascimento))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.WhatsApp, opt => opt.MapFrom(model => model.WhatsApp))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region PessoaEndereco -> PessoaEnderecoDto
            cfg.CreateMap<PessoaEndereco, PessoaEnderecoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.CodPessoa, opt => opt.MapFrom(model => model.IdPessoa))
                .ForMember(dto => dto.CodEndereco, opt => opt.MapFrom(model => model.IdEndereco))
                .ForMember(dto => dto.TipoEndereco, opt => opt.MapFrom(model => model.TipoEndereco))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region SetorEmpresa -> SetorEmpresaDto
            cfg.CreateMap<SetorEmpresa, SetorEmpresaDto>()
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Usuario->UsuarioDto
            cfg.CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Senha, opt => opt.MapFrom(model => model.Senha))
                .ForMember(dto => dto.Acesso, opt => opt.MapFrom(model => model.Acesso))
                .ForMember(dto => dto.CodPessoa, opt => opt.MapFrom(model => model.IdPessoa))
                .ForMember(dto => dto.CodEmpresa, opt => opt.MapFrom(model => model.IdEmpresa))
                .IgnoreAllUnmapped();
            #endregion

        }

        private void ConfigureDtoToModel(IMapperConfigurationExpression cfg)
        {


            #region AgendamentoDto -> Agendamento
            cfg.CreateMap<AgendamentoDto, Agendamento>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.IdChamado, opt => opt.MapFrom(dto => dto.CodChamado))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.DataPrevisaoInicializacao, opt => opt.MapFrom(dto => dto.DataPrevisaoInicializacao))
                .ForMember(model => model.DataPrevisaoFinalizacao, opt => opt.MapFrom(dto => dto.DataPrevisaoFinalizacao))
                .ForMember(model => model.DataAgendamento, opt => opt.MapFrom(dto => dto.DataAgendamento))
                .ForMember(model => model.HoraInicial, opt => opt.MapFrom(dto => dto.HoraInicial))
                .ForMember(model => model.HoraFinal, opt => opt.MapFrom(dto => dto.HoraFinal))
                .ForMember(model => model.Realizado, opt => opt.MapFrom(dto => dto.Realizado))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region AgendamentoItemDto -> AgendamentoItem
            cfg.CreateMap<AgendamentoItemDto, AgendamentoItem>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.DataAgendamento, opt => opt.MapFrom(dto => dto.DataAgendamento))
                .ForMember(model => model.HoraInicio, opt => opt.MapFrom(dto => dto.HoraInicio))
                .ForMember(model => model.HoraFinal, opt => opt.MapFrom(dto => dto.HoraFinal))
                .ForMember(model => model.DataRetorno, opt => opt.MapFrom(dto => dto.DataRetorno))
                .ForMember(model => model.IdSetorEmpresa, opt => opt.MapFrom(dto => dto.CodSetorEmpresa))
                .ForMember(model => model.DataAlteracao, opt => opt.MapFrom(dto => dto.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region ChamadoDto -> Chamado
            cfg.CreateMap<ChamadoDto, Chamado>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.IdEmpresa, opt => opt.MapFrom(dto => dto.CodEmpresa))
                .ForMember(model => model.IdUsuario, opt => opt.MapFrom(dto => dto.CodUsuario))
                .ForMember(model => model.Titulo, opt => opt.MapFrom(dto => dto.Titulo))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.DataAbertura, opt => opt.MapFrom(dto => dto.DataAbertura))
                .ForMember(model => model.HoraInicio, opt => opt.MapFrom(dto => dto.HoraInicio))
                .ForMember(model => model.HoraFim, opt => opt.MapFrom(dto => dto.HoraFim))
                .ForMember(model => model.SituacaoChamado, opt => opt.MapFrom(dto => dto.SituacaoChamado))
                .ForMember(model => model.TipoChamado, opt => opt.MapFrom(dto => dto.TipoChamado))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ChamadoItemDto -> ChamadoItem
            cfg.CreateMap<ChamadoItemDto, ChamadoItem>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.IdChamado, opt => opt.MapFrom(dto => dto.CodChamado))
                .ForMember(model => model.IdUsuario, opt => opt.MapFrom(dto => dto.CodUsuario))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.HoraInicial, opt => opt.MapFrom(dto => dto.HoraInicial))
                .ForMember(model => model.HoraFinal, opt => opt.MapFrom(dto => dto.HoraFinal))
                .ForMember(model => model.DataAlteracao, opt => opt.MapFrom(dto => dto.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region EmpresaDto -> Empresa
            cfg.CreateMap<EmpresaDto, Empresa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.NomeRazaoSocial, opt => opt.MapFrom(dto => dto.NomeRazaoSocial))
                .ForMember(model => model.SobreNomeFantasia, opt => opt.MapFrom(dto => dto.SobreNomeFantasia))
                .ForMember(model => model.CPFCNPJ, opt => opt.MapFrom(dto => dto.CPFCNPJ))
                .ForMember(model => model.RGIE, opt => opt.MapFrom(dto => dto.RGIE))
                .ForMember(model => model.DataNascimento, opt => opt.MapFrom(dto => dto.DataNascimento))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.WhatsApp, opt => opt.MapFrom(dto => dto.WhatsApp))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region EnderecoDto -> Endereco
            cfg.CreateMap<EnderecoDto, Endereco>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Logradouro, opt => opt.MapFrom(dto => dto.Logradouro))
                .ForMember(model => model.Numero, opt => opt.MapFrom(dto => dto.Numero))
                .ForMember(model => model.Bairro, opt => opt.MapFrom(dto => dto.Bairro))
                .ForMember(model => model.Cidade, opt => opt.MapFrom(dto => dto.Cidade))
                .ForMember(model => model.Estado, opt => opt.MapFrom(dto => dto.Estado))
                .ForMember(model => model.CEP, opt => opt.MapFrom(dto => dto.CEP))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region PessoaDto -> Pessoa
            cfg.CreateMap<PessoaDto, Pessoa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.NomeRazaoSocial, opt => opt.MapFrom(dto => dto.NomeRazaoSocial))
                .ForMember(model => model.SobreNomeFantasia, opt => opt.MapFrom(dto => dto.SobreNomeFantasia))
                .ForMember(model => model.CPFCNPJ, opt => opt.MapFrom(dto => dto.CPFCNPJ))
                .ForMember(model => model.RGIE, opt => opt.MapFrom(dto => dto.RGIE))
                .ForMember(model => model.DataNascimento, opt => opt.MapFrom(dto => dto.DataNascimento))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.WhatsApp, opt => opt.MapFrom(dto => dto.WhatsApp))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region PessoaEnderecoDto -> PessoaEndereco
            cfg.CreateMap<PessoaEnderecoDto, PessoaEndereco>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.IdPessoa, opt => opt.MapFrom(dto => dto.CodPessoa))
                .ForMember(model => model.IdEndereco, opt => opt.MapFrom(dto => dto.CodEndereco))
                .ForMember(model => model.TipoEndereco, opt => opt.MapFrom(dto => dto.TipoEndereco))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region SetorEmpresaDto -> SetorEmpresa
            cfg.CreateMap<SetorEmpresaDto, SetorEmpresa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region UsuarioDto->Usuario
            cfg.CreateMap<UsuarioDto, Usuario>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.Senha, opt => opt.MapFrom(dto => dto.Senha))
                .ForMember(model => model.Acesso, opt => opt.MapFrom(dto => dto.Acesso))
                .ForMember(model => model.IdPessoa, opt => opt.MapFrom(dto => dto.CodPessoa))
                .ForMember(model => model.IdEmpresa, opt => opt.MapFrom(dto => dto.CodEmpresa))
                .IgnoreAllUnmapped();
            #endregion

        }

        public virtual TResult Map<TResult>(object viewModel)
        {
            return MapperConfig.Map<TResult>(viewModel);
        }
    }
}
