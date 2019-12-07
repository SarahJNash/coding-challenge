using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.

        }


        public SearchResults Search(SearchOptions options)
        {
            var shirts = _shirts.Where((s) => options.Colors.Contains(s.Color) && options.Sizes.Contains(s.Size)).ToList();

            var colorCounts = new List<ColorCount>();

            foreach (var color in Color.All)
            {
                colorCounts.Add(new ColorCount { Color = color, Count = shirts.Count((s) => s.Color == color) });
            }

            var sizeCounts = new List<SizeCount>();

            foreach (var size in Size.All)
            {
                sizeCounts.Add(new SizeCount { Size = size, Count = shirts.Count((s) => s.Size == size) });
            }

            return new SearchResults
            {
                Shirts = shirts,
                ColorCounts = colorCounts,
                SizeCounts = sizeCounts
            };
        }
    }
}