using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzureNet7WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AzureNet7WebApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Balance { get; set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Amount { get; set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Total { get; set;}  
    }


public static class OrderEndpoints
{
	public static void MapOrderEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Order").WithTags(nameof(Order));

        group.MapGet("/", async (AzureNet7WebApiContext db) =>
        {
            return await db.Order.ToListAsync();
        })
        .WithName("GetAllOrders")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Order>, NotFound>> (int id, AzureNet7WebApiContext db) =>
        {
            return await db.Order.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Order model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetOrderById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Order order, AzureNet7WebApiContext db) =>
        {
            var affected = await db.Order
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, order.Id)
                  .SetProperty(m => m.Name, order.Name)
                  .SetProperty(m => m.Description, order.Description)
                  .SetProperty(m => m.Type, order.Type)
                  .SetProperty(m => m.Price, order.Price)
                  .SetProperty(m => m.Balance, order.Balance)
                  .SetProperty(m => m.Amount, order.Amount)
                  .SetProperty(m => m.Total, order.Total)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateOrder")
        .WithOpenApi();

        group.MapPost("/", async (Order order, AzureNet7WebApiContext db) =>
        {
            db.Order.Add(order);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Order/{order.Id}",order);
        })
        .WithName("CreateOrder")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AzureNet7WebApiContext db) =>
        {
            var affected = await db.Order
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteOrder")
        .WithOpenApi();
    }
}}
