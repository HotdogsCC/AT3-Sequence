using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revealer : MonoBehaviour
{
    [SerializeField] private GameObject blocker;
    public void Hide()
    {
        blocker.SetActive(false);
    }

    public void Show()
    {
        blocker.SetActive(true);
    }
}
