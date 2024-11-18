using UnityEngine;

namespace MyFps
{
    public class PickupPistol : Interactive
    {
        #region Variables
        public GameObject arrow;
        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public GameObject ammoUI;

        // public Animator pistolAnimator;

        // private bool flag = true;
        #endregion

        protected override void DoAction()
        {
            if(PlayerStats.flag)
            {
                arrow.SetActive(false);
                ammoBox.SetActive(true);
                enemyTrigger.SetActive(true);

                // 무기 획득
                PlayerStats.Instance.SetHasGun(true);
                ammoUI.SetActive(true);
                // pistolAnimator.enabled = true;
                PlayerStats.flag = false;
            }

        }
    }
}