using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public abstract class MBCharacterStateBase
    {
        protected MBCharacter character;

        public MBCharacterStateBase(MBCharacter character)
        {
            this.character = character;
        }

        public abstract void UpdateState();
        public abstract void ProcessInput(Vector2 direction, bool specialPressed);
    }
}