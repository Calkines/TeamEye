# Sobre o Projeto

Dado um conjunto de informações tabulares é necessário interpretar seu conteúdo, disponibilizando o resultado em API de maneira consolidada.

## Considerações sobre o uso

Para usar este projeto, existe a url [https://teameye.azurewebsites.net/swagger], que expoe a api juntamente com o Swagger, onde todas rotas podem ser consumidas e testadas; ou você pode fazer um fork, e definir o projeto de api como padrão executando pelo VS ou outro IDE.

Caso deseje utilizar o fork, basta configurar a string de conexão para o seu banco de dados e utilizra a rota de saída+porta seguido de /swagger, por exemplo: localhost:5000/swagger.

Tanto da primeiro quanto na segunda forma, uma página de descricao da API será apresentada. Utilize a rota /api/Leitor para enviar arquivos texto. Após uma resposta com status 200, as demais rotas deverão responder com as informações preenchidas.

## Considerações sobre os documentos

Abaixo estão os pontos entregues juntamente com o pedido de elaboração do desafio. Todos os pontos possuem alguma consideração. Quando isso acontece um prefixo "C" foi adicionado seguido pelo número sequencial do item que está sendo considerado. As considerações são simplemente comentários sobre o porquê da decisão ter sido aquela, e um marcador de conclusão ("Done").

### Requisitos ténicos

```
1 - Linguagem .NetCore 2.2 ou superior.
    C1.1 -  O projeto foi construído utilizando o framework .NET Core 3.1, 
            porque esta versão encontra-se em versão LTS (Long Term Support).
            Done.
2 - O codigo deve ser salvo no github do candidato.
    C2.1 -  Done.
3 - Gerar um arquivo readme com explicação referente ao codigo.
    C3.1 -  Done.
4 - Incluir testes unitários.
    C4.1 -  Técnicas usadas na construção "Vermelho-Verde-Refatorar", "Dado-Quando-Então" e 
            "AAA".
            Usado pacote MOQ para para necessidades de mock.
            Faltou tempo para expansão dos testes para mais camadas, incluindo
            a de controller :/
            Done.
5 - Geração de logs para rastreamento.
    C5.1 -  Alguns logs foram gerados usando o objeto built-in do .NET.
```

### Dicas oferecidas com o projeto

```
1 - Alguns clubes possuem grafia diferente. É necessario padronizar. (Acento, abreviação, etc..)
    C1.1 -  Resolvido com dicionário. Talvez uma outra abordagem de consulta
            a serviços de terceiro e validando proximidade do texto pudesse ser
            usada, mas pelo tempo foi utilizada essa forma.
            Done.
2 - Entrada/Saída pode ser em qualquer formato de preferência (json, xml, txt, etc..)
    C2.1 -  A saída pode ser serializada para qualquer um desses, embora hoje
            hoje esteja como default para json. A entrada depende de extensão
            através de criação de leitores específicos, implementando a interface
            ILeitorDadosCampeonato.
            Done.
3 - O projeto pode ser desenvolvido webservice soap, uma api, console, etc. 
    C3.1 -  O projeto está sendo exposto através de api, com swagger.
            Done.
4 - A qualidade do código é essencial:
  4.1: Não esqueça do tratamento de erro.
    C4.1 -  Erros foram tratados, mas várias partes do código ainda precisam
            de atenção, neste quesito.
            Done.
  4.2: Variaveis locais e privadas, adotar um padrão. Exemplo: CamelCase.
    C4.2 -  privadas usado _camelCase, métodos PascalCase, Props PascalCase, 
            constantes MAIUSCULO.
            Done.
  4.3: Interfaces, Eventos e metodos adotar um padrão. Exemplo: PascalCase.
    C4.3 -  Padrão adotado letra de prefixo mais: IPascalCase.
            Done.
  4.4: Constantes em maiusculo, exemplo: TIME_SP_CORINTHIANS, TIME_RJ_VASCO, TIME_SP_SANTOS, ETC...
    C4.4 -  Aplicado na classe estática de Regras, que tem como responsabilidade
            manter as constantes da applicação.
            Classe de constantes não foi usada.
            Done.
5 - Evite escrever métodos muito longos.
    C5.1 -  Done.
6 - O nome do método, variaveis, interfaces devem dizer o que ele faz. 
    C6.1 -  Done.    
7 - Utilize boas praticas, por exemplo: clean code, solid, etc
    C7.1 -  Done.
```

### Retornos esperados

```
1 - É esperado o seguinte retorno por time:

Posição
    C - Devolvido posição média.    
Nome do Time
    C - Devolvido nome normalizado.
Pontuação total
Qtde de campeonatos disputados
Total de Jogos
Total de Vitorias
Total de Empates
Total de  Derrotas
Total de Gols Prós
Total de Gols Contras
Saldo de gols
    C - calculado.

(Done)
```

```
2 - É esperado o seguinte retorno por estado:

Posição
Estado
Pontuação total
Qtde de campeonatos disputados
Total de Jogos
Total de Vitorias
Total de Empates
Total de Derrotas
Total de Gols Prós
Total de Gols Contra
Saldo de Gols
(Done)
```

```
3 - Informações complementares:

Time com melhor (maior) média de gols a favor.
Time com melhor (menor) média de gols contra.
Time com maior numero de vitórias
Time com menor numero de vitórias
Time com melhor média de vitorias por campeonato
    C - Este item não tinha ficado muito claro, mas como não tinha como esclarecê-lo a tempo, implementei como parecia fazer mais sentido.
Time com menor média de vitórias por campeonato
    C - Este item não tinha ficado muito claro, mas como não tinha como esclarecê-lo a tempo, implementei como parecia fazer mais sentido.

(Done)
```
