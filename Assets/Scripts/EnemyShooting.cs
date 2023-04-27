using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _playerPos;
    private float _timer;
    public GameObject bullet;
    public Transform bulletTf;
    public bool canFire;
    public float timeBetweenFiring;
    
    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        _GunRotation();
    }
    private void _GunRotation()
    {
        _playerPos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _playerPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
