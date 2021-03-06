﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using LibGameAI.DecisionTrees;

namespace LibGameAI.Samples.TestDTs
{
    class Program
    {
        static void Main(string[] args)
        {
            GameAction ga = new GameAction(TestAction);
            ga.DoGameAction();
        }

        private static void TestAction()
        {
            Console.WriteLine("Success!");
        }
    }
}
