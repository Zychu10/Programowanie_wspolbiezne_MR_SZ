using Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract int width { get; }
        public abstract int height { get; }
        public abstract void Stop();


        public static ModelAbstractAPI CreateApi(int Weight, int Height)
        {
            return new ModelApi(Weight, Height);
        }
    }
    internal class ModelApi : ModelAbstractAPI
    {
        public override int width { get; }
        public override int height { get; }

        private LogicAbstractAPI LogicLayer;
        public ModelApi(int Width, int Height)
        {

            width = Width;
            height = Height;
            LogicLayer = LogicAbstractAPI.CreateApi(width, height);
          
        }
    


        public override void Stop()
        {
            LogicLayer.Stop();
        }
    }
}
