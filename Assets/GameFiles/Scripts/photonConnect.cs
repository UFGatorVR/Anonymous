using Photon;
using UnityEngine;

public class photonConnect : Photon.PunBehaviour {

    public string versionName = "0.1";

    public GameObject sectionView1, sectionView2, sectionView3;

    // Use this for initialization
    /*
    public void connectToPhoton () {
        PhotonNetwork.GameVersion = versionName;
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connecting to Photon");
	}
    */

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("Connecting to photon...");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connected to Master");
    }

    public override void OnDisconnectedFromPhoton()
    {
        if (sectionView1.activeInHierarchy)
        {
            sectionView1.SetActive(false);
        }

        if (sectionView2.activeInHierarchy)
        {
            sectionView2.SetActive(false);
        }

        sectionView3.SetActive(true);

        Debug.Log("Disconnected from Photon services");
    }

    public override void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);

        Debug.Log("On joined lobby");
    }
}
