![image](https://user-images.githubusercontent.com/98191980/208100235-0f34b50d-2180-4142-9dee-1114c5582877.png)

<img src="https://img.shields.io/static/v1?label=by&message=Alura&color=blue&style=for-the-badge"> <img src="https://img.shields.io/static/v1?label=Tech&message=.NET 6.0&color=purple&style=for-the-badge&logo=.NET"> <img src="https://img.shields.io/static/v1?label=Tech&message=C%23&color=purple&style=for-the-badge&logo=csharp">

# Descrição do projeto

O projeto se trata de uma API Rest (.NET 6.0) com sistema de autorização de usuários e política de acesso feitas com o pacote Identity.  

# Sobre o curso

- Ocultação de dados sensíveis por meio de secrets
- Fluxo de redefinição de senha de usuários
- Integração de aplicações no Visual Studio
- Utilização de roles para autorização
- Implementação de conceitos de autorização
- Políticas customizadas de acesso

# Executando

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
