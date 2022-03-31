Uma API desenvolvida pra resolver o teste do Albert Einstein https://github.com/HIAE/netcore-test em padrão Repository.

Nesse teste o desafio é criar uma API que permita marcação de consultas através de 2 Endpoints que reutilizem o mesmo service. Tanto através do endpoint /medicos quanto /pacientes, com checagem de conflitos de horários, para que nenhum médico ou paciente tenha 2 consultas que conflitem.

Para suportar maior flexibilidade, eu optei por não designar uma duração fixa para as consultas, permitindo que qualquer médico ao marcar escolhesse um horário de início e uma duração, ao invés de criar "slots" ou "vagas" de 1 hora para cada médico ao longo do dia.

A ideia de separar o projeto em camadas de serviços e repositórios, juntamente com implementação de repositórios e serviços genéricos foi para aumentar a flexibilidade do código, facilitando o reúso ou substituição caso seja necessário.

Através dessa estrutura podemos ter um endpoint, chamando um serviço, esse serviço realiza uma validação, ou manipulação dos dados recebidos, chama então o repository, que é quem faz o acesso à Database, no caso de se mudar de uma DB para outra, nós só precisaríamos alterar essa camada de repositório, preservando o controller e o service. 

