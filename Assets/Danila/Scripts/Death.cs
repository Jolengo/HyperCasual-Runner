using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Health _health;
    void Awake()
    {
        _health = FindObjectOfType<Health>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Trap"))
        {
            _health.Die();
        }
    }

}
