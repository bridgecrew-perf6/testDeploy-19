using UnityEngine;


public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float movSpeed;
    public float sprintSpeed;

    [Tooltip("Controlled from script in Start() method")]
    public float rotSpeed;

    public Vector3 rot;
    public bool isInBooth = false;

    internal bool CanPlayerMove;

    float mouseX, mouseY;
    float rotationSpeed = 2f;
    bool isUserInteracting;

    Rigidbody rb;

    // PhotonView photonView;
    private void Start()
    {
        //photonView = gameObject.GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        sprintSpeed = movSpeed * 2f;
        rotSpeed = 24;
        isUserInteracting = false;
    }

    void Update()
    {
        //if (!photonView.IsMine)
        //    return;

       

        if (Input.GetKey(KeyCode.RightShift))
        {
            PlayerMovement(sprintSpeed);
        }
        else
        {
            if (!CanPlayerMove)
                PlayerMovement(movSpeed);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        isUserInteracting = true;

        //        RaycastHit hit;
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        if (Physics.Raycast(ray, out hit, 100, ~(1 << 2)))//raycast with all layers except second layer
        //        {
        //            //Debug.Log("hitTag:" + hit.collider.gameObject.tag, hit.collider.gameObject);
        //            if (hit.collider.gameObject.tag.Equals("Chair"))
        //            {
        //                isUserInteracting = false;
        //            }
        //        }
        //        //Debug.Log("UiObject:" + EventSystem.current.IsPointerOverGameObject());
        //    }
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    isUserInteracting = false;
        //}
    }



    public void SetNormalMovementValues()
    {
        movSpeed = 10;
        sprintSpeed = 20;
    }

    public void SetSlowMovementValues()
    {
        movSpeed = 6;
        sprintSpeed = 10;
    }

    public void SetMovementValuesToZero()
    {
        movSpeed = 0;
        sprintSpeed = 0;
    }

    private void LateUpdate()
    {

        // Debug.Log("IsPointerOverGameObject" + EventSystem.current.IsPointerOverGameObject());
        //if (!photonView.IsMine)
        //    return;

        CamControl();

    }

    private void OnEnable()
    {
        mouseX = 0;
        // mouseY = 0;
        // transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }


    internal bool IsRightClicked = false;
    void CamControl()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;


        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) //&& !Input.GetKey(KeyCode.LeftShift))
        {
            mouseX = Input.GetAxis("Horizontal") * rotationSpeed;
            //transform.rotation = Quaternion.Euler(0, mouseX, 0);
            transform.Rotate(new Vector3(0, mouseX * rotSpeed * Time.deltaTime, 0));
            if (GetComponentInChildren<AnimationController>().isSit)
            {
                print("CurrChair");
                // PlayerManager.Instance.CurrChair.transform.Rotate(new Vector3(0, mouseX * rotSpeed * Time.deltaTime, 0));
            }
        }

        // else if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift))
        else if (Input.GetMouseButton(0)) // && !Input.GetKey(KeyCode.LeftShift)) //$$$
        {

            //if (MouseInputUIBlocker.BlockedByUI)
            //    return;

            mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);
            transform.Rotate(new Vector3(0, mouseX / 2, 0));
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Reset();
            //transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
    }



    private void Reset()
    {
        mouseX = 0;
        mouseY = 0;
    }


    void PlayerMovement(float movSpeed)
    {
        //Debug.Log("player move");
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(0f, 0f, ver) * movSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        //rb.MovePosition(playerMovement);



        //if (!GetComponent<CameraPlayerControllerDesktop>().cam.GetComponent<ThirdPersonCameraControl>().enabled
        //     && GetComponent<CameraPlayerControllerDesktop>().cam.parent == GetComponent<CameraPlayerControllerDesktop>().camFPC)
        //{
        //    transform.Rotate(0.0f, hor * rotSpeed * Time.deltaTime, 0.0f);
        //}
    }
}