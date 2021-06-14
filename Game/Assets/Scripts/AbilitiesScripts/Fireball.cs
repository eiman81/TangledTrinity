using UnityEngine;

[CreateAssetMenu (fileName = "Fireball", menuName = "Ability/Fireball")]
public class Fireball : Ability
{
    // Reference where an ability projectile should spawn (right in front of the player)
    GameObject projectile;
    GameObject end;

    public override void Use ()
    {
        base.Use ();

        if (Input.GetKeyDown (KeyCode.Alpha1))
        {
            if (x == 0f)
            {
                // Create fireball effect
                projectile = player.fireball;
                end = GameObject.Find ("End");

                GameObject projectileInstance;
                projectileInstance = Instantiate (projectile, end.transform.position, Quaternion.identity);
                projectileInstance.GetComponent<Projectile> ().p_amount = amount;

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