using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponentScript : MonoBehaviour
{
    public int getComponentNumber;
    PlayerScript[] getComponentGameObjects;
    private void OnEnable()
    {
        getComponentGameObjects = new PlayerScript[getComponentNumber];
    }
    void Update()
    {
        //This will only activate if getComponentNumber is changed, simulating a OnEnable for this scenario
        if (getComponentNumber != getComponentGameObjects.Length)
        {
            getComponentGameObjects = new PlayerScript[getComponentNumber];

            for (int i = 0; i < getComponentNumber; i++)
            {
                getComponentGameObjects[i] = GameObject.Find("Player").GetComponent<PlayerScript>(); //This simulates x amount of entities getting a component all at once

            }
        }
    }
}
