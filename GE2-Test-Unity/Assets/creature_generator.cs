using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature_generator : MonoBehaviour
{
    public GameObject[] parts;
    public int length = 1;
    public float frequency = 1;
    public float start_angle = 1;
    public float base_size = 1;
    public float multiplier = 1;
    Transform prev_transform;

    public GameObject prefab;
    void Start()
    {
        parts = new GameObject[length + 1];
        parts[0] = gameObject;
        prev_transform = transform;
        for (int i = 0; i < length; i++)
        {
            prev_transform.transform.localScale = new Vector3(base_size * multiplier, base_size * multiplier, base_size * multiplier);
            GameObject tail = Instantiate(prefab, new Vector3(0 ,0, prev_transform.position.z - base_size * multiplier), Quaternion.identity);
            prev_transform = tail.transform;
            parts[i + 1] = tail;
        }
        prev_transform.transform.localScale = new Vector3(base_size * multiplier, base_size * multiplier, base_size * multiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
