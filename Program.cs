using BinPack.Models;
using BinPack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");

app.MapPost("/api/binpack", (BinPackingRequest request) =>
{
    var service = new BinPackingService(request.ContainerWidth, request.ContainerHeight);

    var boxes = request.Boxes.Select(b => new Box
    {
        Width = b.Width,
        Height = b.Height
    }).ToList();

    var packed = service.Pack(boxes);

    var response = new BinPackingResponse
    {
        ContainerWidth = request.ContainerWidth,
        ContainerHeight = request.ContainerHeight,
        PackedBoxes = packed.Select(b => new PackedBoxDto
        {
            Width = b.Width,
            Height = b.Height,
            X = b.X ?? 0,
            Y = b.Y ?? 0
        }).ToList()
    };

    return Results.Ok(response);
});

app.Run();