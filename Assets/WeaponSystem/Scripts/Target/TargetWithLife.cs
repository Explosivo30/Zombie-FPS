using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetWithLife : TargetBase
{
    [SerializeField] int life = 3;
    [SerializeField] bool isPlayer = false;


    public override void NotifyShot()
    {
        
        life -= 1;
        Debug.Log("Restaste Vida");
        CheckLife(); 
    }

    public override void NotifyExplosion(Explosion explosion)
    {
        life -= 5;
        CheckLife();
    }

    private void CheckLife()
    {
        if (life <= 0)
        {
            if(isPlayer)
            {
                //Loadeamos el gameover
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
                Cursor.lockState = CursorLockMode.None;
                
            }
            Destroy(gameObject);
        }

        Debug.Log("Tienes" + life);
    }

}
