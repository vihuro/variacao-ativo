using AutoMapper;
using MediatR;
using VariacaoAtivo.Application.UseCases.Chart.GetAllChart;
using VariacaoAtivo.Domain.Interfaces;

namespace VariacaoAtivo.Application.UseCases.Chart.GetChartForBI
{
    public class GetChartForBIHandle :
        IRequestHandler<GetChartForBIRequest, List<GetChartForBIResponse>>
    {
        private readonly IChartRepository _repository;
        private readonly IMapper _mapper;

        public GetChartForBIHandle(IChartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetChartForBIResponse>> Handle(GetChartForBIRequest request, CancellationToken cancellationToken)
        {
            var listItem = await _repository.GetAll(cancellationToken);

            return _mapper.Map<List<GetChartForBIResponse>>(listItem);
        }
    }
}
