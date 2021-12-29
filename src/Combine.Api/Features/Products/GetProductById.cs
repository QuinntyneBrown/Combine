using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Combine.Api.Core;
using Combine.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Combine.Api.Features
{
    public class GetProductById
    {
        public class Request: IRequest<Response>
        {
            public Guid ProductId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProductDto Product { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICombineDbContext _context;
        
            public Handler(ICombineDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Product = (await _context.Products.SingleOrDefaultAsync(x => x.ProductId == request.ProductId)).ToDto()
                };
            }
            
        }
    }
}
