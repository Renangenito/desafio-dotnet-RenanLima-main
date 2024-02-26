using AutoMapper;
using ExercicioWorkerService.Modelo;
using ExercicioWorkerService.Servico.Model;


namespace ExercicioWorkerService.Servico.Mapeamento
{
    public class ConfigurarMapeamento : Profile
    {
        public ConfigurarMapeamento()
        {
            CreateMap<Mensagem, MinhaMensagem>()
                .ForMember(dest => dest.Mensagem, opts => opts.MapFrom(src => src.quote));
               
        }
    }
}
