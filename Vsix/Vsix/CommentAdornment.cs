//***************************************************************************
//
//    Copyright (c) Microsoft Corporation. All rights reserved.
//    This code is licensed under the Visual Studio SDK license terms.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//***************************************************************************

using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IntraTextAdornmentSample
{
    internal sealed class CommentAdornment : Button
    {
        private readonly Action _onClick;
        private readonly Rectangle _rect;

        internal CommentAdornment(CommentTag commentTag,Action onClick)
        {
            _onClick = onClick;
            _rect = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Width = 20,
                Height = 10 
            };

            Update(commentTag);
            Content = _rect;
        }

        private Brush MakeBrush(Color color)
        {
            var brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }

        protected override void OnClick()
        {
            _onClick();
        }

        internal void Update(CommentTag commentTag)
        {
            _rect.Fill = MakeBrush(Colors.SeaGreen  );
            _rect.Width = commentTag.Content.Length * 12;
        }
    }
}
