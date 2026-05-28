#!/bin/bash
# Script para aplicar as migrations no banco de dados SQL Server
# Execute este script no seu ambiente local onde o SQL Server é acessível

echo "Aplicando migration CreateSchema no SQL Server..."
dotnet ef database update --context AppDbContext --project dealforge-api.csproj --startup-project dealforge-api.csproj

if [ $? -eq 0 ]; then
    echo "✅ Migration aplicada com sucesso!"
    echo "As tabelas foram criadas no banco de dados."
else
    echo "❌ Erro ao aplicar migration. Verifique:"
    echo "  - Se o SQL Server está rodando"
    echo "  - Se a connection string em appsettings.json está correta"
    echo "  - Se os dados de acesso (sa/senai790) estão corretos"
fi
