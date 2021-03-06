﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using System.Collections.Generic;
using LibGameAI.PathFinding;

namespace LibGameAI.Samples.TestDijkstra
{
    class Test
    {
        static void Main()
        {
            IGraph g;
            IPathFinder pathFinder = new DijkstraPathFinder();

            Console.WriteLine("=== Graph initialized with Adj. Matrix ===");
            g = TestAM();
            //ShowConns(g);
            ShowPath(pathFinder.FindPath(g, 0, 7));

            Console.WriteLine("=== Graph initialized with Adj. List ===");
            g = TestAL();
            //ShowConns(g);
            ShowPath(pathFinder.FindPath(g, 0, 6));

        }

        static void ShowConns(IGraph g)
        {
            int maxNode = 0;
            for (int i = 0; i <= maxNode; i++)
            {
                Console.WriteLine($"** Node {i} **");
                foreach (Connection c in g.GetConnections(i))
                {
                    if (c.ToNode > maxNode) maxNode = c.ToNode;
                    Console.WriteLine($"- from {c.FromNode} to {c.ToNode}: " +
                    c.Cost);
                }
            }
        }

        static void ShowPath(IEnumerable<IConnection> conns)
        {
            foreach (IConnection c in conns)
            {
                Console.WriteLine($"Node {c.FromNode} to {c.ToNode}: " +
                    c.Cost);
            }
        }

        static IGraph TestAM()
        {
            return new Graph(
                new float[,]
                {
                    { 0.0f, 0.2f, 0.0f, 1.2f, 0.0f, 0.0f, 9.5f, 0.0f},
                    { 0.1f, 0.0f, 0.0f, 0.0f, 3.1f, 0.0f, 0.0f, 0.0f},
                    { 0.0f, 2.3f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
                    { 4.5f, 0.0f, 0.0f, 0.0f, 3.5f, 0.0f, 0.0f, 0.0f},
                    { 0.0f, 0.0f, 2.1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                    { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.1f},
                    { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.7f, 0.0f, 5.2f},
                    { 0.0f, 0.0f, 0.0f, 0.0f, 0.3f, 0.0f, 0.0f, 0.0f}
                }
            );
        }

        static IGraph TestAL()
        {
            return new Graph(
                new IConnection[][]
                {
                    new IConnection[]
                    {
                        new Connection(1.3f, 0, 1),
                        new Connection(1.6f, 0, 2),
                        new Connection(3.3f, 0, 3)
                    },
                    new IConnection[]
                    {
                        new Connection(1.5f, 1, 4),
                        new Connection(1.9f, 1, 5)
                    },
                    new IConnection[]
                    {
                        new Connection(1.3f, 2, 3)
                    },
                    new IConnection[]
                    {
                    },
                    new IConnection[]
                    {
                    },
                    new IConnection[]
                    {
                        new Connection(1.4f, 5, 6)
                    },
                    new IConnection[]
                    {
                    }
                }
            );
        }
    }
}
