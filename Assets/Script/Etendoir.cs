using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etendoir : MonoBehaviour
{
    public GameObject HerbeSeche;

    public float count_down_time = 10.0f; //1 minute
    private bool count_down;
    private float initial_value = 0;
    private GameObject herbe;

    // Start is called before the first frame update
    void Start()
    {
        count_down = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count_down)
        {
            if (count_down_time > 0)
            {
                count_down_time -= Time.deltaTime;
            }
            else if(herbe != null)
            {
                Vector3 myVector3 = herbe.transform.position;
                Destroy(herbe);
                herbe = null;

                GameObject herbeSechee = Instantiate(HerbeSeche, myVector3, Quaternion.identity);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.name == "Herbe")
        {
            Debug.Log("Collision !");
            count_down = true;
            initial_value = count_down_time;
            herbe = other.gameObject;
            herbe.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
