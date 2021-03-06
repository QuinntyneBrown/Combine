using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Combine.Api.Models;
using Combine.Api.Core;
using Combine.Api.Interfaces;

namespace Combine.Api.Features
{
    public class RemoveProduct
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
                var product = await _context.Products.SingleAsync(x => x.ProductId == request.ProductId);
                
                _context.Products.Remove(product);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Product = product.ToDto()
                };
            }
            
        }
    }
}
