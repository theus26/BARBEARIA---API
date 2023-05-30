# API-BARBEARIA

Essa API foi desenvolvida para estudo e prática em .net6, usando o EntityFramework e alguns serviços de integração, como um serviço de envio de emails.
Essa aplicação integrada com sua interface, visa facilitar e melhorar o atendimento do usuário, para marcar e gerenciar melhor seu tempo, não precisando sair de sua casa, realizando os serviços de agendamentos pelo sistema Web.

Além disso esse sistema foi desenvolvido tanto pensando no usuario como no seu administrador, o administrador tem poder para realizar diversas coisas, são elas, finalizar um agendamento já realizado, ver todos os agendamentos, ver os agendamentos de cada barbeiro e algumas coisas mais.

## Tecnologias Utilizadas

* .NET 6
* Entity Framework
* MySQL

## Pré-requisitos

* [.NET 6 SDK](https://markdownlivepreview.com/).
* Laragon
* MySQL WorkBench
* Insomina

## Configuração

1. Clone o repositório:

```
git clone https://github.com/theus26/BARBEARIA---API
```

2. Acesse o diretório do projeto:

```
cd seu-repositorio
```

3. Configure as variáveis de ambiente necessárias.

```
ex: 
Nome Da Variável: NOME-VARIAVEL
Valor da Variavel: Server=localhost;Port=3306; DataBase=Barbearia; Uid=root; Pwd=; 
```


4. Execute os seguintes comandos para restaurar as dependências e iniciar a API:

```
dotnet restore
dotnet run
```

5. Acesse a API em http://localhost:porta, onde "porta" é a porta configurada para a sua API.

## Funcionalidades

A API tem diversas funcionalidades, ela realizar um CRUD de operações, Realizar Cadastramento de usuario, Agendamento para corte de Cabelo, Cancelamento do agendamento, editar e entre outras funcionalidades.


Exemplo:

* `POST /User/RegisterUser`: Criar Usuario
* `POST /User/Login`: Faz o Login do usuario através das suas credenciais de acesso.
* `POST /User/Scheduling`: Realizar o agendamento do usario
* `POST /User/GetSchedulingPerId`: Retornar todos os agendamentos do usuario pelo Id.

*Enfim, possuimos diversos outros endpoints para realizar o gerenciamento da aplicação.*





## Banco de Dados

O Entity Framework é uma estrutura de mapeamento de objeto/relacional. Ele mapeia os objetos de domínio em seu código para entidades em um banco de dados relacional. Na maior parte do tempo, você não precisa se preocupar com a camada de banco de dados, pois o Entity Framework cuida dela para você. Seu código manipula os objetos e as alterações são persistentes em um banco de dados.

Exemplo:

A API utiliza o Entity Framework para se comunicar com o banco de dados. O banco de dados padrão é o Mysql. Para configurar o banco de dados:

1. Crie em seu sistema a variavel de conexão, como mostrado no exemplo anterior, logo acima.

2. Antes de executar as migrations para gerar o banco de dados, certifique-se de o Laragon está rodando, instanciando a porta 3306, do MySQL e a sua connctionString, está correta, após isso execute:

```
dotnet ef database update
```
_Esse comando executará todas as migrations criadas e irá gerar toda parte do Banco de Dados._
