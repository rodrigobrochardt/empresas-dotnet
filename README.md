# Desafio Pessoa Desenvolvedora .NET

## ⚙️ Como configurar o banco para usar?

- Modifique a variavel connectionString no locadora-filmes.INFRA > Data > Context > SqlServerContext

# 🚨 Requisitos

- A API construída em .NET Core. ✔️
- Autenticação ***JWT*** ***Bearer***. ✔️
- Implementar utilizando Entity Framework Core. ✔️
- Utilizando Sql Server. ✔️
- Entidades criadas utilizando ***Code First***. ✔️
- Padrão REST. ✔️
- Conter documentação viva utilizando ***Swagger***. ✔️

# 🏗️ Funcionalidades

- Administrador
    - Cadastro
    - Edição
    - Exclusão lógica (desativação)
    - Listagem de usuários não administradores ativos
        - Opção de trazer registros paginados
        - Retornar usuários por ordem alfabética
- Usuário
    - Cadastro
    - Edição
    - Exclusão lógica (desativação)
- Filmes
    - Cadastro (somente um usuário administrador poderá realizar esse cadastro)
    - Voto (a contagem de votos será feita por usuário de 0-4 que indica quanto o usuário gostou do filme)
    - Listagem
        - Opção de filtros por diretor, nome, gênero e/ou atores
        - Opção de trazer registros paginados
        - Retornar a lista ordenada por filmes mais votados e por ordem alfabética
    - Detalhes do filme trazendo todas as informações sobre o filme, inclusive a média dos votos
