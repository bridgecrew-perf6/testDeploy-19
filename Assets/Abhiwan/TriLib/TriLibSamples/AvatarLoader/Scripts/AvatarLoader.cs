using TriLibCore.Extensions;
using TriLibCore.General;
using TriLibCore.Mappers;
using TriLibCore.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriLibCore.Samples
{
    /// <summary>Represents a TriLib sample which allows the user to load and control a custom avatar.</summary>

    public class AvatarLoader : AssetViewerBase
    {
      
        /// <summary>
        /// Game object that is used to hide the model while it is loading.
        /// </summary>
        [SerializeField]
        private GameObject _wrapper;


        /// <summary>
        /// Shows the file picker so the user can load an avatar from the local file system.
        /// </summary>
        public void LoadAvatarFromFile()
        {
            LoadModelFromFile(_wrapper);
        }

        /// <summary>
        /// Shows the file picker so the user can load a new animation for the current avatar from the local file system.
        /// </summary>
        public void LoadAnimationFromFile()
        {
            LoadModelFromFile(_wrapper, OnAnimationMaterialsLoad);
        }

        /// <summary>Event triggered when the Model (including Textures and Materials) has been fully loaded, when user loads a new Animation.</summary>
        /// <param name="assetLoaderContext">The Asset Loader Context reference. Asset Loader Context contains the information used during the Model loading process, which is available to almost every Model processing method</param>
        private void OnAnimationMaterialsLoad(AssetLoaderContext assetLoaderContext)
        {

        }

        /// <summary>Event triggered when the Model (including Textures and Materials) has been fully loaded.</summary>
        /// <param name="assetLoaderContext">The Asset Loader Context reference. Asset Loader Context contains the information used during the Model loading process, which is available to almost every Model processing method</param>
        protected override void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
        {
            base.OnMaterialsLoad(assetLoaderContext);
            if (assetLoaderContext.RootGameObject != null)
            {
                var existingInnerAvatar = AvatarController.Instance.InnerAvatar;
                if (existingInnerAvatar != null)
                {
                    Destroy(existingInnerAvatar);
                }
                var controller = AvatarController.Instance.Animator.runtimeAnimatorController;
                var bounds = assetLoaderContext.RootGameObject.CalculateBounds();
                var factor = AvatarController.Instance.CharacterController.height / bounds.size.y;
                assetLoaderContext.RootGameObject.transform.localScale = factor * Vector3.one;
                AvatarController.Instance.InnerAvatar = assetLoaderContext.RootGameObject;
                assetLoaderContext.RootGameObject.transform.SetParent(AvatarController.Instance.transform, false);
                AvatarController.Instance.Animator = assetLoaderContext.RootGameObject.GetComponent<Animator>();
                AvatarController.Instance.Animator.runtimeAnimatorController = controller;
                Debug.Log("Model is loaded........");
                AvatarController.Instance.IsLvlLoading = true;
                SceneManager.LoadScene("Free_City_Scene_I");
            }
        }

        

        /// <summary>Checks if the Dispatcher instance exists and stores this class instance as the Singleton and adjusts avatar size.</summary>
        protected override void Start()
        {
            base.Start();
            AssetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();
            AssetLoaderOptions.AnimationType = AnimationType.Humanoid;
            AssetLoaderOptions.HumanoidAvatarMapper = Resources.Load<HumanoidAvatarMapper>("Mappers/Avatar/MixamoAndBipedByNameHumanoidAvatarMapper");
            var bounds = AvatarController.Instance.InnerAvatar.CalculateBounds();
            var factor = AvatarController.Instance.CharacterController.height / bounds.size.y;
            AvatarController.Instance.InnerAvatar.transform.localScale = factor * Vector3.one;
            //Debug.Log("Called load model from url .....");
            //LoadModelFromURLCalledFromJavaScript("https://usersss.herokuapp.com/Ch22_nonPBR.fbx");
        }

        /// <summary>
        /// Handles the input.
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
            }
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                UpdateCamera();
            }
            //if (Cursor.lockState != CursorLockMode.None)
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //    Cursor.visible = true;
            //    UpdateCamera();
            //}
        }


        /// <summary>
        /// Added by pawan .......
        /// </summary>
        /// <param name="url"></param>
        public void LoadModelFromURLCalledFromJavaScript(string url)
        {
            Debug.Log("Loading model from url is called....from start btn ......");
            if (string.IsNullOrWhiteSpace(url))
            {
                Debug.Log("String can't be empty or null......");
                return;
            }
            var request = AssetDownloader.CreateWebRequest(url);
            var fileExtension = FileUtils.GetFileExtension(request.uri.Segments[request.uri.Segments.Length - 1], false);
            base.LoadModelFromURL(request, fileExtension);
        }
    }
}