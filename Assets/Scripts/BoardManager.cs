using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int[,] gameBoardArray = { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};

    public int[,] p1BoardArray =   { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};

    public int[,] p2BoardArray =   { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};

    public bool isPlayer1 = true;

    public void UpdateBoard(int xPos, int yPos, bool oneEyedJack)
    {
        if (oneEyedJack)
        {
            gameBoardArray[yPos, xPos] = 0;
            p1BoardArray[yPos, xPos] = 0;
            p2BoardArray[yPos, xPos] = 0;

        }
        else
        {
            gameBoardArray[yPos, xPos] = 1;

            if (isPlayer1)
            {
                p1BoardArray[yPos, xPos] = 1;
                if(HorizontalRowsOfFive("P1") || VerticalRowsOfFive("P1") || DiagonalPosGradRowsOfFive("P1") || DiagonalNegGradRowsOfFive("P1"))
                {
                    Debug.Log("Player 1 Won!");
                }
            }
            else
            {
                p2BoardArray[yPos, xPos] = 1;
                if (HorizontalRowsOfFive("P2") || VerticalRowsOfFive("P2") || DiagonalPosGradRowsOfFive("P2") || DiagonalNegGradRowsOfFive("P2"))
                {
                    Debug.Log("Player 2 Won!");
                }
            }
        }

        isPlayer1 = !isPlayer1;
    }

    private bool HorizontalRowsOfFive(string player)
    {
        bool rowDetected = true;

        if(player == "P1")
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = j; k < j + 5; k++)
                    {
                        if (p1BoardArray[i, k] == 0)
                        {
                            rowDetected = false;
                        }
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 1 has a row of 5 horizontally");
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
                        if (p2BoardArray[i, k] == 0)
                        {
                            rowDetected = false;
                        }
                    }

                    if (rowDetected)
                    {
                        Debug.Log("player 2 has a row of 5 horizontally");
                        return true;
                    }

                    rowDetected = true;
                }
            }
        }
        
        
        return false;
    }

    private bool VerticalRowsOfFive(string player)
    {
        bool rowDetected = true;

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
