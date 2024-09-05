using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAnimator : MonoBehaviour
{
    public Image buttonImage; // Reference to the Button's Image component
    public Sprite[] playButtonSprites; // Array of sprites for animation
    public float frameRate = 0.75f; // Time interval between frames

    private int currentFrame;
    private float timer;

    void Start()
    {
        if (playButtonSprites.Length == 0)
        {
            Debug.LogError("No sprites assigned to the playButtonSprites array.");
            return;
        }

        buttonImage.sprite = playButtonSprites[0];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            CycleSprites();
        }
    }

    void CycleSprites()
    {
        currentFrame = (currentFrame + 1) % playButtonSprites.Length;
        buttonImage.sprite = playButtonSprites[currentFrame];
    }
}
