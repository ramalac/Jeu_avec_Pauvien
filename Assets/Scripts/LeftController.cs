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
            if (currentcollider.tag == "Wood" || currentcollider.tag == "Plank")
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
            if (currentcollider.tag == "Bow")
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
                grabpoint.transform.localPosition = new Vector3(-0.001f,-0.03f,-0.017f);
                grabpoint.transform.localRotation = Quaternion.Euler(67.845f,23.456f,15.595f);
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
        if (currentcollider!=null && currentcollider.tag=="Bow")
        {
            GameObject Human = GameObject.Find("Root_M");
            Debug.Log(Vector3.Distance(hand.position, Human.transform.position));
            if (Vector3.Distance(hand.position, Human.transform.position) <= 1)
            {
                GameObject HumanHand = GameObject.Find("jointItemL");
                grabPosition.transform.parent = HumanHand.transform;
                grabPosition.transform.localPosition = new Vector3(0, 0, 0);
                grabPosition.transform.localRotation = Quaternion.Euler(-4.156f, 266.77f, -0.307f);
                grabPosition.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabPosition.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                GameObject.Find("HumanMale_Character_FREE").GetComponent<Animator>().SetBool("hasBow", true);
                return;
            }
        }
        if (grabPosition != null)
        {
            grabPosition.transform.parent = null;
            grabPosition.GetComponent<Rigidbody>().useGravity = true;
            grabPosition.GetComponentInChildren<MeshCollider>().isTrigger = false;
            grabPosition = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabpointAxe" || other.tag == "Herbe" || other.tag == "Yarn" || other.tag == "Wood" ||other.tag== "Bow" ||other.tag=="Clipboard" || other.tag == "Plank")
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