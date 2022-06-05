using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition();
    }

    private void CameraPosition()
    {
        float posX = player.transform.position.x;
        float posY = player.transform.position.y;

        //posX
        if (player.transform.position.x < boundary.xMin)
        {
            posX = boundary.xMin;
        }
        else if (player.transform.position.x > boundary.xMax)
        {
            posX = boundary.xMax;
        }
        else
        {
            posX = player.transform.position.x;
        }

        //posY
        if (player.transform.position.y < boundary.yMin)
        {
            posY = boundary.yMin;
        }
        else if (player.transform.position.y > boundary.yMax)
        {
            posY = boundary.yMax;
        }
        else
        {
            posY = player.transform.position.y;
        }


        if (tag == "MainCamera")
        {
            transform.position = new Vector3(posX, posY, -10);
        }
        if (tag == "MiniMapCamera")
        {
            transform.position = new Vector3(posX, posY, -20);
        }

    }
}
