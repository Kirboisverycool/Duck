using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);  
    }
}
