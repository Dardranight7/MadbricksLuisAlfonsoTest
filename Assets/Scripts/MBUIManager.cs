using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks 
{ 
    public class MBUIManager : MonoBehaviour
    {
        [SerializeField] GameObject mainScreen, gameScreen , winScreen, looseScreen;
        // Start is called before the first frame update
        void Start()
        {
            MBLevelManager.MBlevelManager.OnLevelStateChanged += HandleLevelStageChanged;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void IniciarJuego()
        {
            MBLevelManager.MBlevelManager.StartGame();
        }

        private void HandleLevelStageChanged(LevelStage stage)
        {
            if (stage == LevelStage.playing)
            {
                mainScreen.SetActive(false);
                gameScreen.SetActive(true);
            }
            if (stage == LevelStage.win)
            {
                gameScreen.SetActive(false);
                winScreen.SetActive(true);
                StartCoroutine(EndGame());
            }
            if (stage == LevelStage.lose)
            {
                gameScreen.SetActive(false);
                looseScreen.SetActive(true);
                StartCoroutine(EndGame());
            }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(4);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
