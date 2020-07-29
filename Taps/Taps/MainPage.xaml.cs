using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taps
{
	public partial class MainPage : ContentPage
	{
        Point _loc;
        bool init = false;

        public MainPage()
        {
            
            InitializeComponent();

            PanTest();
            // PinchTest();

        }


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            
        }

        private void PanTest()
        {            
            
            Point loc = Point.Zero;            


            var act = new PanGestureRecognizer();

            act.PanUpdated += (s, e) =>
            {
                if (init == false)
                {
                    _loc = box.Bounds.Location; init = true;
                }

                log.Text = $"{(int)e.TotalX}:{(int)e.TotalY}({e.GestureId}:{e.StatusType.ToString()})"; // moveLog.Text = $"{(int)loc.X}:{(int)loc.Y}({(int)_loc.X}:{(int)_loc.Y})";                

                if (e.StatusType != GestureStatus.Completed)
                {
                    loc = new Point(e.TotalX + _loc.X, e.TotalY + _loc.Y);
                }
                else loc = _loc;

                AbsoluteLayout.SetLayoutBounds(box, new Rectangle(loc, box.Bounds.Size));                
                
            };
            frame.GestureRecognizers.Add(act);
        }

        private void PinchTest()
        {
            var ract = new PinchGestureRecognizer();
            ract.PinchUpdated += (s, e) =>
            {
                log.Text = $"{e.Scale}";
            };
            back.GestureRecognizers.Add(ract);



            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
                
            };
            back.GestureRecognizers.Add(tap);
        }
    }
}
