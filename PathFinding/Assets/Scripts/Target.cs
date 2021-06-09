using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    private Vector3 mousePosition;
    public Transform player, target;
    GameObject gameObject;
    public bool clicked;
    float moveSpeed = 20f;
    Path path;
    private void Awake()
    {
        gameObject = GameObject.Find("A*");
        if (gameObject != null)
        {
            path = gameObject.GetComponent<Path>();

        }
    }
    void Start()
    {
        
    }


    /*private void OnMouseDown()
    {
        if (path != null)
        {
            path.FindPath(player.position, target.position);
        }
    } */

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
        if (path != null)
        {
            print("Path vai");
            path.FindPath(player.position, target.position);
        }
    }

    // Use this for initialization
    void Update()
    {
        if (clicked)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }

    private void OnMouseDrag()
    {
    }

}
