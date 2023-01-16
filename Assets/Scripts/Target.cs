using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    [SerializeField] float minSpeed = 10;
    [SerializeField] float maxSpeed = 20;
    [SerializeField] float torqueValue = 10;
    [SerializeField] float xRange = 5;
    [SerializeField] float yRange = 6;
    [SerializeField] int pointValue;
    [SerializeField] ParticleSystem explosionParticle;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        RandomPos();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void RandomPos()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), -yRange);
    }

    private float RandomTorque()
    {
        return Random.Range(-torqueValue, torqueValue);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        
    }
}
