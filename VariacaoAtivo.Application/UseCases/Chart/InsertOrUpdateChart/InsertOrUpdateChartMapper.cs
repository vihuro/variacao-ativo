using AutoMapper;
using VariacaoAtivo.Application.UseCases.Extenal;
using VariacaoAtivo.Domain.Entities;

namespace VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart
{
    public class InsertOrUpdateChartMapper : Profile
    {
        public InsertOrUpdateChartMapper()
        {
            CreateMap<GetChartResponse, ChartEntity>()
                .AfterMap((src, dest) => MapMetaToChartEntity(src.Chart.Result.FirstOrDefault(), dest));

            CreateMap<ChartEntity, InsertOrUpdateChartResponse>();
        }
        /// <summary>
        /// Este método, mapeia o result para um tipo ChartEntity
        /// </summary>
        /// <param name="result"></param>
        /// <param name="entity"></param>
        private static void MapMetaToChartEntity(Result result, ChartEntity entity)
        {
            if (result != null)
            {


                entity.Currency = result.Meta.Currency;
                entity.Symbol = result.Meta.Symbol.ToUpper();
                entity.ExachangeName = result.Meta.ExchangeName;
                entity.ExchangeTimeZone = result.Meta.ExchangeTimezoneName;
                entity.RegularMarketPrice = result.Meta.RegularMarketPrice;
                entity.ChartPreviousClose = result.Meta.ChartPreviousClose;
                entity.PreviousClose = result.Meta.PreviousClose;
                entity.QuoteClose = ConverterStringInDooble(result.Indicators.Quote[0].Close);
                entity.QuoteOpen = ConverterStringInDooble(result.Indicators.Quote[0].Open);
                entity.QuoteLow = ConverterStringInDooble(result.Indicators.Quote[0].Low);
                entity.QuoteHigh = ConverterStringInDooble(result.Indicators.Quote[0].High);

                // Adicione outras propriedades conforme necessário
            }
        }
        /// <summary>
        /// Este método Converte uma lista de stings em uma lista de doobles
        /// </summary>
        /// <param name="listString"></param>
        /// <returns></returns>
        private static List<double> ConverterStringInDooble(List<string> listString)
        {
            var listDooble = new List<double>();

            int interadorAuxiliar = 0;

            /// Verifica se o valor passado não é nulo.
            /// 
            /// Se for diferente de nulo, 
            ///     O valor do interadorAuxiliar é igual a I do interador do FOR
            ///     
            /// Se for igual a nulo, 
            ///     verifica se existe um valor válido
            ///         Se for válido o valor de valorAuxiliar é igual ao valor antecessor do valor atual.
            ///         Se não for, ele busca a frente para atribuir a variavel valorAuxiliar.
            for (var i = 0; i < listString.Count; i++)
            {

                if (listString[i] != null)
                {
                    interadorAuxiliar = i;
                }
                else if (i > 0 && listString[i - 1] != null)
                {
                    interadorAuxiliar = i - 1;
                }
                else
                {
                    interadorAuxiliar = i + 1;
                }

                var itemConverter = Convert.ToDouble(listString[interadorAuxiliar]);

                listDooble.Add(itemConverter);



            }
            return listDooble;
        }
    }
}
