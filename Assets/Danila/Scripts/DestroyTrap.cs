using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrap : MonoBehaviour
{
    [SerializeField] GameObject Particle;
    [SerializeField] GameObject Trap;
    [SerializeField] TrapScore trapScore;

    private void Awake()
    {
        trapScore = FindObjectOfType<TrapScore>();
    }

    private void OnMouseDown()
    {
        Destroy(Trap);
        Instantiate(Particle, transform.position, transform.rotation);
        trapScore.AddScore();
    }
}
