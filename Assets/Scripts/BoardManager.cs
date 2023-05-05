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

    private void Start()
    {
        
    }

}
