using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace gasolutions.UInterface
{
    class TextPrint : System.Drawing.Printing.PrintDocument
    {
        Font PrintFont;
        StreamReader StreamToPrint;


        public TextPrint()
        { 
        }

        public TextPrint(StreamReader streamToPrintParam)
        {
            new TextPrint();
            StreamToPrint = streamToPrintParam;
        }

         protected override void OnBeginPrint(PrintEventArgs e)
         {
             try
             {
                 //OnBeginPrint(e);
                 PrintFont = new Font("Courier New", 9);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            try
            {
                PrintFont = new Font("Courier New", 9);
                //this.OnPrintPage(e);
                Single  Lpp = 0;
                Int16 Count = 0;
                Single TopMargin = e.MarginBounds.Top;
                Single YPos = TopMargin;
                string Line;
                Single leftMargin = e.MarginBounds.Left;
                Single  BottonMargin = e.MarginBounds.Bottom;
                Single lineHeight;

            Lpp = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);
            Line = StreamToPrint.ReadLine();
            lineHeight = PrintFont.GetHeight(e.Graphics);


            while (Line != "$$$")
             {
                YPos += PrintFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(Line, PrintFont, Brushes.Black, 0, YPos, new StringFormat());
                Count += 1;
                 if (Count < Lpp)
                 {
                     Line = StreamToPrint.ReadLine();
                 }
             }



             if (Line != "$$$")
                 e.HasMorePages = true;
             else
                 e.HasMorePages = false;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

