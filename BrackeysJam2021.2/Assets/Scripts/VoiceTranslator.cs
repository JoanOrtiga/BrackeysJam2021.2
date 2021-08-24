using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTranslator : MonoBehaviour
{
    private List<int> SoundIndex = new List<int>();
    private char[] letters;
    private float time = 0.1f;

    public AudioClip[] audios;
    public string[] allSounds;
    public AudioSource audioSource;

    private int FindexIndex(string s)
    {
        for (int i = 0; i < allSounds.Length; i++)
        {
            if (allSounds[i] == s)
            {
                return i;
            }

        }
        return -1;
    }
    private void Translator(string sentence)
    {
        letters = sentence.ToCharArray();

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == 'c' || letters[i] == 't' || letters[i] == 'p'
              || letters[i] == 's' || letters[i] == 'w' && letters[i] != letters.Length - 1)
            {
                if (letters[i + 1] == 'h')
                {
                    string m = letters[i].ToString() + letters[i + 1].ToString();
                    SoundIndex.Add(FindexIndex(m));
                    i += 1;
                }
                else
                    SoundIndex.Add(FindexIndex(letters[i].ToString()));
            }
        }
    }

    private IEnumerator ISounds(List<int> soundIndex)
    {
        for (int i = 0; i < soundIndex.Count; i++)
        {
            if (soundIndex[i] == -1)
                yield return new WaitForSeconds(time);

            else
                audioSource.PlayOneShot(audios[soundIndex[i]]);

            yield return new WaitForSeconds(time);
        }
    }
}
