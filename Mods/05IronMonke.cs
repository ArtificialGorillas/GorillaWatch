﻿using GorillaLocomotion;
using System.Collections.Generic;
using TheGorillaWatch.Models;
using UnityEngine;

namespace TheGorillaWatch.Mods
{
    class IronMonke : Page
    {
        public override string modName => "IronMonke";
        public override List<string> incompatibleModNames => new List<string>() { "VelocityFly", "DashMonk" };

        public override void OnUpdate()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(10 * Player.Instance.scale * -GorillaTagger.Instance.leftHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
            }

            if (ControllerInputPoller.instance.rightGrab)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(10 * Player.Instance.scale * GorillaTagger.Instance.rightHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
            }
        }
        public override PageType pageType => PageType.Toggle;
    }
}
