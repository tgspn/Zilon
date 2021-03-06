﻿using System.Linq;

using Zilon.Core.Tactics.Spatial;

namespace Zilon.Core.MapGenerators
{
    public class GridMapGenerator : IMapGenerator
    {
        private const int DEFAULT_MAP_SIZE = 10;
        private readonly int _mapSize;

        public GridMapGenerator() : this(DEFAULT_MAP_SIZE)
        {
        }

        public GridMapGenerator(int mapSize)
        {
            _mapSize = mapSize;
        }

        public void CreateMap(IMap map)
        {
            CreateNodes(map);
            CreateEdges(map);
        }

        private void CreateEdges(IMap map)
        {
            foreach (var node in map.Nodes)
            {
                var currentNode = (HexNode)node;
                var nodes = map.Nodes.Cast<HexNode>().ToArray();
                var neighbors = HexNodeHelper.GetNeighbors(currentNode, nodes);

                foreach (var neighbor in neighbors)
                {
                    var currentEdge = GetExistsEdge(map, (HexNode)node, neighbor);

                    if (currentEdge != null)
                    {
                        continue;
                    }

                    AddEdgeToMap(map, (HexNode)node, neighbor);
                }
            }
        }

        /// <summary>
        /// Создаёт на карте ребро, соединяющее два узла этой карты.
        /// </summary>
        /// <param name="targetMap"> Целевая карта, для которой нужно создать ребро. </param>
        /// <param name="node"> Исходное ребро карты. </param>
        /// <param name="neighbor"> Соседнее ребро карты, с которым будет соединено исходное. </param>
        private static void AddEdgeToMap(IMap targetMap, HexNode node, HexNode neighbor)
        {
            var edge = new Edge(node, neighbor);
            targetMap.Edges.Add(edge);
        }

        /// <summary>
        /// Возвращает ребро, соединяющее указанные узлы.
        /// </summary>
        /// <param name="map"> Карта, в которой проверяются ребра. </param>
        /// <param name="node"> Искомый узел. </param>
        /// <param name="neighbor"> Узел, с которым соединён искомый. </param>
        /// <returns> Ребро или null, если такого ребра нет на карте. </returns>
        private static Edge GetExistsEdge(IMap map, HexNode node, HexNode neighbor)
        {
            return (Edge)(from edge in map.Edges
                    where edge.Nodes.Contains(node)
                    where edge.Nodes.Contains(neighbor)
                    select edge).SingleOrDefault();
        }

        private void CreateNodes(IMap map)
        {
            var nodeIdCounter = 1;
            for (var row = 0; row < _mapSize; row++)
            {
                for (var col = 0; col < _mapSize; col++)
                {
                    var node = new HexNode(col, row)
                    {
                        Id = nodeIdCounter++
                    };

                    map.Nodes.Add(node);
                }
            }
        }

    }
}
