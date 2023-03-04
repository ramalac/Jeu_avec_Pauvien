using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour
{
    private Collider currentcollider = null;
    private GameObject holdingObject = null;
    private GameObject grabPosition = null;
    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GrabObject()
    {
        Debug.Log("Je veux grab !!!" +currentcollider.name);
        if (currentcollider)
        {
            if (currentcollider.name == "GrabpointAxe")
            {
                GameObject axe = GameObject.Find("AXE");
                GameObject grabpoint = GameObject.Find("GrabpointAxe");
                holdingObject = axe;
                grabPosition = grabpoint;
                Vector3 offset = hand.position - grabPosition.transform.position;
                axe.transform.parent = hand.transform;
                axe.transform.localPosition += offset;
                axe.GetComponentInChildren<Rigidbody>().useGravity = false;
                axe.GetComponentInChildren<MeshCollider>().enabled = false;
            }
        }
    }

    public void DropObject()
    {
        Debug.Log("Je veux lacher !!!" + currentcollider);
        if (holdingObject != null)
        {
            holdingObject.transform.parent = null;
            holdingObject.GetComponentInChildren<Rigidbody>().useGravity = true;
            holdingObject.GetComponentInChildren<MeshCollider>().enabled = true;
            holdingObject = null;
            grabPosition = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentcollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        currentcollider = null;
    }
}
