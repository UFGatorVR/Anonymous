using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class ListController : Photon.MonoBehaviour {

    public Button roomName;
    public Text currPlayers;
    public Text maxPlayers;

    RoomInfo[] rooms;
    public RectTransform listPrefab;
    public ScrollRect scrollView;
    public RectTransform contentPanel;


    void Start () {
        rooms = PhotonNetwork.GetRoomList();
        UpdateList();
    }
	
	public void UpdateList ()
    {
        foreach (RoomInfo e in rooms)
        {
            RectTransform newRoom = Instantiate(listPrefab) as RectTransform;
            newRoom.GetChild(0).GetComponentInChildren<Text>().text = e.Name;
            newRoom.GetChild(1).GetComponent<Text>().text  = e.PlayerCount.ToString();
            newRoom.GetChild(2).GetComponent<Text>().text = e.MaxPlayers.ToString();

            newRoom.transform.parent = contentPanel.transform;
            newRoom.transform.localScale = Vector3.one;
        }
    }

    /*public void RemoveServer()
    {
        Button parent;
        string serverName;
        parent = transform.parent.gameObject.GetComponent<Button>();
        serverName = parent.GetComponentInChildren<Text>().text;
        //Close the server

    }*/
}
