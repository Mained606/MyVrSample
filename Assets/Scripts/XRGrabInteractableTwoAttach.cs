using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// �ΰ��� Attach Point ����
    /// </summary>
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        #region Variablse
        public Transform leftAttachTransform;
        public Transform rightAttachTransform;
        #endregion

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            //�ΰ��� Attach Point�� ��� �տ� ���� �����ؼ� ����
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }

            base.OnSelectEntering(args);
        }
        
        /*protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            //�ΰ��� Attach Point�� ��� �տ� ���� �����ؼ� ����
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }

            base.OnSelectEntered(args);
        }*/
    }
}