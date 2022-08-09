using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private Rigidbody Rb;
    private Collider Collider;
    private PhotonView PV;
    private Transform pickPoint;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(pickPoint != null)
        {
            Rb.MovePosition(pickPoint.position);
        }
    }

    public void RequestOwner()
    {
        PV.RequestOwnership();
    }

    public void Pick(Transform pickPoint)
    {
        this.pickPoint = pickPoint;
        PV.RPC("SyncPickState", RpcTarget.All);
    }

    public void Drop()
    {
        this.pickPoint = null;
        PV.RPC("SyncDropState", RpcTarget.All);
    }

    [PunRPC]
    void SyncPickState()
    {
        Rb.isKinematic = true;
        Rb.useGravity = false;
        Collider.enabled = false;
    }

    [PunRPC]
    void SyncDropState()
    {
        Rb.isKinematic = false;
        Rb.useGravity = true;
        Collider.enabled = true;
    }
}
