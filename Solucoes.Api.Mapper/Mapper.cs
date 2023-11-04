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


            #region Contato -> ContatoDto/ContatoPessoaDto
            cfg.CreateMap<Contato, ContatoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Nome, opt => opt.MapFrom(model => model.Nome))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.TipoContato, opt => opt.MapFrom(model => model.TipoContato))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Contato, ContatoPessoaDto>()
               .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
               .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
               .ForMember(dto => dto.Nome, opt => opt.MapFrom(model => model.Nome))
               .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
               .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
               .ForMember(dto => dto.TipoContato, opt => opt.MapFrom(model => model.TipoContato))
               .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
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
                .ForMember(dto => dto.Logradouro, opt => opt.MapFrom(model => model.Logradouro))
                .ForMember(dto => dto.Numero, opt => opt.MapFrom(model => model.Numero))
                .ForMember(dto => dto.Bairro, opt => opt.MapFrom(model => model.Bairro))
                .ForMember(dto => dto.CEP, opt => opt.MapFrom(model => model.CEP))
                .ForMember(dto => dto.Cidade, opt => opt.MapFrom(model => model.Cidade))
                .ForMember(dto => dto.Estado, opt => opt.MapFrom(model => model.Estado))
                .IgnoreAllUnmapped();
            #endregion

            #region Endereco -> EnderecoDto/EnderecoPessoaDto
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
                .ForMember(dto => dto.TipoEndereco, opt => opt.MapFrom(model => model.TipoEndereco))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Endereco, EnderecoPessoaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Logradouro, opt => opt.MapFrom(model => model.Logradouro))
                .ForMember(dto => dto.Numero, opt => opt.MapFrom(model => model.Numero))
                .ForMember(dto => dto.Bairro, opt => opt.MapFrom(model => model.Bairro))
                .ForMember(dto => dto.CEP, opt => opt.MapFrom(model => model.CEP))
                .ForMember(dto => dto.Cidade, opt => opt.MapFrom(model => model.Cidade))
                .ForMember(dto => dto.Estado, opt => opt.MapFrom(model => model.Estado))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
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
                .ForMember(dto => dto.Contatos, opt => opt.MapFrom(model => model.Contatos))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region PessoaEmpresa -> PessoaEmpresaDto
            cfg.CreateMap<PessoaEmpresa, PessoaEmpresaDto>()
                .ForMember(dto => dto.CodEmpresaPessoa, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Pessoa.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.Pessoa.DataCadastro))
                .ForMember(dto => dto.NomeRazaoSocial, opt => opt.MapFrom(model => model.Pessoa.NomeRazaoSocial))
                .ForMember(dto => dto.SobreNomeFantasia, opt => opt.MapFrom(model => model.Pessoa.SobreNomeFantasia))
                .ForMember(dto => dto.CPFCNPJ, opt => opt.MapFrom(model => model.Pessoa.CPFCNPJ))
                .ForMember(dto => dto.RGIE, opt => opt.MapFrom(model => model.Pessoa.RGIE))
                .ForMember(dto => dto.DataNascimento, opt => opt.MapFrom(model => model.Pessoa.DataNascimento))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Pessoa.Email))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Pessoa.Telefone))
                .ForMember(dto => dto.WhatsApp, opt => opt.MapFrom(model => model.Pessoa.WhatsApp))
                .ForMember(dto => dto.TipoPessoa, opt => opt.MapFrom(model => model.Pessoa.TipoPessoa))
                .ForMember(dto => dto.PerfilPessoa, opt => opt.MapFrom(model => model.Pessoa.PerfilPessoa))
                .ForMember(dto => dto.Acesso, opt => opt.MapFrom(model => model.Pessoa.Acesso))
                .ForMember(dto => dto.Contatos, opt => opt.MapFrom(model => model.Pessoa.Contatos))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Pessoa.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Plataforma -> PlataformaDto/PlataformaEmpresaDto
            cfg.CreateMap<Plataforma, PlataformaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Plataforma, PlataformaEmpresaDto>()
               .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
               .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
               .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
               .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
               .IgnoreAllUnmapped();
            #endregion

            #region Reuniao -> ReuniaoDto
            cfg.CreateMap<Reuniao, ReuniaoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.DataPrevisaoInicio, opt => opt.MapFrom(model => model.DataPrevisaoInicio))
                .ForMember(dto => dto.DataAgendamento, opt => opt.MapFrom(model => model.DataAgendamento))
                .ForMember(dto => dto.HoraAgendamentoInicial, opt => opt.MapFrom(model => model.HoraAgendamentoInicial))
                .ForMember(dto => dto.HoraAgendamentoFinal, opt => opt.MapFrom(model => model.HoraAgendamentoFinal))
                .ForMember(dto => dto.Ticket, opt => opt.MapFrom(model => model.Ticket))
                .ForMember(dto => dto.Empresa, opt => opt.MapFrom(model => model.Empresa))
                .ForMember(dto => dto.ReuniaoAcoes, opt => opt.MapFrom(model => model.ReuniaoAcoes))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Reuniao, ReuniaoTicketDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.DataAlteracao, opt => opt.MapFrom(model => model.DataAlteracao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.DataPrevisaoInicio, opt => opt.MapFrom(model => model.DataPrevisaoInicio))
                .ForMember(dto => dto.DataAgendamento, opt => opt.MapFrom(model => model.DataAgendamento))
                .ForMember(dto => dto.HoraAgendamentoInicial, opt => opt.MapFrom(model => model.HoraAgendamentoInicial))
                .ForMember(dto => dto.HoraAgendamentoFinal, opt => opt.MapFrom(model => model.HoraAgendamentoFinal))
                //.ForMember(dto => dto.Ticket, opt => opt.MapFrom(model => model.Ticket))
                //.ForMember(dto => dto.Empresa, opt => opt.MapFrom(model => model.Empresa))
                .ForMember(dto => dto.ReuniaoAcoes, opt => opt.MapFrom(model => model.ReuniaoAcoes))
                .IgnoreAllUnmapped();
            #endregion

            #region ReuniaoAcao -> ReuniaoAcaoDto
            cfg.CreateMap<ReuniaoAcao, ReuniaoAcaoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataPrevisaoRetorno, opt => opt.MapFrom(model => model.DataPrevisaoRetorno))
                .ForMember(dto => dto.HoraInicial, opt => opt.MapFrom(model => model.HoraInicial))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                //.ForMember(dto => dto.Reuniao, opt => opt.MapFrom(model => model.Reuniao))
                //.ForMember(dto => dto.Setor, opt => opt.MapFrom(model => model.Setor))
                //.ForMember(dto => dto.Usuario, opt => opt.MapFrom(model => model.Usuario))
                .IgnoreAllUnmapped();

            cfg.CreateMap<ReuniaoAcao, ReuniaoAcaoReuniaoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataPrevisaoRetorno, opt => opt.MapFrom(model => model.DataPrevisaoRetorno))
                .ForMember(dto => dto.HoraInicial, opt => opt.MapFrom(model => model.HoraInicial))
                .ForMember(dto => dto.HoraFinal, opt => opt.MapFrom(model => model.HoraFinal))
                .IgnoreAllUnmapped();
            #endregion

            #region Setor -> SetorEmpresaDto/SetorDto
            cfg.CreateMap<Setor, SetorDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Setor, SetorEmpresaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                //.ForMember(dto => dto.Empresa, opt => opt.MapFrom(model => model.Empresa))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region TicketAcao -> TicketAcaoDto
            cfg.CreateMap<TicketAcao, TicketAcaoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataAcao, opt => opt.MapFrom(model => model.DataAcao))
                .ForMember(dto => dto.DataUltimaAlteracao, opt => opt.MapFrom(model => model.DataUltimaAlteracao))
                .IgnoreAllUnmapped();
            #endregion

            #region Ticket -> TicketDto
            cfg.CreateMap<Ticket, TicketDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Titulo))
                .ForMember(dto => dto.NumeroSequencial, opt => opt.MapFrom(model => model.NumeroSequencial))
                .ForMember(dto => dto.TipoChamado, opt => opt.MapFrom(model => model.TipoChamado))
                .ForMember(dto => dto.DataAbertura, opt => opt.MapFrom(model => model.DataAbertura))
                .ForMember(dto => dto.Empresa, opt => opt.MapFrom(model => model.Empresa))
                .ForMember(dto => dto.Plataforma, opt => opt.MapFrom(model => model.Plataforma))
                .ForMember(dto => dto.TicketAcoes, opt => opt.MapFrom(model => model.TicketAcoes))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion


            #region TicketAcao -> TicketAcaoTicketDto
            cfg.CreateMap<TicketAcao, TicketAcaoTicketDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Conteudo, opt => opt.MapFrom(model => model.Conteudo))
                .ForMember(dto => dto.DataAcao, opt => opt.MapFrom(model => model.DataAcao))
                .ForMember(dto => dto.DataUltimaAlteracao, opt => opt.MapFrom(model => model.DataUltimaAlteracao))
                .IgnoreAllUnmapped();

            #endregion

            #region TicketAgrupamento -> TicketAgrupamentoDto
            cfg.CreateMap<TicketAgrupamento, TicketAgrupamentoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Ticket.Id))
                .ForMember(dto => dto.CodigoAgrupamento, opt => opt.MapFrom(model => model.Id))
                //.ForMember(dto => dto.Titulo, opt => opt.MapFrom(model => model.Ticket.Titulo))
                //.ForMember(dto => dto.NumeroSequencial, opt => opt.MapFrom(model => model.Ticket.NumeroSequencial))
                //.ForMember(dto => dto.TipoChamado, opt => opt.MapFrom(model => model.Ticket.TipoChamado))
                //.ForMember(dto => dto.DataAbertura, opt => opt.MapFrom(model => model.Ticket.DataAbertura))
                //.ForMember(dto => dto.Empresa, opt => opt.MapFrom(model => model.Ticket.Empresa))
                //.ForMember(dto => dto.Plataforma, opt => opt.MapFrom(model => model.Ticket.Plataforma))
                //.ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Ticket.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region TicketRelacionamento -> TicketRelacionamentoDto
            cfg.CreateMap<TicketRelacionamento, TicketRelacionamentoDto>()
                .ForMember(dto => dto.CodigoTicketAgrupamento, opt => opt.MapFrom(model => model.TicketAgrupamento.Id))
                .IgnoreAllUnmapped();
            #endregion

            #region Usuario -> UsuarioDto
            cfg.CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Login, opt => opt.MapFrom(model => model.Login))
                .ForMember(dto => dto.Senha, opt => opt.MapFrom(model => model.Senha))
                //.ForMember(dto => dto.Pessoa, opt => opt.MapFrom(model => model.Pessoa))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();

            cfg.CreateMap<Usuario, UsuarioPessoaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Login, opt => opt.MapFrom(model => model.Login))
                .ForMember(dto => dto.Senha, opt => opt.MapFrom(model => model.Senha))
                .ForMember(dto => dto.Pessoa, opt => opt.MapFrom(model => model.Pessoa))
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


            #region ContatoDto -> Contato
            cfg.CreateMap<ContatoDto, Contato>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Nome, opt => opt.MapFrom(dto => dto.Nome))
                .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
                .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(model => model.TipoContato, opt => opt.MapFrom(dto => dto.TipoContato))
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
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.Logradouro, opt => opt.MapFrom(dto => dto.Logradouro))
                .ForMember(model => model.Numero, opt => opt.MapFrom(dto => dto.Numero))
                .ForMember(model => model.Bairro, opt => opt.MapFrom(dto => dto.Bairro))
                .ForMember(model => model.CEP, opt => opt.MapFrom(dto => dto.CEP))
                .ForMember(model => model.Cidade, opt => opt.MapFrom(dto => dto.Cidade))
                .ForMember(model => model.Estado, opt => opt.MapFrom(dto => dto.Estado))
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
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region PessoaEmpresaDto -> PessoaEmpresa
            cfg.CreateMap<PessoaEmpresaDto, PessoaEmpresa>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.CodEmpresaPessoa))
                .ForMember(model => model.PessoaId, opt => opt.MapFrom(dto => dto.Codigo))
                .IgnoreAllUnmapped();
            #endregion

            #region PlataformaDto -> Platatorma
            cfg.CreateMap<PlataformaDto, Plataforma>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Empresa, opt => opt.MapFrom(dto => dto.Empresa))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ReuniaoDto -> Reuniao
            cfg.CreateMap<ReuniaoDto, Reuniao>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Titulo, opt => opt.MapFrom(dto => dto.Titulo))
                .ForMember(model => model.DataPrevisaoInicio, opt => opt.MapFrom(dto => dto.DataPrevisaoInicio))
                .ForMember(model => model.DataAgendamento, opt => opt.MapFrom(dto => dto.DataAgendamento))
                .ForMember(model => model.HoraAgendamentoInicial, opt => opt.MapFrom(dto => dto.HoraAgendamentoInicial))
                .ForMember(model => model.HoraAgendamentoFinal, opt => opt.MapFrom(dto => dto.HoraAgendamentoFinal))
                //.ForMember(model => model.ReuniaoAcoes, opt => opt.MapFrom(dto => dto.ReuniaoAcoes))
                .IgnoreAllUnmapped();
            #endregion

            #region ReuniaoAcaoDto -> ReuniaoAcao
            cfg.CreateMap<ReuniaoAcaoDto, ReuniaoAcao>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Titulo, opt => opt.MapFrom(dto => dto.Titulo))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.DataPrevisaoRetorno, opt => opt.MapFrom(dto => dto.DataPrevisaoRetorno))
                .ForMember(model => model.HoraInicial, opt => opt.MapFrom(dto => dto.HoraInicial))
                .ForMember(model => model.HoraFinal, opt => opt.MapFrom(dto => dto.HoraFinal))
                .ForMember(model => model.Setor, opt => opt.MapFrom(dto => dto.Setor))
                .ForMember(model => model.Usuario, opt => opt.MapFrom(dto => dto.Usuario))
                .ForMember(model => model.Reuniao, opt => opt.MapFrom(dto => dto.Reuniao))
                .IgnoreAllUnmapped();
            #endregion

            #region SetorEmpresaDto -> SetorEmpresa
            cfg.CreateMap<SetorDto, Setor>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region TicketAcaoDto => TicketAcao
            cfg.CreateMap<TicketAcaoDto, TicketAcao>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Conteudo, opt => opt.MapFrom(dto => dto.Conteudo))
                .ForMember(model => model.DataAcao, opt => opt.MapFrom(dto => dto.DataAcao))
                .ForMember(model => model.DataUltimaAlteracao, opt => opt.MapFrom(dto => dto.DataUltimaAlteracao))
                .ForMember(model => model.Usuario, opt => opt.MapFrom(dto => dto.Usuario))
                .IgnoreAllUnmapped();
            #endregion

            #region TicketDto -> Ticket
            cfg.CreateMap<TicketDto, Ticket>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.Titulo, opt => opt.MapFrom(dto => dto.Titulo))
                .ForMember(model => model.Origem, opt => opt.MapFrom(dto => dto.Origem))
                .ForMember(model => model.NumeroSequencial, opt => opt.MapFrom(dto => dto.NumeroSequencial))
                .ForMember(model => model.TipoChamado, opt => opt.MapFrom(dto => dto.TipoChamado))
                .ForMember(model => model.DataAbertura, opt => opt.MapFrom(dto => dto.DataAbertura))
                //.ForMember(model => model.Empresa, opt => opt.MapFrom(dto => dto.Empresa))
                //.ForMember(model => model.Plataforma, opt => opt.MapFrom(dto => dto.Plataforma))
                //.ForMember(model => model.TicketAcoes, opt => opt.MapFrom(dto => dto.TicketAcoes))
                .IgnoreAllUnmapped();
            #endregion

            #region TicketAgrupamentoDto -> TicketAgrupamento
            cfg.CreateMap<TicketAgrupamentoDto, TicketAgrupamento>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.CodigoAgrupamento))
                .ForMember(model => model.TicketId, opt => opt.MapFrom(dto => dto.Codigo))
                .IgnoreAllUnmapped();
            #endregion

            #region TicketRelacionamentoDto -> TicketRelacionamento
            cfg.CreateMap<TicketRelacionamentoDto, TicketRelacionamento>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.TicketId, opt => opt.MapFrom(dto => dto.CodigoTicketAgrupamento));
            #endregion

            #region UsuarioDto -> Usuario
            cfg.CreateMap<UsuarioDto, Usuario>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Login, opt => opt.MapFrom(dto => dto.Login))
                .ForMember(model => model.Senha, opt => opt.MapFrom(dto => dto.Senha))
                .ForMember(model => model.Pessoa, opt => opt.MapFrom(dto => dto.Pessoa))
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


