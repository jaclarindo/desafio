# CRUD de Pedidos em .NET Core 6.0

## Descrição do Projeto

Este projeto consiste no desenvolvimento de uma API back-end utilizando .NET Core 6.0, que implementa um CRUD (Create, Read, Update, Delete) de pedidos. A base de dados utilizada é o SQL Server.

## Objetivos

- Desenvolver uma API back-end para gerenciamento de pedidos.
- Implementar operações de CRUD para pedidos.
- Utilizar SQL Server como base de dados.
- Aplicar DDD usando o padrão CQRS com Mediator.

## Tecnologias Utilizadas

- .NET Core 6.0
- SQL Server
- Docker 

## Estrutura do Projeto

- **Controllers:** Contém os controladores da API.
- **Models:** Contém as classes de modelo de dados.
- **Repositories:** Contém as classes de acesso a dados.
- **Services:** Contém a lógica de negócios.
- **Migrations:** Contém as migrações para criação e alteração da base de dados.

## Instalação do SQL Server no Docker

- Baixar a imagem:
  docker pull mcr.microsoft.com/mssql/server:2019-latest

- Criar o container:
  docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Desafio1!" -p 1450:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest

## Arquitetura utilizada

Utilizou-se o padrão CQRS que propõe a separação das operações de leitura (queries) das operações de escritas ou as que tem intenção de mudança	(command). Utilizado a biblioteca Mediatr para o padrão Mediator o qual promove o desacoplamento entre os componentes do sistema.
Para manipulação dos dados, utiliza-se o Entity Framework com o padrão Unit of Work para que seja tratado as operações do banco de dados como uma única unidade de trabalho garantindo a consistencia dos dados durante as operações de CRUD.

## Instruções de Instalação

1. **Clone o repositório:**

   ```sh
   git clone https://github.com/jaclarindo/desafio.git
