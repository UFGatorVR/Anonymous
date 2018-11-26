using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon;

public class PlayerController : Photon.MonoBehaviour {

    public GameObject menu;
	
	// Update is called once per frame
	void Update () {
		if (GvrController.ClickButtonDown == true)
        {
            if (menu.activeSelf == true)
                menu.SetActive(false);
            else
                menu.SetActive(true);
        }
	}

    public void exitServer ()
    {
        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }

}
