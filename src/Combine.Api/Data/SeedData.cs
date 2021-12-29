using System.Collections.Generic;
using System.Linq;

namespace Combine.Api.Data
{
    public static class SeedData
    {
        public static void Seed(CombineDbContext context)
        {
            foreach (var name in new List<string> { "Shoe", "Car", "House" })
            {
                if (context.Products.SingleOrDefault(x => x.Name == name) == null)
                {
                    context.Products.Add(new Models.Product
                    {
                        Name = name
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
