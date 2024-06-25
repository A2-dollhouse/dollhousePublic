using UnityEngine;

public class MonsterSoundController : MonoBehaviour
{
    public void Step()
    {
        SoundManager.Instance.PlayMonsterSFX(MonsterSfxSound.Step);
    }
}
