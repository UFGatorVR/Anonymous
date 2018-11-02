using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : OnJoinedInstantiate {

    public delegate void OnPlayerSpawned(GameObject character);

    public static event OnPlayerSpawned PlayerSpawned;

    public void SpawnPlayer()
    {
        Debug.Log("Player joined room");
        Debug.Log("LENGTH" + PhotonNetwork.GetRoomList().Length);
        // Select a prefab for the player.
        if ( this.PrefabsToInstantiate != null)
        {
            // Choose which prefab we will be spawning next.
            GameObject playerPrefab = PrefabsToInstantiate[0];

            Transform spawnPoint = null;
            // Make sure that this component has a child, and that child has a transform.
            if( this.GetComponentInChildren<Transform>() != null)
            {
                spawnPoint = GetSpawnPoint();
            }

            Debug.Log(spawnPoint);

            playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity, 0);

            if( PlayerSpawned != null)
            {
                PlayerSpawned(playerPrefab);
            }

            playerPrefab.transform.parent = spawnPoint;
        }
       
    }

    public Transform GetSpawnPoint()
    {
        Transform spawner = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<Transform>();
        Transform spawnPoint = null;
        for (int i = 0; i < spawner.childCount; i++)
        {
            spawnPoint = spawner.GetChild(i);
            if(spawnPoint.childCount == 0)
            {
                return spawnPoint;
            }
        }
        return null;
    }

}
