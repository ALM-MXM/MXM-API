
# DESAFIO MXM - MARCUS VOGADO

Recebi o desafio de criar uma API utilizando .NET + RabbitMQ , onde receberia um E-mail com os seguintes atributos: nome , email , e texto.
Que será enviado através de um formulário no um Front-end, ao receber o E-mail o mesmo será colocado em uma fila gerenciada pelo RabbitMQ para que outro desenvolvedor possa consumir a fila e realizar o disparo dos E-mails.

Algumas validações foram adicionas utilizando a biblioteca FluentValidator, estou validando:

Se o corpo(body) do E-mail possuí as principais tags HTML que são elas: <!DOCTYPE html>, <head> e <body>.

Se a mensagem não contém nenhum conteúdo impróprio. 








## Deploy

O deploy da API foi feito em:

```bash
  https://mxm-api.marcusvogado.com
```
A API está sendo consuminda em : 
```bash
  https://luiza-mxm-frontend.vercel.app/
```



## Stack utilizada
**Back-end:** API Web do ASP.NET Core 6 </br>
**Banco de Dados:**  MySql


## Arquitetura do Projeto

![image](https://github.com/ALM-MXM/MXM-API/assets/107502578/7b07c35a-fee7-49bb-9554-24f91443d622)



## Funcionalidades

- Recebimento de E-mails
- Envio de E-mails para uma fila (servidor) RabbitMQ na nuvem
- Validações de dados e de seu conteúdo (Verificação de palavrões e conteúdo impróprio)
- Cadastro de Usuário (via swagger ou postman/ Insomnia ) 
- Autenticação e Autorização (Uso de JWT Web Token) 
- Registro de Logs, obtendo IP do usuário que fez a requisição e armazenando o conteúdo no Banco de Dados.



## Dependências

Você vai precisar adicionar as seguintes Biblíotecas

`RabbitMQ.Client`

`FluentValidation`

`Microsoft.AspNetCore.Authentication.JwtBeare`

`Microsoft.AspNetCore.Identity.EntityFrameworkCore`

`Microsoft.EntityFrameworkCore`

`Microsoft.EntityFrameworkCore.Tools`

`Microsoft.EntityFrameworkCore.Design`

`Microsoft.Extensions.Hosting.Abstractions`

`MySql.EntityFrameworkCore`

`Newtonsoft.Json`
## Documentação da API

#### Envio de E-mail

```http
  POST /api/sendemail/send
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `Nome` | `string` | **Obrigatório**. Mínimo 3 Caracteres  |
| `EnderecoDestino` | `string` | **Obrigatório**. E-mail de Destino   |
| `Corpo` | `string` | **Obrigatório**.Tem que conter<!DOCTYPE html>, <head> e <body> em seu conteúdo.  |


#### Cadastrar um Usuário
```http
  POST /api/applicationUser/created
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `FirstName`      | `string` | **Obrigatório**. Mínimo 3 Caracteres|
| `LastName`      | `string` | **Obrigatório**. Mínimo 3 Caracteres |
| `Email`      | `string` | **Obrigatório**. Formato = exemplo@exemplo.com |
| `Password`      | `string` | **Obrigatório**. Deve conter 1 caractere especial, 1 Letra Maiúscula , 1 Letra minúscula, 1 número e no mínimo 8 caracteres |





#### Realizar Autenticação

```http
  POST /api/auth/auth
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Email`      | `string` | **Obrigatório**. |
| `Senha`      | `string` | **Obrigatório**. |


#### Consultar os Logs por período
```http
  GET /api/log/period
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `DataInicial`      | `string` | **Obrigatório**. Formato = 20-04-2024 |
| `DataFinal`      | `string` | **Obrigatório**. Formato = 25-04-2024 |

## Autor

- [@MarcusVogado](https://github.com/MarcusVogado)

