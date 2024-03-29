﻿using UnityEngine;

namespace YonatanTools.Utilities.RectTransition
{
    [CreateAssetMenu(fileName = "New Transition SO", menuName = "ScriptableObjects/Transitions/New Transition SO")]
    public class TransitionPackSO : ScriptableObject
    {
        public bool HaveMovement = true; 
        public Transition3D Movement;
        public Vector3 MoveOffSet;

        public enum ScaleTypeEnum
        {
            ByFloat,
            ByVector
        };

        public enum PositionType
        {
            WordPosition,
            AnchoredPosition,
            LocalPosition
        };
    
        public PositionType MovePositionType;
        public ScaleTypeEnum ScaleType;
        public bool HaveScale = false; 
        public float ScaleMultiplier;
        public Vector3 ScaleVector;
        public Transition3D Scale;
    
        public bool HaveRotation = false; 
        public Vector3 Rotate; 
        public Transition3D Rotation;
    }
 
}
