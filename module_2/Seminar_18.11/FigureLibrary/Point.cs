﻿using System;

namespace FigureLibrary
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X = {X:F3}; Y = {Y:F3}";
        }
    }
}