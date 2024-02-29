using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Pistol : Gun
{

    protected override void PrimaryFire()
    {
        if(shoot_delay_timer <= 0)
        {
            if (Primary_fire_is_shooting || primary_fire_hold)
            {
                Primary_fire_is_shooting = false;
                shoot_delay_timer = gunData.primary_fire_delay;

                Vector3 dir = Quaternion.AngleAxis(Random.Range(-gunData.spread, gunData.spread), Vector3.up)*cam.transform.forward;
                dir = Quaternion.AngleAxis(Random.Range(-gunData.spread, gunData.spread), Vector3.right) * dir;

                //RayCast 
                ray = new Ray(cam.transform.position, dir);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, gunData.range))
                {
                    Debug.DrawLine(transform.position, hit.point, Color.green, 0.5f);
                }

                //Subtract ammo
                ammo_in_clip--;
                if (ammo_in_clip <= 0) ammo_in_clip = gunData.ammo_per_clip;
            }
        }
    }


    private void SecondaryFire()
    {

    }


}
