using UnityEngine;

public class cutWood : MonoBehaviour
{
    public GameObject plank;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag != null)
            Debug.Log(collision.gameObject.tag);

        //Check if this is a log
        if (collision.gameObject.CompareTag("Wood"))
        {
            //Check if is the top of the table
            if (collision.transform.position.y > transform.position.y)
            {
                Vector3 vector3 = collision.gameObject.transform.position;
                //We destory the log
                Destroy(collision.gameObject);

                //We instantiate a new plank
                GameObject hs = Instantiate(plank, vector3, Quaternion.identity);
            }
        }
    }
}
