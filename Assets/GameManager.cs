using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject loseImg;

    public void Lose()
    {
        Debug.Log("You Died");
        loseImg.SetActive(true);
        Time.timeScale = 0;
    }
}
