namespace VariacaoAtivo.Application.UseCases.Extenal
{
    public class GetChartResponse
    {
        public Chart Chart { get; set; }


    }
    public class Chart
    {
        public List<Result> Result { get; set; }

    }
    public class Result
    {
        public Meta Meta { get; set; }
        public Indicator Indicators { get; set; }

    }
    public class Meta
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string Timezone { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }

    }
    public class Indicator
    {
        public List<Quote> Quote { get; set; }
    }
    public class Quote
    {
        public List<string> Open { get; set; }
        public List<string> Close { get; set; }
    }
}
