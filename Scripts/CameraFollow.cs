using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player; //ออพเจคที่กล้องจะตาม
    public float xMin;//0
    public float xMax;//4.46
    public float yMin;
    public float yMax;

    void Start(){
        if (GameObject.FindGameObjectWithTag("Player")!= null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
