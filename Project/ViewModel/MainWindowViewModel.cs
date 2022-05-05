﻿using Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
{

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractAPI ModelLayer;
        private int _BallVal;
        public ICommand AddCommand { get; set; }

        public MainWindowViewModel()
        {

            ModelLayer = ModelAbstractAPI.CreateApi(700, 400);
            StopCommand = new RelayCommand(Stop);
            AddCommand = new RelayCommand(CreateEllipses);

        }


        public ICommand StopCommand
        { get; set; }


        public int BallVal
        {
            get { return _BallVal; }
            set
            {
                _BallVal = value;
                RaisePropertyChanged();
            }
        }

        public Canvas Canvas
        {
            get => ModelLayer.Canvas;

        }

        private void CreateEllipses()
        {
            ModelLayer.CreateEllipses(BallVal);
        }
        private void Stop()
        {

            ModelLayer.Stop();

        }



    }
}