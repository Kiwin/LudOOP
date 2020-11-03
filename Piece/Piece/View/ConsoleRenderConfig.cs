using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    public class ConsoleRenderConfig
    {
        public ConsoleRenderConfig(int rowOffset = 0, int columnOffset = 0, int rowSpacing = 0, int columnSpacing = 0, int rowScale = 1, int columnScale = 1)
        {
            RowOffset = rowOffset;
            ColumnOffset = columnOffset;
            RowSpacing = rowSpacing;
            ColumnSpacing = columnSpacing;
            RowScale = rowScale;
            ColumnScale = columnScale;
        }

        public int RowOffset, ColumnOffset;
        public int RowSpacing, ColumnSpacing;
        public int RowScale, ColumnScale;

    }
}
