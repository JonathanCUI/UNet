using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {

    public GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;
        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Command function is called from the client, but invoked on the server
            CmdFire();
        }

	}

    [Command]
    void CmdFire()
    {
        // this command code is run on the server

        //create the bullet object locally
        var bullet = Instantiate(bulletPrefab, transform.position - transform.forward, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = -1f * transform.forward * 4f;

        //spawn the bullet on the clients
        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }


    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
