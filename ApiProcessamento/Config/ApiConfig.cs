namespace ApiProcessamento.Config
{
    /// <summary>
    /// ApiConfig é a classe de configuração para a API de Processamento. 
    /// Ela contém as propriedades MaxTemperatura e MaxPressao, que definem 
    /// os limites máximos permitidos para os dados de temperatura e pressão 
    /// recebidos pela API. Esses valores são utilizados para validar os dados 
    /// dos sensores antes de armazená-los no banco de dados. Se os valores 
    /// ultrapassarem os limites definidos, a API retornará um erro 400 (Bad Request).
    /// </summary>
    public class ApiConfig
    {
        public double MaxTemperatura { get; set; }
        public double MaxPressao { get; set; }
    }
}
