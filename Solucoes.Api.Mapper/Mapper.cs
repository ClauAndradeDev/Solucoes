using AutoMapper;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Extensoes;

namespace Solucoes.Api.Mapper
{
    public class Mapper
    {
        protected IMapper MapperConfig { get; set; }

        public Mapper()
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
            #region Chamado -> ChamadoDto
            cfg.CreateMap<Chamado, ChamadoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.TipoChamado, opt => opt.MapFrom(model => model.TipoChamado))
                .ForMember(dto => dto.DataAbertura, opt => opt.MapFrom(model => model.DataAbertura))
                .ForMember(dto => dto.Empresas, opt => opt.MapFrom(model => model.EmpresaId))
                .ForMember(dto => dto.Plataformas, opt => opt.MapFrom(model => model.PlataformaId))
                .ForMember(dto => dto.Usuarios, opt => opt.MapFrom(model => model.UsuarioId))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ChamadoItem -> ChamadoItemDto
            cfg.CreateMap<ChamadoItem, ChamadoItemDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataRegistro, opt => opt.MapFrom(model => model.DataRegistro))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.Chamados, opt => opt.MapFrom(model => model.ChamadoId))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region Contato -> ContatoDto
            cfg.CreateMap<Contato, ContatoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Nome, opt => opt.MapFrom(model => model.Nome))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.TipoContato, opt => opt.MapFrom(model => model.TipoContato))
                 .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.Pessoas, opt => opt.MapFrom(model => model.PessoaId))
                .IgnoreAllUnmapped();
            #endregion

            #region Empresa -> EmpresaDto
            cfg.CreateMap<Empresa, EmpresaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.IEMunicipal, opt => opt.MapFrom(model => model.IEMunicipal))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.NomeRazaoSocial, opt => opt.MapFrom(model => model.NomeRazaoSocial))
                .ForMember(dto => dto.SobreNomeFantasia, opt => opt.MapFrom(model => model.SobreNomeFantasia))
                .ForMember(dto => dto.CPFCNPJ, opt => opt.MapFrom(model => model.CPFCNPJ))
                .ForMember(dto => dto.RGIE, opt => opt.MapFrom(model => model.RGIE))
                .ForMember(dto => dto.DataAbertura, opt => opt.MapFrom(model => model.DataAbertura))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.WhatsApp, opt => opt.MapFrom(model => model.WhatsApp))
                .ForMember(dto => dto.TipoEmpresa, opt => opt.MapFrom(model => model.TipoEmpresa))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Empresa, EmpresaComPessoaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.IEMunicipal, opt => opt.MapFrom(model => model.IEMunicipal))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.NomeRazaoSocial, opt => opt.MapFrom(model => model.NomeRazaoSocial))
                .ForMember(dto => dto.SobreNomeFantasia, opt => opt.MapFrom(model => model.SobreNomeFantasia))
                .ForMember(dto => dto.CPFCNPJ, opt => opt.MapFrom(model => model.CPFCNPJ))
                .ForMember(dto => dto.RGIE, opt => opt.MapFrom(model => model.RGIE))
                .ForMember(dto => dto.DataAbertura, opt => opt.MapFrom(model => model.DataAbertura))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.WhatsApp, opt => opt.MapFrom(model => model.WhatsApp))
                .ForMember(dto => dto.TipoEmpresa, opt => opt.MapFrom(model => model.TipoEmpresa))
                .ForMember(dto => dto.Pessoas, opt => opt.MapFrom(model => model.Pessoas))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Endereco -> EnderecoDto
            cfg.CreateMap<Endereco, EnderecoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Logradouro, opt => opt.MapFrom(model => model.Logradouro))
                .ForMember(dto => dto.Numero, opt => opt.MapFrom(model => model.Numero))
                .ForMember(dto => dto.Bairro, opt => opt.MapFrom(model => model.Bairro))
                .ForMember(dto => dto.CEP, opt => opt.MapFrom(model => model.CEP))
                .ForMember(dto => dto.Cidade, opt => opt.MapFrom(model => model.Cidade))
                .ForMember(dto => dto.Estado, opt => opt.MapFrom(model => model.Estado))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                //.ForMember(dto => dto.Pessoas, opt => opt.MapFrom(model => model.Pessoas))
                //.ForMember(dto => dto.Empresas, opt => opt.MapFrom(model => model.Empresas))
                .ForMember(dto => dto.TipoEndereco, opt => opt.MapFrom(model => model.TipoEndereco))
                .IgnoreAllUnmapped();
            #endregion

            #region Pessoa -> PessoaDto
            cfg.CreateMap<Pessoa, PessoaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.NomeRazaoSocial, opt => opt.MapFrom(model => model.NomeRazaoSocial))
                .ForMember(dto => dto.SobreNomeFantasia, opt => opt.MapFrom(model => model.SobreNomeFantasia))
                .ForMember(dto => dto.CPFCNPJ, opt => opt.MapFrom(model => model.CPFCNPJ))
                .ForMember(dto => dto.RGIE, opt => opt.MapFrom(model => model.RGIE))
                .ForMember(dto => dto.DataNascimento, opt => opt.MapFrom(model => model.DataNascimento))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.WhatsApp, opt => opt.MapFrom(model => model.WhatsApp))
                .ForMember(dto => dto.TipoPessoa, opt => opt.MapFrom(model => model.TipoPessoa))
                .ForMember(dto => dto.TipoPessoa, opt => opt.MapFrom(model => model.TipoPessoa))
                .ForMember(dto => dto.PerfilPessoa, opt => opt.MapFrom(model => model.PerfilPessoa))
                .ForMember(dto => dto.Acesso, opt => opt.MapFrom(model => model.Acesso))
                .ForMember(dto => dto.Empresas, opt => opt.MapFrom(model => model.Empresas))
                .ForMember(dto => dto.Enderecos, opt => opt.MapFrom(model => model.Enderecos))
                .ForMember(dto => dto.Contatos, opt => opt.MapFrom(model => model.Contatos))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Plataforma -> PlataformaDto
            cfg.CreateMap<Plataforma, PlataformaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Reuniao -> ReuniaoDto
            cfg.CreateMap<Reuniao, ReuniaoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataPrevisaoInicio, opt => opt.MapFrom(model => model.DataPrevisaoInicio))
                .ForMember(dto => dto.DataPrevisaoFim, opt => opt.MapFrom(model => model.DataPrevisaoFim))
                .ForMember(dto => dto.DataAgendamento, opt => opt.MapFrom(model => model.DataAgendamento))
                .ForMember(dto => dto.HoraInicial, opt => opt.MapFrom(model => model.HoraInicial))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                .ForMember(dto => dto.DataRetorno, opt => opt.MapFrom(model => model.DataRetorno))
                .ForMember(dto => dto.Chamados, opt => opt.MapFrom(model => model.ChamadoId))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .ForMember(dto => dto.Empresas, opt => opt.MapFrom(model => model.EmpresaId))
                .IgnoreAllUnmapped();
            #endregion

            #region ReuniaoItem -> ReuniaoItemDto
            cfg.CreateMap<ReuniaoItem, ReuniaoItemDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Reuniaos, opt => opt.MapFrom(model => model.ReuniaoId))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataRealizada, opt => opt.MapFrom(model => model.DataRealizada))
                .ForMember(dto => dto.HoraInicial, opt => opt.MapFrom(model => model.HoraInicial))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region SetorEmpresa -> SetorEmpresaDto
            cfg.CreateMap<SetorEmpresa, SetorEmpresaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Empresas, opt => opt.MapFrom(model => model.Empresas))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Usuario -> UsuarioDto
            cfg.CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Login, opt => opt.MapFrom(model => model.Login))
                .ForMember(dto => dto.Senha, opt => opt.MapFrom(model => model.Senha))
                .ForMember(dto => dto.Pessoas, opt => opt.MapFrom(model => model.PessoaId))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region LogMovimentacao -> LogMovimentacaoDto
            cfg.CreateMap<LogMovimentacao, LogMovimentacaoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .ForMember(dto => dto.Tabela, opt => opt.MapFrom(model => model.Tabela))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.Registro, opt => opt.MapFrom(model => model.Registro))
                .ForMember(dto => dto.Movimentacao, opt => opt.MapFrom(model => model.Movimentacao))
                .ForMember(dto => dto.CodUsuario, opt => opt.MapFrom(model => model.IdUsuario))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

        }

        private void ConfigureDtoToModel(IMapperConfigurationExpression cfg)
        {
            #region ChamadoDto -> Chamado
            cfg.CreateMap<ChamadoDto, Chamado>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Titulo, opt => opt.MapFrom(dto => dto.Titulo))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.TipoChamado, opt => opt.MapFrom(dto => dto.TipoChamado))
                .ForMember(model => model.DataAbertura, opt => opt.MapFrom(dto => dto.DataAbertura))
                .ForMember(model => model.EmpresaId, opt => opt.MapFrom(dto => dto.Empresas))
                .ForMember(model => model.PlataformaId, opt => opt.MapFrom(dto => dto.Plataformas))
                .ForMember(model => model.UsuarioId, opt => opt.MapFrom(dto => dto.Usuarios))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ChamadoItemDto -> ChamadoItem
            cfg.CreateMap<ChamadoItemDto, ChamadoItem>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.ChamadoId, opt => opt.MapFrom(dto => dto.Chamados))
                .ForMember(model => model.DataRegistro, opt => opt.MapFrom(dto => dto.DataRegistro))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.DataAlteracao, opt => opt.MapFrom(dto => dto.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region ContatoDto -> Contato
            cfg.CreateMap<ContatoDto, Contato>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Nome, opt => opt.MapFrom(dto => dto.Nome))
                .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.TipoContato, opt => opt.MapFrom(dto => dto.TipoContato))
                .ForMember(model => model.PessoaId, opt => opt.MapFrom(dto => dto.Pessoas))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region EmpresaDto -> Empresa
            cfg.CreateMap<EmpresaDto, Empresa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.IEMunicipal, opt => opt.MapFrom(dto => dto.IEMunicipal))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.NomeRazaoSocial, opt => opt.MapFrom(dto => dto.NomeRazaoSocial))
                .ForMember(model => model.SobreNomeFantasia, opt => opt.MapFrom(dto => dto.SobreNomeFantasia))
                .ForMember(model => model.CPFCNPJ, opt => opt.MapFrom(dto => dto.CPFCNPJ))
                .ForMember(model => model.RGIE, opt => opt.MapFrom(dto => dto.RGIE))
                .ForMember(model => model.DataAbertura, opt => opt.MapFrom(dto => dto.DataAbertura))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
                .ForMember(model => model.WhatsApp, opt => opt.MapFrom(dto => dto.WhatsApp))
                .ForMember(model => model.TipoEmpresa, opt => opt.MapFrom(dto => dto.TipoEmpresa))
                //.ForMember(model => model.Enderecos, opt => opt.MapFrom(dto => dto.Enderecos))
                //.ForMember(model => model.Pessoas, opt => opt.MapFrom(dto => dto.Pessoas))
                //.ForMember(model => model.Setores, opt => opt.MapFrom(dto => dto.Setores))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region EnderecoDto -> Endereco
            cfg.CreateMap<EnderecoDto, Endereco>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Logradouro, opt => opt.MapFrom(dto => dto.Logradouro))
                .ForMember(model => model.Numero, opt => opt.MapFrom(dto => dto.Numero))
                .ForMember(model => model.Bairro, opt => opt.MapFrom(dto => dto.Bairro))
                .ForMember(model => model.CEP, opt => opt.MapFrom(dto => dto.CEP))
                .ForMember(model => model.Cidade, opt => opt.MapFrom(dto => dto.Cidade))
                .ForMember(model => model.Estado, opt => opt.MapFrom(dto => dto.Estado))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                //.ForMember(model => model.Pessoas, opt => opt.MapFrom(dto => dto.Pessoas))
                //.ForMember(model => model.Empresas, opt => opt.MapFrom(dto => dto.Empresas))
                .ForMember(model => model.TipoEndereco, opt => opt.MapFrom(dto => dto.TipoEndereco))
                .IgnoreAllUnmapped();
            #endregion

            #region PessoaDto -> Pessoa
            cfg.CreateMap<PessoaDto, Pessoa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.NomeRazaoSocial, opt => opt.MapFrom(dto => dto.NomeRazaoSocial))
                .ForMember(model => model.SobreNomeFantasia, opt => opt.MapFrom(dto => dto.SobreNomeFantasia))
                .ForMember(model => model.CPFCNPJ, opt => opt.MapFrom(dto => dto.CPFCNPJ))
                .ForMember(model => model.RGIE, opt => opt.MapFrom(dto => dto.RGIE))
                .ForMember(model => model.DataNascimento, opt => opt.MapFrom(dto => dto.DataNascimento))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
                .ForMember(model => model.WhatsApp, opt => opt.MapFrom(dto => dto.WhatsApp))
                .ForMember(model => model.TipoPessoa, opt => opt.MapFrom(dto => dto.TipoPessoa))
                .ForMember(model => model.PerfilPessoa, opt => opt.MapFrom(dto => dto.PerfilPessoa))
                .ForMember(model => model.Acesso, opt => opt.MapFrom(dto => dto.Acesso))
                //.ForMember(model => model.Empresas, opt => opt.MapFrom(dto => dto.Empresas))
                //.ForMember(model => model.Contatos, opt => opt.MapFrom(dto => dto.Contatos))
                //.ForMember(model => model.Enderecos, opt => opt.MapFrom(dto => dto.Enderecos))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region PlataformaDto -> Platatorma
            cfg.CreateMap<PlataformaDto, Plataforma>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ReuniaoDto -> Reuniao
            cfg.CreateMap<ReuniaoDto, Reuniao>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.DataPrevisaoInicio, opt => opt.MapFrom(dto => dto.DataPrevisaoInicio))
                .ForMember(model => model.DataPrevisaoFim, opt => opt.MapFrom(dto => dto.DataPrevisaoFim))
                .ForMember(model => model.DataAgendamento, opt => opt.MapFrom(dto => dto.DataAgendamento))
                .ForMember(model => model.HoraAgendamento, opt => opt.MapFrom(dto => dto.HoraAgendamento))
                .ForMember(model => model.HoraInicial, opt => opt.MapFrom(dto => dto.HoraInicial))
                .ForMember(model => model.HoraFinal, opt => opt.MapFrom(dto => dto.HoraFinal))
                .ForMember(model => model.DataRetorno, opt => opt.MapFrom(dto => dto.DataRetorno))
                .ForMember(model => model.ChamadoId, opt => opt.MapFrom(dto => dto.Chamados))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.EmpresaId, opt => opt.MapFrom(dto => dto.Empresas))
                .IgnoreAllUnmapped();
            #endregion

            #region ReuniaoItemDto -> ReuniaoItem
            cfg.CreateMap<ReuniaoItemDto, ReuniaoItem>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.ReuniaoId, opt => opt.MapFrom(dto => dto.Reuniaos))
                .ForMember(model => model.Titulo, opt => opt.MapFrom(dto => dto.Titulo))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.DataRealizada, opt => opt.MapFrom(dto => dto.DataRealizada))
                .ForMember(model => model.HoraInicial, opt => opt.MapFrom(dto => dto.HoraInicial))
                .ForMember(model => model.HoraFinal, opt => opt.MapFrom(dto => dto.HoraFinal))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.DataAlteracao, opt => opt.MapFrom(dto => dto.DataAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region SetorEmpresaDto -> SetorEmpresa
            cfg.CreateMap<SetorEmpresaDto, SetorEmpresa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                //.ForMember(model => model.Empresas, opt => opt.MapFrom(dto => dto.Empresas))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region UsuarioDto -> Usuario
            cfg.CreateMap<UsuarioDto, Usuario>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Login, opt => opt.MapFrom(dto => dto.Login))
                .ForMember(model => model.Senha, opt => opt.MapFrom(dto => dto.Senha))
                .ForMember(model => model.PessoaId, opt => opt.MapFrom(dto => dto.Pessoas))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region LogMovimentacao -> LogMovimentacaoDto
            cfg.CreateMap<LogMovimentacaoDto, LogMovimentacao>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataAlteracao, opt => opt.MapFrom(dto => dto.DataAlteracao))
                .ForMember(model => model.Tabela, opt => opt.MapFrom(dto => dto.Tabela))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.Registro, opt => opt.MapFrom(dto => dto.Registro))
                .ForMember(model => model.Movimentacao, opt => opt.MapFrom(dto => dto.Movimentacao))
                .ForMember(model => model.IdUsuario, opt => opt.MapFrom(dto => dto.CodUsuario))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

        }

        public virtual TResult Map<TResult>(object viewModel)
        {
            return MapperConfig.Map<TResult>(viewModel);
        }
    }

}


