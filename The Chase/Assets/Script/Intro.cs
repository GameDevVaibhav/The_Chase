using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        //video.Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(1);
    }
   
}
