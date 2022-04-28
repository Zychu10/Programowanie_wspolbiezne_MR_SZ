using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using Model;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //private readonly ModelLayer modelLayer = ModelLayer.CreateApi();
        public bool isReadyToBegin { get => MyModel.isReadyToBegin; set { MyModel.isReadyToBegin = value; RaisePropertyChanged(); } }
        public bool isPaused { get => MyModel.isPaused; set { MyModel.isPaused = value; RaisePropertyChanged(); } }
        public string boxContent;
        public Canvas Canvas { get => MyModel.Canvas; set { MyModel.Canvas = value; RaisePropertyChanged(); } }
        public int numberOfBalls { get => MyModel.numberOfBalls; set => MyModel.numberOfBalls = value; }
        private ModelLayer MyModel { get; set; }



        public MainViewModel()
        {
            MyModel = new ModelLayer(350,600);
            AddBalls = new RelayCommand(MyModel.CreateBalls);
            BeginSimulation = new RelayCommand(Start);
            PauseSimulation = new RelayCommand(Stop);
            isReadyToBegin = true;
            isPaused = false;
        }
        public RelayCommand AddBalls { get; set; }
        public ICommand BeginSimulation { get; set; }
        public ICommand PauseSimulation { get; set; }
        public void Start()
        {
            MyModel.Start();
            isPaused = false;
            isReadyToBegin = true;
        }
        public void Stop()
        {
            MyModel.Stop();
            isPaused = true;
            isReadyToBegin = true;
        }

        private void CreateBalls()
        {
            MyModel.CreateBalls();
            isReadyToBegin = true;

        }
        public void SetCanvas(Canvas canvas)
        {
            MyModel.Canvas = canvas;
        }

    }
}