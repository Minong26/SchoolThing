using UnityEngine;

public class EnemyNormalBullet : MonoBehaviour
{
    private Vector3 _playerPos;
    private Rigidbody2D _rb;
    private float _timer;
    private float _disappearTime;
    public float force;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = _playerPos - transform.position;
        Vector3 rotation = transform.position - _playerPos;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    
    void Update()
    {
        _disappearTime = 3f;
        _timer += Time.deltaTime;
        if (_timer > _disappearTime)
        {
            Destroy(gameObject);
        }
    }
}
