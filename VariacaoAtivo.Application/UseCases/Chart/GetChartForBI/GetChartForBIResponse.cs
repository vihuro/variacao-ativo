namespace VariacaoAtivo.Application.UseCases.Chart.GetChartForBI
{
    public sealed record class GetChartForBIResponse
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExachangeName { get; set; }
        public string ExchangeTimeZone { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }
        public List<VariacaoItem> QuoteOpen { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
    public class VariacaoItem
    {
        public double QuoteOpen { get; set; }
        public double Variacao { get; set;}
    }
}
