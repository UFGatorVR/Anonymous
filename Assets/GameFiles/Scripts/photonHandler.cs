using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;

public class photonHandler : Photon.PunBehaviour {

    public GameObject mainPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }

    public void CreateNewRoom(string text)
    {
        PhotonNetwork.CreateRoom(text, new RoomOptions { MaxPlayers = 6 }, null);
    }

    public void JoinOrCreateRoom(string text)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom(text, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        LoadScene();
        Debug.Log("We are connected to the room.");
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainGame")
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(mainPlayer.name , mainPlayer.transform.position + new Vector3(0,3,0), mainPlayer.transform.rotation, 0);
    }
}
