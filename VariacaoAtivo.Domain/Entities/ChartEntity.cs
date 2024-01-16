using System.ComponentModel.DataAnnotations.Schema;

namespace VariacaoAtivo.Domain.Entities
{
    [Table("tab_chart")]
    public sealed class ChartEntity : BaseEntity
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExachangeName { get; set; }
        public string ExchangeTimeZone { get; set; }
        public double RegularMarketPrince { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }
        public List<double> QuoteClose { get; set; }
        public List<double> QuoteHigh { get;set; }
        public List<double> QuoteLow { get; set; }
        public List<double> QuoteOpen { get; set; }
    }
}
