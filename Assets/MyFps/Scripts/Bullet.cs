using UnityEngine;

namespace MyFps
{
    public class Bullet : MonoBehaviour
    {

        private float damage = 5f;


        void OnCollisionEnter(Collision other)
        {
            RobotController robot = other.gameObject.GetComponent<RobotController>();

            if (robot != null)
            {
                robot.TakeDamage(damage);
                Destroy(gameObject);
            }

        }
    }
}
