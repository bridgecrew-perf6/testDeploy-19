using UnityEngine;
using System;


public class ThirdPersonCameraControl : MonoBehaviour
{

    public Transform Target, Player;
    public Transform Obstruction;

    float minRotation = -25;
    float maxRotation = 25;

    internal bool IsRightClicked = false;

    //float zoomSpeed = 2f;
    float mouseX, mouseY;
    float rotationSpeed = 2f;

    bool isUserInteracting;
    // PhotonView photonView;
    void Start()
    {
        Target = transform.parent;
        Obstruction = Target;
        isUserInteracting = false;
        Player = transform.parent.parent;
        //photonView = Player.GetComponent<PhotonView>();

    }

    private void Update()
    {
        //if (!photonView.IsMine)
        //    return;
        //if (Input.GetMouseButton(1))
        //{
        //    IsRightClicked = true;
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        isUserInteracting = true;
        //        //Debug.Log(EventSystem.current.gameObject.layer.ToString(), EventSystem.current.gameObject);
        //        RaycastHit hit;
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        if (Physics.Raycast(ray, out hit, 100, ~(1 << 2) & ~(1 << 12)))//raycast with all layers except second and twelth layer
        //        {
        //            //Debug.Log("hitTag:" + hit.collider.gameObject.tag, hit.collider.gameObject);
        //            if (hit.collider.gameObject.tag.Equals("Chair"))
        //            {
        //                isUserInteracting = false;
        //            }
        //            //else
        //            //{
        //            //    isUserInteracting = false;
        //            //}
        //        }
        //        //Debug.Log("UiObject:" + EventSystem.current.IsPointerOverGameObject());
        //    }
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    isUserInteracting = false;
        //}
    }

    private void LateUpdate()
    {
        //if (!photonView.IsMine)
        //    return;
        //if (isUserInteracting)
        //    return;

        // if (!EventSystem.current.IsPointerOverGameObject())
        CamControl();
    }


    void CamControl()
    {
        

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            mouseX += Input.GetAxis("Horizontal") * rotationSpeed;
            //Debug.LogError("asdasdasd");
        }
        else if (Input.GetMouseButton(0)) //$$$
        {
            //if (MouseInputUIBlocker.BlockedByUI)
            //    return;
            mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);


           
            //else
            //{
            //if (Target.parent == Player.GetComponent<CameraPlayerControllerDesktop>().camFPC)
            //{
            //    //Debug.Log("if");
            //    X_Y_CamRotation(mouseX, mouseY);
            //}
            //else if (PlayerManager. Instance.MyPhotonPlayer.GetComponentInChildren<AnimationController>().isSit)
            //{
            //    X_Y_CamRotation(mouseX, mouseY);
            //}
            //else
            //{
            //Debug.Log("else");
            Target.Rotate(new Vector3(-mouseY / 2, 0, 0));

                Vector3 currentRotation = Target.localRotation.eulerAngles;
                currentRotation.x = ClampAngle(currentRotation.x, minRotation, maxRotation);
                Target.localRotation = Quaternion.Euler(currentRotation);
        }

        //if (transform.root.GetComponent<CharacterBehaviour>().animcontroller.isSit)
        //{
        //    //if (Input.GetKey(KeyCode.LeftShift))
        //    mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        //    mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        //    mouseY = Mathf.Clamp(mouseY, -35, 60);
        //    //{
        //    Target.Rotate(new Vector3(-mouseY / 2, mouseX / 2, 0)); //$$$
        //}


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();
        }
        transform.LookAt(Target);
    }

    void X_Y_CamRotation(float mouseX, float mouseY)
    {
        if (((Math.Round(Target.localEulerAngles.x) <= 50) && (Math.Round(Target.localEulerAngles.x) >= 0)) 
            || ((Math.Round(Target.localEulerAngles.x) >= 300) && (Math.Round(Target.localEulerAngles.x) <= 360)))
        {
            Target.Rotate(new Vector3(-mouseY / 2, 0, 0));
        }
        else if (Math.Round(Target.localEulerAngles.x) > 50 && mouseY > 0)
        {
            Target.localEulerAngles = new Vector3(290, 0, 0);
        }
        else if (Math.Round(Target.localEulerAngles.x) > 50 && mouseY < 0)
        {
            Target.localEulerAngles = new Vector3(30, 0, 0);
        }

        Target.Rotate(new Vector3(0, mouseX / 2, 0));
        float x = Target.localEulerAngles.x;
        float y = Target.localEulerAngles.y;
        Target.localRotation = Quaternion.Euler(new Vector3(x, y, 0));
    }

    float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }


    public void Reset()
    {
        Target.localEulerAngles = new Vector3(0, 0, 0);
    }

}