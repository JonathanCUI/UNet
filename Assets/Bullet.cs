﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
	//test
        //var hitPlayer = hit.GetComponent<PlayerMove>();
        //if (hitPlayer != null)
        //{
        var combat = hit.GetComponent<Combat>();
        if (combat != null)
        {
            combat.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
