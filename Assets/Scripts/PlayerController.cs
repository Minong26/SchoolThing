using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 7f;
    private float _hp = 100f;

    void Update()
    {
        _MovePlayer();
        _PlayerHp();
    }

    private void _MovePlayer()  
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, y, 0);
        movement = Vector3.ClampMagnitude(movement, 1f);
        transform.Translate(movement * (_speed * Time.deltaTime));
    }

    private void _PlayerHp()
    {
        _hp += 0.01f;
    }
}
