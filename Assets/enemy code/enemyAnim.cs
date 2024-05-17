using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnim : MonoBehaviour
{
    Animator anim;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(speed <= 0.1)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle",  true);
        }
        else if(speed > 0.1 || speed <= 5.1)
        {
            anim.SetBool("isWalking", true) ;
            anim.SetBool("isIdle", false) ;
        }
        else if( speed > 5.1 ||  speed <= 10)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true ) ;
        }
    }
}
