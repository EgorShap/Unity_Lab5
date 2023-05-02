using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private float minSpeed = 15;
    private float maxSpeed = 19;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticles;

    private void OnMouseDown(){
        if (gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticles, transform.position,
            explosionParticles.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }



    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
