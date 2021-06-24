# PathFindingUnity

A simple pathfinding project implemented in Unity 2D using the A* search algorithm. In this project the player can select the target position and the best path will be selected.

This project was made following a tutorial series in the Sebastian Lague channel, for learning purposes. After watching his videos I was able to understand the main concept as well as how to implement the algorithm in unity. So I've adapted his previous code into a 2D project and added a few features.


# How it works
  - Components:
    - Player represented by the yellow circle
    - Obstacles represented by the blue squares
    - Walkable areas in the grid represented by the red squares
    - Target position represented by the position of the white circle
    - Best path from player to target position represented by the black squares
    
To find the best path from Node A, player position, to Node B, target position, the player must drag the white circle into a walkable area. If the position is walkable then the algorithm will find the shortest path until Node B, and will represent the path changing the color of previous red squares to black.

# What I've learned
  - How to implement a* algorithm in unity
