using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _mousePos;
    private float _timer;
    private float _buildTimer;
    public GameObject wall;
    public Transform wallTf;
    public bool canBuild;
    public float cooldown;
    public float timeBetweenBuild;
    public GameObject blueprint;
    //public Animation cannotBuild;
    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canBuild = true;
    }

    // Update is called once per frame
    void Update()
    {
        _BuildPosition();
        _BuildWall();
    }

    private void _BuildPosition()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void _BuildWall()
    {
        if (!canBuild)
        {
            cooldown = 5f;
            _timer += Time.deltaTime;
            if (_timer > cooldown)
            {
                canBuild = true;
                _timer = 0;
            }
        }

        if (Input.GetMouseButton(1) && canBuild)
        {
            _buildTimer += Time.deltaTime;
            if (_buildTimer < 0.25f)
            {
                if (timeBetweenBuild / 2f == 0)
                {
                    Instantiate(wall, wallTf.position, quaternion.identity);
                }
                
                
                //InvokeRepeating("InstantiateWall", 0f, 0.1f);
            }
            else
            {
                _buildTimer = 0;
                canBuild = false;
            }
        }

        if (Input.GetMouseButtonDown(1) && !canBuild)
        {
            blueprint.GetComponent<Animator>().SetTrigger("!CanBuild_t");
        }
    }
    /*
    private void InstantiateWall()
    {
        Instantiate(wall, wallTf.position, quaternion.identity);
    }
    */
}
