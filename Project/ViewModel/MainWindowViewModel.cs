using Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
{

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractAPI ModelLayer;
        private int _BallVal;
        private bool isStartEnabled=false;
        private bool _isAddEnabled=true;
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

        private void CreateEllipses()
        {
            //ModelLayer.CreateEllipses(BallVal);
        }
        private void Stop()
        {

            ModelLayer.Stop();

        }

        public bool isRunEnabled
        {
            get { return isStartEnabled; }
            set
            {
                isStartEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool isAddEnabled
        {
            get
            {
                return _isAddEnabled;
            }
            set
            {
                _isAddEnabled = value;
                RaisePropertyChanged();
            }
        }

        private void AddBalls()
        {
            if (BallVal > 0)
            {
                isRunEnabled = true;
            }
            else
            {
                isRunEnabled = false;
            }
           // Balls = ModelLayer.Start(BallVal);
            //BallVal = 1;
        }



    }
}
