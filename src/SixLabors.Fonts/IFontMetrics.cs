// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.Numerics;
using SixLabors.Fonts.Unicode;

namespace SixLabors.Fonts
{
    /// <summary>
    /// Represents a font face with metrics, which is a set of glyphs with a specific style (regular, italic, bold etc).
    /// </summary>
    public interface IFontMetrics
    {
        /// <summary>
        /// Gets the basic descripton of the face.
        /// </summary>
        FontDescription Description { get; }

        /// <summary>
        /// Gets the number of font units per EM square for this face.
        /// </summary>
        ushort UnitsPerEm { get; }

        /// <summary>
        /// Gets the scale factor that is applied to all glyphs in this face.
        /// Calculated as 72 * <see cref="UnitsPerEm"/> so that 1pt = 1px.
        /// </summary>
        float ScaleFactor { get; }

        /// <summary>
        /// Gets the typographic ascender of the face, expressed in font units.
        /// </summary>
        short Ascender { get; }

        /// <summary>
        /// Gets the typographic descender of the face, expressed in font units.
        /// </summary>
        short Descender { get; }

        /// <summary>
        /// Gets the typographic line gap of the face, expressed in font units.
        /// This field should be combined with the <see cref="Ascender"/> and <see cref="Descender"/>
        /// values to determine default line spacing.
        /// </summary>
        short LineGap { get; }

        /// <summary>
        /// Gets the typographic line spacing of the face, expressed in font units.
        /// </summary>
        short LineHeight { get; }

        /// <summary>
        /// Gets the maximum advance width, in font units, for all glyphs in this face.
        /// </summary>
        short AdvanceWidthMax { get; }

        /// <summary>
        /// Gets the maximum advance height, in font units, for all glyphs in this
        /// face.This is only relevant for vertical layouts, and is set to <see cref="LineHeight"/> for
        /// fonts that do not provide vertical metrics.
        /// </summary>
        short AdvanceHeightMax { get; }

        /// <summary>
        /// Gets the glyph metrics for a given code point.
        /// </summary>
        /// <param name="codePoint">The Unicode code point to get the glyph for.</param>
        /// <returns>The glyph metrics to find.</returns>
        GlyphMetrics GetGlyphMetrics(CodePoint codePoint);

        /// <summary>
        /// Get the kerning offset that should be applied between 2 glyphs.
        /// </summary>
        /// <param name="glyph">The current glyph.</param>
        /// <param name="previousGlyph">The previous glyph in the rendered font.</param>
        /// <returns>The <see cref="Vector2"/> representing the offset between the 2 glyphs.</returns>
        Vector2 GetOffset(GlyphMetrics glyph, GlyphMetrics previousGlyph);
    }
}
