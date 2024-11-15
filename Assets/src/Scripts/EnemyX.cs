using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    //private GameObject[] all = GameObject.FindGameObjectsWithTag("Enemy");
    public NavMeshAgent agent;
    private SpawnManagerX spawnManagerX;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManagerX = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        speed = spawnManagerX.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hitpoint = player.transform.position;
        agent.SetDestination(hitpoint);
        // Set enemy direction towards player goal and move there
        //Vector3 lookDirection = (player.transform.position).normalized;
        //Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Player")
        {   
            
            //Destroy(gameObject);
            Destroy (GameObject.FindWithTag("Enemy"));
            spawnManagerX.waveCount = 1;
            spawnManagerX.SpawnEnemyWave(1);
            spawnManagerX.GenerateSpawnPosition();
            ResetPlayerPosition();
        } 
        else if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }

    }
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }


}