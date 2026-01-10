using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FireController: MonoBehaviour
{
    public GameObject toIns;
    public Vector3 spawnPos;
    public Quaternion spawnRot;
    public float speed;

    private void Awake()
    {
        spawnPos = transform.position + Vector3.right * 2;
        spawnRot = this.transform.rotation * Quaternion.Euler(0, 90, 0);
        speed = 1;
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
