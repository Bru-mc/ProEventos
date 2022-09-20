using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        
        public EventoController(IEventoService eventoService)
        {
            this._eventoService = eventoService;    
        }
        
        //Metodo Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
              var eventos = await this._eventoService.GetAllEventosAsync(true);  
              if(eventos == null) return NotFound("Nenhum evento encontrado");

              return Ok(eventos);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro:{error.Message}");
            }
            
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
              var evento = await this._eventoService.GetEventoByIdAsync(id, true);  
              if(evento == null) return NotFound("Nenhum evento encontrado nesse Id");

              return Ok(evento);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro:{error.Message}");
            }
            
        }
        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
              var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);  
              if(eventos == null) return NotFound("Nenhum evento por tema encontrado");

              return Ok(eventos);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro:{error.Message}");
            }
            
        }
        
        //Metodo Post
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
               var eventoAdded = await _eventoService.AddEventos(model);
               if(eventoAdded != null) return Ok(eventoAdded);
               
               return BadRequest("Erro ao tentar adicionar evento");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar evento. Erro:{error.Message}");
            }
        }
        
        //Metodo Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
               var eventoUpdated = await _eventoService.UpdateEventos(id, model);
               if(eventoUpdated != null) return Ok("Evento atualizado");
               
               return BadRequest("Erro ao tentar atualizar evento");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar evento. Erro:{error.Message}");
            }
        }
        
        //Metodo Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isEventoDeleted = await _eventoService.DeleteEvento(id);
                return isEventoDeleted ? Ok("Evento Deletado!") : BadRequest("Erro ao Deletar evento!");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar evento. Erro:{error.Message}");
            }
        }
    }
}
