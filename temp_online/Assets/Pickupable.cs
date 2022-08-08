using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public Rigidbody Rb;
    public Collider Collider;
    public PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RequestOwner()
    {
        PV.RequestOwnership();
    }
}
