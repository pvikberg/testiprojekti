using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Assertions;

using System;
using System.IO;
using System.Diagnostics;



public class color1vara : MonoBehaviour {

	// Use this for initialization
	void Start () {
    ProcessStartInfo psi = new ProcessStartInfo();
    
psi.FileName = "bash";
psi.Arguments = "-c \"echo tutturuu\"";
psi.UseShellExecute = false;
    psi.RedirectStandardOutput = true;

    Process p = Process.Start(psi);
    string strOutput = p.StandardOutput.ReadToEnd();
    p.WaitForExit();
    
 UnityEngine.Debug.Log( strOutput );


psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-read -a 0x000e\"";
 p = Process.Start(psi);
    strOutput = p.StandardOutput.ReadToEnd();
    p.WaitForExit();
    
 UnityEngine.Debug.Log( strOutput.Substring(33) );

 UnityEngine.Debug.Log( (int.Parse(strOutput.Substring(33))==15) );

	}
	
	// Update is called once per frame
	void Update () {
		Renderer rend = GetComponent<Renderer>();
		if(Input.GetKeyDown(KeyCode.R)){rend.material.SetColor("_Color", Color.red);






}
		else if(Input.GetKeyDown(KeyCode.G)){rend.material.SetColor("_Color", Color.green);}
		else if(Input.GetKeyDown(KeyCode.B)){rend.material.SetColor("_Color", Color.blue);}
		else if(Input.GetKeyDown(KeyCode.W)){rend.material.SetColor("_Color", Color.white);}

	}




}
