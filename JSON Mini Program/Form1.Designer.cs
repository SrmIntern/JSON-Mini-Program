namespace JSON_Mini_Program
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            deserializeButton = new Button();
            serializeButton = new Button();
            jsonTxtBox = new RichTextBox();
            resultInPlaintext = new RichTextBox();
            label2 = new Label();
            resultInJson = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            key1 = new TextBox();
            key2 = new TextBox();
            key3 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            value1 = new TextBox();
            value2 = new TextBox();
            value3 = new TextBox();
            label1 = new Label();
            xmlLabel = new Label();
            xmlToJsonBtn = new Button();
            xmlToTxtBtn = new Button();
            resultFromImportXml = new RichTextBox();
            label9 = new Label();
            picBoxXml = new PictureBox();
            picBoxJson = new PictureBox();
            label10 = new Label();
            resultFromImportJson = new RichTextBox();
            jsonToTxtBtn = new Button();
            jsonToXmlBtn = new Button();
            jsonLabel = new Label();
            resetJsonText = new Button();
            resetPlaintext = new Button();
            resetXmlFile = new Button();
            resetJsonFile = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxXml).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxJson).BeginInit();
            SuspendLayout();
            // 
            // deserializeButton
            // 
            deserializeButton.Location = new Point(514, 126);
            deserializeButton.Name = "deserializeButton";
            deserializeButton.Size = new Size(183, 50);
            deserializeButton.TabIndex = 0;
            deserializeButton.Text = "Deserialize";
            deserializeButton.UseVisualStyleBackColor = true;
            deserializeButton.Click += deserializeButton_Click;
            // 
            // serializeButton
            // 
            serializeButton.Location = new Point(514, 366);
            serializeButton.Name = "serializeButton";
            serializeButton.Size = new Size(183, 54);
            serializeButton.TabIndex = 1;
            serializeButton.Text = "Serialize";
            serializeButton.UseVisualStyleBackColor = true;
            serializeButton.Click += serializeButton_Click;
            // 
            // jsonTxtBox
            // 
            jsonTxtBox.Location = new Point(88, 62);
            jsonTxtBox.Name = "jsonTxtBox";
            jsonTxtBox.Size = new Size(353, 173);
            jsonTxtBox.TabIndex = 2;
            jsonTxtBox.Text = "";
            // 
            // resultInPlaintext
            // 
            resultInPlaintext.Location = new Point(761, 62);
            resultInPlaintext.Name = "resultInPlaintext";
            resultInPlaintext.ReadOnly = true;
            resultInPlaintext.Size = new Size(341, 176);
            resultInPlaintext.TabIndex = 3;
            resultInPlaintext.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(761, 28);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 5;
            label2.Text = "Results:";
            // 
            // resultInJson
            // 
            resultInJson.Location = new Point(761, 304);
            resultInJson.Name = "resultInJson";
            resultInJson.ReadOnly = true;
            resultInJson.Size = new Size(341, 189);
            resultInJson.TabIndex = 6;
            resultInJson.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 266);
            label3.Name = "label3";
            label3.Size = new Size(185, 20);
            label3.TabIndex = 8;
            label3.Text = "Please fill in with plaintext:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(761, 266);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 9;
            label4.Text = "Results:";
            // 
            // key1
            // 
            key1.Location = new Point(88, 315);
            key1.Name = "key1";
            key1.Size = new Size(125, 27);
            key1.TabIndex = 10;
            // 
            // key2
            // 
            key2.Location = new Point(88, 380);
            key2.Name = "key2";
            key2.Size = new Size(125, 27);
            key2.TabIndex = 11;
            // 
            // key3
            // 
            key3.Location = new Point(88, 451);
            key3.Name = "key3";
            key3.Size = new Size(125, 27);
            key3.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(228, 318);
            label5.Name = "label5";
            label5.Size = new Size(12, 20);
            label5.TabIndex = 13;
            label5.Text = ":";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(228, 383);
            label6.Name = "label6";
            label6.Size = new Size(12, 20);
            label6.TabIndex = 14;
            label6.Text = ":";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(228, 454);
            label7.Name = "label7";
            label7.Size = new Size(12, 20);
            label7.TabIndex = 15;
            label7.Text = ":";
            // 
            // value1
            // 
            value1.Location = new Point(262, 315);
            value1.Name = "value1";
            value1.Size = new Size(125, 27);
            value1.TabIndex = 16;
            // 
            // value2
            // 
            value2.Location = new Point(262, 380);
            value2.Name = "value2";
            value2.Size = new Size(125, 27);
            value2.TabIndex = 17;
            // 
            // value3
            // 
            value3.Location = new Point(262, 451);
            value3.Name = "value3";
            value3.Size = new Size(125, 27);
            value3.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 28);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 4;
            label1.Text = "Please insert JSON:";
            // 
            // xmlLabel
            // 
            xmlLabel.AutoSize = true;
            xmlLabel.Location = new Point(88, 527);
            xmlLabel.Name = "xmlLabel";
            xmlLabel.Size = new Size(330, 20);
            xmlLabel.TabIndex = 19;
            xmlLabel.Text = "Please drag and drop, or click to import XML file";
            // 
            // xmlToJsonBtn
            // 
            xmlToJsonBtn.Location = new Point(514, 583);
            xmlToJsonBtn.Name = "xmlToJsonBtn";
            xmlToJsonBtn.Size = new Size(183, 54);
            xmlToJsonBtn.TabIndex = 22;
            xmlToJsonBtn.Text = "Convert to JSON";
            xmlToJsonBtn.UseVisualStyleBackColor = true;
            xmlToJsonBtn.Click += xmlToJsonBtn_Click;
            // 
            // xmlToTxtBtn
            // 
            xmlToTxtBtn.Location = new Point(514, 643);
            xmlToTxtBtn.Name = "xmlToTxtBtn";
            xmlToTxtBtn.Size = new Size(183, 54);
            xmlToTxtBtn.TabIndex = 23;
            xmlToTxtBtn.Text = "Convert to Text";
            xmlToTxtBtn.UseVisualStyleBackColor = true;
            xmlToTxtBtn.Click += xmlToTxtBtn_Click;
            // 
            // resultFromImportXml
            // 
            resultFromImportXml.BackColor = SystemColors.Control;
            resultFromImportXml.Location = new Point(761, 562);
            resultFromImportXml.Name = "resultFromImportXml";
            resultFromImportXml.ReadOnly = true;
            resultFromImportXml.Size = new Size(341, 189);
            resultFromImportXml.TabIndex = 24;
            resultFromImportXml.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(761, 527);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 25;
            label9.Text = "Results:";
            // 
            // picBoxXml
            // 
            picBoxXml.Image = Properties.Resources.import2;
            picBoxXml.Location = new Point(88, 562);
            picBoxXml.Name = "picBoxXml";
            picBoxXml.Size = new Size(353, 189);
            picBoxXml.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxXml.TabIndex = 26;
            picBoxXml.TabStop = false;
            picBoxXml.Click += picBoxXml_Click;
            picBoxXml.DragDrop += picBoxXml_DragDrop;
            picBoxXml.DragEnter += picBoxXml_DragEnter;
            // 
            // picBoxJson
            // 
            picBoxJson.Image = Properties.Resources.import2;
            picBoxJson.Location = new Point(88, 821);
            picBoxJson.Name = "picBoxJson";
            picBoxJson.Size = new Size(353, 189);
            picBoxJson.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxJson.TabIndex = 32;
            picBoxJson.TabStop = false;
            picBoxJson.Click += picBoxJson_Click;
            picBoxJson.DragDrop += picBoxJson_DragDrop;
            picBoxJson.DragEnter += picBoxJson_DragEnter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(761, 786);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 31;
            label10.Text = "Results:";
            // 
            // resultFromImportJson
            // 
            resultFromImportJson.BackColor = SystemColors.Control;
            resultFromImportJson.Location = new Point(761, 821);
            resultFromImportJson.Name = "resultFromImportJson";
            resultFromImportJson.ReadOnly = true;
            resultFromImportJson.Size = new Size(341, 189);
            resultFromImportJson.TabIndex = 30;
            resultFromImportJson.Text = "";
            // 
            // jsonToTxtBtn
            // 
            jsonToTxtBtn.Location = new Point(514, 903);
            jsonToTxtBtn.Name = "jsonToTxtBtn";
            jsonToTxtBtn.Size = new Size(183, 54);
            jsonToTxtBtn.TabIndex = 29;
            jsonToTxtBtn.Text = "Convert to Text";
            jsonToTxtBtn.UseVisualStyleBackColor = true;
            jsonToTxtBtn.Click += jsonToTxtBtn_Click;
            // 
            // jsonToXmlBtn
            // 
            jsonToXmlBtn.Location = new Point(514, 843);
            jsonToXmlBtn.Name = "jsonToXmlBtn";
            jsonToXmlBtn.Size = new Size(183, 54);
            jsonToXmlBtn.TabIndex = 28;
            jsonToXmlBtn.Text = "Convert to XML";
            jsonToXmlBtn.UseVisualStyleBackColor = true;
            jsonToXmlBtn.Click += jsonToXmlBtn_Click;
            // 
            // jsonLabel
            // 
            jsonLabel.AutoSize = true;
            jsonLabel.Location = new Point(88, 786);
            jsonLabel.Name = "jsonLabel";
            jsonLabel.Size = new Size(336, 20);
            jsonLabel.TabIndex = 27;
            jsonLabel.Text = "Please drag and drop, or click to import JSON file";
            // 
            // resetJsonText
            // 
            resetJsonText.Location = new Point(559, 182);
            resetJsonText.Name = "resetJsonText";
            resetJsonText.Size = new Size(94, 29);
            resetJsonText.TabIndex = 33;
            resetJsonText.Text = "Reset";
            resetJsonText.UseVisualStyleBackColor = true;
            resetJsonText.Click += resetJsonText_Click;
            // 
            // resetPlaintext
            // 
            resetPlaintext.Location = new Point(559, 426);
            resetPlaintext.Name = "resetPlaintext";
            resetPlaintext.Size = new Size(94, 29);
            resetPlaintext.TabIndex = 34;
            resetPlaintext.Text = "Reset";
            resetPlaintext.UseVisualStyleBackColor = true;
            resetPlaintext.Click += resetPlaintext_Click;
            // 
            // resetXmlFile
            // 
            resetXmlFile.Location = new Point(559, 703);
            resetXmlFile.Name = "resetXmlFile";
            resetXmlFile.Size = new Size(94, 29);
            resetXmlFile.TabIndex = 35;
            resetXmlFile.Text = "Reset";
            resetXmlFile.UseVisualStyleBackColor = true;
            resetXmlFile.Click += resetXmlFile_Click;
            // 
            // resetJsonFile
            // 
            resetJsonFile.Location = new Point(559, 963);
            resetJsonFile.Name = "resetJsonFile";
            resetJsonFile.Size = new Size(94, 29);
            resetJsonFile.TabIndex = 36;
            resetJsonFile.Text = "Reset";
            resetJsonFile.UseVisualStyleBackColor = true;
            resetJsonFile.Click += resetJsonFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1240, 1055);
            Controls.Add(resetJsonFile);
            Controls.Add(resetXmlFile);
            Controls.Add(resetPlaintext);
            Controls.Add(resetJsonText);
            Controls.Add(picBoxJson);
            Controls.Add(label10);
            Controls.Add(resultFromImportJson);
            Controls.Add(jsonToTxtBtn);
            Controls.Add(jsonToXmlBtn);
            Controls.Add(jsonLabel);
            Controls.Add(picBoxXml);
            Controls.Add(label9);
            Controls.Add(resultFromImportXml);
            Controls.Add(xmlToTxtBtn);
            Controls.Add(xmlToJsonBtn);
            Controls.Add(xmlLabel);
            Controls.Add(label1);
            Controls.Add(value3);
            Controls.Add(value2);
            Controls.Add(value1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(key3);
            Controls.Add(key2);
            Controls.Add(key1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(resultInJson);
            Controls.Add(label2);
            Controls.Add(resultInPlaintext);
            Controls.Add(jsonTxtBox);
            Controls.Add(serializeButton);
            Controls.Add(deserializeButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picBoxXml).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxJson).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button deserializeButton;
        private Button serializeButton;
        private RichTextBox jsonTxtBox;
        private RichTextBox resultInPlaintext;
        private Label label2;
        private RichTextBox resultInJson;
        private Label label3;
        private Label label4;
        private TextBox key1;
        private TextBox key2;
        private TextBox key3;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox value1;
        private TextBox value2;
        private TextBox value3;
        private Label label1;
        private Label xmlLabel;
        private Button xmlToJsonBtn;
        private Button xmlToTxtBtn;
        private RichTextBox resultFromImportXml;
        private Label label9;
        private PictureBox picBoxXml;
        private PictureBox picBoxJson;
        private Label label10;
        private RichTextBox resultFromImportJson;
        private Button jsonToTxtBtn;
        private Button jsonToXmlBtn;
        private Label jsonLabel;
        private Button resetJsonText;
        private Button resetPlaintext;
        private Button resetXmlFile;
        private Button resetJsonFile;
    }
}
