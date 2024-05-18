
# 1 Orientação a Objetos:
- Explique o conceito de herança múltipla e como C# aborda esse cenário.

> A herança múltipla é um conceito da POO, aonde a classe podem herdar múltiplos comportamentos, atributos, características de uma ou mais classes "concretas" > (Que possuem implementação), possibilitando deixar o código mais flexível e com mais reutilização. 
> 
> O C#, assim como muitas outras linguagens, não suportam a herança múltipla de classes, porem, suporta a herança de múltiplas interfaces, apenas garantindo a assinatura do método e não a herança do comportamento. No C# 8, foi adicionando uma feature importante, o qual é a Implementação padrão em interfaces, um pequeno começo para o C# ao encontro da herança múltipla.
 
- Explique o polimorfismo em C# e forneça um exemplo prático de como ele pode ser implementado.
> O polimorfismo em C# permite que métodos com o mesmo nome tenham comportamentos diferentes, dependendo da classe que os implementa, ou seja, dependendo da instância, o comportamento pode ser diferente ao explicitado do tipo declarado da variável.
> Exemplo
```
    public class Worker
        {
            public virtual decimal CalculateSalary()
            {
                return 1000; 
            }
        }
        
    public class CommissionedWorker : Worker
    {
        private decimal _sales;
        
        public CommissionedWorker(decimal sales)
        {
            this._sales = sales;
        }
    
        public override decimal CalculateSalary()
        {
            return 800 + _sales * 2;
        }
    }
    
    public class HourWorker : Worker
    {
        private int _hour;
    
        public WorkerHora(int hour)
        {
            this._hour = hour;
        }
    
        public override decimal CalculateSalary()
        {
            return _hour * 10;
        }
    }
    
    Worker worker = new Worker();
    worker.CalculateSalary(); // 1000
    
    Worker worker = new CommissionedWorker(1000);
    worker.CalculateSalary(); // 2800
    
    Worker worker = new WorkerHora(300);
    worker.CalculateSalary(); // 3000
```

2. SOLID:
- Descreva o princípio da Responsabilidade Única (SRP) e como ele se aplica em um contexto de desenvolvimento C#.

> O Princípio da Responsabilidade Única (SRP), um dos cinco princípios SOLID de design orientado a objetos, afirma que uma classe deve ter apenas uma razão para mudar.
> 
> Considere um exemplo de um sistema de gestão escolar. Sem o SRP, uma classe pode acabar fazendo várias coisas, como: gerenciar detalhes do aluno, calcular notas e imprimir relatórios. 
> Com o SRP, essas responsabilidades seriam segregadas:
> - Classe Aluno: Gerencia informações do aluno como nome, registro e detalhes de contato.
> - Classe Notas: Responsável por manter as notas do aluno e calcular médias.
> - Classe RelatorioAluno: Usada exclusivamente para formatar e imprimir relatórios dos alunos.

- Como o princípio da inversão de dependência (DIP) pode ser aplicado em um projeto C# e como isso beneficia a manutenção do código?

>  O Princípio da Inversão de Dependência (DIP) em C# pode ser aplicado de maneira efetiva usando interfaces ou classes abstratas para desacoplar componentes de software. Isso permite que os módulos de alto nível, como lógica de negócios, não dependam diretamente de módulos de baixo nível, como acesso a dados ou serviços de terceiros. Em vez disso, ambos os tipos de módulos dependem de abstrações.
> 
> Principais benefícios na manutenção do código: 
> - Flexibilidade: Facilita a modificação de componentes do sistema sem afetar outros componentes.
> - Reutilização: Componentes desacoplados podem ser reutilizados em diferentes contextos.
> - Testabilidade: Torna mais fácil testar módulos de alto nível de forma isolada, usando mocks ou stubs para as abstrações.

3. Entity Framework (EF):
- Como o Entity Framework gerencia o mapeamento de objetos para o banco de dados e vice-versa?

> O EF  faz o mapeamento de objetos para o banco de dados e vice-versa usando dois principais métodos: Code-First e Database-First.
> 
> Code-First:
> 
> -   Os desenvolvedores criam classes de entidade em C#.
> -   O EF usa essas classes para gerar o esquema de banco de dados.
> -   As entidades são mapeadas para as tabelas por meio de convenções e configurações via Fluent API ou Data Annotations.
> 
> Database-First:
> - O esquema do banco de dados já existe.
> - O EF gera as classes de entidade que refletem as tabelas e relações do banco de dados.
> - O mapeamento é controlado por um arquivo EDMX (Entity Data Model XML).
> 

- Como otimizar consultas no Entity Framework para garantir um desempenho eficiente em grandes conjuntos de dados?

> Algumas das estratégias para otimizar consultas no Entity Framework e garantir um desempenho eficiente em grandes conjuntos de dados:
> 
> - Use .Select para Projetar Apenas Campos Necessários: Evite trazer todos os campos de uma entidade quando apenas alguns são necessários.
> - Aplique Cláusulas .Where Antes de .ToList: Filtrar dados no banco de dados antes de carregar para a aplicação reduz a sobrecarga de rede e memória.
> - Evitar Carregamento Eager Desnecessário: Use o carregamento lazy (virtual nas propriedades de navegação) para carregar relacionamentos somente quando necessário, ou utilize Include de forma seletiva.
> - Utilize Paginação: Use métodos como .Skip e .Take para carregar apenas uma parte dos dados de cada vez.
> - Evite Consultas N+1: Preveja e inclua os dados relacionados necessários na consulta inicial usando Include para evitar múltiplas consultas ao banco.
> - Use NoTracking Quando Apropriado: Para operações somente de leitura, use AsNoTracking() para melhorar a performance, já que o EF não precisará rastrear as alterações desses objetos.
> - Considere Consultas Armazenadas ou Views: Em casos de consultas muito complexas, pode ser mais eficiente usar consultas SQL nativas, usando Dapper por exemplo.
> - Monitore e Analise as Consultas SQL Geradas: Use ferramentas como SQL Profiler para entender e otimizar as consultas SQL que o EF está gerando.

4. WebSockets:
- Explique o papel dos WebSockets em uma aplicação C# e como eles se comparam às solicitações HTTP tradicionais.

> WebSockets permitem comunicação bidirecional e em tempo real entre o cliente e o servidor. Eles são diferentes das solicitações HTTP tradicionais, que são unidirecionais e não mantêm a conexão aberta após a resposta ser enviada. Em resumo, WebSockets são ideais para aplicações que requerem interações em tempo real e com baixa latência, enquanto o HTTP é adequado para transações de requisição-resposta mais tradicionais.

- Quais são as principais considerações de segurança ao implementar uma comunicação baseada em WebSockets em uma aplicação C#?

> As principais considerações de segurança são:
> - Utilizar WebSocket Secure (WSS): Sempre optar por conexões wss:// para garantir a criptografia dos dados transmitidos, similar ao HTTPS para HTTP.
> - Validação e Sanitização de Dados: Certificar-se de que todos os dados recebidos são validados e sanitizados para evitar ataques como injeção de código.
> - Autenticação e Autorização: Implementar mecanismos robustos para verificar a identidade dos usuários e controlar o acesso.
> - Limitação de Taxa: Aplicar limites na frequência de mensagens para proteger contra ataques de DoS.
> - Verificação de Origem: Implemente verificações de origem para garantir que as conexões WebSocket só sejam aceitas de origens confiáveis, prevenindo assim ataques de falsificação de solicitação entre sites (CSRF).
> - Monitoramento e Logs: Manter um registro das atividades para detectar e responder a atividades suspeitas ou maliciosas.

5. Arquitetura:
- Descreva a diferença entre arquitetura monolítica e arquitetura de microsserviços. Qual seria sua escolha ao projetar uma aplicação C#?

> Em resumo, a diferença principal entre arquitetura monolítica e arquitetura de microsserviços:
> - Arquitetura Monolítica: Todos os componentes de uma aplicação estão integrados em um único e indivisível sistema. Geralmente, todos os processos são geridos e executados como uma unidade única, o que simplifica o desenvolvimento e a implantação inicialmente, mas pode tornar as atualizações, a escalabilidade e a manutenção mais complexas à medida que a aplicação cresce.
> 
> - Arquitetura de Microsserviços: A aplicação é dividida em uma coleção de serviços menores, cada um executando um processo único e independente. Cada serviço é responsável por uma parte específica da funcionalidade da aplicação e pode ser desenvolvido, implantado e escalado de forma independente. Isso aumenta a complexidade da gestão dos serviços, mas oferece melhor escalabilidade, flexibilidade e resiliência.
> 
> A escolha da arquitetura depende de muitas questões, fatores como maturidade do time, quantidade de usuários ativos, complexidade e acoplamento do negócio, requisitos de escalabilidade, resiliência, orçamento e cronograma. Em outras palavras, projetos mais simples, com time mais juniores, uma solução monolítica tende a ser uma escolha mais interessante, enquanto times mais seniores e com grande quantidade de desenvolvedores, uma solução em micro serviço tendem a ser mais interessantes. Mas, tudo depende da realidade de cada projeto.

- Como você escolheria entre a arquitetura de microsserviços e a arquitetura monolítica ao projetar uma aplicação C# que precisa ser altamente escalável?

>  Depende de múltiplos fatores, como citei anteriormente. Consideraria os seguintes pontos:
> 
> - Complexidade do Projeto: Para projetos simples ou de pequena escala, prefiro a arquitetura monolítica. Para projetos complexos e grandes e que sejam fáceis de quebrar em contextos menores, escolha microsserviços.
> - Capacidade da Equipe: Se a equipe tem experiência com contêineres e orquestração, senioridade, microsserviços são viáveis. Caso contrário, consideraria com mais atenção o modelo monolítico.
> - Escalabilidade e Resiliência: Para necessidades de alta escalabilidade e resiliência, microsserviços são a uma escolha devido à sua independência e flexibilidade.
> - Recursos Disponíveis: Microsserviços requerem mais investimento em ferramentas e infraestrutura. Se os recursos forem limitados, começaria com uma arquitetura monolítica, e evoluiria conforme a necessidade para uma solução hibrida.
Logico, existem mais pontos a serem avaliados, mas no geral e se forma sintetizado estes seriam meus primeiros entendimentos para planejar uma solução. Até por que, não existe a melhor solução, cada um possui seus pontos fortes e fracos.