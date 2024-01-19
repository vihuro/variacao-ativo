
# API Variação de Ativo

Bem-vindo(a) à API de Variação de Ativo.

Esta API realiza consultas na [API Yahoo Finance](https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA) e armazena as informações em um banco de dados PostgreSQL para consulta posterior.

A API possui um serviço em segundo plano (background), conhecido como workservice, responsável por atualizar automaticamente a base de dados a cada 2 minutos. Dessa forma, as informações estão sempre sincronizadas com os dados mais recentes disponíveis.

Adicionalmente, oferecemos a flexibilidade de atualizar manualmente os valores quando necessário, acessando o método GET na URL padrão da API.

Estamos comprometidos em proporcionar uma experiência eficiente e atualizada para suas necessidades de variação de ativos. Em caso de dúvidas ou necessidades adicionais, não hesite em entrar em contato conosco.

O método GET na URL padrão retornará informações sobre a ação PETRA4, incluindo a variação dos últimos 30 lançamentos.

A API está acessivel na porta 2525 do servidor local. 


## Deploy

Para fazer o deploy desse projeto você só precisa ter o docker instalado na sua máquina.
Rode o comando para poder fazer um clone do projeto na sua máquina local.

```bash
  git clone https://github.com/vihuro/variacao-ativo.git
```


Após fazer o clone em sua máquina, entre na pasta VariacaoAtivo. Será possivel identificar um arquivo "docker-compose.yml". Abra terminal e rode o comando:

Linux
```bash
docker-compose up 
```
Window
```bash
docker compose up
```
Esse comando, irá iniciar os seguintes containers:  
API Variação-Ativo,  
PostgreSQL usando um volume local que será criado a usar o comando

A API está preparada para que, ao subir o serviço de banco de dados, seja realizado as migrations no banco, corretamente.


## Documentação da API

#### Retorna todos os itens para um gráfico

```http
  GET /api/v1/Chart
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `int` | **Obrigatório**. A chave da sua API |
|`currency`|`string`|Moeda|
|`symbol`|`string`|Símbolo da cotação|
|`ExachangeName`|`string`|Local da bolsa|
|`exchangeTimeZone`|`date`|Local do TimeZone|
|`regularMarketPrice`|`double `|Último preço negociado|
|`chartPreviousClose`|`double `|Preço de fechamento do ativo|
|`previousClose`|`double `|Preço de fechamento do dia anterior|
|`previousClose`|`double `|Preço de fechamento do dia anterior|
| `quoteOpen`         | `list<object>`  | Lista de objetos contendo informações sobre a abertura do mercado |
| `quoteOpen.quoteOpen` | `double`      | Preço de abertura do mercado          |
| `quoteOpen.variacao` | `double`       | Variação em relação ao preço anterior |

#### Atualiza manualmente os dados do banco de dados

```http
  PUT /api/v1/Chart
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `int` | **Obrigatório**. A chave da sua API |
|`currency`|`string`|Moeda|
|`symbol`|`string`|Símbolo da cotação|
|`ExachangeName`|`string`|Local da bolsa|
|`exchangeTimeZone`|`date`|Local do TimeZone|
|`regularMarketPrice`|`double `|Último preço negociado|
|`chartPreviousClose`|`double `|Preço de fechamento do ativo|
|`previousClose`|`double `|Preço de fechamento do dia anterior|
| `quoteOpen`         | `list<double>`  | Lista de preços de abertura do mercado |
| `quoteHigh`         | `list<double>`  | Lista de preços máximos do mercado |
| `quoteLow`         | `list<double>`  | Lista de preços mínimos do mercado |
| `quoteClose`         | `list<double>`  | Lista de preços de fechamento do mercado |

## Referência

 - [API Yahoo Finance](https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA)

