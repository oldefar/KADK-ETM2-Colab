// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using System.Collections;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.GameObject)]
    [Tooltip("Decouples the GameObject from its parent.")]
    public class OrphanOnDeath : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The GameObject to orphan.")]

        public FsmOwnerDefault gameObject;

        public override void OnEnter()
        {
            GameObject go = (gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
            if (go.transform.parent != null)
            {
                go.transform.parent = null;
            }

            Finish();
        }
    }
}