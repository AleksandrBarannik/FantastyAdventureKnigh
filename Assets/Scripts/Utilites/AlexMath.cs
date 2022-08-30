using System;
using System.Collections.Generic;
using UnityEngine;

//Расширенные класс Mathf Для частных случаев (повора игрока в нужную сторону и тд)
namespace Utilites
{
    public static class AlexMath
    {
        public static int GetSign(float value)
        {
            return value > 0 ? 1 : -1;
        }

        public static int GetObjectSide(Vector3 self, Vector3 obj)
        {
            return obj.x > self.x ? 1 : -1;
        }

        public static Vector3 AbsVector3(Vector3 value)
        {
            return new Vector3(
                Mathf.Abs(value.x),
                Mathf.Abs(value.y),
                Mathf.Abs(value.z));
        }

        public static int IncreaseIndex(int currentIndex, int arrayLength, int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                currentIndex++;
                if (currentIndex == arrayLength)
                {
                    currentIndex = 0;
                }
            }

            return currentIndex;
        }

        public static bool GetCorrectScopes(string scopes)
        {
            List<char> stack = new List<char>();
            List<Tuple<char, char>> alphabet = new List<Tuple<char, char>>()
            {
                new Tuple<char, char>('(', ')'),
                new Tuple<char, char>('{', '}'),
            };
            
            foreach (var e in scopes)
            {
                if (stack.Count == 0) stack.Add(e);

                if (stack[stack.Count - 1] == ')' && e == '(')
                {
                    return false;

                }
                do
                {
                    Debug.Log("Enter");
                } while (true);
            }
            return false;
        }

        public static bool IsObjectNearby(Vector3 self, Vector3 obj, float maxDistance = 1)
        {
            return Vector3.Distance(self, obj) <= maxDistance;
        }
    }
}