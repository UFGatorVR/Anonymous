using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = gameObject.transform.position;
		if (Input.GetKey(KeyCode.A)) //Right
        {
            position.x -= speed;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            position.z -= speed;
        }
        if (Input.GetKey(KeyCode.D)) //Left
        {
            position.x += speed;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
            position.z += speed;
        }
        gameObject.transform.position = position * Time.deltaTime;

    }
}
