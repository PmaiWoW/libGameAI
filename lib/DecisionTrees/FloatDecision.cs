﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;

namespace LibGameAI.DecisionTrees
{
    public class FloatDecision : Decision
    {
        private float minValue, maxValue;

        private Func<float> getValueToTest;

        public FloatDecision(IDTNode trueNode, IDTNode falseNode,
            float minValue, float maxValue, Func<float> getValueToTest)
            : base(trueNode, falseNode)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.getValueToTest = getValueToTest;
        }

        protected override bool Test()
        {
            float valueToTest = getValueToTest();
            if (valueToTest >= minValue && valueToTest <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}