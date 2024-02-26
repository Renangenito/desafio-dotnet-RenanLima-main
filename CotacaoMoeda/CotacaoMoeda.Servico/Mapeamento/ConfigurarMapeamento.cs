using AutoMapper;
using CotacaoMoeda.Modelo;
using CotacaoMoeda.Servico.Model;

namespace CotacaoMoeda.Servico.Mapeamento
{
    public class ConfigurarMapeamento : Profile
    {
        public ConfigurarMapeamento()
        {
            CreateMap<USDBRL, CotacaoTeste>();
                //.ForMember(dest => dest.Nome, opts => opts.MapFrom(src => src.USDBRL.name))
                //.ForMember(dest => dest.ValorCompra, opts => opts.MapFrom(src => src.USDBRL.bid))
                //.ForMember(dest => dest.ValorVenda, opts => opts.MapFrom(src => src.USDBRL.ask));
        }
    }
}
