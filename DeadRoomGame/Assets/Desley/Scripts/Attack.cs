using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public GameObject wendigoD;
    public Transform playerPos, walkPoint, spawnPoint;
    NavMeshAgent agent;
    public int randomizer, room;
    public bool attacked, canWalk, stairs, setTimer;
    public float distance, fallbackTimer, walkTimer = Mathf.Infinity, speed = .75f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        else if(!stairs)
        {
            walkTowards();
        }

        walkTimer -= Time.deltaTime;

        if (walkTimer <= 0 && !stairs)
        {
            walkTimer = Mathf.Infinity;
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else if(walkTimer <= 0 && stairs)
        {
            wendigoD.SetActive(true);
            wendigoD.GetComponent<Animator>().SetBool("walk", true);
            wendigoD.GetComponent<Attack>().fallbackTimer = 3f;
            gameObject.SetActive(false);
        }

        if(fallbackTimer <= 0 && !attacked)
        {
            fallbackTimer = Mathf.Infinity;
            agent.stoppingDistance = 2.5f;
        }
    }

    void startAttack()
    {
        transform.LookAt(playerPos);
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
        if(room == 2)
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
        }
        else if(room == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint.position, speed * Time.deltaTime);
            float pointDistance = Vector3.Distance(transform.position, spawnPoint.position);
            if (pointDistance <= .1f)
            {
                GetComponent<NavMeshAgent>().enabled = true;
                spawnPoint.gameObject.SetActive(false);
                canWalk = true;
            }
        }

        if (!setTimer)
        {
            walkTimer = 1f;
            setTimer = true;
        }
    }
}
