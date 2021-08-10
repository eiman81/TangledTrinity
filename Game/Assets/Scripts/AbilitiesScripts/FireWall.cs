using UnityEngine;

[CreateAssetMenu (fileName = "FireWall", menuName = "Ability/FireWall")]
public class FireWall : Ability
{
    // Reference where an ability projectile should spawn (GameObject "end" is right in front of the player)
    GameObject end;

    public override void Use ()
    {
        // Reference the base function so we can automatically get a reference to the player
        base.Use ();

        //
        if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            if (x == 0f)
            {
                // Create fire wall effect
                end = GameObject.Find ("End");

                GameObject projectileInstance;
                projectileInstance = Instantiate (effect, player.transform.position, effect.transform.rotation);

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
