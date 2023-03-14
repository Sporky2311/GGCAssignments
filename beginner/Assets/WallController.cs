using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int length = 20;
        int height = 8;
        float gap = 0.1f;
        MeshRenderer render;

        GameObject backWall = new GameObject();
        backWall.name = "backWall";
        backWall.transform.parent = this.transform;
        for (int k = 0; height > k; k++)
        {
            for (int i = 0; i < length; i++) { 
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = backWall.transform;
            cube.transform.position = new Vector3(5 + i + gap, k+gap, -5);
            cube.transform.name = "Wall" + (i+k*height);
            render = cube.GetComponent<MeshRenderer>();
                if ((i + k) % 2 == 0)
                    render.materials[0].color = Color.red;
                else
                     render.materials[0].color = Color.blue;
                
            }
        }

        GameObject leftWall = GameObject.Instantiate(backWall);
        leftWall.name = "leftWall";
        leftWall.transform.parent = this.transform;
        leftWall.transform.Rotate(Vector3.up, -90);
        leftWall.transform.position = new Vector3(19,0,-30);

        GameObject rightWall = GameObject.Instantiate(backWall);
        rightWall.name = "rightWall";
        rightWall.transform.parent = this.transform;
        rightWall.transform.Rotate(Vector3.up, -90);
        rightWall.transform.position = new Vector3(0, 0, -30);

        GameObject frontWall = GameObject.Instantiate(backWall);
        frontWall.name = "frontWall";
        frontWall.transform.parent = this.transform;
        
        frontWall.transform.position = new Vector3(0, 0, -20);

        GameObject floor1 = GameObject.Instantiate(backWall);
        floor1.name = "floor1";
        floor1.transform.parent = this.transform;
        floor1.transform.Rotate(Vector3.left, -90);
        floor1.transform.position = new Vector3(0, -3, -24);
        floor1.transform.localScale = new Vector3(1, 2.5f, 1);

        /*GameObject floor2 = GameObject.Instantiate(backWall);
        floor2.name = "floor2";
        floor2.transform.parent = this.transform;
        floor2.transform.Rotate(Vector3.left, -90);
        floor2.transform.position = new Vector3(0, -3, -16);

        GameObject floor3 = GameObject.Instantiate(backWall);
        floor3.name = "floor3";
        floor3.transform.parent = this.transform;
        floor3.transform.Rotate(Vector3.left, -90);
        floor3.transform.position = new Vector3(0, -3, -16);
        */


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
