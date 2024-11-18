using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    //인터렉티브 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        // XR부분 추가===================================================
        // XR Interaction 관련
        protected XRBaseInteractable interactable;
        // XR부분 추가===================================================

        //true이면 Interactive 기능을 정지
        protected bool unInteractive = false;
        #endregion

        protected virtual void Awake()
        {
            // theDistance = PlayerCasting.distanceFromTarget;

            // XR부분 추가===================================================
            // XR Interaction 컴포넌트 가져오기
            interactable = GetComponent<XRBaseInteractable>();

            if (interactable != null)
            {
                // XR Hover 이벤트 구독
                interactable.hoverEntered.AddListener(OnHoverEntering);
                interactable.hoverExited.AddListener(OnHoverExit);
                interactable.selectEntered.AddListener(OnSelect);
            }
            // XR부분 추가===================================================

        }

        protected virtual void OnDestroy()
        {
            if (interactable != null)
            {
                interactable.hoverEntered.RemoveListener(OnHoverEntering);
                interactable.hoverExited.RemoveListener(OnHoverExit);
                interactable.selectEntered.RemoveListener(OnSelect);
            }
        }

        // XR부분 추가===================================================

        private void OnSelect(SelectEnterEventArgs args)
        {
            if (!unInteractive)
            {
                DoAction();
            }
        }

        private void OnHoverEntering (HoverEnterEventArgs args)
        {
            if (!unInteractive)
            {
                ShowActionUI();
            }
        }

        private void OnHoverExit(HoverExitEventArgs args)
        {
            HideActionUI();
        }
        // XR부분 추가===================================================

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }
}