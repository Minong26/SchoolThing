using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    private GameManager gm;
    public int maxHp = 100;
    public int currentHp;
    public TextMeshProUGUI textHp;
    public Slider slider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentHp > 0 && collision.CompareTag("Bullet"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("GotDemaged_t");
            currentHp -= 10;
            currentHp = Mathf.Max(currentHp, 0);
            slider.value = currentHp / maxHp;
            textHp.text = $"HP:{currentHp}";
            Destroy(collision.gameObject);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("Died");
            gm.Lose();
        }
    }
}
