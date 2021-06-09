using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;

public class Path : MonoBehaviour
{

	public Transform seeker, target;
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

	public void FindPath(Vector3 startPos, Vector3 targetPos)
	{
		

		if (path!= null)
		{
			foreach (Node n in path)
			{
				n.setColorSpriteRendered(Color.red);
			}
			path.Clear();
		}
		Node startNode = grid.NodeFromWorlPosition(startPos);
		Node targetNode = grid.NodeFromWorlPosition(targetPos);

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
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
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
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
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}
}