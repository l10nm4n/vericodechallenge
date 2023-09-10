Feature: Avaliação - Busca CEP

Scenario: Verificar CEP não existente
Given Entro no site dos Correios - Busca CEP
When Procuro pelo CEP "80700000"
Then Deve ser exibida a mensagem "Dados não encontrado"

Scenario: Verificar CEP existente
Given Entro no site dos Correios - Busca CEP
When Procuro pelo CEP "01013-001"
Then Deve ser exibido o resultado "Rua Quinze de Novembro"

# Scenario: Verificar código de rastreamento incorreto
# Given Entro no site dos Correios - Rastreamento
# When Procuro pelo código de rastreamento "SS987654321BR"
# Then Deve ser exibida a mensagem "Objeto não encontrado na base de dados dos Correios"