using BinPack.Models;

namespace BinPack.Services;

public class BinPackingService
{
    private Node _root;

    public BinPackingService(int containerWidth, int containerHeight)
    {
        _root = new Node(0, 0, containerWidth, containerHeight);
    }

    public List<Box> Pack(List<Box> boxes)
    {
        var packedBoxes = new List<Box>();

        foreach (var box in boxes)
        {
            var node = FindNode(_root, box.Width, box.Height);
            if (node != null)
            {
                var placedNode = SplitNode(node, box.Width, box.Height);
                box.X = placedNode.X;
                box.Y = placedNode.Y;
                packedBoxes.Add(box);
            }
        }

        return packedBoxes;
    }

    private Node? FindNode(Node node, int width, int height)
    {
        if (node.Used)
        {
            return FindNode(node.Right!, width, height) ?? FindNode(node.Down!, width, height);
        }
        else if (width <= node.Width && height <= node.Height)
        {
            return node;
        }
        else
        {
            return null;
        }
    }

    private Node SplitNode(Node node, int width, int height)
    {
        node.Used = true;
        node.Down = new Node(node.X, node.Y + height, node.Width, node.Height - height);
        node.Right = new Node(node.X + width, node.Y, node.Width - width, height);
        return node;
    }
}