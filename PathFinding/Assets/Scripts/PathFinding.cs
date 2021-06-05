using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    public void FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Node startNode = grid.NodeFromWorlPosition(startPosition);
        Node targetNode = grid.NodeFromWorlPosition(targetPosition);

        List<Node> openNodes = new List<Node>();
        HashSet<Node> closedNodes = new HashSet<Node>();

        openNodes.Add(startNode);

        while(openNodes.Count >= 0)
        {
            Node currentNode = openNodes[0];
            for (int i=0; i < openNodes.Count -1; i++)
            {
                if (openNodes[i].fCost< currentNode.fCost || openNodes[i].hCost < currentNode.hCost)
                {
                    currentNode = openNodes[i];
                }
            }

            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);

            if (currentNode == targetNode)
            {
                print("Achamos");
            }
        }
    }
}
