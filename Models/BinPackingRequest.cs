namespace BinPack.Models;

public class BinPackingRequest
{
    public int ContainerWidth { get; set; }
    public int ContainerHeight { get; set; }
    public List<BoxDto> Boxes { get; set; } = new();
}

public class BoxDto
{
    public int Width { get; set; }
    public int Height { get; set; }
}