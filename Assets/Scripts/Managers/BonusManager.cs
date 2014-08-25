using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BonusManager : MonoBehaviour
{
    public GameManager gameManager;
    public List<Transform> collectables = new List<Transform>();
    public GUIText[] myMessages;
    public int collected;
    public TextMesh goldCubeText;
    public int tempCollected;
    private int availableColls;
    private int goldCubes;

    void Start()
    {


    }

    void Update()
    {
        availableColls = collectables[gameManager.levelManager.currentLevel].childCount;

        if (!gameManager.levelLoading)
        {
            myMessages[0].gameObject.SetActive(true);
            myMessages[0].text = ("Collected " + tempCollected + " / "
                + availableColls);
            if (collected == availableColls)
            {
                gameManager.soundManager.soundFX[3].Play();
                myMessages[1].gameObject.SetActive(true);
                goldCubes++;
                StartCoroutine(RemoveText());
                collected = 0;
            }
        }

        else
        {
            myMessages[0].gameObject.SetActive(false);
            goldCubeText.text = ("Golden cubes collected " + goldCubes +
                " / " + gameManager.levelManager.levels.Count);
        }
    }

    IEnumerator RemoveText()
    {
        yield return new WaitForSeconds(2);

        myMessages[1].gameObject.SetActive(false);
    }
}
