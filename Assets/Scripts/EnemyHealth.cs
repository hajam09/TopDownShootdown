using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

	public int healthCounter;
	private int currentHealthCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthCounter = healthCounter;
    }

    // Update is called once per frame
    void Update()
    {
    	if(currentHealthCounter<=0)
    	{
    		Destroy(gameObject);
    	}
        
    }

    public void HurtEnemy(int value)
    {
    	currentHealthCounter -= value;
    }
}
