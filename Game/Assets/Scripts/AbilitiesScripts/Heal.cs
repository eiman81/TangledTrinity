using UnityEngine;

[CreateAssetMenu (fileName = "Heal", menuName = "Ability/Heal")]
public class Heal : Ability
{
    public override void Use ()
    {
        base.Use ();

        if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            if (x == 0)
            {
                // Create heal effect
                player.currentHealth += amount;

                if (player.currentHealth > player.stats.health)
                    player.currentHealth = player.stats.health;

                x = coolDown;
            }
        }

        if (x > 0)
            x -= Time.deltaTime;

        if (x < 0)
            x = 0;
    }
}
