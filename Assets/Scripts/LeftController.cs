using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour
{
    private Collider currentcollider = null;
    //private GameObject holdingObject = null;
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
        Debug.Log("Je veux grab !!!" + currentcollider.name);
        if (currentcollider)
        {
            if (currentcollider.name == "GrabpointAxe")
            {
                //GameObject axe = GameObject.Find("AXE");
                GameObject grabpoint = GameObject.Find("GrabpointAxe");
                //holdingObject = axe;
                grabPosition = grabpoint;
                //axe.transform.parent = hand.transform;
                //Vector3 offset = hand.position - grabPosition.transform.position;
                //axe.transform.localPosition = Vector3.zero;
                grabpoint.transform.parent = hand.transform;
                grabpoint.transform.localPosition = new Vector3(0.06f, 0, 0.081f);
                grabPosition.transform.localRotation = Quaternion.Euler(-70.1f, -166.5f, 2.228f);
                grabpoint.GetComponent<Rigidbody>().useGravity = false;
                grabpoint.GetComponentInChildren<MeshCollider>().isTrigger = true;
            }
        }
    }

    public void DropObject()
    {
        Debug.Log("Je veux lacher !!!" + currentcollider);
        if (grabPosition != null)
        {
            grabPosition.transform.parent = null;
            grabPosition.GetComponentInChildren<Rigidbody>().useGravity = true;
            grabPosition.GetComponentInChildren<MeshCollider>().isTrigger = false;
            //holdingObject = null;
            grabPosition = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabpointAxe")
        {
            currentcollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other)
        {
            if (other.name == currentcollider.name)
            {
                currentcollider = null;
            }
        }
    }
}