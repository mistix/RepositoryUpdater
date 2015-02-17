using System;
using System.Diagnostics;

namespace RepoUpdater.Model
{
    public class CommandLine : ICommandLine
    {
        public string Execute(string executable, string arguments, string workingDirectory, bool standardOutput = false, bool standardError = false, bool throwOnError = false)
        {
            // This will be out return string
            string standardOutputString = string.Empty;
            string standardErrorString = string.Empty;

            if (string.IsNullOrEmpty(workingDirectory))
                throw new ArgumentException("Working directory must be set.");

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(executable, arguments)
                    {
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        ErrorDialog = false,
                        CreateNoWindow = true,
                        WorkingDirectory = workingDirectory
                    }
                };

                if (standardOutput) process.StartInfo.RedirectStandardOutput = true;
                if (standardError || throwOnError) process.StartInfo.RedirectStandardError = true;

                process.Start();

                if (standardError || throwOnError) standardErrorString = process.StandardError.ReadToEnd();
                if (throwOnError && !string.IsNullOrEmpty(standardErrorString))
                    throw new Exception(string.Format("Error in ConsoleCommand while executing {0} with arguments {1}.", executable, arguments));

                if (standardOutput) standardOutputString = process.StandardOutput.ReadToEnd();
                if (standardError) standardOutputString += standardErrorString;

                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error in ConsoleCommand while executing {0} with arguments {1}.", executable, arguments), e);
            }

            return standardOutputString;
        }
    }
}