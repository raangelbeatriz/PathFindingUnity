using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
    public int sizeX = 8;
    public int sizeY = 5;
    public float sizeSquare = 1;
    public Node[,] squares;

    public GameObject square;
    void Start()
    {
        CreateGrid();
        teste();
    }

    // Update is called once per frame
    void Update()
    {
        
        //teste();
    }


    void CreateGrid()
    {
        squares = new Node[sizeX, sizeY];
        for (int x= 0; x < sizeX; x++)
        {
            for (int y = 0; y <sizeY; y++)
            {
                float positionX = x * sizeSquare;
                float positionY = y * sizeSquare;
                GameObject sq = Instantiate<GameObject>(square);
                Vector3 position = new Vector3(positionX, positionY, 0);
                sq.transform.position = position;
                
                if (x == 3 && y == 2 || x == 4 && y == 2 || x == 5 && y==2)
                {
                    //squares[x,y] = new Node(false, position, sq, positionX, positionY);
                    squares[x, y] = gameObject.AddComponent<Node>();
                    squares[x, y].walkable = false;
                    squares[x, y].worldPosition = position;
                    squares[x, y].gameObjectNode = sq;
                    squares[x, y].gridX = positionX;
                    squares[x, y].gridY = positionY;
                    //squares[x, y].gameObjectNode.GetComponent<SpriteRenderer>().color = Color.blue;

                }
                else
                {
                    squares[x, y] = gameObject.AddComponent<Node>();
                    squares[x, y].walkable = true;
                    squares[x, y].worldPosition = position;
                    squares[x, y].gameObjectNode = sq;
                    squares[x, y].gridX = positionX;
                    squares[x, y].gridY = positionY;
                }

            }
        }


        float gridW = sizeX * sizeSquare;
        float gridH = sizeY * sizeSquare;

        transform.position = new Vector3(-gridW / 2 + sizeSquare, gridH / 2 - sizeSquare / 2, 0);
    }


    public List<Node> neighbourNodes (Node currentNode)
    {
        List<Node> neighbours = new List<Node>();

        //Left
        if (currentNode.gridX -1 >=0)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX - 1, currentNode.gridY, 0);
           //print("Vizinho da esquerda é" + vector3);

            neighbours.Add(NodeFromWorlPosition(vector3));

        }  
        //Left Up
        if (currentNode.gridX -1 >= 0 && currentNode.gridY + 1 <= sizeY)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX - 1, currentNode.gridY + 1, 0);
            //print("Vizinho da esquerda pra cima é" + vector3);

            neighbours.Add(NodeFromWorlPosition(vector3));
        }

        //LeftDown 
        if (currentNode.gridX - 1 >= 0 && currentNode.gridY - 1 >= 0)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX - 1, currentNode.gridY - 1, 0);
            //print("Vizinho da esquerda pra baixo é" + vector3);

            neighbours.Add(NodeFromWorlPosition(vector3));
        }

        //Right
        if (currentNode.gridX + 1 <= sizeX)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX +1,currentNode.gridY, 0);
            //print("Vizinho da direita é" + vector3);
            neighbours.Add(NodeFromWorlPosition(vector3));
        }
        //Right up
        if (currentNode.gridX + 1 <= sizeX && currentNode.gridY + 1 <= sizeY)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX + 1, currentNode.gridY + 1, 0);
            //print("Vizinho da direita pra cima é" + vector3);

            neighbours.Add(NodeFromWorlPosition(vector3));
        }

        //RightDown
        if (currentNode.gridX + 1 <= sizeX && currentNode.gridY - 1 >= 0)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX + 1, currentNode.gridY - 1, 0);
            //print("Vizinho da direita pra baixo é" + vector3);

            neighbours.Add(NodeFromWorlPosition(vector3));
        }

        //Up
        if (currentNode.gridY + 1 <= sizeY)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX, currentNode.gridY +1, 0);
            //print("Vizinho de cima é" + vector3);
            neighbours.Add(NodeFromWorlPosition(vector3));
        }
        //Down
        if (currentNode.gridY -1 >= 0)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX, currentNode.gridY - 1, 0);
            //print("Vizinho de baixo é" + vector3);
            neighbours.Add(NodeFromWorlPosition(vector3));
        }

        return neighbours;
    }


    public Node NodeFromWorlPosition(Vector3 worldposition)
    {
        int x = (int)worldposition.x;
        int y = (int)worldposition.y;
        //print(x + " " + y);
        return squares[x, y];
        
    }

    public List<Node> path;
    public void teste()
    {
        //Node playerNode = NodeFromWorlPosition(player.position);
        foreach(Node n in squares)
        {  
            if (n.walkable == false)
            {

                n.setColorSpriteRendered(Color.blue);
            }
            else
            {
                n.setColorSpriteRendered(Color.red);
            }
        }
    }
    
}
