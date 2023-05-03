using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public PlayerController starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualFireInput(bool virtualFireState)
        {
            starterAssetsInputs.FireInput(virtualFireState);
        }
        public void VirtualRoarInput(bool virtualRoarState)
        {
            starterAssetsInputs.RoarInput(virtualRoarState);
        }

       
        
    }

}
