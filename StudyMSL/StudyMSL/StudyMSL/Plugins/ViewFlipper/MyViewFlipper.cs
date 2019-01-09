using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudyMSL.Plugins.ViewFlipper
{
    public class MyViewFlipper : ContentView
    {
        /// BindableProperty for <c>FrontView</c>
        public static readonly BindableProperty FrontViewProperty =
            BindableProperty.Create<MyViewFlipper, View>(p => p.FrontView, default(View), propertyChanged: FrontViewChanged);

        /// BindableProperty for <c>BackView</c>
        public static readonly BindableProperty BackViewProperty =
            BindableProperty.Create<MyViewFlipper, View>(p => p.BackView, default(View), propertyChanged: BackViewChanged);

        /// Gets/Sets the front view
        public View FrontView
        {
            get { return (View)this.GetValue(FrontViewProperty); }
            set { this.SetValue(FrontViewProperty, value); }
        }

        /// Gets/Sets the back view
        public View BackView
        {
            get { return (View)this.GetValue(BackViewProperty); }
            set { this.SetValue(BackViewProperty, value); }
        }

        /// When the <c>FrontView</c> changed
        private static void FrontViewChanged(BindableObject obj, View oldValue, View newValue)
        {
            MyViewFlipper myviewflipper = obj as MyViewFlipper;
            if (myviewflipper == null) return;

            if (oldValue == null)
                myviewflipper.Content = newValue;
        }

        /// When the <c>BackView</c> changed
        private static void BackViewChanged(BindableObject obj, View oldValue, View newValue)
        {
            MyViewFlipper myviewflipper = obj as MyViewFlipper;
            if (myviewflipper == null || newValue == null) return;

            myviewflipper.SetBackviewRotation();

        }



        /// BindableProperty for <c>FlipOnTap</c>
        public static readonly BindableProperty FlipOnTapProperty =
            BindableProperty.Create<MyViewFlipper, bool>(p => p.FlipOnTap, true);

        /// BindableProperty for <c>FlipState</c>
        public static readonly BindableProperty FlipStateProperty =
            BindableProperty.Create<MyViewFlipper, FlipState>(p => p.FlipState, FlipState.Front, BindingMode.TwoWay, propertyChanged: FlipStateChanged);

        /// BindableProperty for <c>RotationDirection</c>
        public static readonly BindableProperty RotationDirectionProperty =
            BindableProperty.Create<MyViewFlipper, RotationDirection>(p => p.RotationDirection, RotationDirection.Horizontal);

        /// BindableProperty for <c>AnimationDuration</c>
        public static readonly BindableProperty AnimationDurationProperty =
            BindableProperty.Create<MyViewFlipper, int>(p => p.AnimationDuration, 250);

        /// Gets/Sets if a flip will be perfomed when tapping anywhere inside the <c>ViewFlipper</c>
        public bool FlipOnTap
        {
            get { return (bool)this.GetValue(FlipOnTapProperty); }
            set { this.SetValue(FlipOnTapProperty, value); }
        }

        /// Gets/Sets the current state of the <c>ViewFlipper</c>. This toggles the animation when changed
        public FlipState FlipState
        {
            get { return (FlipState)this.GetValue(FlipStateProperty); }
            set { this.SetValue(FlipStateProperty, value); }
        }

        /// Gets/Sets the duration of the flip animation
        public int AnimationDuration
        {
            get { return (int)this.GetValue(AnimationDurationProperty); }
            set { this.SetValue(AnimationDurationProperty, value); }
        }

        /// Gets/Sets if the flip will be in horizontal or vertical direction
        public RotationDirection RotationDirection
        {
            get { return (RotationDirection)this.GetValue(RotationDirectionProperty); }
            set { this.SetValue(RotationDirectionProperty, value); }
        }

        /// Performs the flip
        private async void Flip()
        {
            var animationDuration = (uint)Math.Round((double)this.AnimationDuration / 4);

            if (this.FlipState == FlipState.Front)
            {
                // Perform half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(90, animationDuration);
                else
                    await this.RotateXTo(90, animationDuration);

                // Change the visible content
                this.Content = this.FrontView;

                // Perform second half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(0, animationDuration);
                else
                    await this.RotateXTo(0, animationDuration);
            }
            else
            {
                // Perform half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(90, animationDuration);
                else
                    await this.RotateXTo(90, animationDuration);

                // Change the visible content
                this.Content = this.BackView;

                // Perform second half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(180, animationDuration);
                else
                    await this.RotateXTo(180, animationDuration);
            }
        }

        /// Sets the rotation on the back view
        private void SetBackviewRotation()
        {
            if (this.RotationDirection == RotationDirection.Horizontal)
            {
                this.BackView.RotationX = 0;
                this.BackView.RotationY = 180;
            }
            else
            {
                this.BackView.RotationY = 0;
                this.BackView.RotationX = 180;
            }
        }

        /*Self Implemented*/
        // Flipping without animations
        public void swap(int val)
        {
            if (val == 1)
            {
                this.Content = FrontView;
            }
            else
            {
                this.Content = BackView;
            }
        }

        /// When the <c>ViewFlipper</c> gets tapped
        public void OnTapped(int val)
        {
            //if (!this.FlipOnTap) return;
            if (val == 1)
            {
                this.FlipState = FlipState.Back;
            }
            else
            {
                this.FlipState = FlipState.Front;
            }
        }

        /*Not Implemented due to errors*/
        /// When the <c>ViewFlipper</c> gets tapped
        private void OnTapped()
        {
            //if (!this.FlipOnTap) return;

            this.FlipState = this.FlipState == FlipState.Front ?
                FlipState.Back :
                FlipState.Front;
        }

        /// When the <c>FlipState</c> changed
        private static void FlipStateChanged(BindableObject obj, FlipState oldValue, FlipState newValue)
        {
            MyViewFlipper flipper = obj as MyViewFlipper;
            if (flipper == null) return;

            flipper.Flip();
        }

        /// When the <c>RotationDirection</c> changed
        private static void RotationDirectionChanged(BindableObject obj, RotationDirection oldValue, RotationDirection newValue)
        {
            MyViewFlipper flipper = obj as MyViewFlipper;
            if (flipper == null || flipper.BackView == null) return;

            flipper.SetBackviewRotation();
        }


        /// Creates a new instance of <c>ViewFlipper</c>
        public MyViewFlipper()
        {
            //this.GestureRecognizers.Add(
            //    new TapGestureRecognizer
            //    {
            //        Command = new Command(this.OnTapped)
            //    });
        }
    }



    /// State of the <c>ViewFlipper</c>
    public enum FlipState
    {
        /// The front view is currently visible
        Front,

        /// The back view is currently visible
        Back
    }

    /// The direction of the flip animation
    public enum RotationDirection
    {
        /// Flip horizontal around the Y axis
        Horizontal,

        /// Flip vertical around the X axis
        Vertical
    }
}

