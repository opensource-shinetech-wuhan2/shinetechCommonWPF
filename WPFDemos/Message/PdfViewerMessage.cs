using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemos.Message
{
    public enum PdfCommandType
    {
        OpenFile,
        ZoomIn,
        ZoomOut,
        Normal,
        Fit,
        SinglePage,
        Facing
    }

    public class PdfViewerMessage
    {
        public PdfCommandType CommandType { get; set; }
    }
}
