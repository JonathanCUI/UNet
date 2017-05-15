using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EnemySpawner : NetworkBehaviour {
    public GameObject enemyPrefab;
    public int numEnemies;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnStartServer()
    {
        base.OnStartServer();
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), 0.2f, Random.Range(-8f, 8f));
            Quaternion rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            GameObject enemy = Instantiate(enemyPrefab, pos, rotation) as GameObject;
            NetworkServer.Spawn(enemy);
        }
    }
}
