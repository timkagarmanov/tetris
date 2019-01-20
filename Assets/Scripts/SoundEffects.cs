using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource dynamicHit;
    public AudioSource dynamicRemove;

    private void Start()
    {
        Figure.onBlockFall += PlayHitSound;     // If block fall => play sound
        Field.onRowRemoved += PlayRemoveSound;  // If row removed => play sound
    }

    private void OnDestroy()
    {
        Figure.onBlockFall -= PlayHitSound;     
        Field.onRowRemoved -= PlayRemoveSound;
    }

    [ContextMenu("PlayHit")]
    public void PlayHitSound()
    {
        dynamicHit.Play();
    }

    [ContextMenu("PlayRemove")]
    public void PlayRemoveSound()
    {
        dynamicRemove.Play();
    }
}
