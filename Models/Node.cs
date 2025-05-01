namespace BinPack.Models;

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Used { get; set; } = false;
    public Node? Right { get; set; }
    public Node? Down { get; set; }

    public Node(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}