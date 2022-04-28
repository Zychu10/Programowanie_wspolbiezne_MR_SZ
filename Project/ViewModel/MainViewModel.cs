using Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;


namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ModelLayer CollisionModel { get; set; }
        public ObservableCollection<BallModel> Balls { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int BallsCount { get; set; } = 10;
        public ICommand AddBallsCommand { get; set; }

        public MainViewModel() : this(default)
        {
        }
        public MainViewModel(ModelLayer collisionModel = default)
        {
            CollisionModel = collisionModel ?? new ModelLayer();
            //Balls = new ObservableCollection<BallModel>();
            //Balls.CollectionChanged += CollectionChangedHandler;
            AddBallsCommand = new RelayCommand(() => RequestBall());
            Balls = new ObservableCollection<BallModel>();
            CollisionModel.Observable.Add(Framer);
            Width = CollisionModel.Width;
            Height = CollisionModel.Height;
        }

        private void RequestBall()
        {
            CollisionModel.GiveBalls(BallsCount);
        }

        private void Framer(IEnumerable<BallModel> ballModels)
        {
            Balls = new ObservableCollection<BallModel>(ballModels);
            RaisePropertyChanged(nameof(Balls));
        }

    }

}