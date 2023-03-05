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
        Debug.Log("Je veux grab !!!" + currentcollider.tag);
        if (currentcollider)
        {
            if (currentcollider.name == "GrabpointAxe")
            {
                GameObject grabpoint = currentcollider.gameObject;
                grabPosition = grabpoint;
                grabpoint.transform.parent = hand.transform;
                grabpoint.transform.localPosition = new Vector3(-0.023f, 0.023f, 0.045f);
                grabpoint.transform.localRotation = Quaternion.Euler(3.547f, -262.18f, 77.856f);
                grabpoint.GetComponent<Rigidbody>().useGravity = false;
                grabpoint.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabpoint.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                grabpoint.GetComponentInChildren<MeshCollider>().isTrigger = true;
            }
            if (currentcollider.tag == "Herbe" || currentcollider.tag == "Yarn")
            {
                GameObject grabpoint = currentcollider.gameObject;
                grabPosition = grabpoint;
                grabpoint.transform.parent = hand.transform;
                grabpoint.transform.localPosition = new Vector3(0.008f, -0.024f, -0.075f);
                grabpoint.transform.localRotation = Quaternion.Euler(81.836f, -89.157f, -96.862f);
                grabpoint.GetComponent<Rigidbody>().useGravity = false;
                grabpoint.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabpoint.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                grabpoint.GetComponentInChildren<MeshCollider>().isTrigger = true;
            }
            if (currentcollider.tag == "Wood")
            {
                GameObject grabpoint = currentcollider.gameObject;
                grabPosition = grabpoint;
                grabpoint.transform.parent = hand.transform;
                grabpoint.transform.localPosition = new Vector3(0.011f,0.059f,-0.004f);
                grabpoint.transform.localRotation = Quaternion.Euler(0,0,0);
                grabpoint.GetComponent<Rigidbody>().useGravity = false;
                grabpoint.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabpoint.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                grabpoint.GetComponentInChildren<MeshCollider>().isTrigger = true;
            }
            if (currentcollider.name == "GrabpointBow")
            {
                GameObject grabpoint = currentcollider.gameObject;
                grabPosition = grabpoint;
                grabpoint.transform.parent = hand.transform;
                grabpoint.transform.localPosition = new Vector3(0.0242f,-0.00015f,-0.007f);
                grabpoint.transform.localRotation = Quaternion.Euler(9.862f,105.74f,84.362f);
                grabpoint.GetComponent<Rigidbody>().useGravity = false;
                grabpoint.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabpoint.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                grabpoint.GetComponentInChildren<MeshCollider>().isTrigger = true;
            }
            if (currentcollider.tag == "Clipboard")
            {
                GameObject grabpoint = currentcollider.gameObject;
                grabPosition = grabpoint;
                grabpoint.transform.parent = hand.transform;
                grabpoint.transform.localPosition = new Vector3(0,0,0);
                grabpoint.transform.localRotation = Quaternion.Euler(0,0,0);
                grabpoint.GetComponent<Rigidbody>().useGravity = false;
                grabpoint.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabpoint.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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
            grabPosition = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabpointAxe" || other.tag == "Herbe" || other.tag == "Yarn" || other.tag == "Wood" ||other.name== "GrabpointBow" ||other.tag=="Clipboard")
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