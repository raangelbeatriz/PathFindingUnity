using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
   public Transform player;
    public int sizeX = 8;
    public int sizeY = 5;
    public float sizeSquare = 1;
    public Node[,] squares;


    public GameObject square;
    void Start()
    {
        CreateGrid();
        teste();
     // neighbourNodes(NodeFromWorlPosition(player.position));
    }

    // Update is called once per frame
    void Update()
    {
     neighbourNodes(NodeFromWorlPosition(player.position));
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
                    squares[x,y] = new Node(false, position, sq, positionX, positionY);
                    //squares[x, y].gameObjectNode.GetComponent<SpriteRenderer>().color = Color.blue;


                }
                else
                {
                    squares[x,y] = new Node(true, position, sq, positionX, positionY);
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
        }  //Arrumar
         if (currentNode.gridX + 1 <= sizeX - 1)
        {
            Vector3 vector3 = new Vector3(currentNode.gridX +1,currentNode.gridY, 0);
            print("Vizinho da direita é" + vector3);
        }

        return neighbours;
    }


    public Node NodeFromWorlPosition(Vector3 worldposition)
    {
        int x = (int)worldposition.x;
        //int y = (int)(worldposition.y * -1);
        int y = (int)worldposition.y;
        print(x + " " + y);
        return squares[x, y];
    }

    public void teste()
    {
        Node playerNode = NodeFromWorlPosition(player.position);
        foreach(Node n in squares)
        {
          
            
            if (n.walkable == false)
            {

                n.setSpriteRendererBlue();
            }
            /*if (n.worldPosition == playerNode.worldPosition)
            {
                n.setSpriteRenderCyan();
            } */
        }
    }
    
}
