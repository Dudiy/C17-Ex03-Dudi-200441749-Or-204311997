﻿/*
 * C17_Ex01: FacebookApplication.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using C17_Ex01_Dudi_200441749_Or_204311997.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public static class FacebookApplication
    {
        private const int k_TimeBeforeStartingTimer = 10 * 1000; // 10 seconds
        private const int k_TimeBetweenTimerTicks = 60 * 1000;  // 1 minute
        public const int k_CollectionLimit = 500;
        public const byte k_MaxPhotosInAlbum = 100;
        private static readonly List<Thread> sr_Threads = new List<Thread>();
        private static FormMain s_MainForm;
        private static bool s_IsFirstLogoutCall = true;

        public static User LoggedInUser { get; private set; }

        public static AppSettings AppSettings { get; private set; }

        public static bool ExitSelected { get; set; }

        public static void Run()
        {
            try
            {
                // timer that starts after 10 seconds and removes all disposed threads every 1 minute
                new System.Threading.Timer(i_State => removeDisposedThreads(), null, k_TimeBeforeStartingTimer, k_TimeBetweenTimerTicks);
                FacebookService.s_CollectionLimit = k_CollectionLimit;
                ExitSelected = false;
                AppSettings = AppSettings.LoadFromFile();
                while (!ExitSelected)
                {
                    loginToFacebook();
                    if (!ExitSelected && LoggedInUser != null)
                    {
                        showMainForm();
                    }
                }

                // We get here only after ExitSelected is true
                exitApplication();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception while showing main form: " + e.Message);
            }
        }

        // Facebook application manages all threads, any new thread started should be done using this method
        public static Thread StartThread(ThreadStart i_ThreadStart)
        {
            Thread newThread = new Thread(i_ThreadStart);

            sr_Threads.Add(newThread);
            newThread.Start();

            return newThread;
        }

        public static void KillAllRunningThreads()
        {
            foreach (Thread thread in sr_Threads)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }

            sr_Threads.Clear();
        }

        // used as a method to call after successfully invoking FacebookService.Logout
        public static void Logout()
        {
            FacebookService.Logout(logoutSuccessful);
        }

        private static void showMainForm()
        {
            s_MainForm = new FormMain()
            {
                Size = AppSettings.LastWindowsSize,
                StartPosition = AppSettings.LastFormStartPosition,
                Location = AppSettings.LastWindowLocation
            };
            s_MainForm.ShowDialog();
        }

        private static void exitApplication()
        {
            if (!AppSettings.RememberUser)
            {
                AppSettings.SetDefaultSettings();
            }

            AppSettings.SaveToFile();
        }

        private static void loginToFacebook()
        {
            LoginResult loginResult = null;
            bool loginSuccessful = false;
            bool isFirstLoginAttempt = true;

            while (!loginSuccessful)
            {
                try
                {
                    if (AppSettings.RememberUser && !string.IsNullOrEmpty(AppSettings.LastAccessToken) && isFirstLoginAttempt)
                    {
                        loginResult = FacebookService.Connect(AppSettings.LastAccessToken);
                    }
                    else
                    {
                        loginResult = loginWithForm();
                    }

                    if (ExitSelected)
                    {
                        break;
                    }

                    if (loginResult == null)
                    {
                        throw new Exception("Login returned null");
                    }

                    loginSuccessful = true;
                }
                catch
                {
                    MessageBox.Show("Error logging in to Facebook, please try again");
                    isFirstLoginAttempt = false;
                }
            }

            if (!ExitSelected)
            {
                AppSettings.LastAccessToken = loginResult.AccessToken;
                LoggedInUser = loginResult.LoggedInUser;
            }
        }

        private static LoginResult loginWithForm()
        {
            FormLogin formLogin = new FormLogin();
            DialogResult loginSuccessful = DialogResult.No;

            while (loginSuccessful != DialogResult.Yes && loginSuccessful != DialogResult.Cancel)
            {
                loginSuccessful = formLogin.ShowDialog();
                if (loginSuccessful == DialogResult.Cancel)
                {
                    ExitSelected = true;
                }
                else if (loginSuccessful != DialogResult.Yes)
                {
                    MessageBox.Show("Login failed, try again");
                }
            }

            return formLogin.LoginResult;
        }

        private static void logoutSuccessful()
        {
            // this is a patch to fix bug in facebookWrapper where this method is called twice when Logout is invoked            
            if (s_IsFirstLogoutCall)
            {
                AppSettings.SetDefaultSettings();
                MessageBox.Show(string.Format("{0} logged out", LoggedInUser.Name));
                LoggedInUser = null;
                closeAllForms();
            }

            // toggle isFirstLogoutCall
            s_IsFirstLogoutCall = !s_IsFirstLogoutCall;
        }

        private static void closeAllForms()
        {
            int numOfOpenForms = Application.OpenForms.Count;

            for (int i = numOfOpenForms; i > 0; i--)
            {
                Application.OpenForms[i - 1].Close();
            }
        }

        private static void removeDisposedThreads()
        {
            List<Thread> disposedThreads = new List<Thread>();

            foreach (Thread thread in sr_Threads)
            {
                if (!thread.IsAlive)
                {
                    disposedThreads.Add(thread);
                }
            }

            foreach (Thread thread in disposedThreads)
            {
                sr_Threads.Remove(thread);
            }            
        }
    }
}
