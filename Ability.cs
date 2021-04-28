using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public int cooldown;
    public int amount;

    public virtual void Use(int amount)
    {

    }

    [CreateAssetMenu(menuName = "Ability")]
    public class Fireball : Ability
    {
        public override void Use(int amount)
        {
            
        }
    }
}
