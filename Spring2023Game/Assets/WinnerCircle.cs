using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCircle : MonoBehaviour
{
    // Start is called before the first frame update
    int spheres = 25;
    float gap = 0.1f;
    int radius = 9;
    MeshRenderer render;
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
       
            for (int i = 0; i < spheres; i++)
            {
            waiter();
            float angle = i * Mathf.PI * 2f / spheres;
            Vector3 newPos = transform.position + (new Vector3(Mathf.Cos(angle) * radius, -2, Mathf.Sin(angle)*radius));
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.parent = this.transform;
            sphere.transform.localPosition = newPos;
            sphere.transform.name = "sphere" + i;
                render = sphere.GetComponent<MeshRenderer>();
                render.materials[0].color = Color.blue;
            }

        this.transform.Rotate(Vector3.up, 1.0f);

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
    }
}
