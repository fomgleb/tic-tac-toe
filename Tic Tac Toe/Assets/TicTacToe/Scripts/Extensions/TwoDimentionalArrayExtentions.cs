using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Scripts.Extensions
{
    public static class TwoDimentionalArrayExtentions
    {
        public static T[] GetLine<T>(this T[,] inputArray, int lineIndex)
        {
            var inputArrayWidth = inputArray.GetLength(0);
            var line = new T[inputArrayWidth];

            for (var x = 0; x < inputArrayWidth; x++)
                line[x] = inputArray[lineIndex, x];
            
            return line;
        }

        public static T[] GetColumn<T>(this T[,] inputArray, int columnIndex)
        {
            var inputArrayHeight = inputArray.GetLength(1);
            var column = new T[inputArrayHeight];

            for (var y = 0; y < inputArrayHeight; y++)
                column[y] = inputArray[y, columnIndex];

            return column;
        }

        public static T[] GetLeftDiagonal<T>(this T[,] inputArray, Vector2Int positionThatDiagonalCrosses)
        {
            var inputArrayWidth = inputArray.GetLength(0);
            var inputArrayHeight = inputArray.GetLength(1);
            var leftDiagonal = new List<T>();

            var startOfDiagonal = positionThatDiagonalCrosses;
            for (var i = startOfDiagonal; i.x >= 0 && i.y >= 0; i.x--, i.y--)
                startOfDiagonal = i;

            for (var i = startOfDiagonal; i.x < inputArrayWidth && i.y < inputArrayHeight; i.x++, i.y++)
                leftDiagonal.Add(inputArray[i.y, i.x]);

            return leftDiagonal.ToArray();
        }
        
        public static T[] GetRightDiagonal<T>(this T[,] inputArray, Vector2Int positionThatDiagonalCrosses)
        {
            var inputArrayWidth = inputArray.GetLength(0);
            var inputArrayHeight = inputArray.GetLength(1);
            var rightDiagonal = new List<T>();

            var startOfDiagonal = positionThatDiagonalCrosses;
            for (var i = startOfDiagonal; i.x >= 0 && i.y < inputArrayHeight; i.x--, i.y++)
                startOfDiagonal = i;

            for (var i = startOfDiagonal; i.x < inputArrayWidth && i.y >= 0; i.x++, i.y--)
                rightDiagonal.Add(inputArray[i.y, i.x]);

            return rightDiagonal.ToArray();
        }
    }
}