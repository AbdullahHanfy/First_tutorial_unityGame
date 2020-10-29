using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform groundCheckTransform;
    private bool jumpKeyWasPressed;
    private float horizontalKey;
    private Rigidbody rigifBodyComp;
    public LayerMask playMAsk;

    // Start is called before the first frame update
    void Start()
    {
        rigifBodyComp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpKeyWasPressed = true;



        }
        horizontalKey = Input.GetAxis("Horizontal");

    }


    private void FixedUpdate()
    {
        rigifBodyComp.velocity = new Vector3(horizontalKey, rigifBodyComp.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playMAsk).Length == 0) { return; }
        if (jumpKeyWasPressed)
        {
            rigifBodyComp.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }






    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        { Destroy(other.gameObject); }


    }
}


