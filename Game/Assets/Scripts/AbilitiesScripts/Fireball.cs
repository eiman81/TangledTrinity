using UnityEngine;

[CreateAssetMenu (fileName = "Fireball", menuName = "Ability/Fireball")]
public class Fireball : Ability
{
    // Reference where an ability projectile should spawn (GameObject "end" is right in front of the player)
    [SerializeField]
    Transform end;

    public override void Use ()
    {
        base.Use ();

        // When player presses "1" shoot fireball
        if (Input.GetKeyDown (KeyCode.Alpha1))
        {
            if (x == 0f)
            {
                // Create fireball effect
                end = GameObject.Find ("End").transform;

                //GameObject projectileInstance;
                //projectileInstance = Instantiate (effect, end.position, Quaternion.identity);
                Instantiate (effect, end.position, Quaternion.identity);

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
