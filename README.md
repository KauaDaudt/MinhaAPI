# 🚗 MinhaAPI - Gerenciamento Completo de Veículos e Administradores

[![.NET](https://img.shields.io/badge/.NET-9.0-blue)](https://dotnet.microsoft.com/)  
[![MySQL](https://img.shields.io/badge/MySQL-8.0-blue?logo=mysql&logoColor=white)](https://www.mysql.com/)  
[![Swagger](https://img.shields.io/badge/Swagger-API-green?logo=swagger&logoColor=white)](https://swagger.io/)  
[![JWT](https://img.shields.io/badge/JWT-Authentication-orange)](https://jwt.io/)

Oi! 👋 Bem-vindo ao **MinhaAPI**, uma API feita em **C# (.NET 9)** que permite **cadastrar, listar, buscar, atualizar e apagar veículos**, além de gerenciar administradores de forma prática e segura.  

Ela integra com **MySQL**, usa **JWT Bearer** para autenticação, gera arquivos **JSON** com os dados dos veículos e ainda possui documentação pronta com **Swagger**.  

Repositório no GitHub: [https://github.com/KauaDaudt/MinhaAPI](https://github.com/KauaDaudt/MinhaAPI)

---

## 💡 Funcionalidades da API

MinhaAPI possui duas grandes áreas de funcionalidade:

### 👤 Administradores

- 🔐 **Login de administrador** com JWT  
- ➕ **Cadastro** de novos administradores  
- 📋 **Listagem** de todos os administradores  
- 🔍 **Busca** de administrador por ID  
- 🗑 **Apagar** administradores cadastrados  

### 🚗 Veículos

- ➕ **Cadastrar veículo**  
- 📄 **Listar todos os veículos**  
- 🔍 **Buscar veículo por ID**  
- ✏️ **Atualizar veículo**  
- 🗑 **Apagar veículo**  
- 💾 Todas as operações são registradas no **banco de dados** e geram arquivos **JSON** para controle externo  

> Observação: a API permite **gerenciamento completo de veículos**, funcionando como um sistema de armazenamento junto com o banco de dados.

---

## 🛣 Rotas da API

### Administradores

| Método | Rota | Descrição |
|--------|------|-----------|
| POST   | `/administradores/login` | Login de administrador (gera JWT) |
| GET    | `/administradores` | Listar todos os administradores |
| GET    | `/administradores/{id}` | Buscar administrador por ID |
| POST   | `/administradores/cadastrar` | Cadastrar novo administrador |

### Veículos

| Método | Rota | Descrição |
|--------|------|-----------|
| POST   | `/veiculos/cadastrar` | Cadastrar veículo e gerar JSON |
| GET    | `/veiculos/listar` | Listar todos os veículos |
| GET    | `/veiculos/listar/{id}` | Buscar veículo por ID |
| PUT    | `/veiculos/atualizar/{id}` | Atualizar veículo e atualizar JSON |
| DELETE | `/veiculos/apagar/{id}` | Apagar veículo e atualizar JSON |

---

## 🔐 Autenticação

A API usa **JWT Bearer** para proteger rotas de administrador.

- Após login, você recebe um **token JWT** que deve ser enviado no cabeçalho `Authorization` em todas as rotas protegidas:

```
Authorization: Bearer <seu-token>
```

---

## ⚙️ Tecnologias usadas

- 💻 **C# / .NET 9**  
- 🐬 **MySQL**  
- 📦 **Entity Framework Core 9**  
- 🔐 **JWT Bearer**  
- 🛠 **Swagger**  
- 🚀 **API RESTful**

---

## 🚀 Como rodar a API

1. Clone o repositório:

```bash
git clone https://github.com/KauaDaudt/MinhaAPI.git
```

2. Configure o **banco de dados MySQL** e atualize a `ConnectionString` no `appsettings.json`.  

3. Restaure as dependências e rode a API:

```bash
dotnet restore
dotnet run
```

4. Abra o **Swagger** no navegador e teste todas as rotas:

```
http://localhost:<porta>/swagger
```

---

## 🗂 Estrutura do projeto

```
MinhaAPI/
│
├─ Controllers/          # Controladores e rotas
├─ Dominio/              # Entidades, DTOs e enums
├─ Infraestrutura/       # Contexto do banco e migrations
├─ Program.cs            # Configuração da API, rotas e JWT
├─ appsettings.json      # Configurações do MySQL e JWT
└─ ArquivosJSON/         # JSON gerado com dados dos veículos
```

---

Feito por Kauã Daudt Gomes 👨‍💻
