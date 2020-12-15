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

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPos.position);
        float distance = Vector3.Distance(transform.position, playerPos.position);

        if(distance <= 1)
        {
            GetComponent<Animator>().SetBool("preAttack", true);
            if (!attacked)
            {
                randomizer = Random.Range(1, 7);
                GetComponent<Animator>().SetInteger("randomized", randomizer);
                attacked = true;
            }
        }
    }
}
