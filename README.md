# access-management-csharp

Sistema de controle de acesso

* Criar um sistema para gerenciar acessos de usuários
* Tabelas:
    * Usuários
        * id - int
        * nome - string
        * email - string
        * senha - string
    * Perfil
        * id - int
        * usuario_id - int
        * perfil (admin, user) - string ou enum
    * Sessões
        * id - int
        * usuario_id - int
        * token - string
        * data_criacao - DateTime
        * data_expiracao - DateTime (null)
    
* Criar usuário: CRUD de Usuários
  * Criar usuário ☑
  * Alterar usuário ☑
  * Excluir usuário ☑
  * Listar usuário ☑ - Exibir informação de Perfil ☑ 
  * Contabilizar quantos usuários são user e admin ☑ - Exibir na lista de usuários 
  * * Contabilizar quantas sessões totais e quantas ativas ☑ - Exibir na lista de usuários
* Definir Perfil: CUD de Perfil
  * Criar perfil para usuário ☑ - Validar se usuário já não tem perfil ☑
  * Alterar perfil ☑
  * Excluir perfil ☑
* Criar Sessão: CRD de Sessões
  * Criar Login ☑: Autenticação de Usuário ☑
  * Criar Logout ☑: Remover Sessão ☑
  * Listar sessões ☑
    * Imprimir usuário está logado ☑
    * Imprimir se usuário é admin ou user ☑
  * Criar Middleware: Verificar se usuário está logado
  * Criar Middleware: Verificar se usuário é admin
  * Criar Middleware: Verificar se usuário é user
