using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Combine.Api.Core;
using Combine.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Combine.Api.Features
{
    public class GetProducts
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<ProductDto> Products { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICombineDbContext _context;
        
            public Handler(ICombineDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Products = await _context.Products.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
