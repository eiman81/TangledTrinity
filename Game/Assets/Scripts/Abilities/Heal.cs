using UnityEngine;

[CreateAssetMenu (fileName = "Heal", menuName = "Ability/Heal")]
public class Heal : Ability
{
    float x = 0f;

    public override void Use ()
    {
        base.Use ();

        if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            if (x == 0f)
            {
                // Create heal effect
                stats.health += amount;

                x = coolDown;
            }
        }

        if (x > 0)
            x -= Time.deltaTime;

        if (x < 0)
            x = 0;
    }
}
