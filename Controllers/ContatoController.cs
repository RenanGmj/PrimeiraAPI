using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Context;
using PrimeiraAPI.Models;


namespace PrimeiraAPI.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {


        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context){

            _context = context;

        }
        [HttpPost]
        public IActionResult Create(Contato contato){
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);

        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.contatos.Find(id);

            if(contato == null){

                return NotFound();
            }
            return Ok(contato);
            
        }
        
        [HttpGet("obterContatoPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatoss = _context.contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatoss);   


        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();


            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

           

            _context.contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return  NoContent();




        }
    }
}