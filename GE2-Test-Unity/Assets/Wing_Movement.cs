using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing_Movement : MonoBehaviour
{
    public GameObject[] wings;

    public float amplitude = 1;
    public float frequency = 1;
    public float theta = 1;

    public bool left = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (left)
        {
            for (int i = 0; i < wings.Length; i++)
            {
                wings[i].transform.position = new Vector3(wings[i].transform.position.x,
                    wings[i].transform.position.y + Mathf.Sin(Time.time * frequency + theta + i) * amplitude,
                    wings[i].transform.position.z);
            }
           
        }
        if (!left)
        {
            for (int i = 0; i < wings.Length; i++)
            {
                wings[i].transform.position = new Vector3(wings[i].transform.position.x,
                    wings[i].transform.position.y + Mathf.Sin(Time.time * frequency + theta - i) * amplitude,
                    wings[i].transform.position.z);
            }
        }
    }


}
