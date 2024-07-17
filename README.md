# estudanteCRUD
Aplicação web que permita gerenciar informações de estudantes, incluindo listagem, adição, atualização e exclusão de registros. A aplicação é composta por uma WebAPI desenvolvida com .NET 6.

Framework: .NET 6.

Entity Framework: EF Core com banco de dados em memória.

Autenticação: Autenticação básica (JWT).

Endpoints:

GET /api/students: Retorna todos os estudantes (autenticado).

GET /api/students/{id}: Retorna um estudante específico (autenticado).

POST /api/students: Cria um novo estudante (autenticado).

PUT /api/students/{id}: Atualiza um estudante existente (autenticado).

DELETE /api/students/{id}: Deleta um estudante (autenticado).

POST /api/auth/login: Autentica um usuário e retorna um token JWT.
