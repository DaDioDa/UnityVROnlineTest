using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupSystem : MonoBehaviour
{
    public GameObject Cam;
    public GameObject PickUpSlot;
    Pickupable pickupable;
    public float PickDistance = 10;
    PhotonView view;
    public GameObject Crosshair;

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
        if(pickupable) Crosshair.GetComponent<Image>().color = Color.green;
        else Crosshair.GetComponent<Image>().color = Color.white;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.TransformDirection(Vector3.forward), out hit, PickDistance))
        {
            Debug.DrawRay(Cam.transform.position, Cam.transform.TransformDirection(Vector3.forward) * PickDistance, Color.yellow);
            if (hit.transform.TryGetComponent(out Pickupable temp) && !pickupable)
            {
                Crosshair.GetComponent<Image>().color = Color.red;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (pickupable)
            {
                pickupable.Drop();
                pickupable = null;
            }
            else if (hit.transform.TryGetComponent(out pickupable))
            {
                pickupable.RequestOwner();
                PickUpSlot.transform.position = hit.point;
                pickupable.Pick(PickUpSlot.transform);
            } 
        }
    }
}
