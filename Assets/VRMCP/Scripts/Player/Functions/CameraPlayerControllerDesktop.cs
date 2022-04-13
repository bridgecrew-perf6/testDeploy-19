using UnityEngine;


public enum PlayerCameraMode : int
{
    ISOMETRIC, FPC, OFFICEFPC
}

public class CameraPlayerControllerDesktop : MonoBehaviour
{
    public float maxDistanceTap = 10f;
    public float turnSpeed = 4.0f;
    public float speedTeleport = 4.0f;

    //public Vector3 initialIsometricPosition;
    //public Vector3 initialFPCPosition;

    public PlayerCameraMode mode;

    public Transform cam;

    public Transform camFPC;
    public Transform OfficecamFPC;
    internal Transform camIsometric;

    private Vector3 newPlayerPos;
    private Transform pin;
    //private Transform pivotIsometric;
    //private Transform pivotFPC;
    private Vector3 offset;
    //private LayerMask mask;
    private bool hitted;

    Vector3 initCamPos;
    Quaternion initCamRot;


    //public GameObject getPin()
    //{
    //    return pin.gameObject;
    //}


    private void Awake()
    {
        //pin = transform.Find("avatar_03");
        //pivotIsometric = transform.Find("PivotIsometric");
        //pivotFPC = transform.Find("PivotFPC");
        /////cam = transform.Find("Camera");
        Debug.Log("Awake is called..........."+this.gameObject.name);
        camIsometric = transform.Find("CameraIsometricPosition");
        cam = camIsometric.transform.GetChild(0);
        camFPC = transform.Find("CameraFPCPosition");
        OfficecamFPC = transform.Find("OfficeFPCPosition");
        cam.GetComponent<ThirdPersonCameraControl>().Target = camIsometric.transform;
    }

    void Start()
    {
        this.hitted = false;
       // mask = LayerMask.GetMask("Floor");

        //if (!this.GetComponent<PhotonView>().IsMine)
        //{
            //cam.gameObject.SetActive(false);
            //transform.Find("Trigger").GetComponent<CapsuleCollider>().enabled = false;
            //Destroy(this.GetComponent<Rigidbody>());
        //}

        initCamPos = camIsometric.localPosition;
        initCamRot = camIsometric.localRotation;
    }

    public void initIsometricView()
    {
        camIsometric.SetParent(this.gameObject.transform);
        //cam.GetComponent<ThirdPersonCameraControl>().enabled = true;
        GetComponent<ThirdPersonCharacterControl>().isInBooth = false;
        camIsometric.localPosition = initCamPos;
        camIsometric.localRotation = initCamRot;
        cam.transform.localPosition = new Vector3(0, 0, -2.8f );//- 1.4f
        this.mode = PlayerCameraMode.ISOMETRIC;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSitting">True if player wants to sit.</param>
    public void initFPCView(bool isSitting)
    {
        //print("initOfficeView");
        GetComponent<ThirdPersonCharacterControl>().isInBooth = true;
        camIsometric.SetParent(camFPC);
        camIsometric.localRotation = Quaternion.identity;
        camIsometric.localPosition = Vector3.zero;
        camIsometric.localScale = Vector3.one;
        if (isSitting)
        {
            //camFPC.localPosition = new Vector3(0, 3.5f, 0);
            camFPC.localPosition = new Vector3(0, 3.392f, 0.437f);
        }
        else
            camFPC.localPosition = new Vector3(0, 5, 0);

        cam.transform.localPosition = Vector3.zero;
        this.mode = PlayerCameraMode.FPC;
    }

    public void initOfficeView()
    {
        //print("initOfficeView");
        GetComponent<ThirdPersonCharacterControl>().isInBooth = true;
        //camIsometric.SetParent(this.gameObject.transform);
        print(OfficecamFPC.name);
        camIsometric.SetParent(OfficecamFPC);
        camIsometric.localRotation = Quaternion.identity;
        camIsometric.localPosition = Vector3.zero;
        camIsometric.localScale = Vector3.one;
        cam.transform.localPosition = Vector3.zero;
        this.mode = PlayerCameraMode.OFFICEFPC;
    }


    //void hidePlayer(GameObject other)
    //{
    //    if (other.gameObject.GetComponent<CameraPlayerControllerDesktop>().mode == PlayerCameraMode.ISOMETRIC)
    //    {
    //        // Debug.Log("Hide player...");
    //        other.gameObject.GetComponent<CameraPlayerControllerDesktop>().getPin().SetActive(true);
    //    }
    //    else
    //    {
    //        //   Debug.Log("UnHide player...");
    //        other.gameObject.GetComponent<CameraPlayerControllerDesktop>().getPin().SetActive(false);
    //    }
    //}

    //private void moveCameraAroundPlayerFPC(float delta)
    //{
    //    cam.RotateAround(pivotFPC.position, Vector3.up, delta);
    //    pin.LookAt(new Vector3(cam.position.x, pin.position.y, cam.position.z));
    //    pin.localEulerAngles += new Vector3(0, 180, 0);
    //}

    //private void moveCameraAroundPlayerIsometric(float delta)
    //{
    //    cam.RotateAround(pivotIsometric.position, Vector3.up, delta);
    //    pin.LookAt(new Vector3(cam.position.x, pin.position.y, cam.position.z));
    //    pin.localEulerAngles += new Vector3(0, 180, 0);
    //}

}