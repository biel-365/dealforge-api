# Status das Migrations - DealForge API

## Migrations Criadas

1. **20260528114145_Initial** - Vazia (placeholder da estrutura inicial)
2. **20260528141051_CreateSchema** - Schema completo com todas as tabelas

## Como Aplicar no Banco

A migration `CreateSchema` está pronta, mas precisa ser aplicada no seu ambiente local onde o SQL Server é acessível.

### Opção 1: Usar o script bash (macOS/Linux)

```bash
chmod +x apply-migration.sh
./apply-migration.sh
```

### Opção 2: Comando manual

```bash
cd dealforge-api
dotnet ef database update --context AppDbContext
```

## Tabelas Criadas

- Users
- Games
- Offers
- Reviews
- Stores
- Genres
- Platforms
- Favorites
- SystemRequirements
- GameGenres (join table)
- GamePlatforms (join table)

## Connection String

O banco está configurado em `appsettings.json`:

- Server: `192.168.1.124\SQLEXPRESS`
- User: `sa`
- Password: `senai790`
- Database: será criada automaticamente na primeira execução

## Status Atual

✅ AppDbContext completado com todos os DbSets
✅ Controllers scaffoldados (11 units)
✅ Migration CreateSchema gerada
⏳ Aguardando execução no seu ambiente local (SQL Server não acessível remotamente)
