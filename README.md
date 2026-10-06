# AirGuard EAS

Monitoramento contínuo de conformidade de climatização (HVAC) em unidades de saúde.

O sistema acompanha pressão, temperatura e umidade de ambientes críticos (cirurgia, isolamento, UTI), dispara alarmes quando algo sai da norma e guarda um histórico de evidências que não pode ser alterado.

> Em desenvolvimento.

## Stack

C# · .NET 10 · PostgreSQL + TimescaleDB · MQTT · React · Docker · AWS

## Como compilar e testar

```bash
git clone https://github.com/lumiguelx/airguard-eas.git
cd airguard-eas
dotnet build
dotnet test
```

## Roadmap

- [x] Especificação ([docs](docs/especificacao-v0.1.pdf))
- [x] Modelo de domínio inicial
- [x] Validação e testes
- [ ] Ingestão via MQTT e banco de dados
- [ ] Motor de regras e alarmes
- [ ] Log de evidências com hash chain
- [ ] API e painel web
- [ ] Deploy na AWS
