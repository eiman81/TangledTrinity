using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public int cooldown;
    public int amount;
    PlayerStats stats;

    public virtual void Use()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    [CreateAssetMenu(menuName = "Ability/Fireball")]
    public class Fireball : Ability
    {
        public override void Use()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                base.Use();
                // Create fireball effect

                // below vvv should be enemy.health += amount;
                stats.health += amount;
            }
          
        }
    }


    [CreateAssetMenu(menuName = "Ability/Heal")]
    public class Heal : Ability
    {
        public override void Use()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                base.Use();
                // Create heal effect
                stats.health += amount;
            }
        }
    }
}
