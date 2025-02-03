using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationArmorstand : MonoBehaviour, IInteractable
{
    Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        if (animation.isPlaying)
        {
            return;
        }
        else { animation.Play(); }
    }

    //public void Interact()
    //{
    //    if (GetComponent<Animation>().isPlaying)
    //    {
    //        return;
    //    }
    //    GetComponent<Animation>().Play();
    //}
}
