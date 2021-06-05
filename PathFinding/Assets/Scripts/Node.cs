using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public Vector3 worldPosition;
    public bool walkable;

    public Node(bool walkable, Vector3 worldPosition)
    {
        this.walkable = walkable;
        this.worldPosition = worldPosition;
    }
}
