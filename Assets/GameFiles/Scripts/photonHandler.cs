using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;

public class photonHandler : PunBehaviour
{

    private PlayerSpawner spawnScript;
    public ListRooms roomsList;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        var temp = PhotonVoiceNetwork.Client;
        Debug.Log("Awake function was called.");
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("Environment");
    }

    public void CreateNewRoom(string text)
    {
        PhotonNetwork.CreateRoom(text, new RoomOptions { MaxPlayers = 6 }, null);
        roomsList.OnGUI();
    }

    public void JoinOrCreateRoom(string text)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom(text, roomOptions, TypedLobby.Default);
        roomsList.OnGUI();
    }

    public override void OnJoinedRoom()
    {
        LoadScene();
        Debug.Log("We are connected to the room.");
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Environment")
        {
            spawnScript = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<PlayerSpawner>();
            spawnScript.SpawnPlayer();
        }
    }
}
