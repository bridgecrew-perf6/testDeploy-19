
using UnityEngine;

using Wolf3D.ReadyPlayerMe.AvatarSDK;

public class RuntimeTest : MonoBehaviour
{
    [SerializeField] private string AvatarURL = "https://d1a370nemizbjq.cloudfront.net/209a1bc2-efed-46c5-9dfd-edc8a1d9cbe4.glb";

    public GameObject Controller;
    private void Start()
    {
        Debug.Log($"Started loading avatar. [{Time.timeSinceLevelLoad:F2}]");
        AvatarLoader avatarLoader = new AvatarLoader();
        avatarLoader.LoadAvatar(AvatarURL, OnAvatarImported, OnAvatarLoaded);
    }

    private void OnAvatarImported(GameObject avatar)
    {
        Debug.Log($"Avatar imported. [{Time.timeSinceLevelLoad:F2}]");
    }

    private void OnAvatarLoaded(GameObject avatar, AvatarMetaData metaData)
    {
        this.CopypasteComponents(Controller, avatar);
        Debug.Log($"Avatar loaded. [{Time.timeSinceLevelLoad:F2}]\n\n{metaData}");
    }


    #region Component copier
    Component[] copiedComponents;


    void Copy(GameObject from)
    {


        copiedComponents = from.GetComponents<Component>();
    }
    public void CopypasteComponents(GameObject From, GameObject to)
    {
        Copy(From);
        Paste(to);
    }
    void Paste(GameObject targetGameObject)
    {
        if (copiedComponents == null)
        {
           // Debug.LogError("Nothing is copied!");
            return;
        }

        /*    foreach (var targetGameObject in UnityEditor.Selection.gameObjects)
        {
            //  if (!targetGameObject)
            //      continue;

            // Undo.RegisterCompleteObjectUndo(targetGameObject, targetGameObject.name + ": Paste All Components"); // sadly does not record PasteComponentValues, i guess

            foreach (var copiedComponent in copiedComponents)
            {
                if (!copiedComponent)
                    continue;

                UnityEditorInternal.ComponentUtility.CopyComponent(copiedComponent);

                var targetComponent = targetGameObject.GetComponent(copiedComponent.GetType());

                if (targetComponent) // if gameObject already contains the component
                {
                    if (UnityEditorInternal.ComponentUtility.PasteComponentValues(targetComponent))
                    {
                     //   Debug.Log("Successfully pasted: " + copiedComponent.GetType());
                    }
                    else
                    {
                      //  Debug.LogError("Failed to copy: " + copiedComponent.GetType());
                    }
                }
                else // if gameObject does not contain the component
                {
                    if (UnityEditorInternal.ComponentUtility.PasteComponentAsNew(targetGameObject))
                    {
                       // Debug.Log("Successfully pasted: " + copiedComponent.GetType());
                    }
                    else
                    {
                       // Debug.LogError("Failed to copy: " + copiedComponent.GetType());
                    }
                }
            }
        }*/

        //  copiedComponents = null; // to prevent wrong pastes in future
        ClearCoping();
    }

    void ClearCoping()
    {
        copiedComponents = null;
    }
    #endregion
}
