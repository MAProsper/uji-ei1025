using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnd : BaseBehaviour
{
    public float restartDelay = 10f;
    public AudioClip endSound;

    public void Show() {
        if (animator.GetBool("Visible")) {
            ManagerUI.Get<UITransition>().Show("Level");
        } else {
            animator.SetBool("Visible", true);
            Manager.Get<ManagerAttack>().enabled = false;
            Manager.Get<ManagerPlayer>().SetActive(false);
            Manager.Get<ManagerTime>().SetTime(restartDelay);
            GetComponent<AudioSource>().PlayOneShot(endSound);
        }
    }
}
