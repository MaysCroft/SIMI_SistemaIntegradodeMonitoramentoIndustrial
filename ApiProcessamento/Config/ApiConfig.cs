namespace ApiProcessamento.Config
{
    /// <summary>
    /// Classe de configuração ára a API, contendo propriedades
    /// que podem ser definidas no arquivo appsettings.json ou 
    /// em variáveis de ambiente. Neste exemplo, temos a propriedade 
    /// MaxTemperatura, que define o limite máximo de temperatura 
    /// permitido para os dados recebidos pela API.
    /// </summary>
    public class ApiConfig
    {
        public double MaxTemperatura { get; set; }
    }
}
