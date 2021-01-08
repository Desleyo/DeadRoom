using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public GameObject wendigoD, eventPlayer;
    public Transform playerPos, walkPoint, spawnPoint;
    NavMeshAgent agent;
    public AudioSource preAttack, attack;
    public AudioClip[] attackSounds;
    public int randomizer, room, pathfindWarning;
    public bool attacked, canWalk, stairs, setTimer, attackStarted, playerFound;
    public float distance, lastDistance = Mathf.Infinity, attackSoundTimer = Mathf.Infinity, walkTimer = Mathf.Infinity, speed = .75f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathfindWarning == 3 && !playerFound)
        {
            FindPlayer();
            canWalk = false;
        }

        if (canWalk)
        {
            agent.SetDestination(playerPos.position);
            distance = Vector3.Distance(transform.position, playerPos.position);

            if(distance <= agent.stoppingDistance && !attackStarted)
            {
                startAttack();
                attackStarted = true;
            }
            else if(distance < lastDistance)
            {
                lastDistance = distance;
            }
            else if(distance == lastDistance && !attackStarted)
            {
                pathfindWarning += 1;
            }
        }
        else if(!stairs && pathfindWarning != 3)
        {
            walkTowards();
        }

        walkTimer -= Time.deltaTime;

        if (walkTimer <= 0 && !stairs)
        {
            walkTimer = Mathf.Infinity;
            agent.enabled = false;
        }
        else if(walkTimer <= 0 && stairs)
        {
            wendigoD.SetActive(true);
            wendigoD.GetComponent<Animator>().SetBool("walk", true);
            gameObject.SetActive(false);
        }

        if(attackSoundTimer <= 0)
        {
            attackSoundTimer = Mathf.Infinity;
            attack.clip = attackSounds[randomizer];
            attack.Play();
            eventPlayer.GetComponent<End>().SetTimer();
        }

        attackSoundTimer -= Time.deltaTime;
    }

    void startAttack()
    {
        transform.LookAt(playerPos);
        GetComponent<Animator>().SetBool("preAttack", true);
        preAttack.Play();
        if (!attacked)
        {
            randomizer = Random.Range(0, 6);
            GetComponent<Animator>().SetInteger("randomized", randomizer);
            attackSoundTimer = 8;
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
                agent.enabled = true;
                walkPoint.gameObject.SetActive(false);
                canWalk = true;
            }
        }
        else if(room == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint.position, speed * Time.deltaTime);
            float pointDistance = Vector3.Distance(transform.position, spawnPoint.position);
            if (pointDistance <= .1f)
            {
                agent.enabled = true;
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

    void FindPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        float pointDistance = Vector3.Distance(transform.position, playerPos.position);
        Debug.Log(pointDistance);
        if(pointDistance <= agent.stoppingDistance)
        {
            startAttack();
            playerFound = true;
            attackStarted = true;
        }
        else if(pointDistance < lastDistance)
        {
            lastDistance = pointDistance;
        }
        else if(pointDistance >= lastDistance)
        {
            startAttack();
            playerFound = true;
            attackStarted = true;
        }
    }
}
