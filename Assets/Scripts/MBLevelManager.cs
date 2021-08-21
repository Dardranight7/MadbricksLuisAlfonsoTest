using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBLevelManager : MonoBehaviour
    {
        public static MBLevelManager MBlevelManager;
        public event System.Action<LevelStage> OnLevelStateChanged;

        public LevelStage LevelStage { get; private set; } = LevelStage.setup;

        private void Awake()
        {
            if (MBlevelManager == null)
            {
                MBlevelManager = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else if (MBlevelManager != this)
            {
                Destroy(this.gameObject);
            }
        }

        public void StartGame()
        {
            SetLevelState(LevelStage.playing);
        }

        public void Win()
        {
            if (LevelStage != LevelStage.playing) { return; }
            SetLevelState(LevelStage.win);
        }

        public void Lose()
        {
            if (LevelStage != LevelStage.playing) { return; }
            SetLevelState(LevelStage.lose);
        }

        private void SetLevelState(LevelStage state)
        {
            LevelStage = state;
            OnLevelStateChanged?.Invoke(LevelStage);
        }
    }

    public enum LevelStage
    {
        setup = 0,
        playing = 1,
        win = 2,
        lose = 3
    }
}