using UnityEngine;

public class tableCraft : MonoBehaviour
{
    private bool yarnOnTable;
    private bool woodenBoardOnTable;
    private GameObject yarn;
    private GameObject wood;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        yarnOnTable = false;
        woodenBoardOnTable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (yarnOnTable && woodenBoardOnTable)
        {
            Vector3 vector3 = wood.transform.position;
            //We destroy the yarn and wood
            Destroy(yarn);
            Destroy(wood);
            yarn = null;
            wood = null;
            yarnOnTable = false;
            woodenBoardOnTable = false;

            //We instantiate a new arrow
            GameObject hs = Instantiate(arrow, vector3, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag != null)
            Debug.Log(collision.gameObject.tag);

        //Check if this is a wooden board
        if (collision.gameObject.CompareTag("Plank"))
        {
            //Check if is the top of the table
            if (collision.transform.position.y > transform.position.y)
            {
                woodenBoardOnTable = true;
                wood = collision.gameObject;
            }
        }

        //Check if this is a yarn 
        if (collision.gameObject.CompareTag("Yarn"))
        {
            //Check if is the top of the table
            if (collision.transform.position.y > transform.position.y)
            {
                yarnOnTable = true;
                yarn = collision.gameObject;
            }
        }
    }
}