using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTranslator : MonoBehaviour
{

    private char[] letters;
    private float time = 0.1f;

    public AudioClip[] audios;
    public string[] allSounds;
    public AudioSource audioSource;

    private void OnEnable()
    {
        CustomerDialogues.delegateCustomerMessages += Translator;
    }

    private void OnDisable()
    {
        CustomerDialogues.delegateCustomerMessages -= Translator;
    }

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
    //private void Start()
    //{
    //    Translator("Danza kuduro la mano arriba");
    //}

    //CALL THIIS TO MESSAGE
    public void Translator(string sentence) //aqui va la frase
    {
        letters = sentence.ToCharArray();
        List<int> SoundIndex = new List<int>();

        for (int i = 0; i < letters.Length; i++)
        {
            SoundIndex.Add(FindexIndex(letters[i].ToString()));

        }
        StartCoroutine(ISounds(SoundIndex));
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
