using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacterStateDisabled : MBCharacterStateBase
    {
        public MBCharacterStateDisabled(MBCharacter character) : base(character)
        { }

        public override void ProcessInput(Vector2 direction, bool specialPressed)
        {
        }

        public override void UpdateState()
        {
        }
    }
}