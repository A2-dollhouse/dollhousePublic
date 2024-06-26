using UnityEngine;
using UnityEngine.Audio;

public enum PlayerSfxSound
{
    Step = 0,
    KeyGet,
    KeyAll,
    KeyOpen
}

public enum MonsterSfxSound
{
    Step = 0
}

public class SoundManager : Singleton<SoundManager>
{
    [Header("AudioSource")]
    public AudioSource backgroundSource;
    public AudioSource sfxSource;
    [Header("AudioClip")]
    public AudioClip backgroundClip;
    public AudioClip[] playerSfxClips;
    public AudioClip[] playerStepSfxClips;
    public AudioClip[] monsterSfxClips;
    public AudioClip[] monsterStepSfxClips;
    [Header("AudioMixer")]
    public AudioMixerGroup backgroundMixerGroup;
    public AudioMixerGroup sfxMixerGroup;

    private void Start()
    {
        if (backgroundSource == null)
        {
            backgroundSource = gameObject.AddComponent<AudioSource>();
            backgroundSource.outputAudioMixerGroup = backgroundMixerGroup;
            backgroundSource.loop = true;
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.outputAudioMixerGroup = sfxMixerGroup;
        }
    }

    public void PlayPlayerSFX(PlayerSfxSound sfxSound)
    {
        if (sfxSource != null)
        {
            if (sfxSound == PlayerSfxSound.Step)
            {
                if (playerStepSfxClips.Length > 0)
                {
                    int randomIndex = Random.Range(0, playerStepSfxClips.Length);
                    sfxSource.PlayOneShot(playerStepSfxClips[randomIndex]);
                }
            }
            else
            {
                int index = (int)sfxSound;
                if (index < playerSfxClips.Length)
                {
                    sfxSource.PlayOneShot(playerSfxClips[index]);
                }
            }
        }
    }

    public void PlayMonsterSFX(MonsterSfxSound sfxSound)
    {
        if (sfxSource != null)
        {
            if (sfxSound == MonsterSfxSound.Step)
            {
                if (monsterStepSfxClips.Length > 0)
                {
                    int randomIndex = Random.Range(0, monsterStepSfxClips.Length);
                    sfxSource.PlayOneShot(monsterStepSfxClips[randomIndex]);
                }
            }
            else
            {
                int index = (int)sfxSound;
                if (index < monsterSfxClips.Length)
                {
                    sfxSource.PlayOneShot(monsterSfxClips[index]);
                }
            }
        }
    }
}