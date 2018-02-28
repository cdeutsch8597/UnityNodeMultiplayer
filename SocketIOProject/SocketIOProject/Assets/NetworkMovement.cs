using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkMovement : MonoBehaviour {

    Vector3 position;
    //public SocketIOComponent socket;

    // Use this for initialization
    void Start () {
  
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        position = transform.position;
        OnMove(position, h, v);
	}

    public void OnMove(Vector3 position, float h, float v)
    {
        Debug.Log("Sending position to server: " + VectorToJson(position, h, v));
        Network.socket.Emit("move", new JSONObject(VectorToJson(position, h, v)));
    }

    public string VectorToJson(Vector3 vector, float h, float v)
    {
        return string.Format(@"{{""x"":""{0}"",""y"":""{1}"",""h"":""{2}"",""v"":""{3}""}}", vector.x, vector.z, h, v);
    }
}
