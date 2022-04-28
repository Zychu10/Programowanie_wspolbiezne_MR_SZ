using Logic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;



namespace Model
{
    public class ModelLayer
    {
        public int numberOfBalls { get; set; }
        public bool isPaused { get; set; }
        public bool isReadyToBegin { get; set; }
        public Canvas Canvas { get; set; }

        private Canvas canvas;
        public ModelLayer(int width, int height, LogicAPI api = null)
        {
            logicAPI = api ?? LogicAPI.CreateLayer(width, height);
            ellipses = new List<Ellipse>();
            Canvas = new Canvas();
            Canvas.Width = 350;
            Canvas.Height = 600;
            Canvas.Background = null;
        }
    }
}