using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public List<GameObject> Models;

    public int modelindex;

    public void CycleModel ()
    {
        if (modelindex == Models.Count)
        {
            modelindex = 0;
        }

        for (int i = 0; i < Models.Count; i++)
        {
            Models[i].SetActive (false);
        }

        if (Models.Count > 0)
        {
            Models[modelindex].SetActive (true);
            modelindex++;
        }
    }
}
