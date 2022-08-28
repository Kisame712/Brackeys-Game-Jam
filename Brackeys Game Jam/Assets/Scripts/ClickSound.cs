using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        PlayAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio()
    {
        click.Play();

    }
}
