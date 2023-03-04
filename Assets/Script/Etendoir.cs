using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etendoir : MonoBehaviour
{
    public GameObject HerbeSeche;

    public float count_down_time = 10.0f; //1 minute
    private bool count_down;
    private GameObject herbe;

    // Start is called before the first frame update
    void Start()
    {
        count_down = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the count down has started
        if (count_down)
        {
            //If the count down is still turning 
            if (count_down_time > 0)
            {
                //We subtract time
                count_down_time -= Time.deltaTime;
            }
            //If the count down is finished
            else if(herbe != null)
            {
                //We get the current position of the grass
                Vector3 myVector3 = herbe.transform.position;
                //We destroy the grass
                Destroy(herbe);
                herbe = null;

                //We instantiate a new dried grass
                GameObject hs = Instantiate(HerbeSeche, myVector3, Quaternion.identity);
            }
        }
        
    }

    //incoming collision management
    private void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.CompareTag("Herbe"))
        {
            //Start a count down
            count_down = true;

            //Stock the grass object and set it to kinematic
            herbe = other.gameObject;
            herbe.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    //outcoming collision management
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != null)
        {
            //Check for a match with the specified name on any GameObject that collides with your GameObject
            if (other.gameObject.CompareTag("Herbe"))
            {
                //If the grass is no longer on the rack the count_down restart
                count_down = false;
                count_down_time = 10.0f;
            }
        }
    }
}
