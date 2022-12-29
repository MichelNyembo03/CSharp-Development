using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System;


namespace NotePad
{
    public partial class Form1 : Form
    {
        //Declaraing Dialog variables for open and save files
        private OpenFileDialog of;
        private SaveFileDialog sf;

        //Boolean controllers
        bool isActive;

        int line, column;
        string path = string.Empty;

        //Declaring About form
        About ab;

        public Form1()
        {
            InitializeComponent();

            //Adding the dragEvent to the richtextbox
            PageText.DragDrop += new DragEventHandler(PageText_Drop);
            //Allowing the Drop Function in the richtextbox
            PageText.AllowDrop= true;
          

            //Instantiating the About form
            ab = new About();
            ab.Visible = false;
        }

        private void PageText_Drop(object? sender, DragEventArgs e)
        {
            object FileName = e.Data.GetData("FileDrop");
            if(FileName != null )
            {
                var list = FileName as string[];

                if(list!= null && !string.IsNullOrWhiteSpace(list[0]))
                {
                    PageText.Clear();
                    PageText.LoadFile(list[0], RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled";

            CountLnAndCol(PageText);

            menu.Height = 70;
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void Save_As_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

   
        private void newPage_Click(object sender, EventArgs e)
        {
            newText();
        }


        private void OpenDirectory_Click(object sender, EventArgs e)
        {
            of = new OpenFileDialog();
            of.Filter = "Text Files|*txt";

            if(this.Text != "Untitled")
            {
                if (PageText.Modified == true)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save changes to the opened file", "unsaved document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        SaveFile();
                        OpenFile();
                    }
                    else if(dr == DialogResult.No)
                    {
                        OpenFile();
                    }
                }
                else
                {
                    OpenFile();
                }
            }
            else
            {
                OpenFile();
            }
            
        }

        void SaveFile()
        {
            sf = new SaveFileDialog();
            sf.Filter = "Text Files|*.txt";
            sf.DefaultExt = "txt";
            sf.FileName = this.Text;

            sf.AddExtension = true;
            sf.CheckPathExists = true;
            sf.CreatePrompt = false;
            sf.OverwritePrompt = true;
            sf.ValidateNames = true;

            if (this.Text != "Untitled")
            {
               if(PageText.Modified)
               {
                    File.WriteAllText(path: sf.FileName, PageText.Text);
                    this.Text = sf.FileName;

                }
            }
            else
            {
               SaveAs();
            }
        }


        void OpenFile()
        {

            try
            {
                of = new OpenFileDialog();
                of.Filter = "Text Files|*txt";

                if (of.ShowDialog() == DialogResult.Cancel)
                {
                    PageText.Focus();
                }
                else
                {
                    PageText.Text = File.ReadAllText(path = of.FileName);
                    string[] SplitExtension = of.FileName.Split('.');
                    
                    this.Text = of.FileName;
                }
            }catch(Exception erroMessage)
            {
                MessageBox.Show(erroMessage.Message);
            }
            
        }

        void SaveAs()
        {
            sf = new SaveFileDialog();

            sf.AddExtension = true;
            sf.CheckPathExists = true;
            sf.CreatePrompt = false;
            sf.OverwritePrompt = true;
            sf.ValidateNames = true;
            sf.DefaultExt = "txt";

            sf.Filter = "Text Files|*.txt";
            sf.FilterIndex = 0;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sf.FileName, PageText.Text);
            }

            this.Text = sf.FileName;
        }

        void newText()
        {
            sf = new SaveFileDialog();
            sf.Title = "Save";

            if (PageText.Text.Length > 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to save the file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    SaveFile();
                }
                else
                {
                    this.Text = "Untitled";
                }
            }
            else
            {
                PageText.Focus();
            }
            
        }

        private void pageSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog.Document = printDocument1;
            pageSetupDialog.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(PageText.Text, PageText.Font, Brushes.Black, 100, 100);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDialog1.ShowDialog();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PageText.CanUndo)
            {
                PageText.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PageText.CanRedo)
            {
                PageText.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PageText.SelectedText.Length == 0)
                PageText.SelectAll();

            PageText.Copy();

        }

      

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                PageText.ZoomFactor += (float)0.05;

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PageText.ZoomFactor != 0)
                PageText.ZoomFactor -= (float)0.05;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.ZoomFactor = (float)1;
        }

        private void statusBatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                barStatus.Visible= true;
                isActive =false;
            }
            else
            {
                barStatus.Visible= false;
                isActive = true;
            }
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            PageText.Text = date.ToString(); 
        }

        private void PageText_TextChanged(object sender, EventArgs e)
        {
            CountLnAndCol(PageText);
        }

        public void CountLnAndCol(RichTextBox rtb)
        {
            int index = rtb.SelectionStart;
            line = rtb.GetLineFromCharIndex(index);

            int firsChar = rtb.GetLineFromCharIndex(line);
            column = index - firsChar;

            ln.Text = line.ToString();
            col.Text = column.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                PageText.Font = fontDialog1.Font;
            }
        }
        private void GoToText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.BackColor = ColorTranslator.FromHtml("#292A2D");
            PageText.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            menu.BackColor = ColorTranslator.FromHtml("#202124");
            menu.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            barStatus.BackColor = ColorTranslator.FromHtml("#202124");
            barStatus.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            panel1.BackColor = ColorTranslator.FromHtml("#292A2D");

        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageText.BackColor = ColorTranslator.FromHtml("#ffffff");
            PageText.ForeColor = ColorTranslator.FromHtml("#000000");

            menu.BackColor = ColorTranslator.FromHtml("#ffffff");
            menu.ForeColor = ColorTranslator.FromHtml("#000000");
            

            barStatus.BackColor = ColorTranslator.FromHtml("#ffffff");
            barStatus.ForeColor = ColorTranslator.FromHtml("#000000");
            barStatus.BorderStyle = BorderStyle.FixedSingle;

            panel1.BackColor = ColorTranslator.FromHtml("#ffffff");
            panel1.BorderStyle = BorderStyle.FixedSingle;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PageText.Text.Length > 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes to the opened file", "unsaved document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SaveFile();
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ab.ShowDialog();

        }
    }
}