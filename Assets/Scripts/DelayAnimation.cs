using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAnimation : MonoBehaviour
{

    [SerializeField] private float delayTime = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ExecuteAnimation", delayTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ExecuteAnimation()
    {
        animator.Play(animationName);
    }
}
