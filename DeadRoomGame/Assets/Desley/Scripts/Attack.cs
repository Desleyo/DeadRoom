using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public Transform playerPos;
    NavMeshAgent agent;
    public int randomizer;
    public bool attacked;
    public float distance, timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPos.position);
        distance = Vector3.Distance(transform.position, playerPos.position);
        timer -= Time.deltaTime;

        if(distance <= agent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("preAttack", true);
            if (!attacked)
            {
                randomizer = Random.Range(1, 7);
                GetComponent<Animator>().SetInteger("randomized", randomizer);
                attacked = true;
            }
        }
        else if(timer <= 0)
        {
            timer = Mathf.Infinity;
            agent.stoppingDistance = 2.5f;
        }
    }
}
