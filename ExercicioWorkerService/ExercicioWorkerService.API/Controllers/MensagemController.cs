using ExercicioWorkerService.Infra.Entity;
using ExercicioWorkerService.Modelo;
using ExercicioWorkerService.Negocio.MensagemNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioWorkerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemNegocio _mensagemNegocio;

        public MensagemController(IMensagemNegocio mensagemNegocio)
        {
            _mensagemNegocio = mensagemNegocio;
        }

        [HttpPost]
        public async Task Incluir([FromBody] MinhaMensagem minhaMensagem)
        {
            minhaMensagem.DataHoraCotacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _mensagemNegocio.Incluir(minhaMensagem);
            }
        }

        [HttpGet]
        public async Task<List<MinhaMensagem>> Get()
        {
            return await _mensagemNegocio.ObterLista();
        }


    }
}
