﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class title : MonoBehaviour

{
    public Text length1; 
    public static int leng;
    // Start is called before the first frame update
    
     void Start()
    {
    
    
    }

    public void gofield()
    {
    leng=int.Parse(length1.text);
    if(leng>3 && leng<31 && leng %2 ==0)
    {
        DontDestroyOnLoad (this);
        SceneManager.LoadScene("Fieldset");
    }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
