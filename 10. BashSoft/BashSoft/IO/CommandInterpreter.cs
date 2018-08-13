namespace BashSoft.IO
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Exceptions;
    using Judge;
    using Repository;
    using Static_data;

    public class CommandInterpreter
    {
        private Tester judge;
        private StudentRepository repository;
        private IoManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentRepository repository, IoManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            var data = input.Split();
            var command = data[0];
            command = command.ToLower();

            try
            {
                this.ParseCommand(input, command, data);

            }
            catch (InvalidFileNameException ifne)
            {
                OutputWriter.DisplayException(ifne.Message);
            }
            catch (InvalidPathException ipe)
            {
                OutputWriter.DisplayException(ipe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                OutputWriter.DisplayException(dnfe.Message);
            }
            catch (ArgumentNullException ane)
            {
                OutputWriter.DisplayException(ane.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (ArgumentException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch (IOException ioe)
            {
                OutputWriter.DisplayException(ioe.Message);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }

        }

        private void ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    this.TryOpenFile(input, data);
                    break;
                case "mkdir":
                    this.TryCreateDirectory(input, data);
                    break;
                case "ls":
                    this.TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    this.TryCompareFiles(input, data);
                    break;
                case "cdrel":
                    this.TryChangePathRelatively(input, data);
                    break;
                case "cdabs":
                    this.TryChangePathAbsolute(input, data);
                    break;
                case "readdb":
                    this.TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    this.TryGetHelp(input, data);
                    break;
                case "filter":
                    this.TryFilterAndTake(input, data);
                    break;
                case "order":
                    this.TryOrderAndTake(input, data);
                    break;
                case "decorder":
                    break;
                case "download":
                    break;
                case "downloadasynch":
                    break;
                case "show":
                    this.TryShowWantedData(input, data);
                    break;
                default:
                    this.DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private void TryOrderAndTake(string input, string[] data)
        {
            if (!this.IsDataValid(data, 5))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            var courseName = data[1];
            var comparison = data[2].ToLower();
            var takeCommand = data[3].ToLower();
            var takeQuantity = data[4].ToLower();

            this.TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
        }

        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.OrderAndTake(courseName, comparison, null);
                }
                else
                {
                    var hasParsed = int.TryParse(takeQuantity, out var studentsToTake);

                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
                    }
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
            }
        }

        private void TryFilterAndTake(string input, string[] data)
        {
            if (!this.IsDataValid(data, 5))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            var courseName = data[1];
            var filter = data[2].ToLower();
            var takeCommand = data[3].ToLower();
            var takeQuantity = data[4].ToLower();

            this.TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
        }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter, null);
                }
                else
                {
                    int studentsToTake;
                    var hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
                    }
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidTakeQueryParamter);
            }
        }

        private void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                var course = data[1];
                this.repository.GetAllStudentsFromCourse(course);
            }
            else if (data.Length == 3)
            {
                var course = data[1];
                var username = data[2];
                this.repository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine($"|{"make directory - mkdir: path ",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"traverse directory - ls: depth ",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"comparing files - cmp: path1 path2",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"change directory - changeDirREl:relative path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"change directory - changeDir:absolute path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"read students data base - readDb: path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"order increasing students - order {courseName} ascending/descending take 20/10/all",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"download file - download: path of file (saved in current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"download file asinchronously - downloadAsynch: path of file (save in the current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"get help – help",-98}|");
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (!this.IsDataValid(data, 2))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            var databasePath = data[1];
            this.repository.LoadData(databasePath);
        }

        private void TryChangePathRelatively(string input, string[] data)
        {
            if (!this.IsDataValid(data, 2))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            var relPath = data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }

        private void TryChangePathAbsolute(string input, string[] data)
        {
            if (!this.IsDataValid(data, 2))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }
            
            var absPath = data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
        }

        private void TryCompareFiles(string input, string[] data)
        {
            if (!this.IsDataValid(data, 3))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            this.judge.CompareContent(data[1], data[2]);
        }

        private void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length < 2)
            {
                this.inputOutputManager.TraverseDirectory(0);
            }
            else
            {
                int depth;
                var success = int.TryParse(data[1], out depth);
                if (success)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.UnableToParseNumber);
                }
            }
        }

        private void TryCreateDirectory(string input, string[] data)
        {
            if (!this.IsDataValid(data, 2))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            var folderName = data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }

        private void TryOpenFile(string input, string[] data)
        {
            if (!this.IsDataValid(data, 2))
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            var filename = data[1];
            Process.Start(SessionData.CurrentPath + "\\" + filename);
        }

        private bool IsDataValid(string[] data, int neededLength)
        {
            if (data.Length != neededLength)
            {
                this.DisplayInvalidCommandMessage(string.Join(" ", data));
                return false;
            }
            
            return true;
        }

        private void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.WriteMessageOnNewLine($"The command {input} is invalid!");
        }

        private void TryDropDb(string input, string[] data)
        {
            if (data.Length != 1)
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}