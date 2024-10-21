using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace JSON_Mini_Program
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Enable drag-and-drop for both PictureBoxes
            picBoxXml.AllowDrop = true;
            picBoxJson.AllowDrop = true;

            // Attach event handlers to the pictureboxes
            picBoxXml.DragEnter += picBoxXml_DragEnter;
            picBoxXml.DragDrop += picBoxXml_DragDrop;
            picBoxJson.DragEnter += picBoxJson_DragEnter;
            picBoxJson.DragDrop += picBoxJson_DragDrop;
        }

        private void deserializeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jsonTxtBox.Text))
            {
                resultInPlaintext.Text = "Please insert JSON.";
            }
            else
            {
                resultInPlaintext.Text = ConvertJSONToText(jsonTxtBox.Text);
            }
        }

        private string ConvertJSONToText(string jsonContent)
        {
            var plainTextDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonContent);

            return DetermineValueKind(plainTextDict);
        }

        private string DetermineValueKind(Dictionary<string, JsonElement> plainTextDict)
        {
            // create stringbuilder to combine all strings into one
            var result = new StringBuilder();

            foreach (var kvp in plainTextDict)
            {
                result.Append($"{kvp.Key}: "); // output "Key:  " without entering new line
                switch (kvp.Value.ValueKind)
                {
                    case JsonValueKind.Number: // if the value is a number, then assign the value as number in JSON
                        result.AppendLine($"{kvp.Value.GetDecimal()}"); // output "Key: 20" and enters new line
                        break;
                    case JsonValueKind.Null: // if the value is null, then output string "null"
                        result.AppendLine("null");
                        break;
                    case JsonValueKind.Array:
                        int arrayLength = kvp.Value.GetArrayLength();
                        int index = 0;
                        foreach (var item in kvp.Value.EnumerateArray())
                        {
                            // if the one of the array item's value is an object, need further deserialization (since it is a nested JSON)
                            if (item.ValueKind == JsonValueKind.Object) 
                            {
                                var arrNested = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(item);
                                result.AppendLine("");
                                result.Append(DetermineValueKind(arrNested)); // after deserialized, determine the type of that value
                            }
                            else if (index == arrayLength - 1) // if it is the last item in the array
                            {
                                result.AppendLine($"{item}");
                            }
                            else if (item.ValueKind == JsonValueKind.Null && index != arrayLength - 1) // if the nested JSON's value is null and not the last item of array
                            {
                                result.AppendLine("null,");
                            }
                            else if (item.ValueKind == JsonValueKind.Null && index == arrayLength - 1) // if the nested JSON's value is null and is the last item of array
                            {
                                result.AppendLine("null");
                            }
                            else
                            {
                                result.Append($"{item}, "); // comma use to separate each array items
                            }
                            index++;
                        }
                        break;
                    case JsonValueKind.Object: // if value is an object/nested JSON, then deserialize it then determine the nested value's type
                        var nestedJson = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(kvp.Value);
                        result.AppendLine("");
                        result.Append(DetermineValueKind(nestedJson));
                        break;
                    case JsonValueKind.True:
                    case JsonValueKind.False: // if the value is written true or false, convert the value to boolean type
                        result.AppendLine($"{kvp.Value.GetBoolean()}");
                        break;
                    default:
                        result.AppendLine(kvp.Value.GetString()); // else return string
                        break;
                }
            }

            return result.ToString(); // after combining everything (includes every key and value), JSON is ready, and converted into a single string
        }

        private void serializeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(key1.Text) || string.IsNullOrEmpty(key2.Text) || string.IsNullOrEmpty(key3.Text))
            {
                resultInJson.Text = "Please fill in all the details.";
                return;
            }

            var dataDictionary = new Dictionary<string, object>();

            // convert each textboxes into a key-value pair which is Dictionary
            // left side key, right side value
            AddToDictionary(dataDictionary, key1.Text, DetermineValueType(value1.Text)); 
            AddToDictionary(dataDictionary, key2.Text, DetermineValueType(value2.Text));
            AddToDictionary(dataDictionary, key3.Text, DetermineValueType(value3.Text));

            var options = new JsonSerializerOptions // beautify the converted json
            {
                WriteIndented = true,
            };

            string json = System.Text.Json.JsonSerializer.Serialize(dataDictionary, options); // convert into JSON

            resultInJson.Text = json; // output to the textbox
        }

        private void AddToDictionary(Dictionary<string, object> dict, string key, object value)
        {
            if (!dict.ContainsKey(key)) // if the key is new (not inside the dictionary yet / dictionary does not contain that specific key)
            {
                dict[key] = value; // assign the value directly to the key
            }
            else if (dict[key] is List<object> existingList) // if the key existed and the value is a list, then it will create a list called existingList which directly reflects to the original Dictionary
            {
                // any changes made to the existingList will directly change the original dictionary
                existingList.Add(value); 
            } else
            {
                // if the key existed and the value is not a list
                var existingVal = dict[key]; // assign the value to a new variable
                dict[key] = new List<object> {existingVal, value}; // create a new list and at the same time add the old and new value
            }
        }

        private object DetermineValueType(string input)
        {
            // if the string is a number, convert it to a double
            if (double.TryParse(input, out double numVal))
            {
                return numVal;
            }

            if (input.Contains(",")) // if the input contains multiple value seperated by comma
            {
                List<object> newList = new List<object>();

                // split every array item that is separated by comma, and remove the whitespace, then put them into an array
                string[] arr = input.Split(',').Select(x => x.Trim()).ToArray(); 
                foreach (var item in arr)
                {
                    var newItem = DetermineValueType(item);
                    newList.Add(newItem);
                    // add into a new array to be returned
                }
                // return new array

                object[] objects = newList.ToArray(); // convert newList into an array of objects after determining the type

                return objects;
            }

            if (bool.TryParse(input, out bool boolVal))
            {
                return boolVal; // convert string into boolean
            }

            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            return input;
        }

        private void picBoxXml_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog(); // open file explorer

            ofd.Filter = "XML Files(*.xml)|*.xml|All Files|*.*"; // only accepts xml files
            ofd.Title = "Please select a XML file";

            if (ofd.ShowDialog() == DialogResult.OK) // if file is selected
            {
                xmlToJsonBtn.Tag = ofd.FileName; // store file name into button
                xmlToTxtBtn.Tag = ofd.FileName;

                picBoxXml.Image.Dispose(); // dispose the default image
                picBoxXml.Image = Properties.Resources.xml_import_success; // change new image as a feedback to the user

                resultFromImportXml.Clear(); // clear error message in the textbox if any

                xmlLabel.Text = ofd.SafeFileName; // output the file name in the label
            }
        }

        private void xmlToJsonBtn_Click(object sender, EventArgs e)
        {
            if (xmlToJsonBtn.Tag == null || string.IsNullOrEmpty(xmlToJsonBtn.Tag as string))
            {
                resultFromImportXml.Text = "No XML file is selected or File is empty";
                return;
            }

            string xmlContent = File.ReadAllText(xmlToJsonBtn.Tag as string); // everything inside the file selected that is stored in the button

            resultFromImportXml.Text = ConvertXMLToJSON(xmlContent);

            string jsonFilePath = @"C:\Users\user\Downloads\" + Path.GetFileNameWithoutExtension(xmlToJsonBtn.Tag as string) + ".json"; // create file path

            File.WriteAllText(jsonFilePath, ConvertXMLToJSON(xmlContent)); // write the converted code into the file
        }

        private string ConvertXMLToJSON(string xmlContent)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(xmlContent); // load the xml string into a xml document

            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented); // convert xml to json with indented formatting

            jsonText = jsonText.Replace("@description", "description") 
                .Replace("#text", "text");

            return jsonText;
        }

        private void xmlToTxtBtn_Click(object sender, EventArgs e)
        {
            if (xmlToTxtBtn.Tag == null || string.IsNullOrEmpty(xmlToTxtBtn.Tag as string))
            {
                resultFromImportXml.Text = "No XML file is selected or File is empty";
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(File.ReadAllText(xmlToTxtBtn.Tag as string)); // read all xml content in the file to be converted into a xml document

            string textForXml = ConvertXMLToText(xmlDoc); 

            resultFromImportXml.Text = textForXml;
        }

        private string ConvertXMLToText(XmlDocument xmlDoc)
        {
            string result = $"{xmlDoc.DocumentElement.Name}:\n"; // start off by extracting the root tag

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                result += $"{node.Name}:\n"; // in the new line, write the child node of the root tag then iterate

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    result += $"{childNode.Name} : {childNode.InnerText}\n"; // then write the child node of the parent node with key and value together
                }
            }
            return result.Trim(); // return result with whitespace-free
        }

        private void picBoxJson_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog(); // open file explorer

            ofd.Filter = "JSON Files(*.json)|*.json|All Files|*.*"; // only accepts json files
            ofd.Title = "Please select a JSON file";

            if (ofd.ShowDialog() == DialogResult.OK) // if file is selected
            {
                jsonToXmlBtn.Tag = ofd.FileName; // store file name into buttons
                jsonToTxtBtn.Tag = ofd.FileName;

                picBoxJson.Image.Dispose(); // dispose the default image
                picBoxJson.Image = Properties.Resources.json_import_success; // change new image as a feedback to the user

                resultFromImportJson.Clear(); // clear error message in the textbox if any

                jsonLabel.Text = ofd.SafeFileName; // output the file name in the label
            }
        }

        private void jsonToXmlBtn_Click(object sender, EventArgs e)
        {
            if (jsonToXmlBtn.Tag == null || string.IsNullOrEmpty(jsonToXmlBtn.Tag as string))
            {
                resultFromImportJson.Text = "No JSON file is selected or File is empty"; 
                return;
            }

            string jsonContent = File.ReadAllText(jsonToXmlBtn.Tag as string); // read all details in the file and stored it in a string

            resultFromImportJson.Text = ConvertJSONToXML(jsonContent);

            string xmlFilePath = @"C:\Users\user\Downloads\" + Path.GetFileNameWithoutExtension(jsonToXmlBtn.Tag as string) + ".xml"; // create new file path

            File.WriteAllText(xmlFilePath, ConvertJSONToXML(jsonContent)); // write the xml string into the file
        }

        private string ConvertJSONToXML(string jsonContent)
        {
            // Deserialize JSON to XML
            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(jsonContent);

            // Use StringWriter to capture the XML output
            var stringWriter = new StringWriter();
            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            // Create an XML writer with the settings
            using (var xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
            {
                xmlDoc.WriteTo(xmlWriter);
            }

            // Return the beautified XML string
            return stringWriter.ToString();
        }

        private void jsonToTxtBtn_Click(object sender, EventArgs e)
        {
            if (jsonToTxtBtn.Tag == null || string.IsNullOrEmpty(jsonToTxtBtn.Tag as string))
            {
                resultFromImportJson.Text = "No JSON file is selected or File is empty";
                return;
            }

            string jsonContent = File.ReadAllText(jsonToTxtBtn.Tag as string); // read all info in the file and then stored in a string

            resultFromImportJson.Text = ConvertJSONToText(jsonContent);
        }

        private void resetJsonText_Click(object sender, EventArgs e)
        {
            jsonTxtBox.Clear();
            resultInPlaintext.Clear();
        }

        private void resetPlaintext_Click(object sender, EventArgs e)
        {
            key1.Clear();
            key2.Clear();
            key3.Clear();
            value1.Clear();
            value2.Clear();
            value3.Clear();
            resultInJson.Clear();
        }

        private void resetXmlFile_Click(object sender, EventArgs e)
        {
            xmlToJsonBtn.Tag = null;
            xmlToTxtBtn.Tag = null;
            resultFromImportXml.Clear();

            picBoxXml.Image.Dispose();
            picBoxXml.Image = Properties.Resources.import2;

            xmlLabel.Text = "Please drag and drop, or click to import XML file";
        }

        private void resetJsonFile_Click(object sender, EventArgs e)
        {
            jsonToXmlBtn.Tag = null;
            jsonToTxtBtn.Tag = null;
            resultFromImportJson.Clear();

            picBoxJson.Image.Dispose();
            picBoxJson.Image = Properties.Resources.import2;

            jsonLabel.Text = "Please drag and drop, or click to import JSON file";
        }

        private void picBoxXml_DragEnter(object sender, DragEventArgs e)
        {
            HandleDragEnter(e, ".xml");
        }

        private void picBoxXml_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); // stores all dropped files into an array

            if (files.Length == 1) // only accept one file for drag & drop
            {
                xmlToJsonBtn.Tag = files[0]; // store file into button
                xmlToTxtBtn.Tag = files[0];

                picBoxXml.Image.Dispose(); // dispose the default image
                picBoxXml.Image = Properties.Resources.xml_import_success; // change new image as a feedback to the user

                resultFromImportXml.Clear(); // clear error message in the textbox if any

                xmlLabel.Text = Path.GetFileName(files[0]); // output the file name in the label
            }
        }

        private void picBoxJson_DragEnter(object sender, DragEventArgs e)
        {
            HandleDragEnter(e, ".json");
        }

        private void picBoxJson_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); 

            if (files.Length == 1)
            {
                jsonToXmlBtn.Tag = files[0];
                jsonToTxtBtn.Tag = files[0];

                picBoxJson.Image.Dispose();
                picBoxJson.Image = Properties.Resources.json_import_success;
                resultFromImportJson.Clear();

                jsonLabel.Text = Path.GetFileName(files[0]);
            }
        }

        private void HandleDragEnter(DragEventArgs e, string extension)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // if there is a file drop
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); // stores all dropped files into an array

                // if the array has one file only, and the file extension is either xml or json, and case-insensitive 
                if (files.Length == 1 && Path.GetExtension(files[0]).Equals(extension, StringComparison.OrdinalIgnoreCase))
                {
                    e.Effect = DragDropEffects.Copy; // data is copied to the dragged target
                }
                else
                {
                    e.Effect = DragDropEffects.None; // does not allow drag and drop operations
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
