using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Endpoints;

public static class ProductEndpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/api/products", async ([FromServices] ProductDbContext db)
            => await db.Products.ToListAsync());

        routeBuilder.MapPost("/api/product", async ([FromServices] ProductDbContext db, [FromBody] Product product) =>
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return Results.Created($"/product/{product.ProductId}", product);
        });

        routeBuilder.MapGet("/api/product/{id}", async ([FromServices] ProductDbContext db, [FromRoute] int id)
            => await db.Products.FindAsync(id));

        routeBuilder.MapPut("/api/product/{id}", async ([FromServices] ProductDbContext db, [FromBody] Product product, [FromRoute] int id) =>
        {
            var p = await db.Products.FindAsync(id);
            if (p is null) return Results.NotFound();
            p.ProductName = product.ProductName;
            p.ProductCode = product.ProductCode;
            p.ProductPrice = product.ProductPrice;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        routeBuilder.MapDelete("/api/product/{id}", async ([FromServices] ProductDbContext db, [FromRoute] int id) =>
        {
            var pizza = await db.Products.FindAsync(id);
            if (pizza is null)
            {
                return Results.NotFound();
            }
            db.Products.Remove(pizza);
            await db.SaveChangesAsync();
            return Results.Ok();
        });
    }
}
