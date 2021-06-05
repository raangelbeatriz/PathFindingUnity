using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
    public Transform player;
    public int sizeX = 9;
    public int sizeY = 9;
    public float sizeSquare = 1;
    public Node[,] squares;

    public GameObject[,] gameObjects;

    public GameObject[,] gameObjectsNode;

    public GameObject square;
    void Start()
    {
        gameObjectsNode = new GameObject[sizeX, sizeY];
        squares = new Node[sizeX, sizeY];
        CreateGrid();
        NodePlayerPosition(player.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NodePlayerPosition(Vector3 position)
    {
        int positionX = (int)position.x;
        int positionY = (int)(position.y * -1);

        Debug.Log(positionX + " " + positionY);

        gameObjectsNode[positionX, positionY].GetComponent<SpriteRenderer>().color = Color.cyan;

    }

    void CreateGrid()
    {
        squares = new Node[sizeX, sizeY];
        for (int x= 0; x < sizeX; x++)
        {
            for (int y = 0; y <sizeY; y++)
            {
                float positionX = x * sizeSquare;
                float positionY = y * -sizeSquare;
                GameObject sq = Instantiate<GameObject>(square);
                Vector3 position = new Vector3(positionX, positionY, 0);
                sq.transform.position = position;
                
                if (x == 3 && y == 2 || x == 4 && y == 2 || x == 5 && y==2)
                {
                    squares[x, y] = new Node(false, position);

                    sq.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else
                {
                    squares[x, y] = new Node(true, position);
                }

                gameObjectsNode[x, y] = sq;
            }
        }

        /*foreach( Node n in squares)
        {
            if (n.walkable == false)
            {
                print(n.worldPosition.x + " " + n.worldPosition.y); 
            }
        } */


        float gridW = sizeX * sizeSquare;
        float gridH = sizeY * sizeSquare;

        transform.position = new Vector3(-gridW / 2 + sizeSquare, gridH / 2 - sizeSquare / 2, 0);
    }

}
