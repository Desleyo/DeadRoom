using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public Transform playerPos, walkPoint;
    NavMeshAgent agent;
    public int randomizer;
    public bool attacked, canWalk, boolTest, setTimer;
    public float distance, fallbackTimer, walkTimer, speed = .75f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fallbackTimer = 7f;
        walkTimer = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        if(canWalk)
        {
            agent.SetDestination(playerPos.position);
            distance = Vector3.Distance(transform.position, playerPos.position);
            fallbackTimer -= Time.deltaTime;

            if (distance <= agent.stoppingDistance)
            {
                startAttack();
            }
        }
        else
        {
            walkTowards();
        }

        walkTimer -= Time.deltaTime;

        if (walkTimer <= 0)
        {
            walkTimer = Mathf.Infinity;
            GetComponent<NavMeshAgent>().enabled = false;
        }

        if(fallbackTimer <= 0 && !attacked)
        {
            fallbackTimer = Mathf.Infinity;
            agent.stoppingDistance = 2.5f;
        }
    }

    void startAttack()
    {
        GetComponent<Animator>().SetBool("preAttack", true);
        if (!attacked)
        {
            randomizer = Random.Range(1, 7);
            GetComponent<Animator>().SetInteger("randomized", randomizer);
            attacked = true;
        }
    }

    void walkTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, walkPoint.position, speed * Time.deltaTime);
        float pointDistance = Vector3.Distance(transform.position, walkPoint.position);
        if (pointDistance <= .1f)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            walkPoint.gameObject.SetActive(false);
            canWalk = true;
            fallbackTimer = 2f;
        }

        if (!setTimer)
        {
            walkTimer = 1f;
            setTimer = true;
        }
    }
}
