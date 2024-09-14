var builder = WebApplication.CreateBuilder(args); // Cria o builder que vai configurar o aplicativo web

// Adiciona serviços para a API, como o Swagger (que gera a documentação da API).
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints da API (para o Swagger)
builder.Services.AddSwaggerGen(); // Gera a documentação interativa da API com o Swagger

// Adiciona os serviços dos controllers
builder.Services.AddControllers(); // Registra os controllers para que eles possam ser utilizados na API

var app = builder.Build(); // Constrói o aplicativo (app) com as configurações definidas anteriormente

// Verifica se o ambiente é de desenvolvimento para habilitar o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Ativa o Swagger, que gera a documentação da API em JSON
    app.UseSwaggerUI(); // Ativa a interface gráfica do Swagger para interagir com a API
}

app.MapGet("/", () => "Bem vindo à minha API!"); // Define a rota raiz (/) que retorna uma mensagem simples

// Mapeia todos os controllers, ou seja, ativa as rotas dos controllers da API (como /api/produto)
app.MapControllers(); 

// O redirecionamento para HTTPS está comentado. Ele forçaria a API a usar HTTPS, mas está desativado aqui
// app.UseHttpsRedirection();

app.Run(); // Inicia a aplicação e faz o servidor começar a "ouvir" requisições
