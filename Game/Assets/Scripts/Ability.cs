using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject
{
    // Ability properties
    public int cooldown;
    public int amount;
    public bool isCoolingDown = false;

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
                end = GameObject.Find("End");
                
                GameObject projectileInstance;
                projectileInstance = Instantiate(projectile, end.transform.position, Quaternion.identity);
                projectileInstance.GetComponent<Projectile>().p_amount = amount;
               // isCoolingDown = true;
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

    public IEnumerator CoolDown ()
    {
        yield return new WaitForSeconds(cooldown);
        isCoolingDown = false;
    }
}
