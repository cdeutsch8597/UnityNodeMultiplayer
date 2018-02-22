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
        position = transform.position;
        OnMove(position);
	}

    public void OnMove(Vector3 position)
    {
        //Debug.Log("Sending position to server: " + VectorToJson(position));
        Network.socket.Emit("move", new JSONObject(VectorToJson(position)));
    }

    public string VectorToJson(Vector3 vector)
    {
        return string.Format(@"{{""x"":""{0}"",""y"":""{1}""}}", vector.x, vector.z);
    }
}
