using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScore : MonoBehaviour
{
    int score;
    int collectibles;
    UIScore scoreUI;
    UICollectable collectableUI;

    void Awake() {
        score = 0;
        collectibles = 0;
    }

    void Start() {
        scoreUI = ManagerUI.Get<UIScore>();
        collectableUI = ManagerUI.Get<UICollectable>();
    }

    public void ScoreUpdate(int score) {
        this.score += score;
        scoreUI.Show(this.score);
    }

    public void CollectibleUpdate(string name) {
        collectableUI.Show(name);
        collectibles++;
    }

    public int GetScore() {
        return score;
    }

    public int GetCollectibles() {
        return collectibles;
    }
}
