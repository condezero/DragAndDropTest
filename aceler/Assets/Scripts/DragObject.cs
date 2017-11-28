using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class DragObject : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Camera theCam;
    private bool dragging;
    private Rigidbody2D rBody;
    public float Speed;
    void OnMouseDown()
    {
        if (gameObject.tag == "ball")
        {
            Debug.Log("suelta");
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            
        }
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
       
    }

    void OnMouseUp()
    {
            float moveHorizontal = Input.GetAxis("Mouse X");
            float moveVertical = Input.GetAxis("Mouse Y");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical);

            rBody.AddForce(movement , ForceMode2D.Impulse);
    }
    //void FixedUpdate(float h, float v)
    //{
    //    float moveHorizontal = Input.GetAxis("Mouse X");
    //    float moveVertical = Input.GetAxis("Mouse Y");

    //    Vector3 movement = new Vector3(moveHorizontal, moveVertical);

    //    rBody.AddForce(movement , ForceMode2D.Impulse);
    //}
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
}
