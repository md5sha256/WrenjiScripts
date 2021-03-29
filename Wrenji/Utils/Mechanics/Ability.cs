using UnityEngine;

namespace Wrenji.Utils.Mechanics
{
    
    public abstract class Ability : MonoBehaviour
    {

        public float range;
        public float baseDamage;

        public abstract void OnCast();

        public void ExecuteDamage(GameObject other, double damage)
        {
            HealthController healthController = other.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.IncrementHealth(-damage);
            }
        }

    }

}