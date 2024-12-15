namespace Proiect_SOAC
{
    public partial class Form1 : Form
    {
        private string fileContent;
        private IList<Func<IList<string>, IList<Operand>>> extractOperandsMethods = new List<Func<IList<string>, IList<Operand>>>();
        public Form1()
        {
            InitializeComponent();
            process.Visible = false;
            extractOperandsMethods.Add(oneComponent);
            extractOperandsMethods.Add(twoComponents);
            extractOperandsMethods.Add(threeComponents);
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a File",
                Filter = "Text Files All Files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    fileContent = File.ReadAllText(filePath);
                    preview.Text = fileContent;
                    process.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the file: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void process_Click(object sender, EventArgs e)
        {
            var lines = parseFile();
            if (immediateMerging.Checked)
            {
                // do immediate merging
            }
            if (movReabsorption.Checked)
            {
                //do move reabsorption
            }
            if (antiAlias.Checked)
            {
                lines = doAntiAlias(lines);
            }
            render(lines);
        }

        private IList<Line> doAntiAlias(IList<Line> lines)
        {
            for (int i = 0; i < lines.Count - 1; i++)
            {
                if (lines[i].getInstruction().Equals(InstructionSet.ST.ToString()) && lines[i + 1].getInstruction().Equals(InstructionSet.LD.ToString()))
                {
                    var memoryMatch = getMemoryMatch(lines[i + 1], lines[i]);
                    if (memoryMatch.Equals(AntiAliasMemoryMatch.Identic))
                    {
                        var newOperands = new List<Operand>
                        {
                            new Operand
                            {
                                reg1 = lines[i + 1].getOperands()[0].reg1,
                            },
                            new Operand
                            {
                                reg1 = lines[i].getOperands()[1].reg1,
                            }
                        };
                        lines[i + 1] = lines[i];
                        lines[i] = new Instruction
                        {
                            instruction = InstructionSet.MOV.ToString(),
                            operands = newOperands
                        };
                    }
                }
                else if (lines[i].getInstruction().Equals(InstructionSet.LD.ToString()) && lines[i + 1].getInstruction().Equals(InstructionSet.ST.ToString()))
                {
                    var memoryMatch = getMemoryMatch(lines[i], lines[i + 1]);
                    if (memoryMatch.Equals(AntiAliasMemoryMatch.Diferit))
                    {
                        var aux = lines[i];
                        lines[i] = lines[i + 1];
                        lines[i + 1] = aux;
                    }
                }
            }
            return lines;
        }

        private AntiAliasMemoryMatch getMemoryMatch(Line ld, Line st) 
        {
            var ldOperands = ld.getOperands();
            var stOperands = st.getOperands();
            if (((stOperands[0].reg1.Equals(ldOperands[1].reg1) && stOperands[0].reg2.Equals(ldOperands[1].reg2)) || (stOperands[0].reg1.Equals(ldOperands[1].reg2) && stOperands[0].reg2.Equals(ldOperands[1].reg1))) && ldOperands[1].preOffset.Equals(stOperands[0].preOffset) && ldOperands[1].postOffset.Equals(stOperands[0].postOffset))
            {
                return AntiAliasMemoryMatch.Identic;
            } 
            else if (InstructionUtils.isRegister(ldOperands[1].reg1) || InstructionUtils.isRegister(ldOperands[1].reg2) || InstructionUtils.isRegister(stOperands[0].reg1) || InstructionUtils.isRegister(stOperands[0].reg2))
            {
                return AntiAliasMemoryMatch.Esueaza;
            }
            else
            {
                return AntiAliasMemoryMatch.Diferit;
            }
        }

        private IList<Line> parseFile()
        {
            string[] lines = fileContent.Split('\n');
            IList<Line> result = new List<Line>();
            foreach (string line in lines)
            {
                var trimmedLine = line.TrimStart();
                if (line.Any(x => !char.IsWhiteSpace(x)))
                {
                    string[] lineComponents = trimmedLine.Split();
                    if (lineComponents[0].EndsWith(':') || lineComponents[0].StartsWith('.'))
                    {
                        result.Add(new NotInstruction { value = line });
                    }
                    else
                    {
                        var instr = new Instruction();
                        int i = 0;
                        while (i < lineComponents.Length && !InstructionUtils.isInstruction(lineComponents[i]))
                        {
                            instr.label += lineComponents[i] + " ";
                            i++;
                        }
                        if (i < lineComponents.Length)
                        {
                            instr.instruction = lineComponents[i];
                            var operands = extractOperandsAsString(i + 1, lineComponents);
                            var method = extractOperandsMethods[operands.Length - 1];
                            instr.operands = method.Invoke(operands);
                            result.Add(instr);
                        }
                    }
                }
            }
            return result;
        }

        private string[] extractOperandsAsString(int index, string[] lineComponents)
        {
            var result = string.Empty;
            while (index < lineComponents.Length)
            {
                result += lineComponents[index++];
            }
            return result.Split(',');
        }

        private void render(IList<Line> lines)
        {
            string result = string.Empty;
            foreach (Line line in lines)
            {
                result += line.ToString();
            }
            processed.Text = result;
        }

        private IList<Operand> oneComponent(IList<string> components)
        {
            var operand = components[0].Replace("#", "");
            var isNumeric = int.TryParse(operand, out int offset);
            var operands = new List<Operand>();
            if (isNumeric)
            {
                operands.Add(new Operand
                {
                    immediateValue = components[0] ?? ""
                });
            }
            else
            {
                operands.Add(new Operand
                {
                    reg1 = components[0]
                });
            }
            return operands;
        }
        private IList<Operand> twoComponents(IList<string> components)
        {
            var operands = new List<Operand>();
            foreach (var component in components)
            {
                operands.Add(extractOpernad(component));
            }
            return operands;
        }
        private IList<Operand> threeComponents(IList<string> components)
        {
            var operands = new List<Operand>();
            if (components[0].Contains('(') && components[1].Contains(')'))
            {
                var firstOpComp = components[0].Split('(');
                if (firstOpComp[0].Equals(string.Empty))
                {
                    operands.Add(new Operand
                    {
                        reg1 = firstOpComp[1],
                        reg2 = components[1].Replace(")", ""),
                        preOffset = 0
                    });
                } else
                {
                    operands.Add(new Operand
                    {
                        reg1 = firstOpComp[1],
                        reg2 = components[1].Replace(")", ""),
                        preOffset = int.Parse(firstOpComp[0])
                    });
                }
                operands.Add(extractOpernad(components[2]));
            }
            else if (components[1].Contains("(") && components[2].Contains(")"))
            {
                operands.Add(extractOpernad(components[0]));
                var secondOpComp = components[1].Split('(');
                if (secondOpComp[0].Equals(string.Empty))
                {
                    operands.Add(new Operand
                    {
                        reg1 = secondOpComp[1],
                        reg2 = components[2].Replace(")", ""),
                        preOffset=0
                    });
                }
                else
                {
                    operands.Add(new Operand
                    {
                        reg1 = secondOpComp[1],
                        reg2 = components[2].Replace(")", ""),
                        preOffset = int.Parse(secondOpComp[0])
                    });
                }
            }
            else
            {
                foreach (var component in components)
                {
                    operands.Add(extractOpernad(component));
                }
            }
            return operands;
        }

        private Operand extractOpernad(string opernad)
        {
            if (opernad.Contains('+'))
            {
                var opComponents = opernad.Split('+');
                return new Operand
                {
                    immediateValue = opComponents[0],
                    postOffset = int.Parse(opComponents[1])
                };
            }
            else if (opernad.Contains("("))
            {
                var opComponents = opernad.Replace(")", "").Split("(");
                if (!opComponents[0].Equals(string.Empty))
                {
                    var isNumeric = int.TryParse(opComponents[0], out int offset);
                    if (isNumeric)
                    {
                        return new Operand
                        {
                            preOffset = offset,
                            reg1 = opComponents[1]
                        };
                    }
                    else
                    {
                        return new Operand
                        {
                            reg1 = opComponents[0],
                            postOffset = int.Parse(opComponents[1])
                        };
                    }
                } else
                {
                    return new Operand
                    {
                        preOffset = 0,
                        reg1 = opComponents[1]
                    };
                }
            }
            else
            {
                return new Operand
                {
                    reg1 = opernad
                };
            }
        }
    }
}
