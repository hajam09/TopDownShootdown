using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

	public float speed;
    public float elapsed;
    public int damageValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

        elapsed -= Time.deltaTime;
        if(elapsed<=0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
    	if(other.gameObject.tag=="Enemy" || other.gameObject.tag=="Wall")
    	{
    		// Bullet has collided with the enemies
    		other.gameObject.GetComponent<EnemyHealth>().HurtEnemy(damageValue);
    		Destroy(gameObject);
    	}
    }
}