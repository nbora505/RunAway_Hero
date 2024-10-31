using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public GameObject startPanel;
    public Animator animator;
    public AudioClip buttonSfx;
    AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
        StartCoroutine(ReadingCartoon());
    }
    IEnumerator ReadingCartoon()
    {
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);

        yield return new WaitForSeconds(2);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(1);
        sfx.PlayOneShot(buttonSfx);
        yield return new WaitForSeconds(3);

        StartCoroutine(MainGameLoad());
    }

    public void OnSkipButton()
    {
        StopCoroutine(ReadingCartoon());
        StartCoroutine(MainGameLoad());
    }

    IEnumerator MainGameLoad()
    {
        startPanel.SetActive(true);
        animator.SetTrigger("reStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainGame");
    }
}
