using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Points
{
    public class PointsSystem
    {
        private int currentPoints;
        public int CurrentPoints => currentPoints;

        public void InitSystem()
        {
            currentPoints = -1;
        }

        public void IncreasePoints()
        {
            currentPoints++;
        }
    } 
}
