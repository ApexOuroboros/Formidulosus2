using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttack : MonoBehaviour
{
    public Transform player;
    public Transform enemy;

    public playerHealth pHealth;
    public float damage;
    public float speed;

    //NavMeshAgent agent;

    Animator anim;

    [SerializeField] LayerMask groundLayer, playerLayer;

    Vector3 desPoint;
    bool walkpointSet;
    [SerializeField] float range;

    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        //player = GameObject.Find("Player");
        //enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if(playerInSight )
        {
            transform.LookAt(player);

            var step = speed * Time.deltaTime;

            transform.position += transform.forward * step;

            if (playerInAttackRange)
            {
                speed = 0f;
            }
        }

        //if (!playerInSight && !playerInAttackRange) Partol();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("attack");
            collision.gameObject.GetComponent<playerHealth>().health -= damage;
        }
    }
}
