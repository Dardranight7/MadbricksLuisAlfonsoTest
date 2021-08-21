using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacterStateGrounded : MBCharacterStateBase
    {
        float timeElapsed;
        bool jetpack;
        public MBCharacterStateGrounded(MBCharacter character) : base(character)
        {
            timeElapsed = Time.time + 5;
        }

        public override void ProcessInput(Vector2 direction, bool specialPressed)
        {
            character.gameObject.transform.position = Vector3.MoveTowards(character.gameObject.transform.position, (direction * Vector3.right) * 3, 10 * Time.deltaTime);
            jetpack = specialPressed;
        }

        public override void UpdateState()
        {
            if (timeElapsed - Time.time < 0 && jetpack)
            {
                character.SetState(new MBCharacterStateJetpack(character));
            }
        }
    }
}