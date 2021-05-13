using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector2 worldPosition;

    public Node(bool walkable, Vector2 worldPos)
    {
        this.walkable = walkable;
        worldPosition = worldPos;
    }
}
