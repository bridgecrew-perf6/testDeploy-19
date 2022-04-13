
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitAnimationManager : MonoBehaviour
{
    public static SitAnimationManager Instance;

    [HideInInspector]
    public static bool isPlayerSit = false;
    [HideInInspector]
    public static bool isPlayerUp = false;

    public GameObject sittingChar;

    Animator animator;

    GameObject player,currentBench;

    Collider currentSofa;
    float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (sittingChar != null && this.gameObject.name.Contains("BenchType"))
            sittingChar.SetActive(false);
    }


   

    

}
