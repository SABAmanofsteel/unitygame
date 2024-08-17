using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;
    public int buttonspressed = 0;
    public int buttonstoclick = 2;
    private void Update()
    {
        if(buttonspressed==buttonstoclick)
        {
            animator.Play("open");
        }
    }
}
