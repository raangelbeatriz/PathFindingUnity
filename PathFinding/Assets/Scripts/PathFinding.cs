using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Grid grid;
    public Transform player;
    public Transform target;
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        FindPath(player.position, target.position);
    }
    public void FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Node startNode = grid.NodeFromWorlPosition(startPosition);
        Node targetNode = grid.NodeFromWorlPosition(targetPosition);

        List<Node> openNodes = new List<Node>();
        HashSet<Node> closedNodes = new HashSet<Node>();

        openNodes.Add(startNode);

        while(openNodes.Count > 0)
        {
            
            Node currentNode = openNodes[0];

            print(openNodes[0].gridX);
        for (int i=0; i < openNodes.Count; i++)
        {
            if (openNodes[i].fCost< currentNode.fCost || openNodes[i].hCost < currentNode.hCost)
            {
                currentNode = openNodes[i];
                print(currentNode.gridX + " " + currentNode.gridY);
            }
        }

            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePathNodes(currentNode, targetNode);
                grid.teste();
                print("Achamos");
                return;
            }

            foreach(Node neigbhour in grid.neighbourNodes(currentNode))
            {
                if (!neigbhour.walkable || closedNodes.Contains(neigbhour))
                {
                    continue;
                }

                int newMovementCostToNeigbhour = currentNode.gCost + getDistance(currentNode, neigbhour);

                if (newMovementCostToNeigbhour < neigbhour.gCost || !openNodes.Contains(neigbhour))
                {
                    neigbhour.gCost = newMovementCostToNeigbhour;
                    neigbhour.hCost = getDistance(neigbhour, targetNode);
                    neigbhour.parent = currentNode;

                    if (!openNodes.Contains(neigbhour))
                    {
                        openNodes.Add(neigbhour);
                    }
                }


            } 


        }

        void RetracePathNodes(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;
            print("testando");
            while (currentNode != startNode)
            {
                print("entrou");
                path.Add(currentNode);

                currentNode = currentNode.parent;
            }

            path.Reverse();

            grid.path = path;
         
        }

        int getDistance(Node sourceNode, Node targetNode)
        {
            int distX = Math.Abs((int)sourceNode.gridX - (int)targetNode.gridX);
            int distY = Math.Abs((int)sourceNode.gridY - (int)targetNode.gridY);

            if (distX > distY)
            {
                return 14 * distY + 10*distX;
            }
            else
            {
                return 10 * distY + 14 * distY;
            }

        }
    }
}
