﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public GameObject wendigoD;
    public Transform playerPos, walkPoint, spawnPoint;
    NavMeshAgent agent;
    public AudioSource preAttack, attack;
    public AudioClip[] attackSounds;
    public int randomizer, room;
    public bool attacked, canWalk, stairs, setTimer, attackStarted;
    public float distance, fallbackTimer, attackSoundTimer = Mathf.Infinity, walkTimer = Mathf.Infinity, speed = .75f;

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

            if (distance <= agent.stoppingDistance && !attackStarted)
            {
                startAttack();
                attackStarted = true;
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

        if(attackSoundTimer <= 0)
        {
            attackSoundTimer = Mathf.Infinity;
            attack.clip = attackSounds[randomizer];
            attack.Play();
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
