using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour {

    public Button roomName;
    public Text currPlayers;
    public Text maxPlayers;

    private List<RoomClass> rooms;
    public GameObject listPrefab;
    public GameObject contentPanel;

    void Start () {
        rooms = new List<RoomClass>();
	}
	
	public void UpdateList ()
    {
        foreach (RoomClass r in rooms)
        {
            GameObject newRoom = Instantiate(listPrefab) as GameObject;
            ListItemController controller = newRoom.GetComponent<ListItemController>();
            controller.roomName.GetComponentInChildren<Text>().text = r.roomName.GetComponentInChildren<Text>().text;
            controller.currPlayers.text = r.currPlayers.text;
            controller.maxPlayers.text = r.maxPlayers.text;
            newRoom.transform.parent = contentPanel.transform;
            newRoom.transform.localScale = Vector3.one;
        }
    }
}
