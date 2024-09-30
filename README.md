# EDA - Event Driven Architecture

> Tecnologias utilizadas 
>
> Net 8.0, EF-Core, SQL Server, Kafka e Docker

Para rodar, execute:
```
docker-compose -f docker/docker-compose.yml up -d
```

## Kafdrop
Kafdrop é uma UI da web para visualizar tópicos do Kafka e navegar por grupos de consumidores. A ferramenta exibe informações como brokers, tópicos, partições, consumidores e permite que você visualize mensagens.

Acesse pelo link: [Kafdrop](http://localhost:19000/)

## Swagger

Ferramenta para documentação de APIs.

Acesse pelo link:

[Balance API](http://localhost:3003/swagger/index.html)

[Wallet API](http://localhost:3004/swagger/index.html)