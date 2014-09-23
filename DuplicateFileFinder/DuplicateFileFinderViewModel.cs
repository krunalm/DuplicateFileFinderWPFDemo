using Ookii.Dialogs.Wpf;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DuplicateFileFinder
{
    [ImplementPropertyChanged]
    public class DuplicateFileFinderViewModel
    {
        private ICommand cmdFolderBrowse;
        private ICommand cmdFindDuplicates;
        private ICommand cmdOpenDuplicateFile;
        public bool IsBusy { get; set; }
        public string FolderPath { get; set; }
        public List<DuplicateFileEntity> Results { get; set; }

        public ICommand FolderBrowse
        {
            get { return cmdFolderBrowse ?? (cmdFolderBrowse = new DelegateCommand(ShowFolderDialog)); }
        }

        private void ShowFolderDialog(object obj)
        {
            this.IsBusy = true;

            // Old Way...!! Ugly WinForms Dialog...!!
            //var dialog = new System.Windows.Forms.FolderBrowserDialog();
            //System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            // Ookii.Dialogs.Wpf Way!!
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.ShowDialog();

            this.FolderPath = dialog.SelectedPath;

            this.IsBusy = false;
        }

        public ICommand FindDuplicates
        {
            get { return cmdFindDuplicates ?? (cmdFindDuplicates = new DelegateCommand(DuplicateFinder)); }
        }

        private void DuplicateFinder(object obj)
        {
            var task = new Task(DuplicateFinderCore);
            task.Start();
        }

        private void DuplicateFinderCore()
        {
            this.IsBusy = true;
            var myResults = new List<DuplicateFileEntity>();

            try
            {
                if (!string.IsNullOrWhiteSpace(this.FolderPath))
                {
                    if (Directory.Exists(this.FolderPath))
                    {
                        var count = 0;
                        var file = string.Empty;
                        var searchTerm = string.Empty;
                        var files = Directory.GetFiles(this.FolderPath, "*.*", SearchOption.AllDirectories);

                        foreach (var item in files)
                        {
                            file = Path.GetFileNameWithoutExtension(item);
                            searchTerm = (file.Length > Helpers.GetMaxCharLimit() ? file.Substring(0, Helpers.GetMaxCharLimit()) : file) + "*.*";
                            var searchFiles = Directory.GetFiles(this.FolderPath, searchTerm, SearchOption.AllDirectories);

                            if (searchFiles.Count() > 1)
                            {
                                DuplicateFileEntity entity = new DuplicateFileEntity
                                {
                                    Id = ++count,
                                    File = item,
                                    SearchTerm = searchTerm,
                                    Total = searchFiles.Count()
                                };
                                myResults.Add(entity);
                            }
                        }
                    }
                }
                else
                {
                    Helpers.ShowMessage("Please select folder to find duplicate files.");
                }
            }
            catch (Exception ex)
            {
                Helpers.ShowMessage("Something went wrong. Additional Details: " + ex.Message);
            }
            finally
            {
                this.Results = myResults;
                this.IsBusy = false;
            }
        }

        public ICommand OpenDuplicateFile
        {
            get { return cmdOpenDuplicateFile ?? (cmdOpenDuplicateFile = new DelegateCommand(OpenDuplicate)); }
        }

        private void OpenDuplicate(object obj)
        {
            this.IsBusy = true;

            try
            {
                //Helpers.ShowMessage(obj.ToString());
                var path = Path.GetDirectoryName(obj.ToString());
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                Helpers.ShowMessage("Something went wrong. Additional Details: " + ex.Message);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        #region For Sample Purpose

        private ICommand doSomethingCommand;

        public ICommand DoSomething
        {
            get { return doSomethingCommand ?? (doSomethingCommand = new DelegateCommand(LongRunningTask)); }
        }

        private void LongRunningTask(object obj)
        {
            var task = new Task(ComputeResults);
            task.Start();
        }

        private void ComputeResults()
        {
            this.IsBusy = true;
            //var results = Enumerable.Range(0, 12).Select(x =>
            //                                                {
            //                                                    Thread.Sleep(250);
            //                                                    return "Result " + x;
            //                                                }).ToList();

            System.Threading.Thread.Sleep(3000);

            //this.Results = new List<string>();
            this.IsBusy = false;
        }

        #endregion
    }
}
