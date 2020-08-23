using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    //position of the center of the slingshot
    public Transform pivot;
    public float springRange;
    bool canDrag;
    Vector3 distancePointerPivot;
    public float maxVelocity;
    Animator birAnim;    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {   
        canDrag = true;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        springRange = 1.5f;
        maxVelocity = 10f;
        birAnim = GetComponent<Animator>();
    }

    private void OnMouseDrag() 
    {
        if (!canDrag)
            return;
        Debug.Log("Dragueando");
        Vector3 mousePointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distancePointerPivot = mousePointerPosition - pivot.position;
        distancePointerPivot.z = 0;

        if(distancePointerPivot.magnitude > springRange)
        {
            distancePointerPivot = distancePointerPivot.normalized * springRange;
            rb.velocity = distancePointerPivot.normalized;
        }

        transform.position = distancePointerPivot + pivot.position;
    }

    void OnMouseUp()
    {
        if(!canDrag)
            return;

        canDrag = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -distancePointerPivot.normalized * maxVelocity * distancePointerPivot.magnitude / springRange; 


        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Destroyable")
        {

            birAnim.SetBool("isExploding", true);
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(this.gameObject, 0.9f);
        }
    }
    // Update is called once per frame
    void Update()
    {


        
    }
}
