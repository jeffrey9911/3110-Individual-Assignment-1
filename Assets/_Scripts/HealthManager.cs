using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public float _health = 100;

    private float _counter;
    private float healthAffected;
    private bool isAffecting;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void recoverInstantHealth(float healthToRecover)
    {
        _health += healthToRecover;
        Debug.Log("[Health] : " + _health);
    }

    public void recoverContinuousHealth(float healthToRevocer, float inSeconds)
    {
        healthAffected = healthToRevocer / inSeconds * Time.deltaTime;
        _counter = inSeconds;
        isAffecting = true;
    }

    public void instantDamage(float damageToDeal)
    {
        _health -= damageToDeal;
        Debug.Log("[Health] : " + _health);
    }

    public void countinuousDamage(float damageToDeal, float inSeconds)
    {
        healthAffected = -damageToDeal / inSeconds * Time.deltaTime;
        _counter = inSeconds;
        isAffecting = true;
    }

    private void FixedUpdate()
    {
        if(isAffecting)
        {
            _health += healthAffected;
            _counter -= Time.deltaTime;
            isAffecting = _counter > 0;

            Debug.Log("[Health] : " + _health);
        }
    }
}
