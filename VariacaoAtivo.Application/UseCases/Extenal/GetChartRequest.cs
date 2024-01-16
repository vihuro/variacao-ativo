using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivo.Application.UseCases.Extenal
{
    public sealed record class GetChartRequest : IRequest<GetChartResponse>;
}
