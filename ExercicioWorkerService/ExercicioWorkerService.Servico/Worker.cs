using AutoMapper;
using ExercicioWorkerService.Modelo;
using ExercicioWorkerService.Servico.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace ExercicioWorkerService.Servico
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly HttpClient _httpCliente;
        private readonly IMapper _mapper;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient, IMapper mapper)
        {
            _logger = logger;
            _httpCliente = httpClient.CreateClient();
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Serviço executado às {DateTime.Now}");

                Mensagem mensagem = await ObterMensagem();

                //MinhaMensagem minhaMensagem = ConverterMinhaMensagemParaMensagem(mensagem);

                MinhaMensagem minhaMensagem = _mapper.Map<MinhaMensagem>(mensagem);

                await InserirMensagemBanco(minhaMensagem);

                await Task.Delay(10000, stoppingToken);
            }
        }

        private async Task<Mensagem> ObterMensagem()
        {
            HttpResponseMessage retorno = await _httpCliente.GetAsync($"https://api.kanye.rest/");

            if (retorno.IsSuccessStatusCode)
            {
               return JsonConvert.DeserializeObject<Mensagem>(await retorno.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }

        private async Task InserirMensagemBanco(MinhaMensagem minhaMensagem)
        {
            HttpResponseMessage retorno = await _httpCliente.PostAsJsonAsync($"https://localhost:7042/api/Mensagem", minhaMensagem);
            if (retorno.IsSuccessStatusCode)
            {

            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }

        private MinhaMensagem ConverterMinhaMensagemParaMensagem(Mensagem mensagemm)
        {
            MinhaMensagem mensagem = new MinhaMensagem();
            mensagem.Mensagem = mensagemm.quote;

            return mensagem;
        }


    }
}