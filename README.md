# .NET Core 5 MVC Rest API ###

Esse projeto é feito com base no curso que o Les Jackson disponibilizou no Youtube:
Link: https://www.youtube.com/watch?v=fmvcAzHpsk8

Esse projeto conta com o desenvolvimento de uma API Rest.
Durante o projeto nós contamos com o aprendizado de:
* Endpoints;
* Repository Pattern;
* Data Context;
* Interfaces (Contracts);
* Controllers;
* DI (Dependency Injection)
* Frameworks ORM (mais específico o Entity Framework para este projeto).
* DTO;
* Mapping;
* HTTP Verbs.

Os tópicos serão documentados de forma rápida apenas para que fique registrado, lembrando que o leitor precisa ter um conhecimento prévio para conseguir entender alguns termos que são extremamente importantes e muitas vezes complexos.

## Endpoints

Os endpoints é literalmente o "ponto final" é o Path que o Client irá fazer uma requisição e esse Path resultará no Endpoint com os verbos GET, POST, PUT, PATCH e DELETE. É através dos endpoints que é possível fazer as requisições para nossas APIs e assim aguardar o retorno.

## Repoistory Pattern

Esse pattern foi pensado com a ideia de criarmos uma interface de comunicação com os dados seja ela Excel, TXT, SQL ou Qualquer outra fonte. Geralmente para se usar o Repository Pattern utilizamos um Context que será a interface de conexão da aplicação com o provedor de dados. É muito importante ressaltar que o Context já possui uma interface de comunicação com os dados que funciona de forma similar ao Repository Pattern.
Neste projeto é utilizado o conceito de usar o Context diretamente sem precisar do uso de um Repository, como no vídeo o Les Jackson utiliza decidi deixar documentado aqui.

## Data Context

Como dito no tópico anterior, DataContext é a interface de comunicação da sua aplicação com a fonte de dados que foi escolhida, é nesse momento que abrimos as conexões, configuramos as entidades e assim por diante.

## Interfaces

É um meio de criarmos contratos para termos a certeza que qualquer classe que herdar dessa interface terá os campos obrigatórios presente no contrato. O conceito de interface está ligado também ao DIP (Dependency Inversion Principle) do SOLID, onde nossos detalhes devem depender de abstrações e no caso a abstração é a interface.

## DI (Dependency Injection)

A injeção de dependências vem atrelada ao uso de Interfaces, quando nós utilizamos interfaces no nosso projeto, as classes deixam de depender da implementação concreta e passa a depender de uma abstração, sendo assim qual é o valor que irá vir nessa interface? Na verdade tanto faz pois a interface irá garantir que o métodos que eu preciso vão estar implementados e a Injeção de Dependência é um modo de falar para o sistema que a interface X possui valor concreto Y, caso amanhã ou depois a interface X passe a ter o valor concreto Z nós vamos trocar em apenas um único lugar.

## Controllers

É o orquestrador da estrutura MVC, é ele que vai saber quais são os endpoints, ou seja, qual o Path e o Verbo utilizado para fazer determinada requisição. Também vai ser responsável por chamar os Repositórios, verificar se as informações enviadas pelo Client estão em um formato aceitável e irá retornar um valor para o Client seja esse valor uma View ou um JSON.

## Frameworks ORM

Foram desenvolvidos para facilitar a vida do desenvolvedor sendo o ORM um facilitador para a comunicação com o Banco de Dados. O ORM faz todo o processo de requisição para o banco de dados e trata o retorno do mesmo transformando isso em um objeto preparado para ser consumido.

## DTO

DTO é conhecido como Data Transfer Object ele é utilizado para deixarmos nossas entidades protegidas e até mesmo melhorar o retorno para o Client, ou seja, quando precisamos “ocultar” propriedades sensíveis da nossa entidade ou até mesmo diminuir a quantidade de propriedades que o Server irá retornar para o Client nós utilizamos um DTO para isso.

## Mapping

É o mapeamento realizado entre o DTO e a Entidade que ele representa, é um Pattern que facilita a transferência de informação de um objeto para outro.

## HTTP Verbs

São os verbos utilizados no protocolo HTTP e existem vários, porém os mais utilizados são GET, POST, PUT, PATCH e DELETE para não me estender e esse não é o objetivo vou explicar rapidamente. GET: Quando queremos buscar algo no servidor, nesse modo só conseguimos enviar informações pelo Path ou pelo Header. POST: Quando precisamos enviar alguma informação para o servidor, ela pode ser feita pelo Body. PUT: Quando precisamos atualizar alguma informação no servidor, ela pode ser feita pelo Body e lembrando que nesse caso o objeto inteiro é atualizado. PATCH: Quando precisamos atualizar apenas os campos que queremos, isso pode ser feito pelo Body e DELETE: Quando precisamos excluir algo no servidor, ele pode ser feito pelo Path ou Header.

Pacotes Utilizados nesse projeto:
    • Microsoft.EntityFrameworkCore.InMemory
    • AutoMapper.Extensions.Microsoft.DependencyInjection
    • Microsoft.AspNetCore.JsonPatch
    • Microsoft.AspNetCore.Mvc.NewtonsoftJson

Para quem quiser saber mais eu recomendo fortemente que deem uma conferida nos vídeos do canal desse autor.

OBS: Esse projeto conta com algumas liberdades poéticas minhas, ou seja, pequenas mudanças que fui realizando durante o processo para concretizar o meu conhecimento com o conhecimento apresentado neste curso.
