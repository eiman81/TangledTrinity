using UnityEngine;

[CreateAssetMenu (fileName = "Fireball", menuName = "Ability/Fireball")]
public class Fireball : Ability
{
    // Reference where an ability projectile should spawn (GameObject "end" is right in front of the player)
    Transform end;

    public override void Use ()
    {
        // Reference the base function so we can automatically get a reference to the player
        base.Use ();

        // When player presses "1" shoot fireball
        if (Input.GetKeyDown (KeyCode.Alpha1))
        {
            if (x == 0f)
            {
                // Create fireball effect
                end = GameObject.Find ("End").transform;

                GameObject projectileInstance;
                projectileInstance = Instantiate (effect, end.position, effect.transform.rotation);

                // Play the player attack animation
                player.GetComponent<Animator> ().SetTrigger ("attacking");

                // Play a sound effect
                player.source.clip = player.sounds[0];
                player.source.Play ();

                // Begin the cooldown
                x = coolDown;
            }
        }

        // Cooldown
        if (x > 0)
            x -= Time.deltaTime;

        if (x < 0)
            x = 0;
    }
}
