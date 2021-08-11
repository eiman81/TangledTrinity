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

                // This ensures that the player does not gain any more health than what their max health value is. The player can not abuse the heal spell and keep healing themself infinitely
                if (player.currentHealth > player.stats.health)
                    player.currentHealth = player.stats.health;

                // Play a sound effect
                player.source.clip = player.sounds[1];
                player.source.Play ();

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
