using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
    //public Transform player;
    public int sizeX = 9;
    public int sizeY = 9;
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
                    squares[x,y] = new Node(false, position, sq);
                    //squares[x, y].gameObjectNode.GetComponent<SpriteRenderer>().color = Color.blue;


                }
                else
                {
                    squares[x,y] = new Node(true, position, sq);
                }

            }
        }


        float gridW = sizeX * sizeSquare;
        float gridH = sizeY * sizeSquare;

        transform.position = new Vector3(-gridW / 2 + sizeSquare, gridH / 2 - sizeSquare / 2, 0);
    }


    public Node NodeFromWorlPosition(Vector3 worldposition)
    {
        int x = (int)worldposition.x;
        int y = (int)(worldposition.y * -1);
        print(x + " " + y);
        return squares[x, y];
    }


    private void teste()
    {
        //Node playerNode = NodeFromWorlPosition(player.position);
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
