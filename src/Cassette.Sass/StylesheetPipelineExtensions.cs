﻿using Cassette.BundleProcessing;

namespace Cassette.Stylesheets
{
    public static class StylesheetPipelineExtensions
    {
        public static T CompileSass<T>(this T pipeline)
            where T : IBundlePipeline<StylesheetBundle>
        {
            pipeline.InsertAfter<ParseCssReferences, StylesheetBundle>(
                new ParseSassReferences(),
                new CompileSass(new SassCompiler())
            );
            return pipeline;
        }
    }
}