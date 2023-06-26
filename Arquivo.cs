namespace IssueClickHouseClient;

internal class Arquivo
{
    public string Id { get; set; }
    public bool Deletado { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public string CnpjEmpresa { get; private set; }
    public string NomeEmpresa { get; private set; }
    public string CpfCnpjCadastro { get; private set; }
    public string NomeCadastro { get; private set; }
    public int Serie { get; private set; }
    public int NumeroNota { get; private set; }
    public string ChaveAcesso { get; private set; }
    public int Situacao { get; private set; }
    public double TotalNota { get; private set; }
    public DateTime DataEmissao { get; private set; }
    public DateTime DataNota { get; private set; }
    public DateTime? DataEntrada { get; private set; }
    public DateTime DataPadrao { get; private set; }
    public int Operacao { get; private set; }
    public int TipoNota { get; private set; }
    public int Status { get; private set; }
    public string SpacesKey { get; private set; }
    public string MotivoFalha { get; private set; }
    public string UrlExterna { get; private set; }
    public string SpacesKeyCancelamento { get; private set; }

    public Arquivo(string id, string cnpjEmpresa, string nomeEmpresa, string cpfCnpjCadastro, string nomeCadastro, int serie, int numeroNota, string chaveAcesso, int situacao, double totalNota, DateTime dataEmissao, DateTime dataNota, DateTime? dataEntrada, int operacao, int tipoNota, int status, string urlExterna, DateTime? dataCadastro)
    {
        Id = id;
        DataCadastro = DateTime.Now;
        DataAtualizacao = DateTime.Now;
        CnpjEmpresa = cnpjEmpresa;
        NomeEmpresa = nomeEmpresa;
        CpfCnpjCadastro = cpfCnpjCadastro;
        NomeCadastro = nomeCadastro;
        Serie = serie;
        NumeroNota = numeroNota;
        ChaveAcesso = chaveAcesso;
        Situacao = situacao;
        TotalNota = totalNota;
        DataEmissao = dataEmissao;
        DataNota = dataNota;
        DataEntrada = dataEntrada;
        TipoNota = tipoNota;
        DataPadrao = DateTime.Now;
        Operacao = operacao;
        Status = status;
        UrlExterna = urlExterna;
        DataCadastro = dataCadastro;
        SpacesKey = "";
        SpacesKeyCancelamento = "";
    }
}
