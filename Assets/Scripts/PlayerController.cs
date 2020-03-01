using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	private Rigidbody myRigidbody;
	private Vector3 moveinput;
	private Vector3 moveVelocity;
	private Camera mainCamera;
    public GunController theGun;
    // Start is called before the first frame update
    void Start()
    {
    	myRigidbody = GetComponent<Rigidbody>();
    	mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
    	// get input multiply by moveSpeed or timescale and apply to rigidbody for player movement.
    	// GetAxisRaw for immediate movement rather than slope movement
    	moveinput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    	moveVelocity = moveinput*moveSpeed; // Try timescale rather than movespeed

    	Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    	Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    	float rayLength;

    	if(groundPlane.Raycast(cameraRay, out rayLength))
    	{
    		Vector3 pointToLook = cameraRay.GetPoint(rayLength);
    		//transform.LookAt(pointToLook);
    		transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    	}

        if(Input.GetMouseButtonDown(0))
            theGun.isFiring = true;


        if(Input.GetMouseButtonUp(0))
            theGun.isFiring = false;

		// RaycastHit hit;
		// Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		// if(Physics.Raycast(ray,out hit,100))
		// {
		// 	transform.LookAt(hit.point);
		// }
    }

    void FixedUpdate()
    {
    	myRigidbody.velocity = moveVelocity;
    }
}
