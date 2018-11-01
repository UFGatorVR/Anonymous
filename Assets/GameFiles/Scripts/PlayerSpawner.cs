using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : OnJoinedInstantiate {

    public delegate void OnPlayerSpawned(GameObject character);

    public static event OnPlayerSpawned PlayerSpawned;

    public void SpawnPlayer()
    {
        Debug.Log("Player joined room");
        // Select a prefab for the player.
        if( this.PrefabsToInstantiate != null)
        {
            // Choose which prefab we will be spawning next.
            GameObject playerPrefab = PrefabsToInstantiate[0];

            Transform spawnPoint = null;
            // Make sure that this component has a child, and that child has a transform.
            if( this.GetComponentInChildren<Transform>() != null)
            {
                spawnPoint = GetSpawnPoint();
            }

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
        Transform spawnPoint = null;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            spawnPoint = gameObject.transform.GetChild(0).GetChild(i);
            if(spawnPoint.childCount == 0)
            {
                return spawnPoint;
            }
        }
        return null;
    }

}
