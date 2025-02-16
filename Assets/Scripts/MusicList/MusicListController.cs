﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MusicListController : MonoBehaviour
{
    public GameObject itemGO;
    public GameObject listGO;
    public ScrollRect scroll;

    public AudioClip allDayAndNight;
    public AudioClip feelings;
    public AudioClip kream;
    public AudioClip guysMyAge;
    public AudioClip giant;
    public AudioClip tinhSau;
    public AudioClip smooth;
    public List<AudioClip> clips;

    // Use this for initialization
    void Awake()
    {
        clips = new List<AudioClip>();
        clips.Add(allDayAndNight);
        clips.Add(feelings);
        clips.Add(kream);
        clips.Add(guysMyAge);
        clips.Add(giant);
        clips.Add(tinhSau);
        clips.Add(smooth);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < clips.Count; i++)
        {
            itemGO.transform.GetChild(0).gameObject.GetComponent<Text>().text = clips.ElementAt(i).name;
            GameObject item = Instantiate(itemGO, listGO.transform);
            item.transform.localScale = new Vector3(1, 1, 1);
        }
        Destroy(listGO.GetComponent<Transform>().GetChild(0).gameObject);
        scroll.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
