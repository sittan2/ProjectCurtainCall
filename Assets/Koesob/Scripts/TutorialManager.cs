using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPannel;
    public List<Sprite> sprites;
    public int currentIndex;
    public Image image;

    public void OnTutorial()
    {
        tutorialPannel.SetActive(true);
        currentIndex = 0;
        image.sprite = sprites[0];
    }

    public void OffTutorial()
    {
        tutorialPannel.SetActive(false);
    }

    public void NextPage()
    {
        var tempIndex = currentIndex + 1;

        if(tempIndex >= sprites.Count)
        {
            tempIndex = currentIndex;
        }
        else
        {
            currentIndex++;
        }

        image.sprite = sprites[tempIndex];
        
    }

    public void PrePage()
    {
        var tempIndex = currentIndex - 1;

        if (tempIndex < 0)
        {
            tempIndex = 0;
        }
        else
        {
            currentIndex--;
        }

        image.sprite = sprites[tempIndex];
        
    }
}
