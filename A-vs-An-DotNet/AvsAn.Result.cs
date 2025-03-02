﻿//by Eamon Nerbonne (from https://eamonnerbonne.github.io/a-vs-an/), Apache 2.0 license.

using System;
using System.ComponentModel;
using AvsAnLib.Internals;

namespace AvsAnLib {
    public static partial class AvsAn {
        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedMember.Global
        //part of public nuget api, usages may be in external code.
        public readonly struct Result {
            readonly Ratio ratio;
#pragma warning disable IDE1006 // Naming Styles

            /// <summary>
            /// How often this prefix was preceded by "a" on wikipedia.
            /// </summary>
            public int aCount => ratio.aCount;

            /// <summary>
            /// How often this prefix was preceded by "an" on wikipedia.
            /// </summary>
            public int anCount => ratio.anCount;

            /// <summary>
            /// How often this prefix occurred on wikipedia.  Equivalent to aCount+anCount
            /// </summary>
            public int Occurrence => ratio.Occurrence;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("This is a typo, use Occurrence")]
            public int Occurence => Occurrence;

            /// <summary>
            /// How many more "a"s occurred before this prefix than "an"s.
            /// </summary>
            public int AminAnDiff => ratio.AminAnDiff;

            /// <summary>
            /// The prefix of the word on which the determination was based.
            /// </summary>
            public string Prefix
                => Depth > Word.Length
                    ? Word + new string(' ', Depth - Word.Length)
                    : Word.Substring(0, Depth);

            /// <summary>
            /// The tested word.
            /// </summary>
            public readonly string Word;

            /// <summary>
            /// How many letters of the tested word were used in determining the appropriate article.
            /// </summary>
            public readonly int Depth;

            /// <summary>
            /// The article you should use.
            /// </summary>
            public string Article => ratio.AminAnDiff >= 0 ? "a" : "an";

            public Result(Ratio ratio, string word, int depth) {
                Word = word;
                Depth = depth;
                this.ratio = ratio;
            }
        }
        // ReSharper restore UnusedMember.Global
        // ReSharper restore MemberCanBePrivate.Global
    }
}
