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

            Vector3 spawnPoint = Vector3.zero;
            // Make sure that this component has a child, and that child has a transform.
            if( this.GetComponentInChildren<Transform>() != null)
            {
                spawnPoint = GetSpawnPoint();
            }

            playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint, Quaternion.identity, 0);
            if( PlayerSpawned != null)
            {
                PlayerSpawned(playerPrefab);
            }
        }
    }

    public Vector3 GetSpawnPoint()
    {
        Transform spawnPosition = this.GetComponentInChildren<Transform>();
        // This assumes that the max player count is 6.
        spawnPosition.RotateAround(Vector3.zero, Vector3.up, 60f);

        return spawnPosition.position;
    }

}
