using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public Transform _player;

    public float moveSpeed = 3f;

    public float detectRadius = 3f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bool isPlayerNearby = Vector3.Distance(this.transform.position, _player.position) < detectRadius;
        if(isPlayerNearby)
        {
            this.transform.LookAt(_player.position);
            _rigidbody.velocity += this.transform.forward.normalized * moveSpeed * Time.deltaTime * Vector3.Distance(this.transform.position, _player.position);
        }
        else
        {
            _rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HealthManager.instance.countinuousDamage(80f, 10f);
            _rigidbody.velocity += -this.transform.forward.normalized * 10.0f;
        }
    }
}
