using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float maxSpeed;
    [SerializeField] float jumpAmount;

    Vector2 _speedPercent;
    Vector3 _rbVelocity = Vector3.zero;

    void Update()
    {

        _rbVelocity = GetComponent<Rigidbody>().velocity;

        _speedPercent = new Vector2(_rbVelocity.x / maxSpeed, _rbVelocity.y / jumpAmount);
        animator.SetFloat("Xaxis", _speedPercent.x, 0.1f, Time.deltaTime);
        animator.SetFloat("Yaxis", _speedPercent.y, 0.1f, Time.deltaTime);
    }
}
