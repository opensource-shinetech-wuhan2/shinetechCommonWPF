using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFDemos.CustomControl
{
    public class CustomDemo :StackPanel
    {
        //link with
        public TextBox LinkWith
        {
            get => (TextBox)GetValue(LinkWithProperty);
            set => SetValue(LinkWithProperty,value);
        }

        public static readonly DependencyProperty LinkWithProperty =
            DependencyProperty.RegisterAttached(
                nameof(LinkWith),
                typeof(TextBox),
                typeof(CustomDemo),
                new UIPropertyMetadata(null,LinkWithChanged));

        private static void LinkWithChanged (DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            if(!(d is CustomDemo control)) return;

            control.DrawSelf();
        }

        TextBlock textBlock;
        //draw itself
        private void DrawSelf ()
        {
            textBlock = new TextBlock();
            textBlock.Text = LinkWith.Text + ":";
            textBlock.Height = LinkWith.Height;
            textBlock.Width = LinkWith.Width;
            Children.Add(textBlock);

            LinkWith.TextChanged += LinkWith_TextChanged;
        }

        private void LinkWith_TextChanged (object sender,TextChangedEventArgs e)
        {
            var txt = (TextBox)e.Source;
            textBlock.Text = txt.Text;
        }
    }
}
