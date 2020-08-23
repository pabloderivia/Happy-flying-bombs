using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float resistance;
    public Animator animator;
    Rigidbody2D rigidbody;

    void OnCollisionEnter2D(Collision2D other)
    {
            Debug.Log("Magnitud de la velocidad de la bommba = "+other.relativeVelocity.magnitude);
        if(other.relativeVelocity.magnitude > resistance)
        {
            animator.SetBool("isExploding",true);
            rigidbody.bodyType = RigidbodyType2D.Static;

            Destroy(this.gameObject, 0.15f);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
