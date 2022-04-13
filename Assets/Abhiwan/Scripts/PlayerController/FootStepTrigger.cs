using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Robotopia
{
    [RequireComponent(typeof(AudioSource))]
    public class FootStepTrigger : MonoBehaviour
    {
        AudioSource m_AudioSource;
        [SerializeField]
        internal AudioClip _FootClip;

        private void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void OnTriggerEnter(Collider other)
        {
            // Debug.Log("Trigger>>" + other.transform.tag);
            if (other.transform.tag == "BasePlane")
            {
                m_AudioSource.clip = _FootClip;
                m_AudioSource.Play();
            }
        }

    }
}
