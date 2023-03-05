using UnityEngine;

public class cutWood : MonoBehaviour
{
    private bool logOnTable;
    private GameObject log;
    public GameObject plank;

    // Start is called before the first frame update
    void Start()
    {
        logOnTable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (logOnTable)
        {
            Vector3 vector3 = log.transform.position;
            //We destory the log
            Destroy(log);
            log = null;
            logOnTable = false;

            //We instantiate a new plank
            GameObject hs = Instantiate(plank, vector3, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag != null)
            Debug.Log(collision.gameObject.tag);

        //Check if this is a log
        if (collision.gameObject.CompareTag("WoodenBoard"))
        {
            //Check if is the top of the table
            if (collision.transform.position.y > transform.position.y)
            {
                logOnTable = true;
                plank = collision.gameObject;
            }
        }
    }
}
