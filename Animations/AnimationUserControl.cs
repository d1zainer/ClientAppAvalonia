using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Styling;
using Avalonia;
using System.Threading.Tasks;
using System;
using Avalonia.Animation.Easings;
using Avalonia.Media;

public static class AnimationUserControl
{
    public static async Task AnimateVisibility(UserControl control, bool isVisible)
    {
        if (isVisible)
        {
            var moveAnimation = new Animation
            {
                Duration = TimeSpan.FromMilliseconds(1000),
                Easing = new QuinticEaseInOut(),
                Children =
                {
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter(TranslateTransform.XProperty, -200.0)
                        },
                        Cue = new Cue(0.0)
                    },
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter(TranslateTransform.XProperty, 0.0)
                        },
                        Cue = new Cue(1.0)
                    }
                }
            };

            var fadeInAnimation = new Animation
            {
                Duration = TimeSpan.FromMilliseconds(1500),

                Children =
                {
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter(Visual.OpacityProperty, 0.0)
                        },
                        Cue = new Cue(0.0)
                    },
   
                    new KeyFrame
                    {
                        Setters =
                        {
                            new Setter(Visual.OpacityProperty, 1.0)
                        },
                        Cue = new Cue(1.0)
                    }
                }
            };

            await Task.WhenAll(
                 moveAnimation.RunAsync(control),
                fadeInAnimation.RunAsync(control)
            );


        }
    }
}
