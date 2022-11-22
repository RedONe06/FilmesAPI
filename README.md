![image](https://user-images.githubusercontent.com/98191980/203300712-ecf5a4d6-0c66-4ac8-91ff-cbfcace233f4.png)

<img src="https://img.shields.io/static/v1?label=by&message=Alura&color=blue&style=for-the-badge"> <img src="https://img.shields.io/static/v1?label=Tech&message=.NET 6.0&color=green&style=for-the-badge&logo=.NET"> <img src="https://img.shields.io/static/v1?label=Tech&message=C%23&color=green&style=for-the-badge&logo=csharp">

# Descrição do sistema

O projeto se trata de uma API Rest com .NET 6.0 utilizando EFCore 6.0, conectada a um banco de dados MySQL. Neste projeto existem 5 tipos de entidades: Cinemas, Gerentes, Filmes, Endereços e Sessões. Abaixo, segue um diagrama do banco:

![Entitys drawio](https://user-images.githubusercontent.com/98191980/203301373-6fec1eee-32db-4f36-a5a7-6831a09ebaa4.png)

Como referência foi-se utilizado um projeto da Alura, construído na versão 5.0 do .NET.

# Sobre o curso

- Utilização do **AutoMapper** para mapear entidades;
- Execução de relacionamentos **1:1, 1:n, n:n**;
- Utilização de **Lazy Loading Proxies** para o carregamento de informações em tempo de execução;
- Alterações nas migrations com **ModelBuilder**;
- Evitando ciclos com **JsonIgnore**;
- Evitar **deleção em cascata**;
- Uso de **DTO's** para o gerenciamento de informações;
- Métodos utilizando **query parameters e LINQ**;

# Executando

## 🔗 EndPoints

```
localhost/filme
localhost/gerente
localhost/sessao
localhost/endereco
localhost/cinema
```
## ⚙ Downloads

- Para fazer as requisições: [Postman](https://www.postman.com/);
- Banco de dados: [MySQL WorkBench (v.8.0)](https://dev.mysql.com/downloads/workbench/);
- Servidor: [Xampp (v.3.3)](https://www.apachefriends.org/download.html);

## 🖥 Run

### Subindo o servidor

Ativar as portas do Apache e MySQL no Xampp;

### Criando a conexão no banco

Criar uma conexão no Workbanch de senha e usuário _root_;

### Update na Migration

Para criar a database localmente, executar o seguinte comando no cmd:

```
dotnet ef database update
```
**Obs:** Caso o comando não esteja disponível, verificar a documentação do EF Core: [Entity Framework Core tools reference - .NET Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Rodando o programa

Executar de acordo com a IDE ou editor de códigos;

### Fazendo requisições

Fazer requisições de _GET, GET/id, POST, PUT, DELETE_ para o endpoint a partir do Postman;







