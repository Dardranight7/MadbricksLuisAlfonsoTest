using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacterStateJetpack : MBCharacterStateBase
    {
        float timeElapsed;
        float flyHeight;
        public MBCharacterStateJetpack(MBCharacter character) : base(character)
        {
            timeElapsed = Time.time + 10;
            flyHeight = 0;
        }

        public override void ProcessInput(Vector2 direction, bool specialPressed)
        {
            Debug.Log(MBInputManager.MBinputManager.Direction);
            if (direction.y > 0)
            {
                flyHeight += 10 * Time.deltaTime;
            }
            else if (direction.y < 0)
            {
                flyHeight -= 10 * Time.deltaTime;
            }
            flyHeight = Mathf.Clamp(flyHeight, 0, 3);
            character.gameObject.transform.position = Vector3.MoveTowards(character.gameObject.transform.position, new Vector3(direction.x * 3,flyHeight,0), 10 * Time.deltaTime);
        }

        public override void UpdateState()
        {
            if (timeElapsed - Time.time < 0)
            {
                character.SetState(new MBCharacterStateGrounded(character));
            }
        }
    }
}