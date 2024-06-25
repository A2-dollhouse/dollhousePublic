using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public void Step()
    {
        SoundManager.Instance.PlayPlayerSFX(PlayerSfxSound.Step);
    }
}
