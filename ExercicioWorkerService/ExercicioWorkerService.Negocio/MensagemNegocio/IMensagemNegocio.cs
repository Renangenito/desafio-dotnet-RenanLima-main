using ExercicioWorkerService.Modelo;

namespace ExercicioWorkerService.Negocio.MensagemNegocio
{
    public interface IMensagemNegocio
    {
        Task Incluir(MinhaMensagem minhaMensagem);
        Task<List<MinhaMensagem>> ObterLista();
    }
}
