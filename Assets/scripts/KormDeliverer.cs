using UnityEngine;
using System;
public class KormDeliverer : MonoBehaviour
{
    [SerializeField] private Transform Destination;
    [SerializeField] private float speed = 1f;
    
    
    
    Vector2 dest;
    private void Start()
    {
        dest = Destination.position;
        
    }
    private void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);
        speed -= 0.002f;
        if((Vector2)transform.position == dest)
        {
            Destroy(gameObject);
        }
    }

    
}
