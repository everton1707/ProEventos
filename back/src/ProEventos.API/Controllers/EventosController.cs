using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{
               /* new Evento(){
                EventoId = 1,
                Tema = "Angular 11 e dotnet 5",
                Local = "taubate-SP",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto1.png"
                },
                new Evento(){
                EventoId = 2,
                Tema = "Angular e suas novidades",
                Local = "taubate-SP",
                Lote = "5º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagemURL = "foto2.png"
                }*/
            };
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
         
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id );
        }
        [HttpPost]
        public string Post()
        {
            return "exemplo de post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo de Put com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"exemplo de Delete com id = {id}";
        }
    }
}
