# 🌆 Sistema de Gerenciamento de Trânsito Urbano (UrbisTransit)

Este é um sistema de simulação de monitoramento e persistência de dados para frotas de transporte urbano, desenvolvido em **C#** utilizando os conceitos fundamentais da **Orientação a Objetos (POO)**, **LINQ (Language Integrated Query)** e manipulação de arquivos com **Streams**.

O projeto simula um painel de controle para a prefeitura, onde veículos são gerenciados de forma segura, filtrados em tempo real e exportados para relatórios físicos no disco.

---

## 🛠️ Conceitos Praticados e Arquitetura

O projeto foi dividido seguindo boas práticas de arquitetura e separação de responsabilidades:

### 1. 🧱 Orientação a Objetos & Encapsulamento (`Onibus.cs`)
Para proteger as informações críticas da frota (como número da linha e capacidade), foi aplicado o conceito de **Encapsulamento**. 
* **Analogia do Cofre e do Caixa:** Os atributos sensíveis possuem `private set` (o cofre trancado). Ninguém fora da classe pode alterar o estado do veículo livremente. A única forma de interação é através do método público `MudarStatus` (o caixa do banco), que valida e registra a operação.
* **Tipagem Forte com Enums:** Foi implementado o `StatusOnibus` (`EmMovimento`, `Parado`, `Manutencao`) para limitar as opções de forma fortemente tipada, impedindo erros de digitação e dados inválidos no sistema.

### 2. 🎯 Consultas Eficientes com LINQ (`Program.cs`)
Em vez de utilizar laços manuais complexos para varrer a memória RAM atrás de dados específicos, foi utilizada a biblioteca do **LINQ** com expressões **Lambda**.
* **Filtros Inteligentes:** O sistema utiliza o método `.Where()` para peneirar e extrair instantaneamente apenas os ônibus que estão ativos e em circulação (`StatusOnibus.EmMovimento`), otimizando o processamento de coleções.

### 3. 🚰 Fluxo de Dados & Persistência com Streams (`Relatorio.cs`)
Para gravar o relatório final de frotas ativas sem sobrecarregar a memória RAM do computador, o sistema utiliza o conceito de **Streaming**.
* **Analogia da Torneira e do Balde:** Não carregamos dados massivos de uma vez só na memória. Através do `FileStream` e do `StreamWriter`, os dados são transmitidos continuamente em pequenos "pedaços" (buffers) para o arquivo de texto `frotas_ativas.txt`.
* **Gerenciamento de Recursos Seguro (`using`):** O código implementa o padrão `using`, garantindo que o arquivo seja trancado durante o uso e liberado automaticamente para o Sistema Operacional assim que o processo termina, evitando vazamento de memória (*memory leaks*) ou arquivos bloqueados, mesmo se ocorrerem exceções.

---

## 💻 Estrutura do Código

O projeto está organizado nos seguintes ficheiros:

* **`Onibus.cs`**: Modelo de domínio com propriedades encapsuladas e enumeradores.
* **`Relatorio.cs`**: Classe especializada na persistência e exportação de dados em arquivos de texto.
* **`Program.cs`**: O ponto de entrada da aplicação que orquestra a criação dos objetos, os filtros LINQ e invoca a geração do relatório.

---

## ⚙️ Exemplo de Saída no Arquivo (`frotas_ativas.txt`)

Ao executar o sistema, os ônibus ativos são filtrados e o relatório é gerado automaticamente com a seguinte estrutura:

```text
Onibus: 001, Capacidade: 25, Status: EmMovimento
Onibus: 003, Capacidade: 28, Status: EmMovimento
Onibus: 004, Capacidade: 22, Status: EmMovimento
