using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UI.Tooltips;

public class QuestTooltipSpawner : TooltipSpawner
{
    public override bool CanCreateTooltip()
    {
        return true;
    }

    public override void UpdateTooltip(GameObject tooltip)
    {
        
    }
}
