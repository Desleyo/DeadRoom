using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public GameObject wendigoD, eventPlayer, bedroomDoor;
    public Transform playerPos, walkPoint, spawnPoint;
    NavMeshAgent agent;
    public AudioSource preAttack, attack;
    public AudioClip[] attackSounds;
    public int randomizer, room, pathfindWarning;
    public bool attacked, canWalk, stairs, setTimer, attackStarted, playerFound, spawned;
    public float distance, lastDistance = Mathf.Infinity, walkDistance, attackSoundTimer = Mathf.Infinity, walkTimer = Mathf.Infinity, speed = .75f;
    Quaternion neededRotation;

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
            if (!spawned)
            {
                bedroomDoor.transform.rotation = Quaternion.Euler(0, -90, 0);
                transform.position = Vector3.MoveTowards(transform.position, spawnPoint.position, speed * Time.deltaTime);
                walkDistance = Vector3.Distance(transform.position, spawnPoint.position);
                transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, walkPoint.position, speed * Time.deltaTime);
                walkDistance = Vector3.Distance(transform.position, walkPoint.position);
                neededRotation = Quaternion.LookRotation(walkPoint.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, .05f);
            }

            if (walkDistance <= .1f && !spawned)
            {
                spawned = true;
            }
            else if(walkDistance <= .1f && spawned)
            {
                agent.enabled = true;
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
        neededRotation = Quaternion.LookRotation(playerPos.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, .05f);
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        float pointDistance = Vector3.Distance(transform.position, playerPos.position);
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
