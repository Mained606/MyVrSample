using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        //action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        #endregion

        protected override void Awake()
        {
            base.Awake(); // 부모 클래스의 Awake 호출
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;
            audioSource.Play();
        }
    }
}