using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;
    public TextMeshProUGUI textHp;
    public Slider slider;
    public GameObject loseImg;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (currentHp > 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("GotDemaged_t");
                currentHp -= 10;
                slider.value = (float)currentHp / maxHp;
                Debug.Log(currentHp);
                textHp.text = $"HP:{currentHp}";
                Destroy(collision.gameObject);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("Died_t");
                Debug.Log("You Died");
                loseImg.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
