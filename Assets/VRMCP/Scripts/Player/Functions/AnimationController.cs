using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.EventSystems;
using System.Collections.Generic;
//using Photon.Pun;

//[RequireComponent(typeof(PlayableDirector))]
public class AnimationController : MonoBehaviour
{

    public bool isIdle = true;
    public bool isSit = false;
    public bool isTeleporting = false;
    public Transform tempPositionStand;
    public GameObject Body;
    private void Start()
    {
        //if (this.gameObject.GetComponent<PhotonView>().IsMine)
        //{
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.layer = 13;//MyCharacter
        }
        //}
        //else
        //{
        //    //for (int i = 0; i < transform.childCount - 1; i++)
        //    //{
        //    //    transform.GetChild(i).gameObject.layer = 15;//OtherCharacters
        //    //}
        //}
    }
    private void Update()
    {

        //{        if (this.gameObject.GetComponent<PhotonView>().IsMine)
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //Debug.Log("walk");
            GetComponent<Animator>().SetBool("Walking", true);
            //this.transform.GetComponent<Animator>().Play("Walking");
        }
        else if (!Input.GetKey(KeyCode.UpArrow) || !Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("WalkingReverse", true);
        }
        else if (!Input.GetKey(KeyCode.DownArrow) || !Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("WalkingReverse", false);
        }

        //if (Input.GetKey(KeyCode.C))
        //{
        //    OnPlayerSitDown();
        //}

        //if (Input.GetKey(KeyCode.V))
        //{
        //    OnPlayerSitUp();
        //}

        //}



      

        if (isSit && canDoActions)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                //if (MouseInputUIBlocker.BlockedByUI)
                //    return;
                OnPlayerSitUp();
            }


            if (Input.GetKeyDown(KeyCode.M))
            {
                Clap();

            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Laugh();

            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Yawn();

            }



        }

    }

    public bool canDoActions;

    public void CanDoActionS()
    {
        canDoActions = !canDoActions;
        //Body.SetActive(true);
      //  PhotonManager.instance.Player.GetComponent<CharacterBehaviour>().CallCharacterSit(PhotonManager.instance.Player.GetComponent<Photon.Pun.PhotonView>().ViewID, true);
    }

    public void StopWalking()
    {
        GetComponent<Animator>().SetBool("Walking", false);
        GetComponent<Animator>().SetBool("WalkingReverse", false);
    }

    public void OnPlayerSitDown()
    {
        //print("OnPlayerSitDown");
        isIdle = false;
        isSit = true;
        isTeleporting = false;
       // SettingsManager.ins.SitMessage.text = "Press 'V' to get up.";
        GetComponent<Animator>().SetBool("Walking", false);
        GetComponent<Animator>().SetBool("WalkingReverse", false);
        GetComponent<Animator>().SetBool("Sitting", true);
        //Rigidbody rb = PhotonManager.instance.Player.GetComponent<Rigidbody>();
        //rb.isKinematic = true;
        //PhotonManager.instance.Player.GetComponent<ThirdPersonCharacterControl>().enabled = false;
        //SettingsManager.ins.LoadingScreen.SetActive(true);
        //SettingsManager.ins.LoadingScreen.GetComponent<Animation>().Play();
        ////Body.SetActive(false);
        //PhotonManager.instance.Player.GetComponent<CharacterBehaviour>().CallCharacterSit(PhotonManager.instance.Player.GetComponent<Photon.Pun.PhotonView>().ViewID, false);
        Invoke("CanDoActionS", 1);
       // SettingsManager.ins.SettingWindow.SetActive(false);
    }

    public void OnPlayerSitUp()
    {
        isIdle = true;
        isSit = false;
        isTeleporting = false;
        GetComponent<Animator>().SetBool("Sitting", false);
        //Rigidbody rb = PhotonManager.instance.Player.GetComponent<Rigidbody>();
        //rb.isKinematic = false;
       
        //PhotonManager.instance.Player.GetComponent<ThirdPersonCharacterControl>().enabled = true;
        //PhotonManager.instance.Player.transform.position = tempPositionStand.position;
        //SettingsManager.ins.LoadingScreen.SetActive(true);
        //SettingsManager.ins.LoadingScreen.GetComponent<Animation>().Play();
        //PhotonManager.instance.Player.GetComponent<CharacterBehaviour>().CallSit(PhotonManager.instance.Player.GetComponent<CharacterBehaviour>().SitID, false, PhotonManager.instance.Player.GetComponent<Photon.Pun.PhotonView>().ViewID);
        //PhotonManager.instance.Player.GetComponent<CharacterBehaviour>().camControl2.Reset();
        //PhotonManager.instance.Player.GetComponent<CharacterBehaviour>().CallCharacterSit(PhotonManager.instance.Player.GetComponent<Photon.Pun.PhotonView>().ViewID, false);
       // Body.SetActive(false);
        Invoke("CanDoActionS", 1);
        //SettingsManager.ins.SettingWindow.SetActive(true);
    }


    public void Clap()
    {
        // UIController.instance.ButtonDisableEnable(UIController.instance.Clap_Btn, isSit, 5.667f);
        Debug.Log("clap");
        GetComponent<Animator>().SetTrigger("SittingClap");
    }

    public void Laugh()
    {
        // UIController.instance.ButtonDisableEnable(UIController.instance.Laugh_Btn, isSit, 8.33f);
        GetComponent<Animator>().SetTrigger("SittingLaugh");
    }



    public void Yawn()
    {
        //UIController.instance.ButtonDisableEnable(UIController.instance.Yawn_Btn, isSit, 8.33f);
        //LaserPointer.myLaser.DelayedLaserOffOn(8.33f);
        GetComponent<Animator>().SetTrigger("StandingYawn");
    }


    public void ChangeCharacterLayer(int layerNum)
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.layer = layerNum;
        }
    }


    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

