using ClickHouse.Client.ADO;
using ClickHouse.Client.Copy;
using ClickHouse.Client.Utility;
using FastMember;
using IssueClickHouseClient;

ClickHouseConnection clickHouseConnection = new($"Host=;Protocol=http;Port=;Username=;Password=;Compress=true;");

await CriarTabelasPadraoAmigoContador();
await InserirArquivosPorBulkCopy(ObterArquivos());

async Task InserirArquivosPorBulkCopy(List<Arquivo> arquivos)
{
    if (!arquivos.Any()) return;

    using ClickHouseBulkCopy bulkCopyInterface = new(clickHouseConnection)
    {
        DestinationTableName = "amigo_contador.arquivo",
    };

    using var reader = ObjectReader.Create(arquivos, "Id", "Deletado", "Ativo", "DataCadastro", "DataAtualizacao", "CnpjEmpresa", "NomeEmpresa", "CpfCnpjCadastro", "NomeCadastro", "Serie", "NumeroNota", "ChaveAcesso", "Situacao", "TotalNota", "DataEmissao", "DataNota", "DataEntrada", "DataPadrao", "Operacao", "TipoNota", "Status", "SpacesKey", "MotivoFalha", "UrlExterna", "SpacesKeyCancelamento");

    while (reader.Read())
        await bulkCopyInterface.WriteToServerAsync(reader);
}

async Task CriarTabelasPadraoAmigoContador()
{
    const string DATABASE_NAME = "amigo_contador";

    await clickHouseConnection.ExecuteScalarAsync($"CREATE DATABASE IF NOT EXISTS {DATABASE_NAME}");

    await clickHouseConnection.ExecuteScalarAsync($"CREATE TABLE IF NOT EXISTS {DATABASE_NAME}.arquivo ( Id String, Deletado Bool, Ativo Bool, DataCadastro DateTime, DataAtualizacao DateTime, CnpjEmpresa FixedString(14), NomeEmpresa String, CpfCnpjCadastro String, NomeCadastro String, Serie Int32, NumeroNota Int32, ChaveAcesso String, Situacao Int8, TotalNota Float32, DataEmissao DateTime, DataNota DateTime, DataEntrada Nullable(DateTime), DataPadrao DateTime, Operacao UInt8, TipoNota UInt8, Status UInt8, SpacesKey String, MotivoFalha String DEFAULT '', UrlExterna String, SpacesKeyCancelamento String DEFAULT '' ) ENGINE = ReplacingMergeTree(DataAtualizacao) PRIMARY KEY (ChaveAcesso, CnpjEmpresa) PARTITION BY CnpjEmpresa ORDER BY (ChaveAcesso, CnpjEmpresa) SETTINGS index_granularity = 8192");
}

List<Arquivo> ObterArquivos()
{
    List<Arquivo> arquivos = new()
    {
        new Arquivo("a1B2C4878A6", "123456789", "Teste", "123456789", "Teste", 123456789, 123465, "teste", 0, 10.2, DateTime.Now, DateTime.Now, DateTime.Now, 0, 0, 0, "Teste", DateTime.Now), //this value doesn't insert
        new Arquivo("aa", "12345678", "Teste", "123456789", "Teste", 123456789, 123465, "teste", 0, 10.2, DateTime.Now, DateTime.Now, DateTime.Now, 0, 0, 0, "Teste", DateTime.Now),
        new Arquivo("bb", "12345789", "Teste", "123456789", "Teste", 123456789, 123465, "teste", 0, 10.2, DateTime.Now, DateTime.Now, DateTime.Now, 0, 0, 0, "Teste", DateTime.Now),
        new Arquivo("cc", "12356789", "Teste", "123456789", "Teste", 123456789, 123465, "teste", 0, 10.2, DateTime.Now, DateTime.Now, DateTime.Now, 0, 0, 0, "Teste", DateTime.Now),
        new Arquivo("dd", "12456789", "Teste", "123456789", "Teste", 123456789, 123465, "teste", 0, 10.2, DateTime.Now, DateTime.Now, DateTime.Now, 0, 0, 0, "Teste", DateTime.Now)

    };

    return arquivos;
}