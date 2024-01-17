namespace VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart
{
    public sealed record class InsertOrUpdateChartResponse
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExachangeName { get; set; }
        public string ExchangeTimeZone { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }
        public List<double> QuoteClose { get; set; }
        public List<double> QuoteHigh { get; set; }
        public List<double> QuoteLow { get; set; }
        public List<double> QuoteOpen { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
