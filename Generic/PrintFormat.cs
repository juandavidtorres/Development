//Development by Kelmer Ashley Comas Cardona © 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Generic
{
    public class PrintFormat
    {
        private StringBuilder Format = new StringBuilder();

        public PrintFormat(int width)
        {
            this.Format = new StringBuilder();
            this.Width = width;
        }

        public int Width { get; private set; }

        public void AddFormat(PrintFormat format)
        {
           foreach(string line in format.Lines)
            this.Format.AppendLine(line);
        }

        public void AddNewLine()
        {
            this.AddSeparator(' ');
        }

        public void AddNewLines(int countLines)
        {
            for (int i = 1; i <= countLines; i++)
                this.AddSeparator(' ');
        }

        public void AddLine(params Field[] fields)
        {
            try
            {
                string line = string.Empty;

                foreach (Field field in fields)
                {
                    string label = field.Label ?? "";
                    string value = field.Text ?? "";
                    Util.eAlign align = (Util.eAlign)field.Align;
                    int width = (field.Width <= 0) ? this.Width : field.Width;
                    int wAux = width;

                   switch(align)
                   {
                       case Util.eAlign.CENTER:
                           wAux -= (label.Length + 1);

                           if (wAux > 0)
                               if(label.Length > 0)
                                    align = Util.eAlign.RIGHT;
                               else align = Util.eAlign.CENTER;

                           value = Util.TextAlign(value, wAux, align);
                           value = (label.Trim() + " " + value);        
                           break;
                       default:
                           value = (label + " " + value);
                           value = Util.TextAlign(value, wAux, align);
                           break;
                   }

                   line += value;
                }

                if (line.Length > this.Width)
                    throw new Exception(String.Format("La linea '{0}' L={1} supera al ancho ({2}) del formato", 
                                                      line, line.Length, this.Width));

                this.Format.AppendLine(line);
            }
            catch { throw; }
        }


        public void AddText(string text)
        {
            try
            {
                this.Format.Append(text);
            }
            catch { throw; }
        }


        public void AddMuliLine(Field field)
        {
            try
            {
                string label = field.Label ?? "";
                string value = field.Text ?? "\r\n";
                Util.eAlign align = (Util.eAlign)field.Align;
                int width = (field.Width <= 0) ? this.Width : field.Width;

                string lines = Util.MultilineText((label + " "+ value), width, align);
                this.Format.Append(lines);
            }
            catch { throw; }
        }

        public void AddSeparator(char chaSplit)
        {
            try
            {
                string line = Util.TextAlign(new String(chaSplit, this.Width), this.Width, Util.eAlign.LEFT);
                this.Format.AppendLine(line);
            }
            catch { throw; }
        }

        public void SetFormat(string format)
        {
            try
            {
                this.Clear();
                string[] lines = format.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                    this.Format.AppendLine(line);
               
            }
            catch { throw; }
        }

        public string Value
        {
            get
            {
                return this.Format.ToString();
            }
        }      

        public string[] Lines
        {
            get
            {
                return this.Value.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public void Clear()
        {
            this.Format.Clear();
        }

        public PrintFormat GetNewInstance()
        {
            return new PrintFormat(this.Width);
        }

        public override string ToString()
        {
            return this.Value;
        }
    }


    public class Field
    {
        public const int LEFT = 0;
        public const int CENTER = 1;
        public const int RIGHT = 2;

        public Field(){}


        #region "CONSTRUCTORES"

        public Field(string text, int width, int align)
        {
            this.Label = String.Empty;
            this.Text = text;
            this.Width = width;
            this.Align = align;
        }

        public Field(string text)
        {
            this.Label = String.Empty;
            this.Text = text;
            this.Width = 0;
            this.Align = Field.LEFT;
        }

        public Field(string text, int align)
        {
            this.Label = String.Empty;
            this.Text = text;
            this.Width = 0;
            this.Align = align;
        }

        public Field(string label, string text, int width, int align)
        {
            this.Label = label;
            this.Text = text;
            this.Width = width;
            this.Align = align;
        }

        public Field(string label, string text, int align)
        {
            this.Label = label;
            this.Text = text;
            this.Width = 0;
            this.Align = align;
        }

        #endregion


        public Font Font { get; set; }
        public string Label { get; set; }
        public string Text{ get; set; }
        public int Width { get; set; }
        public int Align{ get; set; }

    }
}
