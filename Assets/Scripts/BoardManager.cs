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

    [SerializeField] private SceneManagementing sceneManager; //Reference to sceen manager script

    [SerializeField] private Revealer revealer; //Reference to revealer script

    [SerializeField] private AudioSource tokenSFX; //Initiallises componet that plays the token SFX

    private void Start() //When the game boots up, assign the token SFX component
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

                //Calculates total amount of rows player 1 got
                int totalRows = HorizontalRowsOfFive("P1") + VerticalRowsOfFive("P1") + DiagonalNegGradRowsOfFive("P1") + DiagonalPosGradRowsOfFive("P1");
                if(totalRows >= SceneManagementing.rowsToFind) //Checks whether they have enough rows, depending on the mode
                {
                    sceneManager.GameOver(true); //Player 1 wins
                }
            }
            else
            {
                p2BoardArray[yPos, xPos] = 1; //Stores the position

                //Calculates total amount of rows player 2 got
                int totalRows = HorizontalRowsOfFive("P2") + VerticalRowsOfFive("P2") + DiagonalNegGradRowsOfFive("P2") + DiagonalPosGradRowsOfFive("P2");
                if (totalRows >= SceneManagementing.rowsToFind) //Checls whether they have enough rows, depending on the mode
                {
                    sceneManager.GameOver(false); //Player 2 Wins
                }
            }
        }

        isPlayer1 = !isPlayer1; //swaps turns

        if (isPlayer1) //Displays who's turn it is
        {
            revealer.playerTurnText.text = SceneManagementing.player1Name + "'s Turn";
        }
        else
        {
            revealer.playerTurnText.text = SceneManagementing.player2Name + "'s Turn";
        }

        revealer.Show(); //displays game object that blocks cards
    }

    private int HorizontalRowsOfFive(string player) //Checks for rows of 5 horizontally 
    {
        bool rowDetected = true; //Used for checking whether a row has been found
        int numOfRows = 0;

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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++; //Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++;//Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
                    }

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }
        
        
        return numOfRows; //Returns the amount of rows detected 
    }

    private int VerticalRowsOfFive(string player) //Checks for rows of 5 vertically 
    {
        bool rowDetected = true; //Used for checking whether a row has been found
        int numOfRows = 0;

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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++;//Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++; //Increases row count by 1
                        j = 6;  //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
                    }

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }


        return numOfRows; //Returns the amount of rows detected 
    }

    private int DiagonalNegGradRowsOfFive(string player) //Checks for rows of 5 diagonally on a negative gradient 
    {
        bool rowDetected = true; //Used for checking whether a row has been found
        int numOfRows = 0;

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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++; //Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++; //Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
                    }

                    i = i - 5; //Resets for the next iteration

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }

        return numOfRows; //Returns the amount of rows detected 
    }

    private int DiagonalPosGradRowsOfFive(string player) //Checks for rows of 5 diagonally on a negative gradient 
    {
        bool rowDetected = true; //Used for checking whether a row has been found
        int numOfRows = 0;

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

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++; //Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
                    }

                    i = i + 5; //Resets for the next iteration

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }
        else
        {
            for (int i = 9; i > 3; i--) //Used to iterate between each position a positive diagonal row could start from
            {
                for (int j = 0; j < 6; j++) //Used to iterate between each possible starting position on a row
                {
                    for (int k = j; k < j + 5; k++) //Used to iterate between each position on one possible diagonal
                    {
                        if (p2BoardArray[i, k] == 0) // If there is an empty space, it can't be a row of 5
                        {
                            rowDetected = false; //Stores that there is no sequence of 5
                        }

                        i--; //Incriments column as it is a diagonal it's checking
                    }

                    if (rowDetected) //Activates when there is a row detected
                    {
                        numOfRows++; //Increases row count by 1
                        j = 6; //Skips out of loop to ensure a row of 6 is not counted as 2 rows of 5
                    }

                    i = i + 5; //Resets for the next iteration

                    rowDetected = true; //Resets for the next iteration
                }
            }
        }

        return numOfRows; //Returns the amount of rows detected 
    }
}
