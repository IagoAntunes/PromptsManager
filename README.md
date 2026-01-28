<p align="center">
  <a href="#-português">🇧🇷 Português</a>
  <span>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;</span>
  <a href="#-english">🇺🇸 English</a>
</p>

<p align="center">
  <!-- Badges do Frontend -->
  <img src="https://img.shields.io/badge/Angular-%23DD0031.svg?style=for-the-badge&logo=angular&logoColor=white" alt="Angular Badge" />
  <img src="https://img.shields.io/badge/TypeScript-3178C6.svg?style=for-the-badge&logo=typescript&logoColor=white" alt="Typescript Badge" />
  <img src="https://img.shields.io/badge/Bootstrap-7952B3.svg?style=for-the-badge&logo=bootstrap&logoColor=white" alt="Bootstrap Badge" />
  <!-- Badges do Backend -->
  <img src="https://img.shields.io/badge/.NET-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Badge" />
  <img src="https://img.shields.io/badge/C%23-239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C# Badge" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927.svg?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server Badge" />
</p>


<p align="center">
  <img width="1920" height="1080" alt="Cover (16)" src="https://github.com/user-attachments/assets/8910ab57-445e-403c-b73e-4feadc43a36c" />
</p>

---

## 🇺🇸 English

### 🛠️ Project Description

**PromptsManager** is a full-stack web application designed to help users create, manage, and organize their personal AI prompts.  
It features a secure authentication system (using **JWT**) and a dedicated dashboard for full **CRUD** (Create, Read, Update, Delete) operations on user-specific prompts.

### 🧰 Tools and Technologies Used

#### Frontend
- **Angular 🅰️** — SPA framework for the user interface.  
- **TypeScript ⌨️** — Main frontend programming language.  
- **HTML & SCSS 🎨** — Structure and styling of the application.  
- **Bootstrap & ng-bootstrap 🅱️** — Component library and responsive grid system.  
- **RxJS ⚡** — For asynchronous operations and state management.  

#### Backend
- **ASP.NET Core 🚀** — Framework for building the REST API.  
- **C# ♯** — Main backend programming language.  
- **Entity Framework Core 💾** — ORM for data access with SQL Server.  
- **SQL Server 🗃️** — Relational database.  
- **JWT (JSON Web Tokens) 🔑** — For securing the API endpoints.  

### 🏛️ Project Architecture

The project follows a **monorepo-style structure** with a clear separation between frontend and backend applications.

#### Angular Frontend Architecture
The frontend follows best practices for scalability and maintenance:

- **CoreModule** — Provides singleton services (`AuthService`, `PromptService`), HTTP Interceptors (for JWT), and Route Guards (for auth).  
- **SharedModule** — Contains reusable components (like `CustomInputComponent`) and imported UI modules (`ng-bootstrap`, etc.).  
- **Feature Modules** — Lazy-loaded modules:
  - `AuthModule`: Login and Registration pages.  
  - `HomeModule`: Main dashboard, sidebar layout, and prompt management.  
- **Reactive Forms** — Used for robust form handling and validation.

#### ASP.NET Core Backend Architecture
The backend is built following a **Clean Architecture (4-layer)** pattern:

- **API** — Entry point containing Controllers, DTOs (Request/Response), and service registration.  
- **Application** — Business logic, services, and interfaces (e.g. `IPromptService`).  
- **Infrastructure** — Implements `Application` layer interfaces. Contains Repositories, DbContext (Entity Framework), and service implementations (e.g. `TokenService`).  
- **Domain** — Core of the app with Entities, Repository Interfaces, and custom Domain Errors.  

---

## 🇧🇷 Português

### 🛠️ Descrição do Projeto

**PromptsManager** é uma aplicação web full-stack projetada para ajudar usuários a criar, gerenciar e organizar seus prompts pessoais de IA.  
O projeto possui um sistema de autenticação seguro (usando **JWT**) e um dashboard dedicado para operações **CRUD** (Criar, Ler, Atualizar, Deletar) completas dos prompts de cada usuário.

### 🧰 Ferramentas e Tecnologias Utilizadas

#### Frontend
- **Angular 🅰️** — Framework SPA para a interface do usuário.  
- **TypeScript ⌨️** — Linguagem principal do frontend.  
- **HTML & SCSS 🎨** — Estrutura e estilização da aplicação.  
- **Bootstrap & ng-bootstrap 🅱️** — Biblioteca de componentes e sistema de grid responsivo.  
- **RxJS ⚡** — Para operações assíncronas e gerenciamento de estado.  

#### Backend
- **ASP.NET Core 🚀** — Framework para a construção da REST API.  
- **C# ♯** — Linguagem principal do backend.  
- **Entity Framework Core 💾** — ORM para acesso a dados com o SQL Server.  
- **SQL Server 🗃️** — Banco de dados relacional.  
- **JWT (JSON Web Tokens) 🔑** — Para segurança dos endpoints da API.  

### 🏛️ Arquitetura do Projeto

O projeto é arquitetado com uma clara separação de responsabilidades, apresentando uma estrutura **monorepo-style** com aplicações frontend e backend distintas.

#### Arquitetura Frontend (Angular)
O frontend segue as melhores práticas para escalabilidade e manutenção:

- **CoreModule** — Fornece serviços singleton (`AuthService`, `PromptService`), HTTP Interceptors (para o JWT) e Route Guards (para autenticação).  
- **SharedModule** — Contém componentes reutilizáveis (como `CustomInputComponent`) e módulos compartilhados (como `ng-bootstrap`).  
- **Feature Modules** — Dividido em módulos com lazy-loading:
  - `AuthModule`: Gerencia as páginas de Login e Registro.  
  - `HomeModule`: Gerencia o dashboard principal, o layout com sidebar e o gerenciamento de prompts.  
- **Reactive Forms** — Usado para manipulação e validação robusta de formulários.

#### Arquitetura Backend (ASP.NET Core)
O backend segue o padrão **Clean Architecture** com 4 camadas:

- **API** — Ponto de entrada, contendo Controllers, DTOs (Request/Response) e registro de serviços.  
- **Application** — Contém a lógica de negócio, serviços e interfaces (ex: `IPromptService`).  
- **Infrastructure** — Implementa as interfaces da camada `Application`. Contém os Repositories, o DbContext (Entity Framework) e implementações como `TokenService`.  
- **Domain** — Núcleo da aplicação. Contém as Entidades, Interfaces de Repositórios e Erros de Domínio personalizados.  

---

<p align="center">
  <a href="#-português">⬆️ Voltar ao topo</a>
</p>
