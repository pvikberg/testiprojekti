﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Assertions;

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


public class color1 : MonoBehaviour {

public Text toBT;
public Text fromBT;

string[] tohistory = {"-","-","-","-","-","-","-"};
string[] fromhistory = {"-","-","-","-","-","-","-"};

string strOutput;
Process p = null;
ProcessStartInfo psi;
int framecounter;
Renderer rend;

	// Use this for initialization
	void Start () {

rend = GetComponent<Renderer>();
framecounter = 1;
toupdate("start");
fromupdate("start");

    psi = new ProcessStartInfo();
    
psi.FileName = "bash";
psi.Arguments = "-c \"echo tutturuu\"";
psi.UseShellExecute = false;
    psi.RedirectStandardOutput = true;
/*
    p = Process.Start(psi);
    strOutput = p.StandardOutput.ReadToEnd();
    p.WaitForExit();
    
 UnityEngine.Debug.Log( strOutput );


psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-read -a 0x000e\"";
 p = Process.Start(psi);
    strOutput = p.StandardOutput.ReadToEnd();
    p.WaitForExit();
    
 UnityEngine.Debug.Log( strOutput.Substring(33) );

 UnityEngine.Debug.Log( (int.Parse(strOutput.Substring(33))==15) );
*/
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKeyDown(KeyCode.R)){rend.material.SetColor("_Color", Color.red);}
		else if(Input.GetKeyDown(KeyCode.G)){rend.material.SetColor("_Color", Color.green);}
		else if(Input.GetKeyDown(KeyCode.B)){rend.material.SetColor("_Color", Color.blue);}
		else if(Input.GetKeyDown(KeyCode.W)){rend.material.SetColor("_Color", Color.white);}
*/





int komento = 0;

if(Input.GetKeyDown(KeyCode.Alpha2)){komento = 1;
psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-write-req --handle=0x0011 --value=02\"";
toupdate("02");}
else if(Input.GetKeyDown(KeyCode.Alpha3)){komento = 1;
psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-write-req --handle=0x0011 --value=03\"";
toupdate("03");}
else if(Input.GetKeyDown(KeyCode.Alpha4)){komento = 1;
psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-write-req --handle=0x0011 --value=04\"";
toupdate("04");}
else if(Input.GetKeyDown(KeyCode.Alpha0)){komento = 1;
psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-write-req --handle=0x0011 --value=00\"";
toupdate("00");}



if(komento == 1){ p = Process.Start(psi);
    strOutput = p.StandardOutput.ReadToEnd();
    p.WaitForExit();}




framecounter = framecounter + 1;

if(framecounter > 4){
framecounter = 1;









psi.Arguments = "-c \"gatttool -b 00:64:C3:43:39:19 --char-read -a 0x000e\"";
 p = Process.Start(psi);
    strOutput = p.StandardOutput.ReadToEnd();
    p.WaitForExit();

int nappi = int.Parse(strOutput.Substring(33));
fromupdate(strOutput.Substring(33,2));
if(nappi==0){rend.material.SetColor("_Color", Color.white);}
else if(nappi==1){rend.material.SetColor("_Color", Color.green);}
else if(nappi==2){rend.material.SetColor("_Color", Color.red);}
else if(nappi==3){rend.material.SetColor("_Color", Color.blue);}


}

	}

void toupdate(string uusi){for(int i = 0;i<6;i++){tohistory[i] = tohistory[i+1];}tohistory[6] = uusi;

toBT.text = tohistory[0]+ "\n" + tohistory[1] +"\n"+ tohistory[2] +"\n"+ tohistory[3] +"\n"+ tohistory[4] +"\n"+ tohistory[5] +"\n"+ tohistory[6];}

void fromupdate(string uusi){for(int i = 0;i<6;i++){fromhistory[i] = fromhistory[i+1];}fromhistory[6] = uusi;

fromBT.text = fromhistory[0]+ "\n" + fromhistory[1] +"\n"+ fromhistory[2] +"\n"+ fromhistory[3] +"\n"+ fromhistory[4] +"\n"+ fromhistory[5] +"\n"+ fromhistory[6];}


}
