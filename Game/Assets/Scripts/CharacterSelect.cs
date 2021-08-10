﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public List<GameObject> Models;

    public TextMeshProUGUI nameText, descText, ageText;

    public float rotateSpeed;

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
            ageText.text = "Age: " + Models[modelindex].GetComponent<StatsDisplay> ().stats.age.ToString();
            nameText.text = Models[modelindex].GetComponent<StatsDisplay> ().stats.name;
            descText.text = Models[modelindex].GetComponent<StatsDisplay> ().stats.description;

            modelindex++;
        }
    }

    private void Update ()
    {
        foreach (var model in Models)
        {
            model.transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
