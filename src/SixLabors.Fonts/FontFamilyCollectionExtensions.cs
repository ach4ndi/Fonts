// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

namespace SixLabors.Fonts
{
    /// <summary>
    /// A readonly collection of fonts.
    /// </summary>
    public static class FontFamilyCollectionExtensions
    {
        /// <summary>
        /// Create a new instance of the <see cref="Font"/> for the named font family.
        /// </summary>
        /// <param name="fontFamily">The family.</param>
        /// <param name="size">The size of the font in PT units.</param>
        /// <param name="style">The style.</param>
        /// <returns>Returns instance of the <see cref="Font"/> from the current collection.</returns>
        public static Font CreateFont(this FontFamily fontFamily, float size, FontStyle style)
        {
            Guard.NotNull(fontFamily, nameof(fontFamily));

            return new Font(fontFamily, size, style);
        }

        /// <summary>
        /// Create a new instance of the <see cref="Font"/> for the named font family with regular styling.
        /// </summary>
        /// <param name="fontFamily">The family.</param>
        /// <param name="size">The size of the font in PT units.</param>
        /// <returns>Returns instance of the <see cref="Font"/> from the current collection.</returns>
        public static Font CreateFont(this FontFamily fontFamily, float size)
        {
            Guard.NotNull(fontFamily, nameof(fontFamily));

            return new Font(fontFamily, size);
        }
    }
}
