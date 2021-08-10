using UnityEngine;

[CreateAssetMenu (fileName = "Heal", menuName = "Ability/Heal")]
public class Heal : Ability
{
    public override void Use ()
    {
        // Reference the base function so we can automatically get a reference to the player
        base.Use ();

        if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            if (x == 0)
            {
                // Create heal effect
                player.currentHealth += HealthAmount;

                if (player.currentHealth > player.stats.health)
                    player.currentHealth = player.stats.health;

                // Begin the cooldown
                x = coolDown;
            }
        }

        if (x > 0)
            x -= Time.deltaTime;

        if (x < 0)
            x = 0;
    }
}
