using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Vector3 _playerPos;
    private float _timer;
    public GameObject bullet;
    public Transform bulletTf;
    public bool canFire;
    public float timeBetweenFiring;
    
    void Start()
    {
        canFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        _GunRotation();
        _Fire();
    }
    private void _GunRotation()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 rotation = _playerPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    
    private void _Fire()
    {
        if (!canFire)
        {
            _timer += Time.deltaTime;
            if (_timer > timeBetweenFiring)
            {
                canFire = true;
                _timer = 0;
            }
        }
        if (canFire)
        {
            Instantiate(bullet, bulletTf.position, quaternion.identity);
            canFire = false;
        }
    }
}
