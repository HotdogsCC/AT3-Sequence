using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int[,] gameBoardArray = { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //Initiallises 2D array for storing the board's contents
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};

    public int[,] p1BoardArray =   { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //Initiallises 2D array for storing player 1's contents
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};

    public int[,] p2BoardArray =   { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //Initiallises 2D array for storing player 2's contents
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};

    public bool isPlayer1 = true; //Initiallises variable for checking who's turn it is

    public CardsManager cardsManager; //Reference to card manager script

    [SerializeField] private SceneManagement sceneManager; //Reference to sceen manager script

    [SerializeField] private Revealer revealer; //Reference to revealer script

    public void UpdateBoard(int xPos, int yPos, bool oneEyedJack) //Updates the game board, takes in the x and y position on the board and whether it was a one eyed jack
    {
        if (oneEyedJack) //Sets the selected space as empty (one eyed jacks remove)
        {
            gameBoardArray[yPos, xPos] = 0;
            p1BoardArray[yPos, xPos] = 0;
            p2BoardArray[yPos, xPos] = 0;

        }
        else
        {
            gameBoardArray[yPos, xPos] = 1; //Sets the position as taken

            if (isPlayer1) //Checks whether player 1 or 2 put down the token
            {
                p1BoardArray[yPos, xPos] = 1; //Stores the position
                if(HorizontalRowsOfFive("P1") || VerticalRowsOfFive("P1") || DiagonalPosGradRowsOfFive("P1") || DiagonalNegGradRowsOfFive("P1")) //Checks for rows of 5
                {
                    sceneManager.GameOver(true); //Runs the game over function in the scene manager script, passing that player 1 won
                }
            }
            else
            {
                p2BoardArray[yPos, xPos] = 1; //Stores the position
                if (HorizontalRowsOfFive("P2") || VerticalRowsOfFive("P2") || DiagonalPosGradRowsOfFive("P2") || DiagonalNegGradRowsOfFive("P2")) //Checks for rows of 5
                {
                    sceneManager.GameOver(false); //Runs the game over function in the scene manager script, passing that player 2 won
                }
            }
        }

        isPlayer1 = !isPlayer1; //swaps turns
        revealer.Show(); //displays game object that blocks cards
    }

    private bool HorizontalRowsOfFive(string player) //Checks for rows of 5 horizontally 
    {
        bool rowDetected = true; //Used for checking whether a row has been found

        if(player == "P1") //Checks if the algorithm is testing for player 1 or 2
        {
            for (int i = 0; i < 10; i++) //Used to iterate between each row
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible position on a single row
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each tile in a possible row of 5
                    {
                        if (p1BoardArray[i, k] == 0) //If there is an empty space, it cannot be a row of 5
                        {
                            rowDetected = false; //Stores that there is no row of 5
                        }
                    }

                    if (rowDetected)
                    {
                        return true; //If there is a row of 5, return true
                    }

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++) //Used to iterate between each row
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible position on a single row
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each tile in a possible row of 5
                    {
                        if (p2BoardArray[i, k] == 0) //If there is an empty space, it cannot be a row of 5
                        {
                            rowDetected = false; //Stores that there is no row of 5
                        }
                    }

                    if (rowDetected)
                    {
                        return true; //If there is a row of 5, return true
                    }

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }
        
        
        return false; //After all positions have been checked and true hasn't been returned, there is no row of 5. Return false.
    }

    private bool VerticalRowsOfFive(string player) //Checks for rows of 5 vertically 
    {
        bool rowDetected = true; //Used for checking whether a row has been found

        if (player == "P1")
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p1BoardArray[k, i] == 0)
                        {
                            rowDetected = false;
                        }
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 1 has a row of 5 vertically");
                        return true;
                    }

                    rowDetected = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p2BoardArray[k, i] == 0)
                        {
                            rowDetected = false;
                        }
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 2 has a row of 5 vertically");
                        return true;
                    }

                    rowDetected = true;
                }
            }
        }


        return false;
    }

    private bool DiagonalNegGradRowsOfFive(string player)
    {
        bool rowDetected = true;

        if(player == "P1")
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p1BoardArray[i, k] == 0)
                        {
                            rowDetected = false;
                        }

                        i++;
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 1 has a row of 5 diagonally on a negative gradient");
                        return true;
                    }

                    i = i - 5;

                    rowDetected = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p2BoardArray[i, k] == 0)
                        {
                            rowDetected = false;
                        }

                        i++;
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 2 has a row of 5 diagonally on a negative gradient");
                        return true;
                    }

                    i = i - 5;

                    rowDetected = true;
                }
            }
        }

        return false;
    }

    private bool DiagonalPosGradRowsOfFive(string player)
    {
        bool rowDetected = true;

        if(player == "P1")
        {
            for (int i = 9; i > 3; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p1BoardArray[i, k] == 0)
                        {
                            rowDetected = false;
                        }

                        i--;
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 1 has a row of 5 diagonally on a positive gradient");
                        return true;
                    }

                    i = i + 5;

                    rowDetected = true;
                }
            }
        }
        else
        {
            for (int i = 9; i > 3; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p2BoardArray[i, k] == 0)
                        {
                            rowDetected = false;
                        }

                        i--;
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 2 has a row of 5 diagonally on a positive gradient");
                        return true;
                    }

                    i = i + 5;

                    rowDetected = true;
                }
            }
        }

        return false;
    }
}
