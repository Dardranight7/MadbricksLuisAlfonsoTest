using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacter : MonoBehaviour
    {
        private MBCharacterStateBase currentState;

        public void SetState(MBCharacterStateBase state)
        {
            currentState = state;
        }

        private void Awake()
        {
            SetState(new MBCharacterStateDisabled(this));
        }

        private void Start()
        {
            MBLevelManager.MBlevelManager.OnLevelStateChanged += HandleLevelStageChanged;
        }

        private void Update()
        {
            currentState.UpdateState();
            //TODO: handle state input
            currentState.ProcessInput(MBInputManager.MBinputManager.Direction, MBInputManager.MBinputManager.SpecialPressedThisFrame);
        }

        private void HandleLevelStageChanged(LevelStage stage)
        {
            if (stage == LevelStage.playing)
            {
                SetState(new MBCharacterStateGrounded(this));
            }
            if (stage == LevelStage.win)
            {
                SetState(new MBCharacterStateDisabled(this));
            }
            if (stage == LevelStage.lose)
            {
                SetState(new MBCharacterStateDisabled(this));
            }
        }
    }
}