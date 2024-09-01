using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Queries.GetByIdPost
{
    public class GetByIdPostQueryRequest : IRequest<GetByIdPostQueryResponse>
    {
        public string Id { get; set; }
    }
}
