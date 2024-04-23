using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature_generator : MonoBehaviour
{
    public GameObject[] parts;
    public int length = 1;
    [Range(0,5)]
    public float frequency = 1;
    public float start_angle = 1;
    public float base_size = 0.5f;
    public float multiplier = 1;

    public float amplitude = 1;
    public float follow_frequency = 5;

    Transform prev_transform;
    float max_mult = 0;

    public GameObject prefab;
    public GameObject follow;

    void Start()
    {
        float prev_mult;
        max_mult = Mathf.Sin(frequency + start_angle) + 1;
        parts = new GameObject[length + 1];
        parts[0] = gameObject;
        prev_transform = transform;

        for (int i = 0; i < length; i++)
        {
            prev_mult = max_mult;
            max_mult = Mathf.Sin(i * frequency + start_angle) + 1;

            GameObject tail = Instantiate(prefab, new Vector3(0 ,0,
                prev_transform.position.z - prev_transform.localScale.z/2 - (base_size * multiplier * max_mult)/2),
                Quaternion.identity);

            prev_transform.transform.localScale = new Vector3(base_size * multiplier * max_mult,
                base_size * multiplier * max_mult,
                base_size * multiplier * max_mult);

            prev_transform = tail.transform;
            parts[i + 1] = tail;
        }
        prev_transform.transform.localScale = new Vector3(base_size * multiplier * max_mult,
            base_size * multiplier * max_mult,
            base_size * multiplier * max_mult);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow.transform.position = new Vector3(transform.position.x,
           follow.transform.position.y + Mathf.Sin(Time.time * follow_frequency + start_angle) * amplitude,
           transform.position.z + 5);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(follow.transform.position, 1);
    }
}
