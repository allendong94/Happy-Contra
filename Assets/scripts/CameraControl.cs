﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    public float CameraCenterVerticalOffset;
    public int cameraEdgeX;
    public int cameraEdgeY;
    // Use this for initialization
    private void Awake()
    {

    }
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player)
        {
            float x;
            float y;
            if (player.transform.position.y > 9) y = player.transform.position.y - 3;
            else y = Mathf.Clamp(player.transform.position.y + CameraCenterVerticalOffset, ymin, ymax);
            x = Mathf.Clamp(player.transform.position.x, xmin, xmax);
            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
        
    }
    public bool InRange(float x, float y)
    {
        return (gameObject.transform.position.x - cameraEdgeX <= x && 
                gameObject.transform.position.x + cameraEdgeX >= x && 
                gameObject.transform.position.y - cameraEdgeY <= y &&
                gameObject.transform.position.y + cameraEdgeY >= y);
    }
    public bool RightOutOfRange(float x)
    {
        return (gameObject.transform.position.x + cameraEdgeX < x);
    }
    public bool LeftOutOfRange(float x)
    {
        return (gameObject.transform.position.x - cameraEdgeX > x);
    }
}
