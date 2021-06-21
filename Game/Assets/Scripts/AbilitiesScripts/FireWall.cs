using UnityEngine;

[CreateAssetMenu (fileName = "FireWall", menuName = "Ability/FireWall")]
public class FireWall : Ability
{
    // Reference where an ability projectile should spawn (GameObject "end" is right in front of the player)
    GameObject end;

    public override void Use ()
    {
        base.Use ();

        if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            if (x == 0f)
            {
                // Create fire wall effect
                end = GameObject.Find ("End");

                GameObject projectileInstance;
                projectileInstance = Instantiate (effect, player.transform.position, effect.transform.rotation);
                projectileInstance.GetComponent<Projectile> ().p_amount = HealthAmount;

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
