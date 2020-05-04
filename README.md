# Sobre o Projeto

Dado um conjunto de informações tabulares é necessário interpretar seu conteúdo, disponibilizando o resultado em API de maneira consolidada.

## Considerações sobre o uso

Para usar este projeto, existe a url [http://xpto.azurewebsites.net/swagger], que expoe a api juntamente com o Swagger, onde todas rotas podem ser consumidas e testadas; ou você pode fazer um fork, e definir o projeto de api como padrão executando pelo VS ou outro IDE.

## Considerações sobre os documentos

Abaixo estão os pontos entregues juntamente com o pedido de elaboração do desafio. Todos os pontos possuem alguma consideração. Quando isso acontece um prefixo "C" foi adicionado seguido pelo número sequencial do item que está sendo considerado. As considerações são simplemente comentários sobre o porquê da decisão ter sido aquela, e um marcador de conclusão ("Done").

### Requisitos ténicos

```
1 - Linguagem .NetCore 2.2 ou superior.
    C1.1 -  O projeto foi construído utilizando o framework .NET Core 3.1, 
            porque esta versão encontra-se em versão LTS (Long Term Support).
            Doing.
2 - O codigo deve ser salvo no github do candidato.
    C2.1 -  Doing.
3 - Gerar um arquivo readme com explicação referente ao codigo.
    C3.1 -  Doing.
4 - Incluir testes unitários.
    C4.1 -  Técnicas usadas na construção "Vermelho-Verde-Refatorar", "Dado-Quando-Então" e 
            "AAA".
            Usado pacote MOQ para para necessidades de mock.
            Doing.
5 - Geração de logs para rastreamento.
    C5.1 -  TODO.
```

### Dicas oferecidas com o projeto

```
1 - Alguns clubes possuem grafia diferente. É necessario padronizar. (Acento, abreviação, etc..)
    C1.1 -  TODO.
2 - Entrada/Saída pode ser em qualquer formato de preferência (json, xml, txt, etc..)
    C2.1 -  A saída pode ser serializada para qualquer um desses, embora hoje
            hoje esteja como default para json. A entrada depende de extensão
            através de criação de leitores específicos, implementando a interface
            ILeitorDadosCampeonato.
            Done.
3 - O projeto pode ser desenvolvido webservice soap, uma api, console, etc. 
    C3.1 -  O projeto está sendo exposto através de api, com swagger.
            Doing.
4 - A qualidade do código é essencial:
  4.1: Não esqueça do tratamento de erro.
    C4.1 -  TODO.
  4.2: Variaveis locais e privadas, adotar um padrão. Exemplo: CamelCase.
    C4.2 -  TODO.
  4.3: Interfaces, Eventos e metodos adotar um padrão. Exemplo: PascalCase.
    C4.3 -  TODO.
  4.4: Constantes em maiusculo, exemplo: TIME_SP_CORINTHIANS, TIME_RJ_VASCO, TIME_SP_SANTOS, ETC...
    C4.4 -  Aplicado na classe estática de Regras, que tem como responsabilidade
            manter as constantes da applicação.
5 - Evite escrever métodos muito longos.
    C5.1 -  TODO.
6 - O nome do método, variaveis, interfaces devem dizer o que ele faz. 
    C6.1 -  TODO.    
7 - Utilize boas praticas, por exemplo: clean code, solid, etc
    C7.1 -  TODO.
```

### Retornos esperados

```
1 - É esperado o seguinte retorno por time:

Posição
    C - Devolvido posição média.
Nome do Time
Pontuação total
Qtde de campeonatos disputados
Total de Jogos
Total de Vitorias
Total de Empates
Total de  Derrotas
Total de Gols Prós
Total de Gols Contras
Saldo de gols
```