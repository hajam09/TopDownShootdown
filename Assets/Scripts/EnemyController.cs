using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float moveSpeed;

    public PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }

    void FixedUpdate()
    {
        // Move towards the direction the object is facing
        myRigidbody.velocity = (transform.forward*moveSpeed);
    }
}