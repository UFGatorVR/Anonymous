using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : OnJoinedInstantiate {

    public delegate void OnPlayerSpawned(GameObject character);

    public static event OnPlayerSpawned PlayerSpawned;
    public PhotonView photonView;
    public Vector3 selfPosition;

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

    private void Start()
    {
        transform.position = new Vector3(-1.9f, 0.98f, 2.03f);
        selfPosition = transform.position;
    }

    void Update()
    {
        if (photonView.isMine)
        {
            //Handle our movement/camera
            selfPosition = transform.position;
        }
        else
        {
            //Handle other's movement/camera
            transform.position = selfPosition;
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            selfPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
