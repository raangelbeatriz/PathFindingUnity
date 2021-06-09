using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;

public class Path : MonoBehaviour
{

	Grid grid;
	List<Node> path = new List<Node>();

	void Awake()
	{
		grid = GetComponent<Grid>();
	}

	void Update()
	{
		//FindPath(seeker.position, target.position);
	}

	public void FindPath(Vector3 startPosition, Vector3 targetPosition)
	{
		

		if (path!= null)
		{
			foreach (Node n in path)
			{
				n.setColorSpriteRendered(Color.red);
			}
			path.Clear();
		}
		Node startNode = grid.NodeFromWorlPosition(startPosition);
		Node targetNode = grid.NodeFromWorlPosition(targetPosition);

		List<Node> openNodes = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openNodes.Add(startNode);

		while (openNodes.Count > 0)
		{
			Node node = openNodes[0];
			for (int i = 1; i < openNodes.Count; i++)
			{
				if (openNodes[i].getfCost() < node.getfCost() || openNodes[i].getfCost() == node.getfCost())
				{
					if (openNodes[i].hCost < node.hCost)
						node = openNodes[i];
				}
			}

			openNodes.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
				RetracePath(startNode, targetNode);
				return;
			}

			foreach (Node neighbour in grid.neighbourNodes(node))
			{
				if (!neighbour.walkable || closedSet.Contains(neighbour))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openNodes.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openNodes.Contains(neighbour))
						openNodes.Add(neighbour);
				}
			}
		}
	}

	void RetracePath(Node startNode, Node endNode)
	{
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			print(currentNode.gridX + " " + currentNode.gridY);
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();
		grid.path = path;
		foreach (Node p in path)
		{
			p.setColorSpriteRendered(Color.black);
		}
	}

	int GetDistance(Node nodeA, Node nodeB)
	{
		int dstX = Mathf.Abs((int)nodeA.gridX - (int)nodeB.gridX);
		int dstY = Mathf.Abs((int)nodeA.gridY - (int)nodeB.gridY);

		if (dstX > dstY)
		{
			return 14 * dstY + 10 * (dstX - dstY);
		}
		else
		{
			return 14 * dstX + 10 * (dstY - dstX);
		}
		
	}
}