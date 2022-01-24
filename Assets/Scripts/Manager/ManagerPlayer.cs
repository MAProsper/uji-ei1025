using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayer : MonoBehaviour
{
    public float switchDealy = 0.5f;
    public List<GameObject> players;
    public GameObject target;
    InputDealy switchInput;
    bool active;

    void Awake() {
        target = null;
        active = true;
        players = new List<GameObject>();
        switchInput = new InputDealy(switchDealy);
    }

    public void SetActive(bool active) {
        this.active = active;
        SetTarget(target);
    }

    public bool GetActive() {
        return active;
    }
    
    public void Add(GameObject player) {
        players.Add(player);
        SetTarget(player);
    }

    public void Remove(GameObject player) {
        if (players.Count > 1) {
            if (target == player) MoveTarget(1);
        } else {
            if (active) OnPlayersEmpty();
        }
        
        players.Remove(player);
    }

    void OnPlayersEmpty() {
        ManagerUI.Get<UIEnd>().Show();
    }

    void SetTarget(GameObject player) {
        target?.GetComponent<PlayerMovement>().SetActive(false);
        player?.GetComponent<PlayerMovement>().SetActive(active);
        target = player;
    }

    void MoveTarget(int delta) {
        int index = players.IndexOf(target);
        index += players.Count + delta;
        index %= players.Count;
        SetTarget(players[index]);
    }

    void SwitchUpdate() {
        float scroll = Input.GetAxis("Scroll");
        if (scroll != 0 && switchInput.PressIfValid()) {
            MoveTarget(scroll > 0 ? Mathf.CeilToInt(scroll) : Mathf.FloorToInt(scroll));
        }
    }

    void FixedUpdate() {
        SwitchUpdate();
    }
}
