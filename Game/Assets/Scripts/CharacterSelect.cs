using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public List<GameObject> Models;

    public TextMeshProUGUI nameText, descText, ageText;

    public float rotateSpeed;

    public int modelindex;


    // The method to cycle through the characters to select
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
            // For the current active model in the cycle, set it to true so it can be displayed
            Models[modelindex].SetActive (true);

            // Set the text (e.g. name, age, description) of the characters
            ageText.text = "Age: " + Models[modelindex].GetComponent<StatsDisplay> ().stats.age.ToString();
            nameText.text = Models[modelindex].GetComponent<StatsDisplay> ().stats.name;
            descText.text = Models[modelindex].GetComponent<StatsDisplay> ().stats.description;

            // Increment the model index
            modelindex++;
        }
    }

    // For all of the models, rotate them on their axis so they can be viewed in the character select
    private void Update ()
    {
        foreach (var model in Models)
        {
            model.transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
