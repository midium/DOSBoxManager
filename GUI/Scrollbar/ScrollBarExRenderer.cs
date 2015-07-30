/*
 * DOSBox Manager : .NET front-end for DOSBox
 * Copyright (C) 2015 MiDiUm Software
 * 
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program.
 * If not, see <http://www.gnu.org/licenses/>.
 */
namespace GUI.Scrollbar
{
   using System;
   using System.Drawing;
   using System.Drawing.Drawing2D;
   using System.Drawing.Imaging;

   /// <summary>
   /// The scrollbar renderer class.
   /// </summary>
   internal static class ScrollBarExRenderer
   {
      #region fields

      /// <summary>
      /// The colors of the thumb in the 3 states.
      /// </summary>
      private static Color[,] thumbColors = new Color[3, 8];

      /// <summary>
      /// The arrow colors in the three states.
      /// </summary>
      private static Color[,] arrowColors = new Color[3, 8];

      /// <summary>
      /// The arrow border colors.
      /// </summary>
      private static Color[] arrowBorderColors = new Color[4];

      /// <summary>
      /// The background colors.
      /// </summary>
      private static Color[] backgroundColors = new Color[5];

      /// <summary>
      /// The track colors.
      /// </summary>
      private static Color[] trackColors = new Color[2];

      #endregion

      #region constructor

      /// <summary>
      /// Initializes static members of the <see cref="ScrollBarExRenderer"/> class.
      /// </summary>
      static ScrollBarExRenderer()
      {
         // hot state
          thumbColors[0, 0] = Color.FromArgb(64, 64, 64); // border color
          thumbColors[0, 1] = Color.FromArgb(64, 64, 64); // left/top start color
          thumbColors[0, 2] = Color.FromArgb(64, 64, 64); // left/top end color
          thumbColors[0, 3] = Color.FromArgb(64, 64, 64); // right/bottom line color
          thumbColors[0, 4] = Color.FromArgb(64, 64, 64); // right/bottom start color
          thumbColors[0, 5] = Color.FromArgb(64, 64, 64); // right/bottom end color
          thumbColors[0, 6] = Color.FromArgb(64, 64, 64); // right/bottom middle color
          thumbColors[0, 7] = Color.FromArgb(64, 64, 64); // left/top line color

         // over state
          thumbColors[1, 0] = Color.FromArgb(124, 124, 124); // border color
          thumbColors[1, 1] = Color.FromArgb(124, 124, 124); // left/top start color
          thumbColors[1, 2] = Color.FromArgb(124, 124, 124); // left/top end color
          thumbColors[1, 3] = Color.FromArgb(124, 124, 124); // right/bottom line color
          thumbColors[1, 4] = Color.FromArgb(124, 124, 124); // right/bottom start color
          thumbColors[1, 5] = Color.FromArgb(124, 124, 124); // right/bottom end color
          thumbColors[1, 6] = Color.FromArgb(124, 124, 124); // right/bottom middle color
          thumbColors[1, 7] = Color.FromArgb(124, 124, 124); // left/top line color

         // pressed state
          thumbColors[2, 0] = Color.Black; // border color
          thumbColors[2, 1] = Color.Black;  // left/top start color
          thumbColors[2, 2] = Color.Black;  // left/top end color
          thumbColors[2, 3] = Color.Black;  // right/bottom line color
          thumbColors[2, 4] = Color.Black;  // right/bottom start color
          thumbColors[2, 5] = Color.Black;  // right/bottom end color
          thumbColors[2, 6] = Color.Black;  // right/bottom middle color
          thumbColors[2, 7] = Color.Black;  // left/top line color

         /* picture of colors and indices
          *(0,0)
          * -----------------------------------------------
          * |                                             |
          * | |-----------------------------------------| |
          * | |                  (2)                    | |
          * | | |-------------------------------------| | |
          * | | |                (0)                  | | |
          * | | |                                     | | |
          * | | |                                     | | |
          * | |3|                (1)                  |3| |
          * | |6|                (4)                  |6| |
          * | | |                                     | | |
          * | | |                (5)                  | | |
          * | | |-------------------------------------| | |
          * | |                  (12)                   | |
          * | |-----------------------------------------| |
          * |                                             |
          * ----------------------------------------------- (15,17)
          */

         // hot state
          arrowColors[0, 0] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 1] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 2] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 3] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 4] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 5] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 6] = Color.FromArgb(64, 64, 64); 
          arrowColors[0, 7] = Color.FromArgb(64, 64, 64); 

         // over state
          arrowColors[1, 0] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 1] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 2] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 3] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 4] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 5] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 6] = Color.FromArgb(124, 124, 124);
          arrowColors[1, 7] = Color.FromArgb(124, 124, 124);

         // pressed state
          arrowColors[2, 0] = Color.Black;
          arrowColors[2, 1] = Color.Black;
          arrowColors[2, 2] = Color.Black;
          arrowColors[2, 3] = Color.Black;
          arrowColors[2, 4] = Color.Black;
          arrowColors[2, 5] = Color.Black;
          arrowColors[2, 6] = Color.Black;
          arrowColors[2, 7] = Color.Black;

         // background colors
         backgroundColors[0] = Color.FromArgb(50, 50, 50);
         backgroundColors[1] = Color.FromArgb(50, 50, 50);
         backgroundColors[2] = Color.FromArgb(50, 50, 50);
         backgroundColors[3] = Color.FromArgb(50, 50, 50);
         backgroundColors[4] = Color.FromArgb(50, 50, 50);

         // track colors
         trackColors[0] = Color.FromArgb(204, 204, 204);
         trackColors[1] = Color.FromArgb(220, 220, 220);

         // arrow border colors
         arrowBorderColors[0] = Color.Gray; 
         arrowBorderColors[1] = Color.Gray; 
         arrowBorderColors[2] = Color.Gray; 
         arrowBorderColors[3] = Color.Gray; 
      }

      #endregion

      #region methods

      #region public methods

      /// <summary>
      /// Draws the background.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="orientation">The <see cref="ScrollBarOrientation"/>.</param>
      public static void DrawBackground(
         Graphics g,
         Rectangle rect,
         ScrollBarOrientation orientation)
      {
         if (g == null)
         {
            throw new ArgumentNullException("g");
         }

         if (rect.IsEmpty || g.IsVisibleClipEmpty
            || !g.VisibleClipBounds.IntersectsWith(rect))
         {
            return;
         }

         if (orientation == ScrollBarOrientation.Vertical)
         {
            DrawBackgroundVertical(g, rect);
         }
         else
         {
            DrawBackgroundHorizontal(g, rect);
         }
      }

      /// <summary>
      /// Draws the channel ( or track ).
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The scrollbar state.</param>
      /// <param name="orientation">The <see cref="ScrollBarOrientation"/>.</param>
      public static void DrawTrack(
         Graphics g,
         Rectangle rect,
         ScrollBarState state,
         ScrollBarOrientation orientation)
      {
         if (g == null)
         {
            throw new ArgumentNullException("g");
         }

         if (rect.Width <= 0 || rect.Height <= 0
            || state != ScrollBarState.Pressed || g.IsVisibleClipEmpty
            || !g.VisibleClipBounds.IntersectsWith(rect))
         {
            return;
         }

         if (orientation == ScrollBarOrientation.Vertical)
         {
            DrawTrackVertical(g, rect);
         }
         else
         {
            DrawTrackHorizontal(g, rect);
         }
      }

      /// <summary>
      /// Draws the thumb.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The <see cref="ScrollBarState"/> of the thumb.</param>
      /// <param name="orientation">The <see cref="ScrollBarOrientation"/>.</param>
      public static void DrawThumb(
         Graphics g,
         Rectangle rect,
         ScrollBarState state,
         ScrollBarOrientation orientation)
      {
         if (g == null)
         {
            throw new ArgumentNullException("g");
         }

         if (rect.IsEmpty || g.IsVisibleClipEmpty
            || !g.VisibleClipBounds.IntersectsWith(rect)
            || state == ScrollBarState.Disabled)
         {
            return;
         }

         if (orientation == ScrollBarOrientation.Vertical)
         {
            DrawThumbVertical(g, rect, state);
         }
         else
         {
            DrawThumbHorizontal(g, rect, state);
         }
      }

      /// <summary>
      /// Draws the grip of the thumb.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="orientation">The <see cref="ScrollBarOrientation"/>.</param>
      public static void DrawThumbGrip(
         Graphics g,
         Rectangle rect,
         ScrollBarOrientation orientation)
      {
         if (g == null)
         {
            throw new ArgumentNullException("g");
         }

         if (rect.IsEmpty || g.IsVisibleClipEmpty
            || !g.VisibleClipBounds.IntersectsWith(rect))
         {
            return;
         }

         // get grip image
         using (Image gripImage = GUI.Properties.Resources.GripNormal)
         {
            // adjust rectangle and rotate grip image if necessary
            Rectangle r = AdjustThumbGrip(rect, orientation, gripImage);

            // adjust alpha channel of grip image
            using (ImageAttributes attr = new ImageAttributes())
            {
               attr.SetColorMatrix(
                  new ColorMatrix(new float[][] {
                  new[] { 1F, 0, 0, 0, 0 },
                  new[] { 0, 1F, 0, 0, 0 },
                  new[] { 0, 0, 1F, 0, 0 },
                  new[] { 0, 0, 0,  .8F, 0 },
                  new[] { 0, 0, 0, 0, 1F }
                  }),
                  ColorMatrixFlag.Default,
                  ColorAdjustType.Bitmap
               );

               // draw grip image
               g.DrawImage(gripImage, r, 0, 0, r.Width, r.Height, GraphicsUnit.Pixel, attr);
            }
         }
      }

      /// <summary>
      /// Draws an arrow button.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The <see cref="ScrollBarArrowButtonState"/> of the arrow button.</param>
      /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
      /// <param name="orientation">The <see cref="ScrollBarOrientation"/>.</param>
      public static void DrawArrowButton(
         Graphics g,
         Rectangle rect,
         ScrollBarArrowButtonState state,
         bool arrowUp,
         ScrollBarOrientation orientation)
      {
         if (g == null)
         {
            throw new ArgumentNullException("g");
         }

         if (rect.IsEmpty || g.IsVisibleClipEmpty
            || !g.VisibleClipBounds.IntersectsWith(rect))
         {
            return;
         }

         if (orientation == ScrollBarOrientation.Vertical)
         {
            DrawArrowButtonVertical(g, rect, state, arrowUp);
         }
         else
         {
            DrawArrowButtonHorizontal(g, rect, state, arrowUp);
         }
      }

      #endregion

      #region private methods

      /// <summary>
      /// Draws the background.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      private static void DrawBackgroundVertical(Graphics g, Rectangle rect)
      {
         using (Pen p = new Pen(backgroundColors[0]))
         {
            g.DrawLine(p, rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Bottom - 1);
            g.DrawLine(p, rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Bottom - 1);
         }

         using (Pen p = new Pen(backgroundColors[1]))
         {
            g.DrawLine(p, rect.Left + 2, rect.Top + 1, rect.Left + 2, rect.Bottom - 1);
         }

         Rectangle firstRect = new Rectangle(
            rect.Left + 3,
            rect.Top,
            8,
            rect.Height);

         Rectangle secondRect = new Rectangle(
            firstRect.Right - 1,
            firstRect.Top,
            7,
            firstRect.Height);

         using (LinearGradientBrush brush = new LinearGradientBrush(
            firstRect,
            backgroundColors[2],
            backgroundColors[3],
            LinearGradientMode.Horizontal))
         {
            g.FillRectangle(brush, firstRect);
         }

         using (LinearGradientBrush brush = new LinearGradientBrush(
            secondRect,
            backgroundColors[3],
            backgroundColors[4],
            LinearGradientMode.Horizontal))
         {
            g.FillRectangle(brush, secondRect);
         }
      }

      /// <summary>
      /// Draws the background.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      private static void DrawBackgroundHorizontal(Graphics g, Rectangle rect)
      {
         using (Pen p = new Pen(backgroundColors[0]))
         {
            g.DrawLine(p, rect.Left + 1, rect.Top + 1, rect.Right - 1, rect.Top + 1);
            g.DrawLine(p, rect.Left + 1, rect.Bottom - 2, rect.Right - 1, rect.Bottom - 2);
         }

         using (Pen p = new Pen(backgroundColors[1]))
         {
            g.DrawLine(p, rect.Left + 1, rect.Top + 2, rect.Right - 1, rect.Top + 2);
         }

         Rectangle firstRect = new Rectangle(
            rect.Left,
            rect.Top + 3,
            rect.Width,
            8);

         Rectangle secondRect = new Rectangle(
            firstRect.Left,
            firstRect.Bottom - 1,
            firstRect.Width,
            7);

         using (LinearGradientBrush brush = new LinearGradientBrush(
            firstRect,
            backgroundColors[2],
            backgroundColors[3],
            LinearGradientMode.Vertical))
         {
             g.FillRectangle(brush, firstRect);
         }

         using (LinearGradientBrush brush = new LinearGradientBrush(
            secondRect,
            backgroundColors[3],
            backgroundColors[4],
            LinearGradientMode.Vertical))
         {
            g.FillRectangle(brush, secondRect);
         }
      }

      /// <summary>
      /// Draws the channel ( or track ).
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      private static void DrawTrackVertical(Graphics g, Rectangle rect)
      {
         Rectangle innerRect = new Rectangle(rect.Left + 1, rect.Top, 15, rect.Height);

         using (LinearGradientBrush brush = new LinearGradientBrush(
            innerRect,
            trackColors[0],
            trackColors[1],
            LinearGradientMode.Horizontal))
         {
            g.FillRectangle(brush, innerRect);
         }
      }

      /// <summary>
      /// Draws the channel ( or track ).
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      private static void DrawTrackHorizontal(Graphics g, Rectangle rect)
      {
         Rectangle innerRect = new Rectangle(rect.Left, rect.Top + 1, rect.Width, 15);

         using (LinearGradientBrush brush = new LinearGradientBrush(
            innerRect,
            trackColors[0],
            trackColors[1],
            LinearGradientMode.Vertical))
         {
            g.FillRectangle(brush, innerRect);
         }
      }

      /// <summary>
      /// Adjusts the thumb grip according to the specified <see cref="ScrollBarOrientation"/>.
      /// </summary>
      /// <param name="rect">The rectangle to adjust.</param>
      /// <param name="orientation">The scrollbar orientation.</param>
      /// <param name="gripImage">The grip image.</param>
      /// <returns>The adjusted rectangle.</returns>
      /// <remarks>Also rotates the grip image if necessary.</remarks>
      private static Rectangle AdjustThumbGrip(
         Rectangle rect,
         ScrollBarOrientation orientation,
         Image gripImage)
      {
         Rectangle r = rect;

         r.Inflate(-1, -1);

         if (orientation == ScrollBarOrientation.Vertical)
         {
            r.X += 3;
            r.Y += (r.Height / 2) - (gripImage.Height / 2);
         }
         else
         {
            gripImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            r.X += (r.Width / 2) - (gripImage.Width / 2);
            r.Y += 3;
         }

         r.Width = gripImage.Width;
         r.Height = gripImage.Height;

         return r;
      }

      /// <summary>
      /// Draws the thumb.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The <see cref="ScrollBarState"/> of the thumb.</param>
      private static void DrawThumbVertical(
         Graphics g,
         Rectangle rect,
         ScrollBarState state)
      {
         int index = 0;

         switch (state)
         {
            case ScrollBarState.Hot:
               {
                  index = 1;
                  break;
               }

            case ScrollBarState.Pressed:
               {
                  index = 2;
                  break;
               }
         }

         Rectangle innerRect = rect;
         innerRect.Inflate(-1, -1);

         Rectangle r = innerRect;
         r.Width = 8;
         r.Height++;

         // draw left gradient
         using (LinearGradientBrush brush = new LinearGradientBrush(
            r,
            thumbColors[index, 1],
            thumbColors[index, 2],
            LinearGradientMode.Horizontal))
         {
            g.FillRectangle(brush, r);
         }

         r.X = r.Right;

         // draw right gradient
         if (index == 0)
         {
            using (LinearGradientBrush brush = new LinearGradientBrush(
               r,
               thumbColors[index, 4],
               thumbColors[index, 5],
               LinearGradientMode.Horizontal))
            {
               brush.InterpolationColors = new ColorBlend(3)
               {
                  Colors = new[]
                            {
                               thumbColors[index, 4],
                               thumbColors[index, 6],
                               thumbColors[index, 5]
                            },
                  Positions = new[] { 0f, .5f, 1f }
               };

               g.FillRectangle(brush, r);
            }
         }
         else
         {
            using (LinearGradientBrush brush = new LinearGradientBrush(
               r,
               thumbColors[index, 4],
               thumbColors[index, 5],
               LinearGradientMode.Horizontal))
            {
               g.FillRectangle(brush, r);
            }

            // draw left line
            using (Pen p = new Pen(thumbColors[index, 7]))
            {
               g.DrawLine(p, innerRect.X, innerRect.Y, innerRect.X, innerRect.Bottom);
            }
         }

         // draw right line
         using (Pen p = new Pen(thumbColors[index, 3]))
         {
            g.DrawLine(p, innerRect.Right, innerRect.Y, innerRect.Right, innerRect.Bottom);
         }

         g.SmoothingMode = SmoothingMode.AntiAlias;

         // draw border
         using (Pen p = new Pen(thumbColors[index, 0]))
         {
            using (GraphicsPath path = CreateRoundPath(rect, 2f, 2f))
            {
               g.DrawPath(p, path);
            }
         }

         g.SmoothingMode = SmoothingMode.None;
      }

      /// <summary>
      /// Draws the thumb.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The <see cref="ScrollBarState"/> of the thumb.</param>
      private static void DrawThumbHorizontal(
         Graphics g,
         Rectangle rect,
         ScrollBarState state)
      {
         int index = 0;

         switch (state)
         {
            case ScrollBarState.Hot:
               {
                  index = 1;
                  break;
               }

            case ScrollBarState.Pressed:
               {
                  index = 2;
                  break;
               }
         }

         Rectangle innerRect = rect;
         innerRect.Inflate(-1, -1);

         Rectangle r = innerRect;
         r.Height = 8;
         r.Width++;

         // draw left gradient
         using (LinearGradientBrush brush = new LinearGradientBrush(
            r, thumbColors[index, 1],
            thumbColors[index, 2],
            LinearGradientMode.Vertical))
         {
            g.FillRectangle(brush, r);
         }

         r.Y = r.Bottom;

         // draw right gradient
         if (index == 0)
         {
             using (LinearGradientBrush brush = new LinearGradientBrush(
                r,
                thumbColors[index, 4],
                thumbColors[index, 5],
                LinearGradientMode.Vertical))
             {
                 brush.InterpolationColors = new ColorBlend(3)
                 {
                     Colors = new[]
                            {
                               thumbColors[index, 4],
                               thumbColors[index, 6],
                               thumbColors[index, 5]
                            },
                     Positions = new[] { 0f, .5f, 1f }
                 };

                 g.FillRectangle(brush, r);
             }
         }
         else
         {
            using (LinearGradientBrush brush = new LinearGradientBrush(
               r, thumbColors[index, 4],
               thumbColors[index, 5],
               LinearGradientMode.Vertical))
            {
               g.FillRectangle(brush, r);
            }

            // draw left line
            using (Pen p = new Pen(thumbColors[index, 7]))
            {
               g.DrawLine(p, innerRect.X, innerRect.Y, innerRect.Right, innerRect.Y);
            }
         }

         // draw right line
         using (Pen p = new Pen(thumbColors[index, 3]))
         {
            g.DrawLine(p, innerRect.X, innerRect.Bottom, innerRect.Right, innerRect.Bottom);
         }

         g.SmoothingMode = SmoothingMode.AntiAlias;

         // draw border
         using (Pen p = new Pen(thumbColors[index, 0]))
         {
            using (GraphicsPath path = CreateRoundPath(rect, 2f, 2f))
            {
               g.DrawPath(p, path);
            }
         }

         g.SmoothingMode = SmoothingMode.None;
      }

      /// <summary>
      /// Draws an arrow button.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The <see cref="ScrollBarArrowButtonState"/> of the arrow button.</param>
      /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
      private static void DrawArrowButtonVertical(
         Graphics g,
         Rectangle rect,
         ScrollBarArrowButtonState state,
         bool arrowUp)
      {
         using (Image arrowImage = GetArrowDownButtonImage(state))
         {
            if (arrowUp)
            {
               arrowImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            g.DrawImage(arrowImage, rect);
         }
      }

      /// <summary>
      /// Draws an arrow button.
      /// </summary>
      /// <param name="g">The <see cref="Graphics"/> used to paint.</param>
      /// <param name="rect">The rectangle in which to paint.</param>
      /// <param name="state">The <see cref="ScrollBarArrowButtonState"/> of the arrow button.</param>
      /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
      private static void DrawArrowButtonHorizontal(
         Graphics g,
         Rectangle rect,
         ScrollBarArrowButtonState state,
         bool arrowUp)
      {
         using (Image arrowImage = GetArrowDownButtonImage(state))
         {
            if (arrowUp)
            {
               arrowImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
               arrowImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            g.DrawImage(arrowImage, rect);
         }
      }

      /// <summary>
      /// Draws the arrow down button for the scrollbar.
      /// </summary>
      /// <param name="state">The button state.</param>
      /// <returns>The arrow down button as <see cref="Image"/>.</returns>
      private static Image GetArrowDownButtonImage(
         ScrollBarArrowButtonState state)
      {
         Rectangle rect = new Rectangle(0, 0, 15, 17);
         Bitmap bitmap = new Bitmap(15, 17, PixelFormat.Format32bppArgb);
         bitmap.SetResolution(72f, 72f);

         using (Graphics g = Graphics.FromImage(bitmap))
         {
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.Low;

            int index = -1;

            switch (state)
            {
               case ScrollBarArrowButtonState.UpHot:
               case ScrollBarArrowButtonState.DownHot:
                  {
                     index = 1;

                     break;
                  }

               case ScrollBarArrowButtonState.UpActive:
               case ScrollBarArrowButtonState.DownActive:
                  {
                     index = 0;

                     break;
                  }

               case ScrollBarArrowButtonState.UpPressed:
               case ScrollBarArrowButtonState.DownPressed:
                  {
                     index = 2;

                     break;
                  }
            }

            if (index != -1)
            {
               using (Pen p1 = new Pen(arrowBorderColors[0]),
                  p2 = new Pen(arrowBorderColors[1]))
               {
                  g.DrawLine(p1, rect.X, rect.Y, rect.Right - 1, rect.Y);
                  g.DrawLine(p2, rect.X, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
               }

               rect.Inflate(0, -1);

               using (LinearGradientBrush brush = new LinearGradientBrush(
                  rect,
                  arrowBorderColors[2],
                  arrowBorderColors[1],
                  LinearGradientMode.Vertical))
               {
                  ColorBlend blend = new ColorBlend(3)
                  {
                     Positions = new[] { 0f, .5f, 1f },
                     Colors = new[] {
                     arrowBorderColors[2],
                     arrowBorderColors[3],
                     arrowBorderColors[0] }
                  };

                  brush.InterpolationColors = blend;

                  using (Pen p = new Pen(brush))
                  {
                     g.DrawLine(p, rect.X, rect.Y, rect.X, rect.Bottom - 1);
                     g.DrawLine(p, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
                  }
               }

               rect.Inflate(0, 1);

               Rectangle upper = rect;
               upper.Inflate(-1, 0);
               upper.Y++;
               upper.Height = 7;

               using (LinearGradientBrush brush = new LinearGradientBrush(
                  upper,
                  arrowColors[index, 2],
                  arrowColors[index, 3],
                  LinearGradientMode.Vertical))
               {
                  g.FillRectangle(brush, upper);
               }

               upper.Inflate(-1, 0);
               upper.Height = 6;

               using (LinearGradientBrush brush = new LinearGradientBrush(
                  upper,
                  arrowColors[index, 0],
                  arrowColors[index, 1],
                  LinearGradientMode.Vertical))
               {
                  g.FillRectangle(brush, upper);
               }

               Rectangle lower = rect;
               lower.Inflate(-1, 0);
               lower.Y = 8;
               lower.Height = 8;

               using (LinearGradientBrush brush = new LinearGradientBrush(
                  lower,
                  arrowColors[index, 6],
                  arrowColors[index, 7],
                  LinearGradientMode.Vertical))
               {
                  g.FillRectangle(brush, lower);
               }

               lower.Inflate(-1, 0);

               using (LinearGradientBrush brush = new LinearGradientBrush(
                  lower,
                  arrowColors[index, 4],
                  arrowColors[index, 5],
                  LinearGradientMode.Vertical))
               {
                  g.FillRectangle(brush, lower);
               }
            }

            using (Image arrowIcon = GUI.Properties.Resources.ScrollBarArrowDown)
            {
               if (state == ScrollBarArrowButtonState.DownDisabled
                  || state == ScrollBarArrowButtonState.UpDisabled)
               {
                  System.Windows.Forms.ControlPaint.DrawImageDisabled(
                     g,
                     arrowIcon,
                     3,
                     6,
                     Color.Transparent);
               }
               else
               {
                  g.DrawImage(arrowIcon, 3, 6);
               }
            }
         }

         return bitmap;
      }

      /// <summary>
      /// Creates a rounded rectangle.
      /// </summary>
      /// <param name="r">The rectangle to create the rounded rectangle from.</param>
      /// <param name="radiusX">The x-radius.</param>
      /// <param name="radiusY">The y-radius.</param>
      /// <returns>A <see cref="GraphicsPath"/> object representing the rounded rectangle.</returns>
      private static GraphicsPath CreateRoundPath(
         Rectangle r,
         float radiusX,
         float radiusY)
      {
         // create new graphics path object
         GraphicsPath path = new GraphicsPath();

         // calculate radius of edges
         PointF d = new PointF(Math.Min(radiusX * 2, r.Width), Math.Min(radiusY * 2, r.Height));

         // make sure radius is valid
         d.X = Math.Max(1, d.X);
         d.Y = Math.Max(1, d.Y);

         // add top left arc
         path.AddArc(r.X, r.Y, d.X, d.Y, 180, 90);

         // add top right arc
         path.AddArc(r.Right - d.X, r.Y, d.X, d.Y, 270, 90);

         // add bottom right arc
         path.AddArc(r.Right - d.X, r.Bottom - d.Y, d.X, d.Y, 0, 90);

         // add bottom left arc
         path.AddArc(r.X, r.Bottom - d.Y, d.X, d.Y, 90, 90);

         // close path
         path.CloseFigure();

         return path;
      }

      #endregion

      #endregion
   }
}
