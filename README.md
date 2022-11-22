![image](https://user-images.githubusercontent.com/98191980/201112306-393edb45-275e-4d8b-9913-41f72b642dcf.png)

<img src="https://img.shields.io/static/v1?label=by&message=Alura&color=blue&style=for-the-badge"> <img src="https://img.shields.io/static/v1?label=Tech&message=.NET 6.0&color=00BFFF&style=for-the-badge&logo=.NET"> <img src="https://img.shields.io/static/v1?label=Tech&message=C%23&color=00BFFF&style=for-the-badge&logo=csharp">

# Descrição do sistema

O projeto se trata de uma API Rest com .NET 6.0 básica de filmes utilizando EFCore 6.0, conectada a um banco de dados MySQL. Como referência foi-se utilizado um projeto da Alura, construído na versão 5.0 do .NET.

# Sobre o curso

- Preparação do ambiente Linux e Windows;
- Validação de parâmetros com o uso de **annotations** e restrições;
- Retornos baseados no tipo da requisição;
- Instação de pacotes pelo NuGet;
- Abrindo conexão da API com o Banco de dados;
- Gerando e modificando migrations;
- Utilizando DbContext para alterações no banco;
- Utilizando AutoMapper e DTO's;

# Executando

## 🔗 EndPoint

```
localhost/filme
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





