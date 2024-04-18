using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace InventoryManagement.Models;

public partial class TblUsersInfo
{
    [Key]
    public int? UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public bool IsActive { get; set; }
}


public static class TblUsersInfoEndpoints
{
	public static void MapTblUsersInfoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/TblUsersInfo").WithTags(nameof(TblUsersInfo));

        group.MapGet("/", () =>
        {
            return new [] { new TblUsersInfo() };
        })
        .WithName("GetAllTblUsersInfos")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new TblUsersInfo { ID = id };
        })
        .WithName("GetTblUsersInfoById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, TblUsersInfo input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateTblUsersInfo")
        .WithOpenApi();

        group.MapPost("/", (TblUsersInfo model) =>
        {
            //return TypedResults.Created($"/api/TblUsersInfos/{model.ID}", model);
        })
        .WithName("CreateTblUsersInfo")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new TblUsersInfo { ID = id });
        })
        .WithName("DeleteTblUsersInfo")
        .WithOpenApi();
    }
}