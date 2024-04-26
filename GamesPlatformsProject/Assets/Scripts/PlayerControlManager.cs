using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerControlManager : MonoBehaviour
{
    // PLAYER OBJ COMPONENTS \\
    public InputManager inputManager;
    public LocomotionSystem locomotionSystem;
    public DeviceBasedSnapTurnProvider deviceBasedSnapTurnProvider;
    public TeleportationProvider teleportationProvider;

    // PLAYER RIGHT HAND RAY \\
    public XRRayInteractor rightInteractor;

    // PLAYER LEFT HAND CONTROLLER \\
    public XRController leftController;

    // TIP TEXT \\
    public TMP_Text tipText;

    string tip_LookAtLights, tip_UseRightStickToMove, tip_PointAtBoxesToInteract, tip_LeftStickToTeleport, tip_ClickStartThenPickupGun, tip_BeatYourScore, tip;

    //int test;

    void Start()
    {
        tip = "TIP : ";

        tip_LookAtLights = tip + "LOOK at all 3 LIGHTS to gain movement control.";
        tip_UseRightStickToMove = tip + "Push the RIGHT THUMBSTICK up or down to move forward or backward.\n Push the RIGHT THUMBSTICK left or right to turn.";
        tip_PointAtBoxesToInteract = tip + "POINT at the boxes with your RIGHT HAND and hold the RIGHT GRIP button. Move the boxes.";
        tip_LeftStickToTeleport = tip + "Push up on the LEFT THUMBSTICK to teleport.";
        tip_ClickStartThenPickupGun = tip + "POINT at the START BUTTON and press the RIGHT TRIGGER to start the firing range.\n Then GRAB THE GUN and shoot the targets.";
        tip_BeatYourScore = tip + "Try to BEAT your BEST SCORE!";

        inputManager.enabled = false;
        deviceBasedSnapTurnProvider.enabled = false;
        locomotionSystem.enabled = false;        
        teleportationProvider.enabled = false;

        DisplayNextTip(0);
    }

    public void DisplayNextTip(int tipCount)
    {
        switch (tipCount)
        {
            case 0:
                tipText.text = tip_LookAtLights;
                break;
            case 1:
                deviceBasedSnapTurnProvider.enabled = true;
                locomotionSystem.enabled = true;
                rightInteractor.enabled = true;
                inputManager.enabled = true;
                tipText.text = tip_UseRightStickToMove;                
                break;
            case 2:
                tipText.text = tip_PointAtBoxesToInteract;
                break;
            case 3:
                tipText.text = tip_LeftStickToTeleport;
                inputManager.ChangeCanMove();
                teleportationProvider.enabled = true;
                break;
            case 4:
                tipText.text = tip_ClickStartThenPickupGun;
                break;
            case 5:
                tipText.text = tip_BeatYourScore;
                break;
            default:
                tipText.text = "TIP TEXT MISSING";
                break;
        }

        leftController.SendHapticImpulse(1f, 0.75f);
    }
}
