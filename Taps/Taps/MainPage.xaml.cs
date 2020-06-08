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
		public MainPage()
        {
            InitializeComponent();

            GestureStatus status = default(GestureStatus);
            Point _loc = Point.Zero;
            Point loc = Point.Zero;
            bool tapped = true;

            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
                if (status == GestureStatus.Running)
                {
                    _loc = loc;
                    tapped = false;
                }                
            };
            frame.GestureRecognizers.Add(tap);

            var act = new PanGestureRecognizer();
            act.PanUpdated += (s, e) =>
            {
                log.Text = $"{(int)e.TotalX}:{(int)e.TotalY}({e.GestureId}:{e.StatusType.ToString()})";

                
                if (_loc != Point.Zero)
                {
                    loc = new Point(e.TotalX - _loc.X, e.TotalY - _loc.Y);
                }
                // 

                loc = new Point(e.TotalX, e.TotalY);
                AbsoluteLayout.SetLayoutBounds(box, new Rectangle(loc, box.Bounds.Size));

                // moveLog.Text = $"{(int)loc.X}:{(int)loc.Y}({(int)_loc.X}:{(int)_loc.Y})";

                status = e.StatusType;
            };
            frame.GestureRecognizers.Add(act);



            // PinchTest();

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
