using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerServer : MonoBehaviour {

    private photonHandler pHandler;

    public void ChangeScene()
    {
        pHandler = GameObject.FindGameObjectWithTag("PhotonHandler").GetComponent<photonHandler>();
        pHandler.JoinOrCreateRoom(gameObject.GetComponentInChildren<Text>().text);
    }
}
