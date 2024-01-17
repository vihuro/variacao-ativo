using AutoMapper;
using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Application.UseCases.Chart.GetChartForBI
{
    public class GetChartForBIMapper : Profile
    {
        public GetChartForBIMapper()
        {
            CreateMap<ChartEntity, GetChartForBIResponse>()
                .ForMember(x => x.QuoteOpen, map => map.MapFrom(src => QueoteOpen(src.QuoteOpen)))
                .ForMember(x => x.RegularMarketPrice, map => map.MapFrom(src => src.RegularMarketPrice))
                .ForMember(x => x.DateCreated, map => map.MapFrom(src => src.DateCreated))
                .ForMember(x => x.DateUpdated, map => map.MapFrom(src => src.DateUpdated))
                .ForMember(x => x.ChartPreviousClose, map => map.MapFrom(src => src.ChartPreviousClose))
                .ForMember(x => x.Currency, map => map.MapFrom(src => src.Currency))
                .ForMember(x => x.ExachangeName, map => map.MapFrom(src => src.ExachangeName))
                .ForMember(x => x.ExchangeTimeZone, map => map.MapFrom(src => src.ExchangeTimeZone))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.PreviousClose, map => map.MapFrom(src => src.PreviousClose));
        }

        private List<VariacaoItem> QueoteOpen(List<double> quoteOpen)
        {
            var list = new List<VariacaoItem>();
            for (var i = 0; i < quoteOpen.Count; i++)
            {
                var item = new VariacaoItem
                {
                    QuoteOpen = quoteOpen[i]
                };
                if (i == 0)
                {
                    item.Variacao = 0;
                }
                else
                {
                    var valorCotacaoAnterior = quoteOpen[i - 1];
                    
                    var valorCotacao = quoteOpen[i] == 0 ? quoteOpen[i - 1] : quoteOpen[i];


                    item.Variacao = item.QuoteOpen - valorCotacaoAnterior;
                }
                list.Add(item);
            }
            return list;
        }
    }
}
