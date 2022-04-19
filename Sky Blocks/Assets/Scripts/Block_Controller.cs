using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour
{

    private HingeJoint joint;

    private Rigidbody rb;

    private bool justStopped;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<HingeJoint>();
    }

    public void DropBlock()
    {
        Destroy(joint);
        tag = "Block";
    }
    private void OnCollisionStay(Collision collision)
    {
        //StartCoroutine(MovementCheck(collision.gameObject));
        /*
        if (!collision.gameObject.CompareTag("Limits"))
        {
            if (transform.eulerAngles.x % 90 >= 0 && transform.eulerAngles.x % 90 <= 1)
            {
                if (transform.eulerAngles.y % 90 >= 0 && transform.eulerAngles.y % 90 <= 1)
                {
                    if (transform.eulerAngles.z % 90 >= 0 && transform.eulerAngles.z % 90 <= 1)
                    {

                        rb.constraints = RigidbodyConstraints.FreezeAll;

                    }
                }
            }

        }
        */
        if (!gameObject.CompareTag("ActualBlock"))
        {
            if (!collision.gameObject.CompareTag("Limits"))
            {

                if (Vector3.Angle(collision.transform.up, transform.up) % 90 >= 0 && transform.eulerAngles.z % 90 <= 1)
                {
                    Destroy(rb);
                }

            }
        }
    }
    /*
    IEnumerator MovementCheck(GameObject go)
    {
        if (!go.CompareTag("Limits"))
        {
            if (transform.eulerAngles.x % 90 >= 0 && transform.eulerAngles.x % 90 <= 1)
            {
                if (transform.eulerAngles.y % 90 >= 0 && transform.eulerAngles.y % 90 <= 1)
                {
                    if (transform.eulerAngles.z % 90 >= 0 && transform.eulerAngles.z % 90 <= 1)
                    {

                        justStopped = true;

                        yield return justStopped;

                    }
                }
            }

        }

    }
    */

}
