namespace Aula55_MoverArquivos
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string pastaOrigem = "c:\\Teste\\Pasta 1";
            string pastaDestinoTxt = @"c:\\Teste\\Pasta 2\txt";
            string pastaDestinoExcel = @"c:\\Teste\\Pasta 2\excel";

            DirectoryInfo directoryInfo = new DirectoryInfo(pastaOrigem);

            while (!stoppingToken.IsCancellationRequested)
            {

                
                //List<FileInfo> arquivos = directoryInfo.GetFiles().ToList(); tudo
                //List<FileInfo> arquivos = directoryInfo.GetFiles("*.txt").ToList(); só txt

                List<FileInfo> arquivos = directoryInfo.GetFiles()
                    .Where(x => x.Extension.Equals(".txt") || x.Extension.Equals(".xlsx"))
                    .ToList();

                foreach (var arquivo in arquivos)
                {
                    //arquivo.MoveTo(pastaDestino + arquivo.Name);

                    if (arquivo.Extension.Equals(".txt"))
                    {
                        arquivo.MoveTo(Path.Combine(pastaDestinoTxt, arquivo.Name));
                    }
                    else
                    {
                        arquivo.MoveTo(Path.Combine(pastaDestinoExcel, arquivo.Name));
                    }

                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}