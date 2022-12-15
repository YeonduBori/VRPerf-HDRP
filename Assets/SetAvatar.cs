using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SetAvatar : MonoBehaviour
{
    public GameObject canvas;
    private VisualEffect particleAvatar;

    private bool bStart = false;
    private bool bUI = false;

    private float lifeTime = 0;
    private float position = 0;
    private float force = 10;

    private float timer = 0.0f;

    private void Start()
    {
        particleAvatar = transform.GetComponent<VisualEffect>();
        InitValue();
        SetValue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitValue();
            SetValue();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            bStart = true;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            bUI = !bUI;
            canvas.SetActive(bUI);
        }

        if(bStart)
        {
            Intro();
            SetValue();
        }
    }

    private void InitValue()
    {
        lifeTime = 0;
        position = 0;
        force = 10;
    }

    private void PlaySetValue()
    {
        position = 1;
        force = 1;
        lifeTime = 1;
    }

    private void Intro()
    {
        timer += Time.deltaTime;

        if(timer < 3)
        {
            lifeTime = Mathf.Lerp(0, 10, timer);
        }
        else if(timer < 4)
        {
            position = Mathf.Lerp(0, 1, timer - 3);
            force = Mathf.Lerp(10, 1, timer - 3);
            lifeTime = Mathf.Lerp(10, 1, (timer - 3) * 0.5f);
        }
        else if (timer > 8)
        {
            PlaySetValue();
            timer = 0;
            bStart = false;
        }
    }

    private void SetValue()
    {
        particleAvatar.SetFloat("Set Lifetime", lifeTime);
        particleAvatar.SetFloat("Set Position", position);
        particleAvatar.SetFloat("Set Force", force);
    }
}
