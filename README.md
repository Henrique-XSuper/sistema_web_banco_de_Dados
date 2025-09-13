# Sistema de Consórcio ASP.NET Core MVC
---
Este projeto é um sistema web desenvolvido com ASP.NET Core MVC, voltado para gerenciamento de consórcios de bens como carros, casas e outros produtos diversos. <br>
O sistema permite o cadastro de usuários, postagem de produtos, simulação de compra e armazenamento de dados em banco de dados.

---
 ## Funcionalidades
 ---
 
### 🏷Cadastro de Produtos

Postagem de produtos como:

- Carros
- Casas
- Itens diversos (eletrodomésticos, terrenos, motos, etc.) <br><br>
Cada produto contém:<br>
  Nome <br>
  Descrição<br>
  Imagem<br>
  Valor estimado<br>
  Categoria<br>
  
---

 ## Simulação de Compra
 
Simulação de parcelas de consórcio com base no valor do produto.<br>
Escolha de planos com diferentes prazos e taxas.<br>
Visualização de parcelas mensais e totais.<br>

---

### 📊 Armazenamento de Dados

Utilização de Entity Framework Core para persistência. <br>
Banco de dados relacional (SQL Server ou SQLite).<br>
Tabelas para usuários, produtos, planos e simulações.<br>

---
### 🛠️ Administração

Painel administrativo para gerenciar produtos e usuários.<br>
Aprovação ou rejeição de produtos postados.<br>
Relatórios de simulações e cadastros.<br>

---

### 🧰 Tecnologias Utilizadas
ASP.NET Core MVC <br>
Entity Framework Core<br>
SQL Server / SQLite<br>
Bootstrap para layout responsivo<br>
Razor Pages para renderização dinâmica<br>
Identity para autenticação<br>
