using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace MinhaApi.Controllers{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase{

        private static List<Produto> produtos = new List<Produto>{
            new Produto { Id = 1, Nome = "Produto 1", Preco = 10.00m, Descricao = "Descrição do Produto 1"},
            new Produto { Id = 2, Nome = "Produto 2", Preco = 20.00m, Descricao = "Descrição do Produto 2"}
        };

        [HttpGet]
        public IEnumerable<Produto> Get(){
            return produtos;
        }

        [HttpGet("{id}")]
        public IActionResult Get (int id){
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null){
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto){
            novoProduto.Id = produtos.Count + 1;
            produtos.Add(novoProduto);

            return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produtoAtualizado){
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null){
                return NotFound();
            }

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Descricao = produtoAtualizado.Descricao;

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null){
                return NotFound();
            }

            produtos.Remove(produto);
            return Ok(produto);
        }
    }
}