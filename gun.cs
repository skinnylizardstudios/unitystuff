using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Camera fpsCam;


    float range = 50f;
    float impactFactor = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // call shoot script if left mouse is clicked

        if (Input.GetButtonDown("Fire1") )
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // using unity raycast system to create bullet effect
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // display name of transform on which raycast hit

            Debug.Log(hit.transform.name);

            // if raycast hit to any rigidbody then it makes impulse on it

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactFactor, ForceMode.Impulse);

                // calling enemyscript to kill him
                enemy enemyscipt = hit.transform.GetComponent<enemy>();
                enemyscipt.takeDamage(30);

            }

        }
     }
}
