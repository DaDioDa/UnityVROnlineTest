using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public GameObject Cam;

    public GameObject PickUpSlot;

    Pickupable pickupable;

    public float PickDistance = 10;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(Cam.transform.position, Cam.transform.TransformDirection(Vector3.forward) * PickDistance, Color.red);

        if(Physics.Raycast(Cam.transform.position, Cam.transform.TransformDirection(Vector3.forward), out hit, PickDistance))
        {
            Debug.DrawRay(Cam.transform.position, Cam.transform.TransformDirection(Vector3.forward) * PickDistance, Color.yellow);
            hit.transform.GetComponent<Pickupable>().RequestOwner();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (pickupable) dropItem(pickupable);
            else if (hit.transform.GetComponent<Pickupable>()) pickItem(hit.transform.GetComponent<Pickupable>());
        }
    }

    void pickItem(Pickupable pick)
    {
        pickupable = pick;

        pick.Rb.isKinematic = true;
        pick.Rb.velocity = Vector3.zero;
        pick.Rb.angularVelocity = Vector3.zero;

        pick.transform.SetParent(PickUpSlot.transform);

        pick.transform.localPosition = Vector3.zero;
        pick.transform.localEulerAngles = Vector3.zero;

        pick.Collider.enabled = false;
    }

    void dropItem(Pickupable pick)
    {
        pickupable = null;
        pick.transform.SetParent(null);
        pick.Rb.isKinematic = false;
        pick.Rb.AddForce(pick.transform.forward * 2, ForceMode.VelocityChange);
        pick.Collider.enabled = true;
    }
}
