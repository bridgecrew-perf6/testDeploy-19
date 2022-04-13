using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterChange : MonoBehaviour
{
    //public TMP_InputField NameField;
    //public TMP_InputField AboutFeild;

    public Image CharacterSelectionLeft;
    public Image CharacterSelectionRight;
    public Image CharacterSelectionMiddle;

  //  public GameObject[] Characters;
    public Sprite[] CharacterSprites;
    public Sprite AlphaImage;

  //  public Button startGameButton;
    public GameObject LoadingScreen;
    private TriLibCore.Samples.AvatarLoader avatarLoader;

    void Start()
    {
        avatarLoader = GameObject.Find("AvatarLoader").GetComponent<TriLibCore.Samples.AvatarLoader>();
        //if (PlayerPrefs.HasKey("PlayerNickName"))
        //{
        //    NameField.text = PlayerPrefs.GetString("PlayerNickName");
        //    StaticStrings.PlayerName = NameField.text;
        //}

        //if (PlayerPrefs.HasKey("PlayerBio"))
        //{
        //    AboutFeild.text = PlayerPrefs.GetString("PlayerBio");
        //}

        //PlayerPrefs.SetString("PlayerName", CharacterSprites[0].name);


        // AddUserData("asdasdasdasdasd", "swwww", "avatar.pmg");
    }

    #region Character Selection

    int charID = 0;
    int CurrentCharacterID;
    public void NextCharacter()
    {
        if (charID < CharacterSprites.Length - 1)
            charID++;

        SetCharacter();
    }

    public void PreviousCharacter()
    {
        if (charID > 0)
            charID--;

        SetCharacter();
    }

    private void SetCharacter()
    {
        if (charID == CharacterSprites.Length - 1)
        {
            CharacterSelectionRight.sprite = AlphaImage;
            CharacterSelectionLeft.sprite = CharacterSprites[charID - 1];
        }
        else if (charID == 0)
        {
            CharacterSelectionRight.sprite = CharacterSprites[charID + 1];
            CharacterSelectionLeft.sprite = AlphaImage;
        }
        else
        {
            CharacterSelectionLeft.sprite = CharacterSprites[charID - 1];
            CharacterSelectionRight.sprite = CharacterSprites[charID + 1];
        }

        CharacterSelectionMiddle.sprite = CharacterSprites[charID];
        Debug.Log("character sprit is :: "+ charID);

       // PlayerPrefs.SetString("PlayerName", Characters[charID].name);


    }

    //public void selectCharacter()
    //{
    //    if (CurrentCharacterID != charID)
    //    {

    //        PlayerPrefs.SetString("PlayerName", Characters[charID].name);
    //        PlayerPrefs.SetInt("PlayerIndex", charID);
    //        CurrentCharacterID = charID;

    //    }
    //}


    public void StartGame()
    {
        //avatarLoader.LoadModelFromURLCalledFromJavaScript("https://usersss.herokuapp.com/Ch22_nonPBR.fbx");

        switch (charID)
        {
            case 0:
                Debug.Log("First charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("https://d1a370nemizbjq.cloudfront.net/7e1d1c4d-7def-4115-8cb1-da810d58f21a.glb");
                break;
            case 1:
                Debug.Log("Second charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("https://usersss.herokuapp.com/Ch22_nonPBR.fbx");
                break;
            case 2:
                Debug.Log("third charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("https://usersss.herokuapp.com/Ch31_nonPBR.fbx");
                break;
            case 3:
                Debug.Log("fourth charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("http://45.79.126.10/AbhiwanDemos/FBX_test/Female.fbx");
                break;
            case 4:
                Debug.Log("fifth charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("http://45.79.126.10/AbhiwanDemos/FBX_test/exo_gray.fbx");
                break;
            case 5:
                Debug.Log("Sixth charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("http://45.79.126.10/AbhiwanDemos/FBX_test/erika.fbx");
                break;
            case 6:
                Debug.Log("Seveth charcter is selected ....");
                avatarLoader.LoadModelFromURLCalledFromJavaScript("http://45.79.126.10/AbhiwanDemos/FBX_test/Capoeira.fbx");
                break;

        }

        //if(!string.IsNullOrWhiteSpace(AboutFeild.text))
        //{
        //    PlayerPrefs.SetString("PlayerBio", AboutFeild.text);
        //}
        //int ran = Random.Range(111, 777);

        //if (!string.IsNullOrWhiteSpace(NameField.text))
        //{
        //    PlayerPrefs.SetString("PlayerNickName", NameField.text);

        //}
        //else
        //{
        //    NameField.text = "Player_" + ran.ToString();
        //    PlayerPrefs.SetString("PlayerNickName", NameField.text);
        //}

        //StaticStrings.PlayerName = NameField.text;


        LoadingScreen.SetActive(true);
       // AddUserData(PlayerPrefs.GetString("Account"), NameField.text, "Avatar.png");

        
    }


    //public async void AddUserData(string MetaId, string Name, string Avatar)
    //{
    //    User user = new User();
    //    user.metamaskID = MetaId;
    //    user.nickname = Name;
    //    user.avatar = Avatar;

    //    string jsonStringTrial = JsonUtility.ToJson(user);
    //    // string shopID = "shopID=" + shopIdVal;

    //    var request = new UnityWebRequest(StaticString.GetAddUser(), "POST");
    //    byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringTrial);
    //    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    //    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");
    //    var operation = request.SendWebRequest();
    //    while (!operation.isDone)
    //        await Task.Yield();
    //    Debug.Log("Status Code: " + request.responseCode);

    //    if (request.responseCode == 200)
    //    {
    //        Debug.Log($"Sucesss: {request.downloadHandler.text}");
    //        //  var response = JsonUtility.no(request.downloadHandler.text);
    //        //Debug.Log($"Sucesss: {response["error"]}");
    //        string resp = JsonHelper.Json(request.downloadHandler.text);
    //        Debug.Log($"Sucesss: {resp[3]}");
    //        char c = resp[3];
    //        if (c.Equals('d'))
    //        {
    //            Debug.Log("user added");
    //            Debug.Log($"Sucesss: {request.downloadHandler.text}");
    //            LoadingScreen.SetActive(false);
    //            startGameButton.onClick.Invoke();
              
    //            //  var response = JsonUtility.no(request.downloadHandler.text);
    //            //Debug.Log($"Sucesss: {response["error"]}");
    //        }
    //        else
    //        {
    //            Debug.Log("already exist");
    //        }

    //    }

        #endregion
    }

