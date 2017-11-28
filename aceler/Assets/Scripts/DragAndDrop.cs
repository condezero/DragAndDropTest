using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 oldVel;
    private Vector3 screenPoint;
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        transform.position = currentPos;
    }
    void Start()
    {
        if (myRigidbody.tag == "ball")
        {
            myRigidbody = GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        oldVel = myRigidbody.velocity;
    }

    void OnCollisionEnter(Collision c)
    {
        ContactPoint cp = c.contacts[0];
        // calculate with addition of normal vector
        // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;

        // calculate with Vector3.Reflect
        myRigidbody.velocity = Vector3.Reflect(oldVel, cp.normal);

        // bumper effect to speed up ball
        myRigidbody.velocity += cp.normal * 2.0f;
        foreach (ContactPoint contact in c.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}