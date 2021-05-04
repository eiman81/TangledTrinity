using UnityEngine;

public abstract class Ability : ScriptableObject
{
    // Ability properties
    public int cooldown;
    public int amount;

    // Reference a character's stats so we can access properties such as health
    GameObject player;
    PlayerStats stats;

    // Reference where an ability projectile should spawn (right in front of the player)
    GameObject projectile;
    GameObject end;

    public virtual void Use()
    {
        player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
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
                projectile = player.GetComponent<AbilityController>().fireball;
                end = GameObject.Find("end");
                
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectile, end.transform.position, Quaternion.id);
                //projectileInstance.AddForce(end.forward* 5000);
                //projectileInstance.transform.position()


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
