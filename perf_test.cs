using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Create_Sphere_3 : MonoBehaviour
{
    // build a sphere and Set is as prefab - than set it into the game obj / thx to bensen!
    public GameObject prefab;
    // how much spheres ...
    public int amount;
    // how far is the area ...
    public int space = 1;
    // start position 
    Vector3 position;
 
 
    // Start is called before the first frame update
    void Start()
    {
        // plane building
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, -5, 0);
        plane.transform.localRotation = Quaternion.Euler(0, 0, 5);
        plane.transform.localScale = new Vector3(5, 1, 5);
  
 
        //ori: position = new Vector3(-5f, 10f, -4f);
 
        // position = new Vector3(1, 0, 0); //position 1st sphere
        // function here
        new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), 0); //leichte korrektur 
        position = new Vector3(1, 0, 0); //position 1st sphere
        CreatePrefabSpheres(amount * 2);
        // CreatePrimitiveSpheres(amount * space);
    }
 
 
    // 3 times prefab instantiating
    private void CreatePrefabSpheres(int amount)
    {
        for (int a = 0; a < amount; a += space)
        {
            for (int b = 0; b < amount; b += space)
            {
                for (int c = 0; c < amount; c += space)
                {
                    GameObject sphere = Instantiate(prefab, new Vector3(position.x + a, position.y + b, position.z + c), Quaternion.identity);
                    sphere.AddComponent<Rigidbody>();
                }
            }
        }
    }
 
    // 3 times prefab instantiating
    private void CreatePrimitiveSpheres(int amount)
    {
        for (int a = 0; a < amount; a += space)
        {
            for (int b = 0; b < amount; b += space)
            {
                for (int c = 0; c < amount; c += space)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = new Vector3(position.x + a, position.y + b, position.z + c);
                    // sphere.AddComponent<Rigidbody>();
                    // without gravity
                    sphere.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }
}