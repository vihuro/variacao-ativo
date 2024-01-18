using AutoMapper;
using MediatR;
using VariacaoAtivo.Application.UseCases.Extenal;
using VariacaoAtivo.Domain.Entities;
using VariacaoAtivo.Domain.Interfaces;

namespace VariacaoAtivo.Application.UseCases.Chart.InsertOrUpdateChart
{
    public class InsertOrUpdateChartHandle :
        IRequestHandler<InsertOrUpdateChartRequest, InsertOrUpdateChartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChartRepository _repository;

        public InsertOrUpdateChartHandle()
        {

        }

        public InsertOrUpdateChartHandle(IMapper mapper,
                                        IMediator mediator,
                                        IUnitOfWork unitOfWork,
                                        IChartRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        /// <summary>
        /// Aqui é feito a busca na API externa do yahoo
        /// e antes de atualizar a lista no banco de dados, 
        /// é verificado se já está salvo essa cotação. 
        /// Se sim, ele altera os valores se não, adiciona um novo valor de cotação ao banco.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<InsertOrUpdateChartResponse> Handle(InsertOrUpdateChartRequest request,
                                                             CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetChartRequest(), cancellationToken);

            var resultMapper = _mapper.Map<ChartEntity>(result);

            var myChart = await _repository.GetBySymbol(resultMapper.Symbol, cancellationToken);

            if (myChart != null)
            {
                myChart.ExachangeName = resultMapper.ExachangeName;
                myChart.ExchangeTimeZone = resultMapper.ExchangeTimeZone;
                myChart.RegularMarketPrice = resultMapper.RegularMarketPrice;
                myChart.ChartPreviousClose = resultMapper.ChartPreviousClose;
                myChart.QuoteClose = resultMapper?.QuoteClose;
                myChart.QuoteHigh = resultMapper?.QuoteHigh;
                myChart.QuoteLow = resultMapper?.QuoteLow;
                myChart.QuoteOpen = resultMapper?.QuoteOpen;

                _repository.Update(myChart);

                resultMapper = myChart;
            }
            else
            {
                _repository.Create(resultMapper);
            }


            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<InsertOrUpdateChartResponse>(resultMapper);
        }
    }
}
