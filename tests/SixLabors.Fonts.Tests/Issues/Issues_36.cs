// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.Globalization;
using SixLabors.Fonts.Tests.Fakes;
using Xunit;

namespace SixLabors.Fonts.Tests.Issues
{
    public class Issues_36
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TextWidthFroTabOnlyTextSouldBeSingleTabWidthMultipliedByTabCount(int tabCount)
        {
            Font font = CreateFont("\t x");

            FontRectangle tabWidth = TextMeasurer.MeasureBounds("\t", new RendererOptions(font, font.FontMetrics.ScaleFactor));
            string tabString = string.Empty.PadRight(tabCount, '\t');
            FontRectangle tabCountWidth = TextMeasurer.MeasureBounds(tabString, new RendererOptions(font, font.FontMetrics.ScaleFactor));

            Assert.Equal(tabWidth.Width * tabCount, tabCountWidth.Width, 2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TextWidthFroTabOnlyTextSouldBeSingleTabWidthMultipliedByTabCountMinusX(int tabCount)
        {
            Font font = CreateFont("\t x");

            FontRectangle xWidth = TextMeasurer.MeasureBounds("x", new RendererOptions(font, font.FontMetrics.ScaleFactor));
            FontRectangle tabWidth = TextMeasurer.MeasureBounds("\tx", new RendererOptions(font, font.FontMetrics.ScaleFactor));
            string tabString = "x".PadLeft(tabCount + 1, '\t');
            FontRectangle tabCountWidth = TextMeasurer.MeasureBounds(tabString, new RendererOptions(font, font.FontMetrics.ScaleFactor));

            float singleTabWidth = tabWidth.Width - xWidth.Width;
            float finalTabWidth = tabCountWidth.Width - xWidth.Width;
            Assert.Equal(singleTabWidth * tabCount, finalTabWidth, 2);
        }

        public static Font CreateFont(string text)
        {
            var fc = new FontCollection();
            Font d = fc.Install(new FakeFontInstance(text), CultureInfo.InvariantCulture).CreateFont(12);
            return new Font(d, 1);
        }
    }
}
