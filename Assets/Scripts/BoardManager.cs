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

    [SerializeField] private AudioSource tokenSFX;

    private void Start()
    {
        tokenSFX = GetComponent<AudioSource>();
    }

    public void UpdateBoard(int xPos, int yPos, bool oneEyedJack) //Updates the game board, takes in the x and y position on the board and whether it was a one eyed jack
    {
        tokenSFX.Play();

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

        if (isPlayer1) //Displays who's turn it is
        {
            revealer.playerTurnText.text = SceneManagement.player1Name + "'s Turn";
        }
        else
        {
            revealer.playerTurnText.text = SceneManagement.player2Name + "'s Turn";
        }
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

        if (player == "P1") //Checks if the algorithm is testing for player 1 or 2
        {
            for (int i = 0; i < 10; i++) //Used to iterate between each column
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible position on a single column
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each tile in a possible sequence of 5
                    {
                        if (p1BoardArray[k, i] == 0) //If there is an empty space, it cannot be a sequence of 5
                        {
                            rowDetected = false; //Stores that there is no sequence of 5
                        }
                    }

                    if (rowDetected)
                    {
                        return true; //If there is a sequence of 5, return true
                    }

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++) //Used to iterate between each column
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible position on a single column
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each tile in a possible sequence of 5
                    {
                        if (p2BoardArray[k, i] == 0) //If there is an empty space, it cannot be a sequence of 5
                        {
                            rowDetected = false; //Stores that there is no sequence of 5
                        }
                    }

                    if (rowDetected)
                    {
                        return true; //If there is a sequence of 5, return true
                    }

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }


        return false; //After all positions have been checked and true hasn't been returned, there is no sequence of 5. Return false.
    }

    private bool DiagonalNegGradRowsOfFive(string player) //Checks for rows of 5 diagonally on a negative gradient 
    {
        bool rowDetected = true; //Used for checking whether a row has been found

        if (player == "P1") //Checks if the algorithm is testing for player 1 or 2
        {
            for (int i = 0; i < 6; i++) //Used to iterate between each position a negative diagonal row could start from
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible starting position on a row
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each position on one possible diagonal
                    {
                        if (p1BoardArray[i, k] == 0) // If there is an empty space, it can't be a row of 5
                        {
                            rowDetected = false; //Stores that there is no sequence of 5
                        }

                        i++; //Incriments column as it is a diagonal it's checking
                    }

                    if (rowDetected) 
                    {
                        return true; //If there is a sequence of 5, return true
                    }

                    i = i - 5; //Resets for the next iteration

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }
        else
        {
            for (int i = 0; i < 6; i++) //Used to iterate between each position a negative diagonal row could start from
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible starting position on a row
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each position on one possible diagonal
                    {
                        if (p2BoardArray[i, k] == 0) // If there is an empty space, it can't be a row of 5
                        {
                            rowDetected = false; //Stores that there is no sequence of 5
                        }

                        i++; //Incriments column as it is a diagonal it's checking
                    }

                    if (rowDetected) 
                    {
                        return true; //If there is a sequence of 5, return true
                    }

                    i = i - 5; //Resets for the next iteration

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }

        return false; //After all positions have been checked and true hasn't been returned, there is no sequence of 5. Return false.
    }

    private bool DiagonalPosGradRowsOfFive(string player) //Checks for rows of 5 diagonally on a negative gradient 
    {
        bool rowDetected = true; //Used for checking whether a row has been found

        if (player == "P1") //Checks if the algorithm is testing for player 1 or 2
        {
            for (int i = 9; i > 3; i--) //Used to iterate between each position a negative diagonal row could start from
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible starting position on a row
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each position on one possible diagonal
                    {
                        if (p1BoardArray[i, k] == 0) //If there is an empty space, it can't be a row of 5
                        {
                            rowDetected = false; //Stores that there is no sequence of 5
                        }

                        i--; //Incriments column as it is a diagonal it's checking
                    }

                    if (rowDetected)
                    {
                        return true; //If there is a sequence of 5, return true
                    }

                    i = i + 5; //Resets for the next iteration

                    rowDetected = true; //Resets for the next iteration
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
