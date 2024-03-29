using AutoMapper;
using CotacaoMoeda.Modelo;
using CotacaoMoeda.Servico.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace CotacaoMoeda.Servico
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient, IMapper mapper)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();
            _mapper = mapper;   
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");


            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Servi�o executado �s {DateTime.Now}");

                CotacaoMercadoRetorno cotacaoMercadoRetorno = await ObterCotacaoMercado();

                //Cotacao cotacao = ConverterCotacaoMercadoRetornoParaCotacao(cotacaoMercadoRetorno);

                Cotacao cotacao = _mapper.Map<Cotacao>(cotacaoMercadoRetorno);

                //await InserirCotacaoBancoDeDadosInterno(cotacao);


                await Task.Delay(35000, stoppingToken);

            }
        }
        private async Task<CotacaoMercadoRetorno> ObterCotacaoMercado()
        {
            HttpResponseMessage retorno = await _httpClient.GetAsync($"http://economia.awesomeapi.com.br/json/last/USD-BRL");

            if (retorno.IsSuccessStatusCode)
            {

                JObject obj = JObject.Parse(await retorno.Content.ReadAsStringAsync());
                string nomeMoeda = obj["USDBRL"]["name"].ToString();
                string bid = obj["USDBRL"]["varBid"].ToString();


                return JsonConvert.DeserializeObject<CotacaoMercadoRetorno>(await retorno.Content.ReadAsStringAsync());

            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }

        private async Task InserirCotacaoBancoDeDadosInterno(Cotacao cotacao)
        {
            HttpResponseMessage retorno = await _httpClient.PostAsJsonAsync($"https://localhost:7005/api/Cotacao", cotacao);
            if (retorno.IsSuccessStatusCode)
            {

            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }

        private Cotacao ConverterCotacaoMercadoRetornoParaCotacao(CotacaoMercadoRetorno cotacaoMercadoRetorno)
        {
            Cotacao cotacao = new Cotacao();
            cotacao.Nome = cotacaoMercadoRetorno.USDBRL.name;
            cotacao.ValorCompra = Convert.ToDecimal(cotacaoMercadoRetorno.USDBRL.bid);
            cotacao.ValorVenda = Convert.ToDecimal(cotacaoMercadoRetorno.USDBRL.ask);

            return cotacao;
        }

    }
}
