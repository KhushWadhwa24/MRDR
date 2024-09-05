using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeartBreakControl : MonoBehaviour
{
    private float delay = 0.5f;
    [SerializeField] private Animator heart = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            heart.Play("HeartBreak", 0, 0.0f);
            float animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

            ScoreSystem.score++;
            Destroy(gameObject, animTime - delay);
        }
    }
}
