using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Movement : MonoBehaviour
{
    [SerializeField] private float armSpeed;

    private void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * armSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {

            transform.position -= Vector3.right * armSpeed * Time.deltaTime;
        }
    }
}
