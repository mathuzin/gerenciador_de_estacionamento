# Gerenciador de Estacionamento

Sistema web para controle de entrada e saída de veículos em um estacionamento, com cálculo automático do valor a pagar baseado em uma tabela de preços parametrizável por período de vigência.

## Tecnologias utilizadas

- C#
- ASP.NET Core MVC
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MariaDB

## Como instalar e executar

### Pré-requisitos
- .NET 9 SDK
- MariaDB 

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/mathuzin/gerenciador_de_estacionamento.git
cd gerenciador_de_estacionamento
```

2. Crie o banco de dados no MariaDB e ajuste a connection string em `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=estacionamento;User=root;Password=SUASENHA;"
}
```

3. Crie as tabelas necessárias executando o script `database.sql` no seu banco MariaDB.

4. Restaure os pacotes e execute o projeto:
```bash
dotnet restore
dotnet run
```

5. Acesse `http://localhost:5093` no navegador.

---

This is a challenge by [Coodesh](https://coodesh.com/)
