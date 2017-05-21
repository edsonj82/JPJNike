**API MASSA - Log John Paul Jonnes - NIKE**


Operações:
- Mostrar todas corridas - OK
- Mostrar uma corrida - busca por id - OK
- Registrar nova corrida - OK
- Atualizar corrida - OK
- Excluir corrida - OK
- Mostrar corridas do ultimo mes - OK
- Mostrar última corrida registrada - OK

----------------------------

    Corrida
    {
        id - integer
        tempo total (minutos) - double
        tempo total segundos - integer
        data - datetime
    }


----------------------------
Rotas
- recursos
- verbos
- headers

Base de Dados
- entityframeworkcore
- xml datasource - OK


ORM
Object Relationship Model
- Mapeia models csharp para tabelas sql
- Criar e gerencia o banco de dados (cria tabelas, deleta, altera)
- Gerencia versao do database
- baseia-se bastante em linq


-----------------------------

**API MASSA - Log John Paul Jonnes - NIKE**

*Model*

    class Exercicio
    {
        id integer
        string nome
        int quantidade
        int series
    }


*Tabela*

    Table Exercicio
        (int) id
        (varchar) nome
        (int) quantidade
        (int) series

-------------------------------
