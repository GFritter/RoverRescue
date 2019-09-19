using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb.AddForce(new Vector2(0, 1000));
        Destroy(this.transform.gameObject, 6);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.AddForce(new Vector2(0, 10));

    }
}
