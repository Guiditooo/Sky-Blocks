using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_Configurator : MonoBehaviour
{
    [SerializeField] private GameObject anchorObject;

    private Transform floor;

    private HingeJoint joint;
    private MeshRenderer mr;

    private Rigidbody jointAnchor;
    private Transform transformAnchor;

    private void Awake()
    {
        joint = GetComponent<HingeJoint>();
        mr = GetComponent<MeshRenderer>();

    }

    private void Start()
    {
        mr.material.color = Random.ColorHSV();
    }

    public void SetAnchorObject(GameObject obj)
    {
        anchorObject = obj;
        jointAnchor = anchorObject.GetComponent<Rigidbody>();
        joint.connectedBody = jointAnchor;
        transformAnchor = anchorObject.GetComponent<Transform>();
    }

    public void SetFloor(Transform t)
    {
        floor = t;
    }

    public Vector3 GetFloorPos()
    {
        return floor.position;
    }

}
