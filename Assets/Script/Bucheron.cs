using UnityEngine;

public class Bucheron : MonoBehaviour
{
    public GameObject souche;
    public GameObject planche;
    private int nbCout;

    // Start is called before the first frame update
    void Start()
    {
        nbCout = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            nbCout++;
        }
        if (nbCout == 3)
        {
            nbCout = 0;
            Vector3 vector3 = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            GameObject hs = Instantiate(souche, this.transform.position, Quaternion.identity);
            GameObject hs1 = Instantiate(planche, vector3, Quaternion.identity);
        }
    }
}