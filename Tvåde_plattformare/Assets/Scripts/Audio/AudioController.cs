using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] AudioClip CurrentClip;

    void Start()
    {
        this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayOof()
    {
        AudioSource.PlayClipAtPoint(CurrentClip, transform.position);
    }
}
