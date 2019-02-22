using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private Light flashLight;
    private bool isEnabled = true;
    
  
    [SerializeField]
    private Image indicator;

    private float maxBatteryLife;
    private float curBatteryLife;
    [SerializeField]
    private float lightDrain;

    void Start(){
        maxBatteryLife= flashLight.intensity;
        curBatteryLife= maxBatteryLife;

    }

    void Update(){
        if(isEnabled==true){
           if(curBatteryLife > 0){
                curBatteryLife -= lightDrain * Time.deltaTime;

                flashLight.intensity=curBatteryLife;

                var indicatorWidth= curBatteryLife/maxBatteryLife;
                var indicatorScale= indicator.transform.localScale;
                indicator.transform.localScale =new Vector3(indicatorWidth,indicatorScale.y,indicatorScale.z);
      
           }
           else {
               curBatteryLife=0;
               isEnabled=false;
               flashLight.enabled=false;
           }
        }

        if(Input.GetKeyDown(KeyCode.F) && curBatteryLife>0){
            // если фонарик включен - выключить
            isEnabled = !isEnabled;
            flashLight.enabled = isEnabled;
        }
    }
    public void AddEnergy(float value){
        if(maxBatteryLife>=curBatteryLife+value){
        curBatteryLife+=value;
        }
        else{
            curBatteryLife=maxBatteryLife;
        }

    }
}
