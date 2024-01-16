using MediatR;
using Newtonsoft.Json;

namespace VariacaoAtivo.Application.UseCases.Extenal
{
    public class GetChartHandle :
        IRequestHandler<GetChartRequest, GetChartResponse>
    {
        private HttpClient _httpClient;



        public async Task<GetChartResponse> Handle(GetChartRequest request, CancellationToken cancellationToken)
        {
            _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync("https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var context = await response.Content.ReadAsStringAsync(cancellationToken);

                var objectResponse = JsonConvert.DeserializeObject<GetChartResponse>(context);

                return objectResponse;
            }


            return new GetChartResponse();
        }
    }
}
