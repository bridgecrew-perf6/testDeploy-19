using TriLibCore.Samples;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    private GameObject _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        AvatarController.Instance.IsLvlLoading = false;
        if (_mainCamera == null)
			{
				_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
        _mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
			
    }

    // Update is called once per frame
  
}
