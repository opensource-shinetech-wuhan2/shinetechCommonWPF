using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Message;

namespace WPFDemos.ViewModel
{
    public class PdfViewerViewModel:ViewModelBase
    {
        //OpenFile,
        //ZoomIn,
        //ZoomOut,
        //Normal,
        //Fit,
        //SinglePage,
        //Facing
        public RelayCommand FileCommand { get; set; }
        public RelayCommand ZoomInCommand { get; set; }
        public RelayCommand ZoomOutCommand { get; set; }
        public RelayCommand NormalCommand { get; set; }
        public RelayCommand FitCommand { get; set; }
        public RelayCommand SinglePageCommand { get; set; }
        public RelayCommand FacingCommand { get; set; }

        public PdfViewerViewModel ()
        {
            FileCommand = new RelayCommand(OpenFile);
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            NormalCommand = new RelayCommand(Normal);
            FitCommand = new RelayCommand(Fit);
            SinglePageCommand = new RelayCommand(SinglePage);
            FacingCommand = new RelayCommand(Facing);
        }

        public void OpenFile ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType =  PdfCommandType.OpenFile });
        }

        public void ZoomIn ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType = PdfCommandType.ZoomIn });
        }

        public void ZoomOut ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType = PdfCommandType.ZoomOut });
        }

        public void Normal ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType = PdfCommandType.Normal });
        }

        public void Fit ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType = PdfCommandType.Fit });
        }


        public void SinglePage ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType = PdfCommandType.SinglePage });
        }

        public void Facing ()
        {
            Messenger.Default.Send(new PdfViewerMessage { CommandType = PdfCommandType.Facing });
        }
    }
}
