using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FireController: MonoBehaviour
{
    public bool FireAudioEnable = true;
    [Header("开火")]
    public GameObject toIns;
    public Vector3 spawnPos;
    public Quaternion spawnRot;
    public float speed;
    [Header("音效")]
    public AudioClip audioClip;

    private AudioSource _fireAudioSource;

    private void Awake()
    {
        spawnPos = transform.position + Vector3.right * 2;
        spawnRot = this.transform.rotation * Quaternion.Euler(0, 90, 0);
        speed = 1;

        // 设置开火时的音效源
        _fireAudioSource = this.gameObject.AddComponent<AudioSource>();
        if (audioClip != null)
            _fireAudioSource.clip = audioClip;
    }
    public void Fire()
    {
        if(toIns != null)
        {
            GameObject shell = GameObject.Instantiate(toIns);
            shell.transform.position = spawnPos;
            shell.transform.rotation = spawnRot;
            shell.AddComponent<ShellMove>();
            shell.GetComponent<ShellMove>().Init(speed);
        }
    }
    public void FireAudioPlay()
    {
        if(FireAudioEnable)
            _fireAudioSource?.Play();
    }
}

public class ShellMove : MonoBehaviour
{
    public void Init(float speed)
    {
        StartCoroutine(LifeCycleRoutine(speed));
    }

    private IEnumerator LifeCycleRoutine(float speed)
    {
        float timer = 0;
        while (timer < 3)
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            timer += Time.deltaTime;
            yield return null;
        }
        GameObject.Destroy(this.gameObject);
    }
}
