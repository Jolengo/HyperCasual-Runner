using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
     Animator anim;

    LevelManager _levelManager;

    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        anim = gameObject.GetComponent<Animator>();
    }

    /*private void Update()
    {
        Die();
    }*/

    public void Die()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //Debug.Log("Death");
                
                GetComponent<RunnerController>().enabled = false;
                anim.Play("Die");
                _levelManager.WaitAndLoadScene("LoseMenu");
            
           // Destroy(gameObject);
        //}
    }
}
