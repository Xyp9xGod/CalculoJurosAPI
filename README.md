# CalculoJurosAPI
Realiza cálculo de juros dados parâmetros de Valor inicial e Tempo.

# API TaxaJuros
    1. Endpoint "/api/TaxaJuros": Busca taxa de juros a ser utilizada.

# API CalculaJuros
    1. Endpoint "/api/CalculaJuros": Acessa o endpoint "/api/TaxaJuros" da api TaxaJuros para buscar a taxa 
       de juros e realiza o cálculo de juros com base nos parâmetros de Valor inicial e Tempo.
    2. Endpoint "/api/CalculaJuros/ShowMeTheCode": Retornar Url do projeto no github.

# Swagger
    1. Os endpoints estão disponíveis no swaggwer.

# Pontos de Melhoria
    1. Inicializar as APIs via docker.
    2. Necessário utilizar o método Autenticação para que seja gerado um token de acesso.
    3. Autorização via Jwt.
