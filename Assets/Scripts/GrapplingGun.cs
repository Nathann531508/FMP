using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;

    private Vector3 GrapplePoint;

    public LayerMask whatIsGrappleable;

    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            StopGrapple();
        }
    }
    void LateUpdate()
    {
        DrawRope();
    }


    void StartGrapple()
    {
        RaycastHit hit;
        StopGrapple();
        if (Physics.Raycast(origin: camera.position, direction: camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            GrapplePoint= hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = GrapplePoint;

            float distanceFromPoint = Vector3.Distance( a: player.position, b: GrapplePoint );
            // distance grapple will keep from grapple point
            joint.maxDistance = distanceFromPoint * 0.0f;
            joint.maxDistance = distanceFromPoint * 0.25f;

            // change these values to fit game
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }

    }

    void DrawRope()
    {
        if (!joint) return;
        lr.SetPosition(index: 0, gunTip.position);
        lr.SetPosition(index: 1, GrapplePoint);
    }
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
    
        
    

}
