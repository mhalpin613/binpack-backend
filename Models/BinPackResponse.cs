namespace BinPack.Models;

public class BinPackingResponse
{
    public int ContainerWidth { get; set; }
    public int ContainerHeight { get; set; }
    public List<PackedBoxDto> PackedBoxes { get; set; } = new();
}

public class PackedBoxDto
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}
