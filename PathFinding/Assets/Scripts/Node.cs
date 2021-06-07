using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 worldPosition;
    public bool walkable;
    public GameObject gameObjectNode;

    public float gridX;
    public float gridY;
    public int hCost;
    public int gCost;
    public int fCost;

    public Node(bool walkable, Vector3 worldPosition, GameObject gameObjectNode, float gridX, float gridY)
    {
        this.walkable = walkable;
        this.worldPosition = worldPosition;
        this.gameObjectNode = gameObjectNode;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public void setSpriteRendererBlue()
    {
        gameObjectNode.GetComponent<SpriteRenderer>().color = Color.blue;
        
    }

    public void setSpriteRenderCyan()
    {
        gameObjectNode.GetComponent<SpriteRenderer>().color = Color.cyan;
    }

}
