﻿using System;

using UnityEngine;

using Zilon.Core.Components;

public class ActorGraphicBase : MonoBehaviour
{
    public virtual VisualPropHolder GetVisualProp(EquipmentSlotTypes types)
    {
        throw new NotImplementedException();
    }

    public virtual void ProcessDeath()
    {
        throw new NotImplementedException();
    }
}