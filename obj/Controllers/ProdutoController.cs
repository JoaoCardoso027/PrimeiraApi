using Microsoft.AspNetCore.Mvc; // Importa as classes necessárias para o funcionamento do Controller (como [ApiController], [HttpGet], [HttpPost], etc.)
using System.Collections.Generic; // Importa o namespace que contém as listas (List<T>), que usaremos para simular os dados

namespace MinhaApi.Controllers
{
    [ApiController] // Define que a classe será tratada como um Controller de API. Isso ativa validações automáticas e facilita o desenvolvimento de APIs REST.
    [Route("api/produto")] // Define a rota para acessar esse controller. "api/[controller]" significa que a rota será baseada no nome da classe (no caso, /api/produto)
    public class ProdutoController : ControllerBase // Esta classe herda de ControllerBase, o que permite que ela use métodos como Ok(), NotFound(), etc.
    {
        // Lista estática que simula uma base de dados de produtos.
        // É estática para que a lista de produtos seja mantida em memória enquanto a aplicação está rodando.
        private static List<string> produtos = new List<string> { "Produto 1", "Produto 2", "Produto 3" };

        [HttpGet] // Define que esse método vai responder a requisições HTTP GET na rota "/api/produto"
        public IEnumerable<string> Get() // O método retorna uma lista de strings (produtos) como resposta
        {
            return produtos; // Retorna a lista de produtos em formato JSON (automaticamente convertido pelo ASP.NET Core)
        }

        [HttpPost] // Define que esse método vai responder a requisições HTTP POST na rota "/api/produto"
        // O método POST é usado para adicionar um novo produto à lista
        public IActionResult Post([FromBody] string produto) // O parâmetro [FromBody] indica que o produto será enviado no corpo da requisição
        {
            produtos.Add(produto); // Adiciona o novo produto à lista de produtos
            return Ok(produto); // Retorna uma resposta HTTP 200 (OK) com o produto recém-adicionado
        }

        [HttpDelete("{id}")] // Define que esse método vai responder a requisições HTTP DELETE na rota "/api/produto/{id}"
        // O {id} na rota significa que o ID do produto será passado como um parâmetro na URL
        public IActionResult Delete(int id) // O parâmetro id é o índice do produto que será removido da lista
        {
            // Verifica se o ID é inválido (menor que 0 ou maior que o tamanho da lista)
            if (id < 0 || id >= produtos.Count)
            {
                return NotFound(); // Retorna uma resposta HTTP 404 (Not Found) se o ID for inválido
            }

            produtos.RemoveAt(id); // Remove o produto da lista no índice especificado pelo ID
            return Ok(); // Retorna uma resposta HTTP 200 (OK) confirmando que o produto foi removido
        }
    }
}
