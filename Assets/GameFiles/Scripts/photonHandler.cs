using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;

public class photonHandler : Photon.PunBehaviour {

    [SerializeField] private PlayerSpawner spawnScript;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        var temp = PhotonVoiceNetwork.Client;
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
            spawnScript.SpawnPlayer();
        }
    }
}
