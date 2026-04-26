<h1 align='center'>🏭 SIMI - Sistema Integrado de Monitoramento Industrial</h1>

A **API de Processamento** é o núcleo do Sistema Integrado de Monitoramento Industrial, responsável por receber, validar e armazenar os dados de sensores (temperatura e pressão).

- Aluno: Maycon Siqueira
- Instrutor: Fred Aguiar
- Curso: Desenvolvimento de Sistemas - SENAI Nova Lima MG

---

<h1 align='center'>📌 Endereços de Acesso</h1>

* **Base URL (Desenvolvimento):** `http://localhost:5022` ou `https://localhost:7257`
* **Documentação Swagger:** `/documentacao`

---

<h1 align='center'>🛠️ Tecnologias Utilizadas</h1>

* **.NET 8.0**
* **Entity Framework Core** com **SQLite**
* **Swagger (Swashbuckle)** para documentação

---

<h1 align='center'>📑 Endpoints da API</h1>

A API utiliza a rota base: `api/v1/sensores`.

### 1. Listar Dados dos Sensores
Retorna o histórico completo de todas as leituras armazenadas no banco de dados.

* **Método:** `GET`
* **Rota:** `/api/v1/sensores`
* **Resposta de Sucesso:**
    * **Código:** `200 OK`
    * **Corpo:** Lista de objetos `SensorData`.

**Exemplo de Resposta:**
```json
[
  {
    "id": 1,
    "temperatura": 72.5,
    "pressao": 5.8,
    "timestamp": "2026-04-26T13:05:36.3621607"
  },
  {
    "id": 2,
    "temperatura": 45.0,
    "pressao": 4.2,
    "timestamp": "2026-04-26T13:05:50.8103464"
  }
]
```

---

### 2. Receber Dados do Sensor
Recebe uma nova leitura, valida se os valores estão dentro dos limites configurados e salva no banco de dados.

* **Método:** `POST`
* **Rota:** `/api/v1/sensores`
* **Parâmetros (Corpo da Requisição):**

| Campo         | Tipo       | Descrição                  |
| :------------ | :--------- | :------------------------- |
| `temperatura` | `double`   | Valor da temperatura em °C |
| `pressao`     | `double`   | Valor da pressão em bar    |
| `timestamp`   | `DateTime` | Data e hora da leitura     |

**Exemplo de Requisição (JSON):**

```json
{
  "temperatura": 65.4,
  "pressao": 7.2,
  "timestamp": "2026-04-26T13:50:00"
}
```

* **Respostas:**
    * **`200 OK`**: "Dados do sensor recebidos com sucesso!"
    * **`400 Bad Request`**: "Temperatura acima do limite permitido!" ou "Pressão acima do limite permitido!"

---

<h1 align='center'>⚙️ Regras de Negócio e Configuração</h1>

A API possui um sistema de validação baseado em limites máximos definidos no arquivo `appsettings.json`.

* **Limites Padrão:**
    * **Temperatura Máxima:** 80 °C
    * **Pressão Máxima:** 8.5 bar

Se um sensor enviar um valor superior a esses limites, a API rejeitará a entrada para garantir a segurança industrial.

---

<h1 align='center'>🗄️ Persistência de Dados</h1>
Os dados são persistidos em um arquivo de banco de dados local chamado `sensores.db` utilizando SQLite. 
A estrutura da tabela principal (`Sensores`) inclui os campos `Id` (Chave Primária), `Temperatura`, `Pressao` e `Timestamp`.

---
