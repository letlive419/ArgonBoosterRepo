using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int pointsForKills = 12;


    ScoreBoard scoreBoard;


    // Start is called before the first frame update
    void Start()
    {
        AddEnemyBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddEnemyBoxCollider()
    {
       Collider boxNotATrigger= gameObject.AddComponent<BoxCollider>();
        boxNotATrigger.isTrigger = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {

        scoreBoard.scoreHit(pointsForKills);
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        
        Destroy(gameObject);

    }
}
