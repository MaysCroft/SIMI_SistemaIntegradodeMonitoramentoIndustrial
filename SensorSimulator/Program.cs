using System.Net.Http.Json;
using Shared;

var http = new HttpClient();
int index = 0;

while (true)
{
    var sensor = new SensorData
    {
        Id = index,
        Temperatura = new Random().Next(20, 100),
        Pressao = new Random().Next(1, 10),
        Timestamp = DateTime.Now
    };

    var response = await http.PostAsJsonAsync(
        "https://localhost:7257/api/v1/sensores", sensor);

    if (!response.IsSuccessStatusCode)
    {
        var erro = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Erro: {response.StatusCode} - {erro}");
    }
    else
    {
        Console.WriteLine($"Enviado: Temperatura: {sensor.Temperatura} - Pressão: {sensor.Pressao}");
    }

    await Task.Delay(2000);
    index++;
}